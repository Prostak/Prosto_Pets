using System.Collections.Generic;

namespace Prosto_Pets
{
    public class PetChooser : IPetChooser
    {
        private IPluginProperties _pluginProperties;
        private IPetLua _petLua;
        private IPetJournal _petJournal;

        const int success = 1;
        const int failure = 0;

        public PetChooser(IPluginProperties pluginProperties, IPetLua petLua, IPetJournal petJournal)
        {
            _petLua = petLua;
            _pluginProperties = pluginProperties;
            _petJournal = petJournal;
        }

        private HashSet<string> _blacklistForSelection = new HashSet<string>();

        public PetPlace[] _selectedpets = new PetPlace[3];

        public static int ValidLevel(int level)
        {
            return Prosto_Pets.ValidLevel(level);
        }

        private void CopyCurrentPet(int slot)
        {
            _selectedpets[slot].pet.PetId = MyPets.Pet(slot).PetID;
            _selectedpets[slot].pet.SetStatsInvalid();  // Only ID is needed, but just in case.
        }

        private void InitPlace(int slot, bool locked)
        {
            _selectedpets[slot].pet = new Pet(_petLua);

            _selectedpets[slot].selected = false;
            _selectedpets[slot].opened = !_petLua.IsSlotLocked(slot + 1);
            if (_selectedpets[slot].opened)
            {
                if (locked)
                {
                    CopyCurrentPet(slot);  // need to be checked to avoid double selection
                    _selectedpets[slot].selected = true;
                    Logger.WriteDebug("Slot " + slot + " is locked, marked as selected");
                }
            }
        }

        public PetPlace[] SelectPetsForLevel(int Level)
        {
            _selectedpets = new PetPlace[3];

            
            InitPlace(0, PluginSettings.Instance.LockFirstSlot);
            InitPlace(1, PluginSettings.Instance.LockSecondSlot);
            InitPlace(2, PluginSettings.Instance.LockThirdSlot);

            // now that locked ones are copied we may select the remaining ones, avoiding duplicates

            for( int i=0; i < 3; i++)
            {
                if( !_selectedpets[i].selected && _selectedpets[i].opened )
                {
                    Pet pet = SelectPetForSlot(i, Level);
                    if( pet != null )
                    {
                        _selectedpets[i].pet = pet;
                        _selectedpets[i].selected = true;
                    }
                    else
                    {
                        Logger.Write( "Failed to select pet for a slot " + (i+1) + ". Provide less restricting criteria, pls.");
                    }
                }
            }
            return _selectedpets;  // all info is there

        }

        private Pet SelectPetForSlot(int slot, int Level)  // 0-2
        {
            eMode mode = _pluginProperties.Mode;
            bool isRinger = (slot == 1 && mode == eMode.Ringerx2) || (slot == 2 && (mode == eMode.Ringer || mode == eMode.Ringerx2));

            int minLevel = Level;
            if (slot == 1)
            {
                minLevel += mode == eMode.Ringerx2 ? PluginSettings.ModeInfo.Pet3_Diff : PluginSettings.ModeInfo.Pet2_Diff; 
                //Logger.WriteDebug("Slot " + (slot + 1) + ": Added Pet2_Diff" + (eMode.Ringerx2 ? PluginSettings.ModeInfo.Pet3_Diff : PluginSettings.ModeInfo.Pet2_Diff) + ", result =" + minLevel);
            }
            else if (slot == 2)
            {
                minLevel += PluginSettings.ModeInfo.Pet3_Diff;
                //Logger.WriteDebug("Slot " + (slot + 1) + ": Added Pet3_Diff" + PluginSettings.ModeInfo.Pet3_Diff + ", result =" + minLevel);
            }
            minLevel = ValidLevel(minLevel);
            //Logger.WriteDebug("Slot " + (slot + 1) + ": Applied ValidLevel, result =" + minLevel);


            int maxLevel = _pluginProperties.MaxLevel;
            if (maxLevel < minLevel) maxLevel = minLevel;
            if (mode == eMode.Capture) maxLevel = 25;

            Pet pet = SelectPet(slot, minLevel, maxLevel, isRinger, true);
            if (pet != null) { return pet; }

            // try some corrections, like:
            if( isRinger && maxLevel<25 )
            {
                Logger.WriteDebug("Slot " +(slot+1)+ ": Trying to increase the level for the Ringer");
                maxLevel = 25;
                pet = SelectPet(slot, minLevel, maxLevel, isRinger, true);
                if (pet != null) { return pet; }
            }

            if( minLevel>PluginSettings.Instance.MinLevel)
            {
                Logger.WriteDebug("Slot " + (slot + 1) + ": Trying to consider lower level pets, ignoring mode diff");
                for (int i = minLevel; i >= PluginSettings.Instance.MinLevel; i--)  // going down
                {
                    pet = SelectPet(slot, i, i, isRinger, true);
                    if (pet != null) { return pet; }
                }
            }

            Pet candidate = null;
            Logger.WriteDebug("Slot " +(slot+1)+ ": Checking non-healthy pets, ignoring health");
            pet = SelectPet(slot, minLevel, maxLevel, isRinger, false);
            if (pet != null) 
            {
                if (pet.Health > 0) return pet;
                candidate = pet; 
            }
            // candidate not found or has 0 health, checking lower-level

            if (minLevel > PluginSettings.Instance.MinLevel)
            {
                Logger.WriteDebug("Slot " + (slot + 1) + ": Checking lower level non-healthy pets");
                for (int i = minLevel; i >= PluginSettings.Instance.MinLevel; i--)  // going down
                {
                    pet = SelectPet(slot, i, i, isRinger, false);
                    if (pet != null) 
                    {
                        if ( candidate == null || pet.Health > candidate.Health)
                            candidate = pet; 
                    }
                }
            }
            if( candidate != null )
            {
                Logger.WriteDebug("Slot " + (slot + 1) + ": Using non-healthy with highest health");
                return candidate;
            }

            Logger.Write("Slot " + (slot + 1) + ": Failed to obtain any pets");
            return null;
        }

        private bool AlreadySelected( Pet pet)
        {
            for( int i=0; i<3; i++)
            {
                string petId = _selectedpets[i].pet.PetId;
                if (!string.IsNullOrEmpty(petId) && petId == pet.PetId) { return true; }
            }
            return false;
        }

        private void Wd( string line)
        {
            //Logger.WriteDebug( "[SelectPet] " + line);
        }

        private Pet SelectPet(int slot, int minPetLevel, int maxPetLevel, bool isRingerSelection, bool healthyNeeded)
        {

            List<Pet> petsList = _petJournal.OwnedPetsList;
            if( isRingerSelection && PluginSettings.Instance.UseFavouriteRingers && _petJournal.FavouritePetsList!=null)
            {
                Wd( "Fav Ringers");
                petsList = _petJournal.FavouritePetsList; 
            }
            else if (!isRingerSelection && PluginSettings.Instance.UseFavouritePetsOnly && _petJournal.FavouritePetsList != null)
            {
                Wd( "Fav all");
                petsList = _petJournal.FavouritePetsList; 
            }
            
            Logger.WriteDebug(string.Format("Slot " +(slot+1)+ ": Asked to select [{0}-{1}], ringer={2}, healthy={3}", minPetLevel, maxPetLevel, isRingerSelection, healthyNeeded));
            //find the lowest available pet which matches the criteria
            Pet candidate = null;
            //for (int level = minPetLevel; level <= maxPetLevel; level++)  - we have sorted by level
            {
                foreach (Pet availablePet in petsList)
                {
                    if( availablePet.Level > maxPetLevel)
                    {
                        Wd("Max level " + maxPetLevel + " reached. Exit.");
                        return candidate;
                    }
                    Wd("Checking " + availablePet.Name + ", level=" + availablePet.Level + (availablePet.IsRare ? ", Blue" : ""));
                    if (availablePet.Level < minPetLevel) { Wd("too low"); continue; }
                    if (AlreadySelected(availablePet)) { Wd("already selected"); continue; } //already selected
                    if (!availablePet.IsEquipable) { Wd("not eqipable"); continue; } // not equippable

                    if (availablePet.IsWild && !_pluginProperties.UseWildPets && (!isRingerSelection)) { Wd("wild"); continue; } // is wild
                    if (!availablePet.CanBattle) { Wd("Can't battle"); continue; } // can't battle
                    if (_blacklistForSelection.Contains(availablePet.PetId)) { Wd("Blacklisted"); continue; } // black listed

                    if (minPetLevel <= availablePet.Level && availablePet.Level <= maxPetLevel)
                    {
                        if (healthyNeeded && availablePet.HealthPercentage < _pluginProperties.MinPetHealth && !isRingerSelection) { Wd("health levelled"); continue; } // health too low
                        if (healthyNeeded && availablePet.HealthPercentage < _pluginProperties.MinRingerPetHealth && isRingerSelection) { Wd("Health Ringer"); continue; } // health too low
                        if (_pluginProperties.OnlyBluePets && !availablePet.IsRare && (!isRingerSelection)) { Wd("not blue"); continue; } // not rare
                        if (availablePet.IsSummonable() || availablePet.Health==0)
                        {
                            Wd("selected");
                            if (healthyNeeded)
                            {
                                return availablePet;
                            }
                            else if (candidate == null || (candidate.HealthPercentage < availablePet.HealthPercentage))
                            {
                                Wd("candidate replaced");
                                candidate = availablePet;
                            }
                        }
                        else
                        {
                            Logger.Write("Slot " +(slot+1)+ ": Can't Summon pet " + availablePet.ToString() + "... blacklisting it.");
                            _blacklistForSelection.Add(availablePet.PetId);
                        }
                    }
                    else
                    {
                        Wd(string.Format("level {0} not in [{1}-{2}]", availablePet.Level, minPetLevel, maxPetLevel));
                    }
                }
            }
            return candidate;
        }
    }
}
