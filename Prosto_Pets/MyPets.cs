using Styx.WoWInternals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prosto_Pets
{

    // TODO: replace with PetJournal?
    public static class MyPets
    {
        static private IPetLua _petLua;
        static private string Reported;

        static MyPets()
        {
            _petLua = PetLua.Instance;

            _pets = new BattlePet[3];
            _pets[0] = new BattlePet();
            _pets[1] = new BattlePet();
            _pets[2] = new BattlePet();
            _enemeyActivePet = new BattlePet();
            _activePet = 0;   // 0 to 2
            Reported = "";
            _weather = "";
            
            //updatePets();                 --Removed because we might not always have 3 pets.
            updateMyPets();         // TODO: test with 1 pet acc
            updateEnemyActivePet();
        }

        private static BattlePet[] _pets;
        private static int _activePet;

        private static List<string> _abilityNames;
        private static List<Single> _abilityModifiers;

        private static string _weather;

        private static BattlePet _enemeyActivePet;

        public static BattlePet EnemyActivePet
        {
            get { return _enemeyActivePet; }
        }

        public static BattlePet ActivePet
        {
            get { return _pets[_activePet]; }
        }

        public static int ActivePetNum
        {
            get { return _activePet; }
        }

        public static List<string> ButtonNames
        {
            get { return _abilityNames;  }
        }

        public static BattlePet Pet(int index)
        {
            return _pets[index];
        }

        public static void updateMyPets() {
            //Can probably be combined into one single (HUGE) Lua statement
            List<string> l;
            if (_petLua.IsInBattle())
            {
                l = Lua.GetReturnValues("return C_PetBattles.GetActivePet(1)");
                _activePet = Convert.ToInt32(l[0]) - 1;

                _abilityNames = _petLua.GetActivePetAbilities();
                _abilityModifiers = _petLua.GetActivePetAbilityModifiers();
                //string abils = "Abilities: "; foreach (string n in _abilityNames) { abils = abils + "'" + n + "' "; } Logger.WriteDebug(abils);
                //string mods = "Modifiers: "; foreach (Single f in _abilityModifiers) { mods = mods + f + " "; } Logger.WriteDebug( mods);  
                _weather = _petLua.GetWeather();
                if (_weather != "")
                    Logger.WriteDebug("Weather: " + _weather);
            }
            for (int i = 0; i < 3; i++)
            {
                if (_petLua.IsInBattle())
                {
                    l = Lua.GetReturnValues("local speciesID = C_PetBattles.GetPetSpeciesID(1, " + (i + 1) + ") local level = C_PetBattles.GetLevel(1, " + (i + 1) + ") local xp, maxXP = C_PetBattles.GetXP(1, " + (i + 1) + ") local displayID = C_PetBattles.GetDisplayID(1, " + (i + 1) + ") local customName, name = C_PetBattles.GetName(1, " + (i + 1) + ") local icon = C_PetBattles.GetIcon(1, " + (i + 1) + ") local petType = C_PetBattles.GetPetType(1, " + (i + 1) + ") local health = C_PetBattles.GetHealth(1, " + (i + 1) + ") local maxHealth = C_PetBattles.GetMaxHealth(1, " + (i + 1) + ") local power = C_PetBattles.GetPower(1, " + (i + 1) + ") local speed = C_PetBattles.GetSpeed(1, " + (i + 1) + ") local rarity = C_PetBattles.GetBreedQuality(1, " + (i + 1) + ") local petID = C_PetJournal.GetPetLoadOutInfo(" + (i + 1) + ") return speciesID, level, xp, maxXP, displayID, name, icon, petType, health, maxHealth, power, speed, rarity, petID");

                    if (l != null)  // pets may be 0 to 3
                    {
                        int petHP = Convert.ToInt32(l[8]);//GetPetHP(i);

                        _pets[i].updateActive(l[0], Convert.ToInt32(l[1]), Convert.ToInt32(l[2]), Convert.ToInt32(l[3]), Convert.ToInt32(l[4]), l[5], l[6], Convert.ToInt32(l[7]), /*Convert.ToInt32(l[8])*/petHP, Convert.ToInt32(l[9]), Convert.ToInt32(l[10]), Convert.ToInt32(l[11]), Convert.ToInt32(l[12]), l[13]);
                    }
                }
                else
                {
                    l = Lua.GetReturnValues("local petID = C_PetJournal.GetPetLoadOutInfo(" + (i + 1) + ") local speciesID, customName, level, xp, maxXp, displayID, isFavorite, name, icon, petType, creatureID, sourceText, description, isWild, canBattle, tradable, unique, obtainable = C_PetJournal.GetPetInfoByPetID(petID) local health, maxHealth, power, speed, rarity = C_PetJournal.GetPetStats(petID) return speciesID, customName, level, xp, maxXp, displayID, isFavorite, name, icon, petType, creatureID, sourceText, description, isWild, canBattle, tradable, unique, obtainable, health, maxHealth, power, speed, rarity, petID");
                    if (l != null)  // pets may be 0 to 3
                    {
                        _pets[i].update(l[0]
                            , l[1],
                            Convert.ToInt32(l[2]),
                            Convert.ToInt32(l[3]),
                            Convert.ToInt32(l[4]),
                            Convert.ToInt32(l[5]),
                            convertLuaBool(l[6]),
                            l[7],
                            l[8],
                            Convert.ToInt32(l[9]),
                            Convert.ToInt32(l[10]),
                            l[11],
                            l[12],
                            convertLuaBool(l[13]),
                            convertLuaBool(l[14]),
                            convertLuaBool(l[15]),
                            convertLuaBool(l[16]),
                            convertLuaBool(l[17]),
                            Convert.ToInt32(l[18]),
                            Convert.ToInt32(l[19]),
                            Convert.ToInt32(l[20]),
                            Convert.ToInt32(l[21]),
                            Convert.ToInt32(l[22]),
                            l[23]);
                        //Logger.WriteDebug(string.Format("Update pet {0} from Lua: l6={1}, convertl6={2}", l[7], l[6], convertLuaBool(l[6]) ));
                    }
                }
            }
        }

        public static void updateEnemyActivePet()
        {
            List<string> l = Lua.GetReturnValues("local petIndex = C_PetBattles.GetActivePet(2) local speciesID = C_PetBattles.GetPetSpeciesID(2, petIndex) local level = C_PetBattles.GetLevel(2, petIndex) local xp, maxXP = C_PetBattles.GetXP(2, petIndex) local displayID = C_PetBattles.GetDisplayID(2, petIndex) local name = C_PetBattles.GetName(2, petIndex) local icon = C_PetBattles.GetIcon(2, petIndex) local petType = C_PetBattles.GetPetType(2, petIndex) local health = C_PetBattles.GetHealth(2, petIndex) local maxHealth = C_PetBattles.GetMaxHealth(2, petIndex) local power = C_PetBattles.GetPower(2, petIndex) local speed = C_PetBattles.GetSpeed(2, petIndex) local rarity = C_PetBattles.GetBreedQuality(2, petIndex) return speciesID, level, xp, maxXP, displayID, name, icon, petType, health, maxHealth, power, speed, rarity");
            _enemeyActivePet.updateActive(l[0], 
                Convert.ToInt32(l[1]), 
                Convert.ToInt32(l[2]), 
                Convert.ToInt32(l[3]), 
                Convert.ToInt32(l[4]), 
                l[5], 
                l[6], 
                Convert.ToInt32(l[7]), 
                Convert.ToInt32(l[8]),
                Convert.ToInt32(l[9]), 
                Convert.ToInt32(l[10]), 
                Convert.ToInt32(l[11]), 
                Convert.ToInt32(l[12]), 
                "");
            int owned = _petLua.NumberOwnedBySpecies(EnemyActivePet.SpeciesID);
            if (Reported != EnemyActivePet.PetID)
            {
                Logger.WriteDebug(EnemyActivePet.Name + " Number owned: " + owned);
                Reported = EnemyActivePet.PetID;
            }
        }

        public static bool convertLuaBool(string s)
        {
            if( s == "nil" ) return false;
            if (s == "0") return false;
            return true;
        }
		
        public static int GetPetHP(int petnum)
        {

            int getal = 0;
            List<string> cnt = Lua.GetReturnValues("local petID= C_PetJournal.GetPetLoadOutInfo(" + petnum + ") local health, maxHealth, attack, speed, rarity = C_PetJournal.GetPetStats(petID) local dummy = (health / maxHealth) * 100 return dummy");
            try
            {
                cnt[0].Replace(",", ".");
                int i = cnt[0].IndexOf('.');

                // Remainder of string starting at 'c'.
                if (i > -1) cnt[0] = cnt[0].Substring(0, i);
                //BBLog("Lua received HP :"+cnt[0]);
                getal = Convert.ToInt32(cnt[0]);
            }
            catch (Exception exc)
            {
                Logger.Write(exc.Message);
            }
			
            return getal;
        }
		
        //////////////////////////////////////////////////////////////
        ///
        ///   Class Strategy Lists helper functions
        ///   
        public static float hp()
        {
            return (ActivePet.HealthPercent*1.0F) / 100.0F;
        }
        public static float hpEnemy()
        {
            return (EnemyActivePet.HealthPercent*1.0F) / 100.0F;
        }
        public static bool buff(string name)
        {
            int left = _petLua.buffLeft(name);
            //Logger.WriteDebug("buff " + name + ", left = " + left);
            return left > 0; 
        }
        public static int buffLeft(string name)
        {
            int left = _petLua.buffLeft(name);
            //Logger.WriteDebug("buff " + name + ", left = " + left);
            return left;
        }
        public static bool debuff(string name)
        {
            int left = _petLua.debuffLeft(name);
            //Logger.WriteDebug("debuff " + name + ", left = " + left);
            return left > 0;
        }
        public static int debuffLeft(string name)
        {
            int left = _petLua.debuffLeft(name);
            //Logger.WriteDebug("debuff " + name + ", left = " + left);
            return left;
        }
        public static string Weather
        { get { return _weather; } }

        public static bool shouldIHide()
        {
            if (debuff("Underwater") || debuff("Underground") || debuff("Chew") || debuff("Flying"))
                return true;
            // TODO: check "Flying" debuff by id? since all flying pets have diff debuff with the same "Flying" name (id 239, speed boost while healthy) vs. Flying id 341 as a result of Lift-Off
            // currently we are blocking 239 inside Lua code. Probably it's ok. 
            return false;
        }

        public static float GetMod(string ability)
        {
            for (int i = 0; i < _abilityNames.Count; i++)
            {
                if (_abilityNames[i] == ability)
                {
                    if (i >= _abilityModifiers.Count)
                    {
                        Logger.Alert("GetMod: ability " + i + " (" + ability + ") has no modifier, total mods " + _abilityModifiers.Count);
                        return 0;
                    }
                    float mod = _abilityModifiers[i];
                    bool res = mod > 1;
                    Logger.WriteDebug(string.Format("GetMod: ability {0}, modifier {1:F}", ability, mod));
                    return mod;
                }
            }
            Logger.WriteDebug("GetMod: ability " + ability + " not active");
            return 0;
        }

        public static bool IsStrong(string ability)
        {
            return GetMod(ability) > 1;
        }

        public static bool IsWeak(string ability)
        {
            return GetMod(ability) < 1;
        }

        public static bool enemyIsAsleep()
        {
            if (debuff("Asleep"))
            {
                return true;
            }
            return false;
        }

        public static bool enemyIsBleeding()
        {
            if (debuff("Bleeding"))
            {
                return true;
            }
            return false;
        }

        public static bool enemyIsBlinded()
        {
            if ((_weather == "Darkness" && EnemyActivePet.PetType != (int)PF.Elemental) ||
                debuff("Blinding Poison") || debuff("Blinded") || debuff("Partially Blinded"))
            {
                return true;
            }
            return false;
        }

        public static bool enemyIsBurning()
        {
            if ((_weather == "Scorched Earth" && EnemyActivePet.PetType != (int)PF.Elemental) ||
                debuff("Fel Immolate") || debuff("Flame Breath") || debuff("Flame Jet") ||
                debuff("Flamethrower") || debuff("Immolate"))
            {
                return true;
            }
            return false;
        }

        public static bool enemyIsChilled()
        {
            if ((_weather == "Blizzard" && EnemyActivePet.PetType != (int)PF.Elemental) ||
                debuff("Frostbite") || debuff("Frost Nova") ||
                debuff("Frost Shock") || debuff("Slippery Ice"))
            {
                return true;
            }
            return false;
        }

        public static bool enemyIsPoisoned()
        {
            // Glowing Toxin is a debuff but does not poison apparently
            if (debuff("Poisoned") || debuff("Acidic Goo") ||
                debuff("Blinding Poison") || debuff("Confusing Sting") ||
                debuff("Corpse Explosion") || debuff("Creeping Ooze") ||
                debuff("Sting"))
            {
                return true;
            }
            return false;
        }

        // immune to stun, polymorph, sleep
        public static bool enemyIsResilient()
        {
            if (debuff("Resilient"))
            {
                return true;
            }
            return false;
        }

        public static bool enemyIsStunned()
        {
            if (debuff("Stunned") || debuff("Crystal Prison"))
            {
                return true;
            }
            return false;
        }

        public static bool myPetIsAsleep()
        {
            if (buff("Asleep"))
            {
                return true;
            }
            return false;
        }

        public static bool myPetIsBleeding()
        {
            if (buff("Bleeding"))
            {
                return true;
            }
            return false;
        }

        public static bool myPetIsBlinded()
        {
            if ((_weather == "Darkness" && ActivePet.PetType != (int)PF.Elemental) ||
                buff("Blinding Poison") || buff("Blinded") || buff("Partially Blinded"))
            {
                return true;
            }
            return false;
        }

        public static bool myPetIsBurning()
        {
            if ((_weather == "Scorched Earth" && ActivePet.PetType != (int)PF.Elemental) ||
                buff("Fel Immolate") || buff("Flame Breath") || buff("Flame Jet") ||
                buff("Flamethrower") || buff("Immolate"))
            {
                return true;
            }
            return false;
        }

        public static bool myPetIsChilled()
        {
            if ((_weather == "Blizzard" && ActivePet.PetType != (int)PF.Elemental) ||
                buff("Frostbite") || buff("Frost Nova") ||
                buff("Frost Shock") || buff("Slippery Ice"))
            {
                return true;
            }
            return false;
        }
        
        public static bool myPetIsPoisoned()
        {
            // Glowing Toxin is a debuff but does not poison apparently
            if (buff("Poisoned") || buff("Acidic Goo") ||
                buff("Blinding Poison") || buff("Confusing Sting") ||
                buff("Corpse Explosion") || buff("Creeping Ooze") ||
                buff("Sting"))
            {
                return true;
            }
            return false;
        }

        // immune to stun, polymorph, sleep
        public static bool myPetIsResilient()
        {
            if (buff("Resilient"))
            {
                return true;
            }
            return false;
        }

        public static bool myPetIsStunned()
        {
            if (buff("Stunned") || buff("Crystal Prison"))
            {
                return true;
            }
            return false;
        }
    }
}
