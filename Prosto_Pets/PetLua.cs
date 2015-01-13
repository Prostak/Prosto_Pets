using System;
using System.Collections.Generic;
using Styx.Helpers;
using Styx.WoWInternals;

namespace Prosto_Pets
{
    public class PetLua : IPetLua
    {

        public static PetLua Instance { get; private set; }

        static PetLua()
        {
            Instance = new PetLua();
        }

        public bool IsSummonable(string PetID)
        {
            string lua = string.Format("local Vv=C_PetJournal.PetIsSummonable(\"{0}\");return tostring(Vv);", PetID);
            bool isSummomable = Lua.GetReturnValues(lua)[0].ToBoolean();
            return isSummomable;
        }

        public List<String> GetPetStats(string PetID)
        {
            string lua = "local RetInfo = {}; local b = {};b[0],b[1],b[2],b[3],b[4] = C_PetJournal.GetPetStats(\"" + PetID + "\");" +
                        "for j_=0,4 do table.insert(RetInfo,tostring(b[j_]));end; " +
                        "return unpack(RetInfo)";

            List<String> stats = Lua.GetReturnValues(lua);
            return stats;
        }

        public int GetTargetLevel()
        {
            try
            {
                List<string> cnt = Lua.GetReturnValues("return UnitBattlePetLevel('target')");
                return Convert.ToInt32(cnt[0]);
            }
            catch (Exception e)
            {
                Logger.Alert(e.ToString());
            }
            return -1;
        }

        public string GetTargetClassification()
        {
            try
            {
                List<string> cnt = Lua.GetReturnValues("return UnitClassification('target')");
                return cnt[0];
            }
            catch (Exception e)
            {
                Logger.Alert(e.ToString());
            }
            return "error";
        }

        public int GetLevelBySlotID_Enemy(int slotID)
        {
            return Lua.GetReturnVal<int>("return C_PetBattles.GetLevel(LE_BATTLE_PET_ENEMY, " + slotID + ");", 0);
        }

        public string GetNameBySlotID_Enemy(int slotID)
        {
            return Lua.GetReturnVal<string>("return C_PetBattles.GetName(LE_BATTLE_PET_ENEMY, " + slotID + ");", 0);
        }
        
        // TODO: make something less hack-ish here
        public bool IsInBattle()
        {
            List<string> cnt = Lua.GetReturnValues("dummy,reason=C_PetBattles.IsTrapAvailable(); return dummy,reason");
            return cnt[1] != "0";
        }

        public void LoadPet(int slot, string petID)
        {
            string lua = "local petID, ability1, ability2, ability3, locked = C_PetJournal.GetPetLoadOutInfo({0}) ";
            lua += "if locked then C_PetJournal.SetPetLoadOutInfo({0},\"0x0\") end ";
            lua += "if petID ~= \"{1}\" then  C_PetJournal.SetPetLoadOutInfo({0}, \"{1}\") end";
            string slotLua = string.Format(lua, slot, petID);
            Lua.DoString(slotLua);
        }

        public void SetFilterAllCollectedPets()
        {
            Lua.DoString("C_PetJournal.ClearSearchFilter();");
            Lua.DoString("C_PetJournal.AddAllPetSourcesFilter();");
            Lua.DoString("C_PetJournal.AddAllPetTypesFilter();");
            Lua.DoString("C_PetJournal.SetFlagFilter(LE_PET_JOURNAL_FLAG_FAVORITES, false);");
            Lua.DoString("C_PetJournal.SetFlagFilter(LE_PET_JOURNAL_FLAG_COLLECTED, true) ;");
            Lua.DoString("C_PetJournal.SetFlagFilter(LE_PET_JOURNAL_FLAG_NOT_COLLECTED, false);");
        }

        public void SetFavouritesFlag()  // TODO this no longer works, removed by Blizz
        {
            Lua.DoString("C_PetJournal.SetFlagFilter(LE_PET_JOURNAL_FLAG_FAVORITES, true);");
        }

        public int GetNumPetsOwned()
        {
            string lua = "local numPets, numOwned = C_PetJournal.GetNumPets(false); return tostring(numOwned);";
            return Lua.GetReturnValues(lua)[0].ToInt32();
        }

        public int GetNumPets()
        {
            string lua = "local numPets, numOwned = C_PetJournal.GetNumPets(false); return tostring(numPets);";
            return Lua.GetReturnValues(lua)[0].ToInt32();
        }

        public bool IsSlotLocked(int slot)
        {
            string lua = "local petID, ability1, ability2, ability3, locked = C_PetJournal.GetPetLoadOutInfo(" + slot + "); return locked;";
            return Lua.GetReturnVal<bool>( lua, 0);
        }

        public int NumActiveSlots()
        {
            int i;
            for( i=1; i<=3; i++)
            {
                if (IsSlotLocked(i)) return i-1;
            }
            return 3;
        }

        public List<string> GetPetInfoByIndex(int partsize, uint k, int currentportionsize)
        {
            string lua = "local RetInfo = {}; local filename = {};" +
            "for i_=" + k * partsize + "," + ((k * partsize) + currentportionsize) + " do " +
                "table.insert(RetInfo,'----------'); " +
                "filename[0],filename[1],filename[2],filename[3],filename[4],filename[5],filename[6],filename[7],filename[8],filename[9],filename[10],filename[11],filename[12],filename[13],filename[14],filename[15],filename[16],filename[17] = C_PetJournal.GetPetInfoByIndex(i_ + 1); " +
                "for j_=0,17 do table.insert(RetInfo,tostring(filename[j_]));end;" +
            "end;" +
            "return unpack(RetInfo)";

            List<string> List1 = new List<string>();

            try
            {
                List1 = Lua.GetReturnValues(lua);
            }
            catch (Exception e)
            {
                Logger.Write(e.ToString());
            }

            if (List1 == null)
            {
                Logger.Write("---- error reading part of the journal. null list. k:" + k);
            }
            return List1;
        }

        public bool CanRessurrectPets()  // TODO: refactor similar is...Cooldown
        {
             WoWSpell spell = WoWSpell.FromId(125439);
             return (spell != null && spell.CanCast);
        }

        public void ResurrectPets()
        {
            try
            {
                WoWSpell spell = WoWSpell.FromId(125439);
                if (spell != null && spell.CanCast)
                {
                    Logger.Write("Casting 'Revive Battle Pets'...");
                    spell.Cast();
                }
            }
            catch { }
        }

        public bool MustSelectNew()
        {
            //Logger.WriteDebug("before ShouldShowPetSelect");
            List<string> cnt = Lua.GetReturnValues("return C_PetBattles.ShouldShowPetSelect()");
            //Logger.WriteDebug("after  ShouldShowPetSelect");

            if (cnt != null) { if (cnt[0] == "1") return true; }
            return false;
        }

        public bool IsOurTurn()
        {
            //Logger.WriteDebug("before IsWaitingOnOpponent");
            List<string> cnt = Lua.GetReturnValues("return C_PetBattles.IsWaitingOnOpponent()");  // TODO: with our pet dead on Lift-Off returns wrong answer
            //Logger.WriteDebug("after  IsWaitingOnOpponent");

            if (cnt != null) { if (cnt[0] == "0") return true; }
            return false;
        }

        public int GetBattleState()
        {
            return Lua.GetReturnVal<int>("return C_PetBattles.GetBattleState()", 0);
        }

        public bool CanSwapIn(int petnum)
        {
            List<string> cnt = Lua.GetReturnValues("return C_PetBattles.CanPetSwapIn(" + petnum + ")");

            if (cnt != null) { if (cnt[0] == "1") return true; }
            return false;
        }

        public bool CanActivePetSwapOut()
        {
            List<string> cnt = Lua.GetReturnValues("return C_PetBattles.CanActivePetSwapOut()");

            if (cnt != null) { if (cnt[0] == "1") return true; }
            return false;
        }


        public void SwapIn(int petnum)
        {
            Lua.DoString("if C_PetBattles.GetActivePet(1) ~= " + petnum + " then C_PetBattles.ChangePet(" + petnum + ") end");
        }

        public void UseAbility(int num)
        {
            Lua.DoString("C_PetBattles.UseAbility(" + num + ")");
        }

        public bool CanUseAbility(int skillnum)
        {
            List<string> cnt = Lua.GetReturnValues("local isUsable, currentCooldown = C_PetBattles.GetAbilityState(LE_BATTLE_PET_ALLY, C_PetBattles.GetActivePet(LE_BATTLE_PET_ALLY), " + skillnum + "); if isUsable == nil then isUsable=0 end return isUsable,currentCooldown");
            if (cnt != null) { if (cnt[0] == "1") return true; }
            return false;
        }
        public void SkipTurn()
        {
            Lua.DoString("C_PetBattles.SkipTurn()");
        }

        // Functions adapted from MyPetBattles
        public List<string> GetActivePetAbilities()
        {
            List<string> ret = new List<string>();
            for (int i = 1; i <= 3; i++)
            {
                string name = GetActivePetAbility(i);
                if( string.IsNullOrEmpty(name) ) return ret;
                ret.Add( name );
            }
            return ret;
        }

        public string GetActivePetAbility( int num )
        {
            return Lua.GetReturnValues( 
                "local activePetSlot = C_PetBattles.GetActivePet(LE_BATTLE_PET_ALLY);"
                + "local id, name, icon, maxCooldown, desc, numTurns, petType, noStrongWeakHints  = C_PetBattles.GetAbilityInfo(LE_BATTLE_PET_ALLY, activePetSlot, " +num+ ");"
                + "return name;"
                )[0];
        }

        public List<Single> GetActivePetAbilityModifiers()
        {
            List<Single> ret = new List<Single>();
            for (int i = 1; i <= 3; i++)
            {
                Single val = GetActivePetModifier(i);
                ret.Add(val);
                //Logger.WriteDebug("Adding mod " + val + "");
            }
            return ret;
        }

        public Single GetActivePetModifier( int num )
        {
            string lua = "local activePetSlot = C_PetBattles.GetActivePet(LE_BATTLE_PET_ALLY);"
    + "local enemyPetSlot = C_PetBattles.GetActivePet(LE_BATTLE_PET_ENEMY);"
    + "local enemyType = C_PetBattles.GetPetType(LE_BATTLE_PET_ENEMY, enemyPetSlot);"
    + "local abilityName, abilityType, noHints;"
    + "_, abilityName, _, _, _, _, abilityType, noHints = C_PetBattles.GetAbilityInfo(LE_BATTLE_PET_ALLY, activePetSlot," + num + ");"
    + "	local modifier = C_PetBattles.GetAttackModifier(abilityType, enemyType);"
    + " return tostring(modifier);";
            List<string> ret = Lua.GetReturnValues(lua);
            try
            {
                if( ret != null )
                    return Convert.ToSingle( ret[0] );
                return (Single)1.0;
            }
            catch( Exception e)
            {
                Logger.WriteDebug("Mod: " + e.Message + e.ToString());
                return (Single) 1.0;
            }
        }

        public bool IsTrapAvailable()
        {
            //Logger.WriteDebug("before IsTrapAvailable");
            List<string> cnt = Lua.GetReturnValues("dummy,reason=C_PetBattles.IsTrapAvailable(); return dummy,reason");
            //Logger.WriteDebug("after IsTrapAvailable");
            if (cnt != null) { if (cnt[0] == "1") return true; }
            return false;
        }

        public int NumberOwnedBySpecies( string speciesId )
        {
            string lua = "local numCollected, limit = C_PetJournal.GetNumCollectedInfo(" +speciesId+ "); return numCollected";
            //Logger.WriteDebug("before GetNumCollected");
            List<string> cnt = Lua.GetReturnValues( lua );
            //Logger.WriteDebug("after  GetNumCollected");
            if (cnt != null) return Convert.ToInt32(cnt[0]);
            return 99;  // 0 will force an action
        }

        public void UseTrap()
        {
            Lua.DoString("C_PetBattles.UseTrap()");
        }

        ///////////////////////////////////////////////////////////////
        ///
        /// Strategy Lists helper functions
        /// 
        public int buffLeft( string auraName )
        {
            string lua = "local petIndex = C_PetBattles.GetActivePet(LE_BATTLE_PET_ALLY);"
	+ "local numAuras = C_PetBattles.GetNumAuras(LE_BATTLE_PET_ALLY, petIndex);"
	+ "if numAuras == nil then return false end;" // Return false if nil, e.g. when NOT in battle

	// Checking front pet buffs
	+ "for auraIndex = 1,numAuras do\n" 
	+ "	local auraID, instanceID, turnsRemaining, isBuff = C_PetBattles.GetAuraInfo(LE_BATTLE_PET_ALLY, petIndex, auraIndex)\n"
	+ "	local id, name, icon, maxCooldown, unparsedDescription, numTurns, petType, noStrongWeakHints = C_PetBattles.GetAbilityInfoByID(auraID)\n"
	+ "	if name == \"" +auraName+ "\" then  return true,turnsRemaining end\n"
	+ "end\n"

	// Checking team wide buffs
	+ "local numTeamwideAuras = C_PetBattles.GetNumAuras(LE_BATTLE_PET_ALLY, PET_BATTLE_PAD_INDEX) or 0\n" // Can be nil
	+ "for auraIndex = 1, numTeamwideAuras do\n"
	+	" local auraID, instanceID, turnsRemaining, isBuff = C_PetBattles.GetAuraInfo(LE_BATTLE_PET_ALLY, PET_BATTLE_PAD_INDEX, auraIndex)\n"
	+	" local id, name, icon, maxCooldown, unparsedDescription, numTurns, petType, noStrongWeakHints = C_PetBattles.GetAbilityInfoByID(auraID)\n"
	+	" if name == \"" +auraName+ "\" then  return true,turnsRemaining end\n"
	+ "end\n"
	+ "return false;\n";
            List<string> cnt = Lua.GetReturnValues(lua);
            if (cnt != null)
            {
                //Logger.WriteDebug("Cnt[0]=" + cnt[0]);
                if (cnt[0] == "1")
                {
                    //Logger.WriteDebug("Cnt[1]=" + cnt[1]);
                    return Convert.ToInt32(cnt[1]);
                }
            }
            return -1; 
        }
        public bool buff( string name)
        {
            return buffLeft(name) > 0;
        }
        public int debuffLeft(string auraName)
        {
            string lua = "local petIndex = C_PetBattles.GetActivePet(LE_BATTLE_PET_ENEMY);"
    + "local numAuras = C_PetBattles.GetNumAuras(LE_BATTLE_PET_ENEMY, petIndex);"
    + "if numAuras == nil then return false end;" // Return false if nil, e.g. when NOT in battle

    // Checking front pet buffs
    + "for auraIndex = 1,numAuras do\n"
    + "	local auraID, instanceID, turnsRemaining, isBuff = C_PetBattles.GetAuraInfo(LE_BATTLE_PET_ENEMY, petIndex, auraIndex)\n"
    + "	local id, name, icon, maxCooldown, unparsedDescription, numTurns, petType, noStrongWeakHints = C_PetBattles.GetAbilityInfoByID(auraID)\n"
    + "	if name == \"" + auraName + "\" and id ~= 239 then  return true,turnsRemaining,id end\n"
    + "end\n"

    // Checking team wide buffs
    + "local numTeamwideAuras = C_PetBattles.GetNumAuras(LE_BATTLE_PET_ENEMY, PET_BATTLE_PAD_INDEX) or 0\n" // Can be nil
    + "for auraIndex = 1, numTeamwideAuras do\n"
    + " local auraID, instanceID, turnsRemaining, isBuff = C_PetBattles.GetAuraInfo(LE_BATTLE_PET_ENEMY, PET_BATTLE_PAD_INDEX, auraIndex)\n"
    + " local id, name, icon, maxCooldown, unparsedDescription, numTurns, petType, noStrongWeakHints = C_PetBattles.GetAbilityInfoByID(auraID)\n"
    + " if name == \"" + auraName + "\" then  return true,turnsRemaining,id end\n"
    + "end\n"
    + "return false;\n";
            List<string> cnt = Lua.GetReturnValues(lua);
            if (cnt != null)
            {
                if (cnt[0] == "1")
                {
                    //Logger.WriteDebug("Debuff: " + auraName + ", count=" + cnt.Count + ", id = " + ((cnt.Count>2 && (cnt[2] != null)) ? cnt[2] : "null"));
                    return Convert.ToInt32(cnt[1]);
                }
            }
            return -1;
        }
        public bool debuff(string name)
        {
            return debuffLeft(name) > 0;
        }

        public int debuffLeft(int id)
        {
            string lua = "local petIndex = C_PetBattles.GetActivePet(LE_BATTLE_PET_ENEMY);"
    + "local numAuras = C_PetBattles.GetNumAuras(LE_BATTLE_PET_ENEMY, petIndex);"
    + "if numAuras == nil then return false end;" // Return false if nil, e.g. when NOT in battle

    // Checking front pet buffs
    + "for auraIndex = 1,numAuras do\n"
    + "	local auraID, instanceID, turnsRemaining, isBuff = C_PetBattles.GetAuraInfo(LE_BATTLE_PET_ENEMY, petIndex, auraIndex)\n"
    + "	if auraID == " + id + " then  return true,turnsRemaining end\n"
    + "end\n"

    // Checking team wide buffs - not now
    + "return false;\n";
            List<string> cnt = Lua.GetReturnValues(lua);
            if (cnt != null)
            {
                //Logger.WriteDebug("Cnt[0]=" + cnt[0]);
                if (cnt[0] == "1")
                {
                    //Logger.WriteDebug("Cnt[1]=" + cnt[1]);
                    return Convert.ToInt32(cnt[1]);
                }
            }
            return -1;
        }
        public bool debuff(int id)
        {
            return debuffLeft(id) > 0;
        }


        public string GetWeather()
        {
            if (!IsInBattle()) { return ""; }
            string lua = "local auraID, instanceID, turnsRemaining, isBuff,_,_ = C_PetBattles.GetAuraInfo(LE_BATTLE_PET_WEATHER, PET_BATTLE_PAD_INDEX, 1)\n"
    + "if auraID ~= nil then\n"
    + "	local id, currentWeather, icon, maxCooldown, unparsedDescription, numTurns, petType, noStrongWeakHints = C_PetBattles.GetAbilityInfoByID(auraID);\n"
    + " return currentWeather\n"
    + "end\n"
    + "return \"\"";
            //Logger.WriteDebug("before Weather");
            List<string> cnt = Lua.GetReturnValues(lua);
            //Logger.WriteDebug("after Weather");
            if (cnt != null && cnt.Count > 0)
            {
                //Logger.WriteDebug("Weather Cnt[0]=" + cnt[0]);
                return cnt[0];
            }
            return "";
        }
    }
}