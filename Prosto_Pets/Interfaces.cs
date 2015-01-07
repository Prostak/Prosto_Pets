using System;
using System.Collections.Generic;
using Prosto_Pets;

namespace Prosto_Pets
{
    public struct PetPlace
    {
        public Pet pet;
        public bool selected;   // already selected
        public bool opened;     // slot is available to player
    }

    public interface IPetLua
    {
        int GetLevelBySlotID_Enemy(int slotID);
        string GetNameBySlotID_Enemy(int slotId);
        int GetNumPets();
        int GetNumPetsOwned();
        bool IsSlotLocked(int num);
        int NumActiveSlots();
        System.Collections.Generic.List<string> GetPetInfoByIndex(int partsize, uint k, int currentportionsize);
        System.Collections.Generic.List<string> GetPetStats(string PetID);
        int GetTargetLevel();
        bool IsInBattle();
        bool IsSummonable(string PetID);
        void LoadPet(int slot, string petID);
        void SetFilterAllCollectedPets();
        void SetFavouritesFlag();
        bool CanRessurrectPets();
        void ResurrectPets();

        // Added for Prosto_Pets
        bool MustSelectNew();           // TODO: check semantics: is it surely dead?
        
        bool IsOurTurn();                   
        int GetBattleState();               // Get BattleState - enum
        bool CanSwapIn(int slot);           // can select this guy to fight  TODO: remove +1
        bool CanActivePetSwapOut();         // can swap out
        void SwapIn(int petnum);            // select this guy to fight
        bool CanUseAbility(int skillnum);   // was PetCanCast. TODO: check if it is the same num as above
        void UseAbility(int num);           // press button 1-3
        void SkipTurn();

        // trap support
        bool IsTrapAvailable();
        int NumberOwnedBySpecies(string speciesId);
        void UseTrap();

        // beast scripts support

        List<Single> GetActivePetAbilityModifiers();
        List<string> GetActivePetAbilities();
        bool buff(string name);
        int  buffLeft(string name);
        bool debuff(string name);
        int  debuffLeft(string name);
        string GetWeather();
        
    }

    public interface IPluginProperties
    {
        // TODO: provide proper interface? Now many are accessed through static functions
        int MaxLevel { get; set; }
        int MinLevel { get; set; }
        int MinPetHealth { get; set; }
        eMode Mode { get; set; }
        bool OnlyBluePets { get; set; }
        bool UseWildPets { get; set; }
        bool UseFavouritePetsOnly { get; set; }
        bool UseFavouriteRingers { get; set; }
        int MinRingerPetHealth { get; set; }
    }

    public interface IPluginSettings
    {
        void ConvertSettingsToProperties();
        void ConvertsPropertiesToSettings();
        void Save();
    }

    public interface IPetChooser
    {
        PetPlace[] SelectPetsForLevel(int Level);
    }

    public interface IPetJournal
    {
        bool IsLoaded { get; }
        void PopulatePetJournal();
        void WritePetsByLevel();
        void Clear();
        List<Pet> OwnedPetsList { get; }
        List<Pet> FavouritePetsList { get; }
        List<string> DistinctPetNames { get; }
        int LowestLevel();
    }

    public interface IPetLoader
    {
        void Load(PetPlace[] selectedpets);
    }

    public interface IPetReporter
    {
        void Start();  // create empty or appends to the existing profile for the zone the pet is in
        void Stop();  // 
        void AddBattle(string name);  // checks if the player is in the same area, if not performs Close - Start 
                                      // then checks if filename point is close to filename previous hotspot, if not - writes out one
                                      // writes out filename battle rec with pet name as an xml comment
                                      // <!--Battle Name="xxx" -->

        // checks if the player is in the same area, if not performs Close - Start 
        // then checks if the exact pet was already reported as seen, if not
        // then checks if filename point is close to filename previous hotspot, if not - writes out one
        // then writes out filename "seen" rec with pet name as an xml comment
        // <!--Seen Name="xxx" -->
        void AddSeen(string id, string name, Styx.WoWPoint point);                                     
    }
}