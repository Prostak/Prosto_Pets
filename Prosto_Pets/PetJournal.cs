using System.Collections.Generic;
using System.Linq;
using System.Text;
using Styx.Helpers;
using Styx.WoWInternals;
using Styx;

namespace Prosto_Pets
{
    public class PetJournal : IPetJournal
    {
        private IPluginProperties _pluginProperties;
        private IPetLua _petLua;

        public static PetJournal Instance { get; private set; }

        public PetJournal(IPluginProperties pluginProperties, IPetLua petLua)
        {
            _petLua = petLua;
            _pluginProperties = pluginProperties;
            Instance = this;
        }

        List<Pet> _ownedPetsList = new List<Pet>();
        List<Pet> _favouritePetsList = new List<Pet>();

        public void Clear()
        {
            _ownedPetsList = new List<Pet>();
            _favouritePetsList = new List<Pet>();
        }

        public List<Pet> FavouritePetsList
        {
            get { return _favouritePetsList; }
        }

        public List<Pet> OwnedPetsList
        {
            get { return _ownedPetsList; }
        }

        public bool IsLoaded { get { return _ownedPetsList.Count > 0; } }

        public void PopulatePetJournal()
        {
            Logger.Write("Populating pet journal...");

            using (StyxWoW.Memory.AcquireFrame())
            {

                try
                {
                    _petLua.SetFilterAllCollectedPets();
                    _ownedPetsList = LoadFromJournal();
                    Logger.Write("Owned pets journal count: " + _ownedPetsList.Count);


                    // TODO: leave sort order as is?
                    //_ownedPetsList.Sort(delegate(Pet p1, Pet p2) { return p1.Name.CompareTo(p2.Name); });
                    _ownedPetsList.Sort(delegate(Pet p1, Pet p2) { return p1.Level-p2.Level; });

                    _favouritePetsList = new List<Pet>();
                    foreach (Pet pet in _ownedPetsList)  // TODO: Select ToList
                    {
                        if (pet.IsFav)
                        {
                            Pet pf = new Pet(pet);
                            _favouritePetsList.Add(pf);
                        }
                    }
                    Logger.Write("Favourite pets journal count: " + _favouritePetsList.Count);

                    if (_pluginProperties.Mode != eMode.Capture)  // TODO: what's wrong with capture
                    {
                        WritePetsByLevel();
                    }

                }
                catch
                {
                    Logger.Write("Journal init query fail!!! ");
                    try
                    {
                        int PetCount = _petLua.GetNumPets();
                        int PetsOwned = _petLua.GetNumPetsOwned();
                        Logger.Write("Query too large?? " + PetsOwned + "," + PetCount);
                    }
                    catch
                    {
                        Logger.Write("simple C_PetJournal.GetNumPets function failed. Try in WoW: \n/run local numPets, numOwned = C_PetJournal.GetNumPets(false); print('Journal: pet count:' .. tostring(numOwned) .. ' total:' .. tostring(numPets));");
                    }
                }
            }
        }

        public string GetPetsByLevel( bool safeLog )
        {
            if( ! IsLoaded )                // needed for config form (before start)
            { PopulatePetJournal(); }

            int[] levelCount = new int[26];
            for (int i = 0; i < levelCount.Length; i++) { levelCount[i] = 0; }

            List<Pet> petList = _ownedPetsList;
            if (PluginSettings.Instance.UseFavouritePetsOnly) petList = _favouritePetsList;
            foreach (Pet pet in petList)
            {
                if (0 < pet.Level && pet.Level < 26)
                {
                    if (pet.CanBattle && pet.IsEquipable && (_pluginProperties.UseWildPets || !pet.IsWild) && (!_pluginProperties.OnlyBluePets || pet.IsRare))
                    {
                        levelCount[pet.Level]++;
                    }
                }
                else
                {
                    Logger.Alert(string.Format("PetsByLevel: Pet name='{0}' has wrong level={1}, favs={2}", pet.Name, pet.Level, PluginSettings.Instance.UseFavouritePetsOnly));
                }
            }

            StringBuilder levelText = new StringBuilder(string.Format("[{0}-{1}]: ", _pluginProperties.MinLevel, _pluginProperties.MaxLevel ));
            int minL = _pluginProperties.MinLevel;
            int maxL = _pluginProperties.MaxLevel;
            if (minL < 1) minL = 1;
            if (maxL > 25) maxL = 25;
            bool found = false;
            for (int i = minL; i <= maxL; i++)
            {
                if (levelCount[i] > 0) { 
                    levelText.Append("#" + i.ToString() + "=" + 
                    (safeLog ? 
                        "**"    // replace exact count in the log 
                        : levelCount[i].ToString())
                    + " "); 
                    found = true; 
                }
            }
            if (!found) levelText.Append(" No pets match criteria");
            return levelText.ToString();
        }

        public void WritePetsByLevel()   // TODO: make this a string and add to the GUI
        {
            string byLevel = GetPetsByLevel( true );
            string toPrint = string.Format("Pets by level {0} ({1}, {2})", byLevel,
                _pluginProperties.UseWildPets?"wilds ok":"no wilds",
                _pluginProperties.OnlyBluePets?"blues only":"not only blues");
            Logger.Write(toPrint);
        }

        public bool IsInConfiguredRange( int level)
        {
            if (_pluginProperties.MinLevel <= level && level <= _pluginProperties.MaxLevel) { return true; }
            return false;
        }

        public int LowestLevel()
        {
            if (!IsLoaded) PopulatePetJournal();

            int minLevel = 26;
            List<Pet> petList = PluginSettings.Instance.UseFavouritePetsOnly ? _favouritePetsList : _ownedPetsList;
            foreach (Pet pet in petList)
            {
                // TODO: this should be a function
                if (IsInConfiguredRange(pet.Level) && pet.CanBattle && pet.IsEquipable && (_pluginProperties.UseWildPets || !pet.IsWild) && (!_pluginProperties.OnlyBluePets || pet.IsRare))
                {
                    if (pet.Level < minLevel) minLevel = pet.Level;
                }
            }

            if( minLevel == 26)
            {
                Logger.WriteDebug("LowestLevel: No pets selected at all?");
                WritePetsByLevel();
                minLevel = 0;
            }
            // Logger.WriteDebug("Min Level: " + minLevel);
            return minLevel;
        }

        private List<Pet> LoadFromJournal()
        {
            List<Pet> ownedPets = new List<Pet>();
            int partsize = 10;
            int PetsOwned = _petLua.GetNumPets();

            if (PetsOwned == 0) { Logger.Write("0 pets in journal."); return ownedPets; }

            int remaining = (PetsOwned - 1) % partsize;
            int maxportions = ((PetsOwned - 1) / partsize) + 1;

            string[] AllCollectedPetFullData;
            //string additionlreporttext = "";
            for (uint k = 0; k < maxportions; k++)
            {
                List<string> List1 = null;
                for (uint t = 0; t < 1; t++)
                {
                    int currentportionsize = ((k == maxportions - 1) ? remaining : partsize - 1);
                    List1 = _petLua.GetPetInfoByIndex(partsize, k, currentportionsize);

                    if (List1 == null)
                    {
                        continue;
                    }
                    break;
                }
                if (List1 == null)
                    continue;
                AllCollectedPetFullData = List1.ToArray();

                for (int i = 0; i < AllCollectedPetFullData.Count(); i++)
                {
                    if (AllCollectedPetFullData[i] == "----------")
                    {
                        Pet pd = new Pet(_petLua);
                        pd.PROTECTEDfromreleasing = true;
                        for (int j = 1; j < 25; j++)
                        {
                            if (i + j >= AllCollectedPetFullData.Count()) break;

                            if (AllCollectedPetFullData[i + j] == "----------")
                                break;
                            if (j == 1)
                            {
                                pd.PetId = AllCollectedPetFullData[i + j];
                            }
                            if (j == 2)
                                pd.SpeciesID = AllCollectedPetFullData[i + j].ToInt32();
                            if (j == 5) pd.Level = AllCollectedPetFullData[i + j].ToInt32();
							if (j == 6) pd.IsFav = AllCollectedPetFullData[i + j].ToBoolean();
                            if (j == 8) pd.Name = AllCollectedPetFullData[i + j];
                            if (j == 11) pd.CreatureID = AllCollectedPetFullData[i + j].ToInt32();
                            if (j == 12) if ((AllCollectedPetFullData[i + j].IndexOf("Áèòâû ïèòîìöåâ") >= 0) || (AllCollectedPetFullData[i + j].IndexOf("battles") >= 0)) pd.PROTECTEDfromreleasing = false;
                            if (j == 12) if (AllCollectedPetFullData[i + j].IndexOf("UI-GOLDICON") >= 0) pd.PROTECTEDfromreleasing = true;
                            if (j == 12) if (AllCollectedPetFullData[i + j].IndexOf("UI-SILVERICON") >= 0) pd.PROTECTEDfromreleasing = true;
                            if (j == 12) if (AllCollectedPetFullData[i + j].IndexOf("MONEYFRAME") >= 0) pd.PROTECTEDfromreleasing = true;
                            if (j == 12) if ((AllCollectedPetFullData[i + j].IndexOf("Ïðîôåññèÿ") >= 0) || (AllCollectedPetFullData[i + j].IndexOf("rofess") >= 0)) pd.PROTECTEDfromreleasing = true;
                            if (j == 12) if ((AllCollectedPetFullData[i + j].IndexOf("Äîñòèæåíèå") >= 0) || (AllCollectedPetFullData[i + j].IndexOf("chiev") >= 0)) pd.PROTECTEDfromreleasing = true;
                            if (j == 12) if ((AllCollectedPetFullData[i + j].IndexOf("ÿéöî") >= 0) || (AllCollectedPetFullData[i + j].IndexOf("egg") >= 0)) pd.PROTECTEDfromreleasing = true;
                            if (j == 14) pd.IsWild = AllCollectedPetFullData[i + j].ToBoolean();
                            if (j == 15) pd.CanBattle = AllCollectedPetFullData[i + j].ToBoolean();
                        }

                        ownedPets.Add(pd);
                    }
                };
            }
            return ownedPets;
        }
        public List<string> DistinctPetNames
        {
            get
            {
                List<string> result = new List<string>();
                foreach (Pet pet in OwnedPetsList)
                {
                    if (!result.Contains(pet.Name)) { result.Add(pet.Name); }
                }
                return result;
            }
        }
    }
}