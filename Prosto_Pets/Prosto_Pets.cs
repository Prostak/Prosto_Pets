﻿// Created Dec 14, 2014 by Prostak
// Based on: Pokehbuddy Bot code by           , 
//           Prosto_Pets plugin by Andy West (Based on PetsAng Apoc/Ang)
//           MyPetBattles protected Lua Wow (WoW, not HB) plugin by
//           my own combat logic developed for various pets for MyPetBattles plugin    

// Does not need 3 pets to start
// swap logic incorporated

using Styx.Common.Helpers;
using Styx.CommonBot.Inventory;
using Styx.Helpers;
using Styx.Plugins;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Styx.Common;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using Styx;

using Styx.CommonBot;
using Styx.CommonBot.Profiles;
using Styx.CommonBot.POI;

//*************************************************

using Styx.WoWInternals.World;
using Styx.WoWInternals.Misc;

using Bots.BGBuddy.Helpers;

using Styx.CommonBot.Routines;
using Styx.Pathing;
using Styx.TreeSharp;
using Levelbot.Decorators.Death;
using Levelbot.Actions.Death;
using Bots.Grind;
using CommonBehaviors.Actions;
using System.Windows.Forms;
using NewMixedMode;

namespace Prosto_Pets
{

    public partial class Prosto_Pets : BotBase
    {
        public string Version { get { return "0.9.16"; } }
        // 0.9.16:
        // - Studio60 Aquatic/Beast Tactics Pre-5.3 + Fixes 
        // - Elekk Plushie blacklisted
        //
        // 0.9.15:
        // - Studio60 120+ pet tactics merged
        //
        // 0.9.14:
        // - closest profile selected
        //
        // 0.9.13:
        // - speedEnemy corrected
        // - Base tactics corrected.
        // - debuffLeft added.
        //
        // 0.9.12:
        // - additions for battle tactics
        //
        // 0.9.11:
        // - profiles for EK and Kalimdor replaced with ground ones
        // - zone selection based on the current continent implemented:
        //   -- Default zone profile is now empty (--- not set ----).
        //   -- If the zone is to be autoselected, but not set on "Pet Zone" tab (or set for another continent) - the bot will load a zone for the continent you are in. Stop if failed.
        //   -- Button to load the zones for the continent added to "Pet Zones" tab. Set to (--- not found ---) if not found.
        //   -- CATA zones prefix changed to EK and KALI as appropriate.
        //
        // 0.9.10:
        // - help system implemented
        //
        // 0.9.9:
        // - using real names instead of custom names (thanks Studio60)
        // - shouldHide fixed (thanks Studio60)
        // - tactics for Pierre and Ancient Nest Guardian added (thanks Studio60)
        // - tactics for Bronze Whelpling (thanks Valpsjuk)
        // - mechanical tactics (too many to list here) by Studio60
        // - Bot now remembers last used profile between sessions (and loads it if needed)
        //
        // 0.9.8: to Edacra with thanks
        // - dead pets in the current team no longer stop the bot (it will wait for Revive CD) (Edacra issue 1)
        // - reload pet journal on Start (Edacra issue 2)
        // - movement from the indoor area corrected
        // - names of the locked pets are printed
        // - Waterfly tactics corrected
        //
        // 0.9.7:
        // - "Ignore Elites" checkbox added. Will not auto engage Legendary Pets if set (which is default)
        //
        // 0.9.6:
        // - text on Min Health corrected
        // - Humanoid/Grommlok support added (thanks Misanthrope)

        public int battleCount;
        private static Stopwatch blacklistTimer = new Stopwatch();
        private static Stopwatch rezTimer = new Stopwatch();
        private static Stopwatch RoundStartTimer = new Stopwatch();
        private static Stopwatch ClickWildTimer = new Stopwatch();

        private IPluginSettings _pluginSettings;
        private IPluginProperties _pluginProperties;
        private IPetLua _petLua;
        private IPetJournal _petJournal;
        private IPetChooser _petChooser;
        private IPetLoader _petLoader;
        private PetProfile _petProfile;
        private ZoneList _zoneTable;

        private IPetReporter _petReport;

        int _lastEnemyLevel;

        const int success = 1;
        const int failure = 0;

        private bool Moved;  // TODO: better name
        private bool Selected;
        private bool AnimationActive;
        private bool LoadSuccess;

        private int numPetsOwnedOnStart;  // used just to check eligibility
        private bool isSlotAvailableOnStart;
        private int CurrentProfileLevel;     // This is a profile level

        private bool WasInitialized;

        Random rand;
        double ReactionTime;

        public static Prosto_Pets Instance { get; private set; } 

        public Prosto_Pets()
        {
            WasInitialized = false;
            Instance = this;
            BotEvents.Profile.OnNewOuterProfileLoaded += Profile_OnNewOuterProfileLoaded;

        }
        #region BotBaseOverrides

        private Composite _root;
        public override Composite Root
        {
            get
            {
                return _root ?? (_root = createBotBehavior());
            }
        }

#if false
        public override Form ConfigurationForm
        {
            // get { return new PluginSettingsForm(); }
            get { return new UI.FormMP();  }
        }
#endif
        private Form _frm;
        public override Form ConfigurationForm
        {
            get
            {
                try { if (_frm == null || !_frm.Visible) _frm = new UI.FormMP(); return _frm; }
                //try { if (_frm == null || !_frm.Visible) _frm = new PluginSettingsForm(); return _frm; }
                catch (Exception e) 
                {
                    Logger.Alert(e.ToString());
                }
                return null;
            }
        }



        public override PulseFlags PulseFlags
        {
            get { return PulseFlags.All; }
        }

        public override string Name { get { return "Prosto Pets"; } }


        public override void Initialize()
        {
            if (WasInitialized)
                return;
            battleCount = 0;
            _petLua = PetLua.Instance;
            _pluginSettings = new PluginSettings();
            _pluginProperties = _pluginSettings as IPluginProperties;
            _petJournal = new PetJournal(_pluginProperties, _petLua);
            _petChooser = new PetChooser(_pluginProperties, _petLua, _petJournal);
            _petLoader = new PetLoader(_petLua);
            _petReport = new PetReport();
            _zoneTable = new ZoneList();

            _lastEnemyLevel = 0;
            CurrentProfileLevel = 0;

            MyPets.updateMyPets();      // some healing behavior may need to know the current state

            Moved = false;
            Selected = false;
            AnimationActive = false;
            LoadSuccess = true;        // no failures detected yet

            rand = new Random();
            ReactionTime = rand.NextDouble() * 1000 + 500;
            Logger.Write(string.Format("Reaction time set about {0:F1} msec" , ReactionTime));

            numPetsOwnedOnStart = _petLua.GetNumPetsOwned();
            isSlotAvailableOnStart = ! _petLua.IsSlotLocked(1);
            Logger.WriteDebug("Owned on start: " + numPetsOwnedOnStart + ", slot available: " + isSlotAvailableOnStart);

            if( !string.IsNullOrEmpty(PluginSettings.Instance.LastProfile) )
                LoadProfile(PluginSettings.Instance.LastProfile);

            // will fight everything. Is "nothing" better?

            WasInitialized = true;
        }

        public override void Pulse()
        {
        }

        public override void Start()
        {
            Logger.Write("Prosto_Pets started, version " + Version);
            BotPoi.Clear();
            AttachLuaEvents();
            MyPets.updateMyPets();

            // make sure Stop-Start does not create "Waiting for our Turn" situation
            AnimationActive = false;
            RoundStartTimer.Reset();
            ClickWildTimer.Reset();
            LoadSuccess = true;      // amnesty TODO: load right here? -- after PopulatePetJournal

            _petReport.Start();

            numPetsOwnedOnStart = _petLua.GetNumPetsOwned();
            isSlotAvailableOnStart = !_petLua.IsSlotLocked(1);
            Logger.WriteDebug("Owned on start: " + numPetsOwnedOnStart + ", slot available: " + isSlotAvailableOnStart);

            _petJournal.PopulatePetJournal();  // unconditional load - things may have changed while stopped
            PluginSettings.Instance.SetSwapByCurrentMode();
            CurrentProfileLevel = 0;
            ChangeProfileIfNeeded();
        }

        public override void Stop()
        {
            //battleCount updated twice per battle - no more
            Logger.Write("Fought " + battleCount + " battles.");
            battleCount = 0;
            _petReport.Stop();
            DetachLuaEvents();
        }

        public override bool RequiresProfile
        {
            get
            {
                return false;  // should autoload
            }
        }

        public override bool IsPrimaryType
        {
            get
            {
                return true; //MySettings.isPrimaryType;
            }
        }

        public override bool RequirementsMet
        {
            get
            {
                return true; // wildPetTargetNearby() || inPetCombat();
            }
        }
        #endregion

        private void Profile_OnNewOuterProfileLoaded(BotEvents.Profile.NewProfileLoadedEventArgs args)
        {
            try
            {
                //Logger.Write("Processing new profile");
                _petProfile = new PetProfile(args.NewProfile);
                PluginSettings.Instance.LastProfile = ProfileManager.XmlLocation;
                PluginSettings.Instance.Save();

            }
            catch (Exception ex)
            {
                Logging.WriteException(ex);
            }
        }

        public static void Log( string line )
        {
            Logger.Write( line );
        }


        public static int ValidLevel(int level)
        {
            if (level < 1) return 1;
            if (level > 25) return 25;
            return level;
        }

        #region Behaviors
        public Composite createBotBehavior()
        {
            return new PrioritySelector(
                new Decorator(ret => !preconditionsVerified(),
                            PreconditionsNotMetAction()),
                new Decorator(ret => !LoadSuccess,
                            TeamLoadFailedAction()),
                new Decorator(ret => !StyxWoW.Me.IsAlive,
                    new PrioritySelector(
                            new DecoratorNeedToRelease(new ActionReleaseFromCorpse()),
                            new DecoratorNeedToMoveToCorpse(LevelBot.CreateDeathBehavior()),
                            new DecoratorNeedToTakeCorpse(LevelBot.CreateDeathBehavior()),
                            new ActionSuceedIfDeadOrGhost()
                            )),
                new Decorator(
                        c => StyxWoW.Me.Combat && !StyxWoW.Me.IsFlying,
                        LevelBot.CreateCombatBehavior()),
                new Decorator(ret => _petLua.IsInBattle(),
                    createPetCombatBehavior()),
                new Decorator(ret => isRezFinished(),
                            processHealResults()),
                new Decorator(ret => !isRezPetOnCooldown(),
                            healPetsAction()),
                new Decorator(ret => numberOfPetsSick() >= 1 ,       // TODO: parameter?
                    new PrioritySelector(

                        new Decorator(ret => shouldUsePetBandage(),
                            usePetBandageAction()),
                        new Decorator(ret => numberOfPetsSick() > 1,  // TODO: parameter  
                            waitToRezBattlePetsAction())
                        )),
                //new Decorator(ret => PokehBuddy.MySettings.DoPVP,
                //    createPvpBehavior()),
                createMovementBehavior());

        }

        public Composite createPetCombatBehavior()
        {
            return new PrioritySelector(
                    new Decorator(ret => _petLua.MustSelectNew(),  // should be checked before OurTurn
                        SelectNewPet_Action()),
                    new Decorator(ret => WaitingForOurTurn(),
                        new ActionAlwaysSucceed()),
                    new Decorator(ret => shouldTrap(), 
                        TrapPetAction()),
                    //new Decorator(ret => shouldForfeit(),
                    //    forfeitBattleAction()),
                    PetBattleAttackAction()
                );
        }

#if false
        public Composite createPvpBehavior()
        {
            return new PrioritySelector(
                    new Decorator(ret => !inPetBattleQueue(),
                        queueForPetBattleAction()),
                    new Decorator(ret => queuePrompted(),
                        acceptQueuePromptAction()),
                    new ActionAlwaysSucceed()
                );
        }
#endif

        public Composite createMovementBehavior()
        {
            return new PrioritySelector(
                        new Decorator(ret => poiIsWildPet(),
                            new PrioritySelector(
                                new Decorator(ret => !isWildPetValidTarget(),
                                    clearPoiAction()),
                                new Decorator(ret => shouldBlacklistTarget(),
                                    new Sequence(
                                        blacklistPoiAction(),
                                        clearPoiAction())),
                                new Decorator(ret => canInteract(),
                                    new Sequence(
                                        preCombatSwappingAction(), // - actually here needs to be a pre-config team preparation if needed. But we may want to avoid Spiders too
                                        new Mount.ActionLandAndDismount(),
                                        interactWildPetAction())),
                                moveToPoiAction(),
                                new ActionAlwaysSucceed())),

                        new Decorator(ret => wildPetTargetNearby(),
                            moveToWildPetAction()),
                        new Decorator(ret => movementByPlayer(),
                            new ActionAlwaysSucceed()),
                        new Decorator(ret => !havePoi(),
                            setPoiToNextHotspotAction()),
                        moveToPoiAction(),
                        new ActionAlwaysSucceed()
                );
        }

        #endregion

        #region Actions

        int GetZoneRangePart( string part)
        {
            if(part.Length>0 && part.Length<=2)
            {
                int number = 0;
                if (Int32.TryParse(part, out number))
                {
                    return number;
                }
            }
            return 0;
        }

        int[] GetRangeOfCurrentProfile()
        {
            int[] range = { 0, 0 };
            string name = GetCurrentProfileName();
            string[] parts = name.Split( new char[]{' ', '-', '[', ']'});
            int i = 0;
            while( i<parts.Length)
            {
                int limit = 0;
                if( (limit = GetZoneRangePart(parts[i])) > 0)
                {
                    range[0] = limit;
                    break;
                }
                i++;
            }
            i++;
            while (i < parts.Length)
            {
                int limit = 0;
                if ((limit = GetZoneRangePart(parts[i])) > 0)
                {
                    range[1] = limit;
                    break;
                }
                i++;
            }
            return range;
        }

        // TODO: is more detailed config needed? Probably a difference may be set configurable
        public bool ShouldAttack(WoWUnit pet)
        {

            if (PluginSettings.Instance.DoNotEngage)
            {
                Logger.WriteDebug("DoNotEngage is set - not engaging");
                return false;
            }

            // if the pet is withing the range of desired zone
            pet.Target();
            int level = _petLua.GetTargetLevel();
            string classification = _petLua.GetTargetClassification();
            Logger.WriteDebug("Pet " + pet.Name + ", level=" + level + ", " + classification);

            if( classification != "normal" && PluginSettings.Instance.IgnoreElites)
            {
                Logger.WriteDebug("Pet is " + classification + " and IgnoreElites is set. Ignoring.");
                return false;
            }

            if (PluginSettings.Instance.AutoZoneChange)
            {
                if ((CurrentProfileLevel - 2 <= level && level <= CurrentProfileLevel + 2))
                { return true; }
                else
                { Logger.WriteDebug(string.Format("WildPet {0} level {1}: not fit for expected zone range [{2}-{3}]", pet.Name, level, ValidLevel(CurrentProfileLevel - 2), ValidLevel(CurrentProfileLevel + 2))); }
            }

            int shiftedLevel = MyPets.Pet(0).Level + PluginSettings.ModeInfo.ZoneDiff;
            shiftedLevel = ValidLevel(shiftedLevel);

            if (shiftedLevel-2 <= level && level <= shiftedLevel+2 )
                return true;

            Logger.WriteDebug( string.Format("WildPet {0} level {1}: not fit for expected range about Pet1 level={2} + ZoneDiff={3}: [{4}-{5}]", 
                pet.Name, level, MyPets.Pet(0).Level, PluginSettings.ModeInfo.ZoneDiff, ValidLevel(shiftedLevel-2), ValidLevel(shiftedLevel+2 )));

            int[] rangeProfile = GetRangeOfCurrentProfile();
            if (rangeProfile.Length == 2 && rangeProfile[0] != 0 && rangeProfile[1] != 0)
            {
                if (rangeProfile[0] - 2 <= level && level <= rangeProfile[1] + 2)
                {
                    Logger.Write(string.Format("WildPet {0} level {1}: fit for loaded profile range [{2}-{3}]", pet.Name, level, ValidLevel(rangeProfile[0] - 2), ValidLevel(rangeProfile[1] + 2)));
                    return true;
                }
                else
                {
                    Logger.WriteDebug(string.Format("WildPet {0} level {1}: not fit for loaded profile range [{2}-{3}]", pet.Name, level, ValidLevel(rangeProfile[0] - 2), ValidLevel(rangeProfile[1] + 2)));
                }
            }
            else
            {
                Logger.WriteDebug("No Range in current profile name: " + GetCurrentProfileName());
            }

            return false;
        }

        private bool preconditionsVerified()
        {
            return (numPetsOwnedOnStart > 0 && isSlotAvailableOnStart);
        }

        private Composite PreconditionsNotMetAction()
        {
            return new Styx.TreeSharp.Action(
                ctx =>
                {
                    Logger.Alert("Owned on start: " + numPetsOwnedOnStart + " pets, slots available: " + (isSlotAvailableOnStart? "yes":"no") + ". Can't work");
                    TreeRoot.Stop("Bot conditions not met: need a pet and a slot.");
                    return RunStatus.Success;
                });
        }

        private Composite TeamLoadFailedAction()
        {
            return new Styx.TreeSharp.Action(
                ctx =>
                {
                    TreeRoot.Stop("Team selection failed: all done?");
                    return RunStatus.Success;
                });
        }


        public string GetBattleStateName(int state)
        {
            if (state < 1) { return "Too Low"; }
            if (state == 1) { return "CREATED"; }
            if (state == 2) { return "WAITING_PRE_BATTLE"; }
            if (state == 3) { return "ROUND_IN_PROGRESS"; }
            if (state == 4) { return "WAITING_FOR_ROUND_PLAYBACK"; }
            if (state == 5) { return "WAITING_FOR_FRONT_PETS"; }
            if (state == 6) { return "CREATED_FAILED"; }
            if (state == 7) { return "FINAL_ROUND"; }
            if (state == 8) { return "FINISHED"; }
            return "Too High";
        }

        public bool WaitingForOurTurn()
        {
            bool ourTurn = _petLua.IsOurTurn();

            if( !ourTurn )
            {
                int battleState = _petLua.GetBattleState();
                if (battleState != 3)
                {
                    //Logger.WriteDebug("Not our turn, BattleState = " + battleState + "(" + GetBattleStateName(battleState) + ")");
                    //Logger.WriteDebug("MustSelectNew: " + _petLua.MustSelectNew());
                }
            }

            if( AnimationActive || !ourTurn )
            {
                //Logger.WriteDebug(string.Format("Waiting: Anim={0}, turn={1}", AnimationActive, ourTurn));
                return true;
            }
            if( RoundStartTimer.IsRunning )
            {
                // roll a dice
                double interval = (ReactionTime-500)*2;
                double rand2 = rand.NextDouble();
                rand2 = rand2*interval + 500;
                if (RoundStartTimer.ElapsedMilliseconds <= rand2)
                {
                    //Logger.WriteDebug(string.Format("StartTimer: running={0}, elapsed={1}", RoundStartTimer.IsRunning, RoundStartTimer.ElapsedMilliseconds));
                    return true;  // still waiting
                }
                else
                {
                    Logger.WriteDebug(string.Format("Move timer released after {0:F1} msec, go!", RoundStartTimer.ElapsedMilliseconds));
                }
            }
            RoundStartTimer.Reset();
            return false;
        }

        public bool inPetCombat()
        {
            return _petLua.IsInBattle();
        }

        public bool canInteract()
        {
            return BotPoi.Current.AsObject.WithinInteractRange;
        }

        public bool poiIsWildPet()
        {
            if (BotPoi.Current.AsObject != null)
                return BotPoi.Current.AsObject.ToUnit().IsPetBattleCritter;
            return false;
        }

        public bool shouldBlacklistTarget()
        {
            return blacklistTimer.ElapsedMilliseconds >= 15000;
        }

        #region Rezzing and Healing

        public int numberOfPetsSick()
        {
            int count = 0;
            //MyPets.updateMyPets();
            if (MyPets.Pet(0).Health < 40) count++;   // TODO: make a parameter
            if (!_petLua.IsSlotLocked(2) && MyPets.Pet(1).Health < 40) count++;
            if (!_petLua.IsSlotLocked(3) && MyPets.Pet(2).Health < 40) count++;
            return count;
        }

        public bool isRezPetOnCooldown()
        {
            string revive = "Revive Battle Pets";
            if( ! SpellManager.Spells.ContainsKey(revive)) return true;
            return SpellManager.Spells[revive].Cooldown;
        }

        public bool movementByPlayer()
        {
            //Logger.WriteDebug("movementByPlayer: " + PluginSettings.Instance.MovementByPlayer);
            return PluginSettings.Instance.MovementByPlayer;
        }

        public bool shouldUsePetBandage()
        {
            // TODO: implement?
            return false; //PokehBuddy.MySettings.UseBandagesToHeal != 0 && numberOfPetsDead() >= PokehBuddy.MySettings.UseBandagesToHeal;
        }

        public bool isRezFinished()
        {
            return rezTimer.ElapsedMilliseconds >= 500;
        }

        private Composite processHealResults()
        {
            return new Styx.TreeSharp.Action(
                ctx =>
                {
                    Log("Process Heal Results");
                    rezTimer.Reset();
                    _petJournal.PopulatePetJournal();  // read heal results
                    return RunStatus.Success;
                });
        }

        private Composite preCombatSwappingAction()
        {
            return new Styx.TreeSharp.Action(
                ctx =>
                {
                    if (!Selected)
                    {
                        MyPets.updateMyPets();
                        // TODO: here we know the target. This is a place to put a target-based team selection.
                        LoadSuccess = LoadPetsForLevel( );  // TODO: look at config
                        if( !LoadSuccess)
                        {
                            TreeRoot.Stop("Team selection failed: all done?");
                        }
                    }
                    return RunStatus.Success;
                });
        }

        private Composite healPetsAction()
        {
            return new Styx.TreeSharp.Action(
                ctx =>
                {
                    SpellManager.Cast("Revive Battle Pets");
                    rezTimer.Reset();
                    rezTimer.Restart();
                    return RunStatus.Success;
                });
        }

        private Composite usePetBandageAction()
        {
            return new Styx.TreeSharp.Action(
                ctx =>
                {
                    Log("Enough pets injured, Using Bandages");
                    Lua.DoString("RunMacroText(\"/use Battle Pet Bandage\");");
                    return RunStatus.Success;
                });
        }

        // TODO: implement stable master?
        private Composite waitToRezBattlePetsAction()
        {
            return new Styx.TreeSharp.Action(
                ctx =>
                {
                    LoadSuccess = LoadPetsForLevel(); // try this before waiting
                    if( !LoadSuccess)
                    {
                        TreeRoot.Stop("Team selection failed: all done?");
                        return RunStatus.Success;
                    }
                    Log("Waiting to revive pets.");
                    return RunStatus.Success;
                });
        }


        #endregion

        #region Trapping
        private bool shouldTrap()
        {
            if (!_petLua.IsOurTurn()) return false;
            if( !_petLua.IsTrapAvailable()) return false;

            if( MyPets.EnemyActivePet.Rarity >= 4 && PluginSettings.Instance.CaptureRares)
            {
                 return true;
            }
            if( MyPets.EnemyActivePet.Rarity >= PluginSettings.Instance.CaptureNotOwnRarity )
            {
                if (_petLua.NumberOwnedBySpecies(MyPets.EnemyActivePet.SpeciesID) == 0) return true;
            }
            return false;
        }

        private Composite TrapPetAction()
        {
            return new Styx.TreeSharp.Action(
                ctx =>
                {
                    Log("Trap Pet Action");
                    _petLua.UseTrap();
                    return RunStatus.Success;
                });
        }

        #endregion


        #endregion


        private Composite blacklistPoiAction()
        {
            return new Styx.TreeSharp.Action(
                ctx =>
                {
                    Log("Took longer than 15 seconds to enter battle with pet. Blacklisting.");
                    Blacklist.Add(BotPoi.Current.Guid, BlacklistFlags.Interact, new TimeSpan(0, 1, 0), "Unable to battle.");
                    blacklistTimer.Reset();
                    return RunStatus.Success;
                });
        }

        private Composite clearPoiAction()
        {
            return new Styx.TreeSharp.Action(
                ctx =>
                {
                    Log("Pet is dead or uninteractable, clearing POI.");
                    BotPoi.Clear();
                    return RunStatus.Success;
                });
        }


        public bool wildPetTargetNearby()
        {
            return WildBattleTarget() != null;
        }

        public bool isWildPetValidTarget()
        {
            var pet = BotPoi.Current.AsObject.ToUnit();
            return pet.IsAlive && !pet.IsTagged;

        }

        public WoWUnit WildBattleTarget()
        {

            WoWUnit ret = (from unit in ObjectManager.GetObjectsOfType<WoWUnit>(true, true)
                           orderby unit.Distance ascending

                           where !Blacklist.Contains(unit.Guid, BlacklistFlags.All)
                           //where unit.CreatureType.ToString() == "14"
                           where unit.IsPetBattleCritter
                           where !unit.IsDead
                           where !IsUnderWater(unit.Location)
                           //where (MySettings.UseWhiteList && thewhitelist.Contains(unit.Name.ToLower()) || !MySettings.UseWhiteList)
                           //where (MySettings.UseBlackList && !theblacklist.Contains(unit.Name.ToLower()) || !MySettings.UseBlackList)
                           //where unit.Distance < PokehBuddy.MySettings.Distance
                           select unit).FirstOrDefault();
            if (ret != null)
            {
                _petReport.AddSeen(ret.Guid.ToString(), ret.Name, ret.Location);
                //ret.Target();
                if( ShouldAttack(ret) )
                {
                    return ret;
                }
                else
                {
                    // CHECK: if (dumlevel > 0)
                    {
                        Logger.WriteDebug("Blacklisting " + ret.Guid + " for 1 min" );
                        Blacklist.Add(ret.Guid, BlacklistFlags.All, TimeSpan.FromMinutes(1));
                    }
                }
            }
            return null;
        }

        private Composite moveToWildPetAction()
        {
            return new Styx.TreeSharp.Action(
                ctx =>
                {
                    WoWUnit target = WildBattleTarget();
                    if (target == null) return RunStatus.Failure;
                    BotPoi.Current = new BotPoi(target, PoiType.Interact, NavType.Fly);
                    blacklistTimer.Reset();
                    blacklistTimer.Start();
                    return RunStatus.Success;
                });
        }

        private static string GetCurrentProfileName()
        {
            return System.IO.Path.GetFileName(Styx.CommonBot.Profiles.ProfileManager.XmlLocation);
        }

        private Composite setPoiToNextHotspotAction()
        {
            return new Styx.TreeSharp.Action(
                ctx =>
                {
                    //Move to next hotspot

                    Logger.WriteDebug("Moving To Next Hotspot, old Poi type=" + BotPoi.Current.Type.ToString() + ". Profile: '" + GetCurrentProfileName() + "'");
                    if( _petProfile == null || _petProfile.WayPoints.Count <= 0 )
                    {
                        Logger.WriteDebug(string.Format("PetProfile {0}, WayPoints {1}", _petProfile == null ? "empty" : "loaded", _petProfile==null ? 0 : _petProfile.WayPoints.Count));
                        Logger.Alert("Profile with Hotspots Needed for Auto navigation. Current profile: '" + GetCurrentProfileName() + "'");  // TODO: check earlier?
                        TreeRoot.Stop("Bot conditions not met: Profile with Hotspots needed.");
                        return RunStatus.Success;
                    }
                    WoWPoint hsLoc = WoWPoint.Empty;
                    if (BotPoi.Current.Type == PoiType.Interact || BotPoi.Current.Type == PoiType.None)
                    {
                        _petProfile.CycleToNearest();
                    }
                    else
                    {
                        _petProfile.CycleToNextPoint();
                    }
                    hsLoc = _petProfile.CurrentPoint;
                    BotPoi.Current = new BotPoi(hsLoc, PoiType.Hotspot, NavType.Fly);
                    Logger.WriteDebug(string.Format("BotPoi.Current.Location: X={0}, Y={1}, Z={2}", BotPoi.Current.Location.X, BotPoi.Current.Location.Y, BotPoi.Current.Location.Z));

                    return RunStatus.Success;
                });
        }

        public static IEnumerable<WoWPoint> GetAllHeights(WoWPoint point)
        {
            List<WoWPoint> heights = new List<WoWPoint>();
            using (StyxWoW.Memory.AcquireFrame())
            {
                heights.AddRange(Navigator.FindHeights(point.X, point.Y).Select(height => new WoWPoint(point.X, point.Y, height)));
            }
            return heights;
        }

        public static WoWPoint FindGroundLocation(WoWPoint location)
        {
            WoWPoint ret = StyxWoW.Me.IsFlying
                ? GetAllHeights(location).OrderBy(x => x.Distance(location)).FirstOrDefault()
                : GetAllHeights(location)
                    .OrderBy(x => x.Distance(location))
                    .Where(x => Navigator.CanNavigateFully(location, x))
                    .FirstOrDefault(x => x.Z <= (location.Z + 1.5));
            if (ret.Equals(WoWPoint.Zero))
            {
                //Logger.WriteDebug("Can't find ground height for " + location.ToString() + ". Not changing");  // TODO: periodic print?
                return location;
            }
            return ret;
        }

        // Returns WoWPoint.Empty if unable to locate water's surface
        public static WoWPoint WaterSurface(WoWPoint location)
        {
            WoWPoint hitLocation;
            bool hitResult;
            WoWPoint locationUpper = location.Add(0.0f, 0.0f, 2000.0f);
            WoWPoint locationLower = location.Add(0.0f, 0.0f, -2000.0f);

            hitResult = (GameWorld.TraceLine(locationUpper, locationLower, TraceLineHitFlags.LiquidAll, out hitLocation));

            return (hitResult ? hitLocation : WoWPoint.Empty);
        }

        // Returns WoWPoint.Empty if unable to locate water's surface
        public static bool IsUnderWater(WoWPoint location)
        {
            WoWPoint waterLocation;
            bool hitResult;
            WoWPoint locationUpper = location.Add(0.0f, 0.0f, 2000.0f);
            WoWPoint locationLower = location.Add(0.0f, 0.0f, -2000.0f);

            hitResult = (GameWorld.TraceLine(locationUpper, locationLower, TraceLineHitFlags.LiquidAll, out waterLocation));

            if (!hitResult) return false;

            return (location.Z < waterLocation.Z);
        }

        private Composite moveToPoiAction()
        {
            return new Styx.TreeSharp.Action(
                ctx =>
                {
                    //Logger.WriteDebug("moveToPoiAction");
                    if (canFly())
                        Flightor.MoveTo(BotPoi.Current.Location, false);
                    else
                    {
                        WoWPoint p = BotPoi.Current.Location;
                        var pZ = p.Z;
                        if (BotPoi.Current.Type != PoiType.Interact)   // mushroom interfereing in Draenor. TODO: enable FPSware's height selection method
                        {
                            p = FindGroundLocation(p);
                            //Logger.WriteDebug("After FindHeight: " + p.ToString());
                            if (p.Z == 0f) p.Z = pZ;  // Height unknown, keeping Hs Z       
                        }
                        //MoveResult res = Navigator.MoveTo(p);
                        Flightor.MoveTo(p, false);
                    }
                    return RunStatus.Success;
                });
        }

        private Composite interactWildPetAction()
        {
            return new Styx.TreeSharp.Action(
                ctx =>
                {
                    if (!ClickWildTimer.IsRunning || ClickWildTimer.ElapsedMilliseconds > 100)  // TODO: 1600 is ok but probably need another battle start criteria
                    {
                        //Logger.WriteDebug("Interact, Timer: " + ClickWildTimer.ElapsedMilliseconds);
                        BotPoi.Current.AsObject.Interact();
                        ClickWildTimer.Restart();
                    }
                    return RunStatus.Success;
                });
        }

        public bool havePoi()
        {
            //Logger.WriteDebug("havePoi: " + (BotPoi.Current.Type != PoiType.None) + " && " + (BotPoi.Current.Location.Distance2D(StyxWoW.Me.Location) > 5.0));
            return BotPoi.Current.Type != PoiType.None && BotPoi.Current.Location.Distance2D(StyxWoW.Me.Location) > 5.0;
        }

        // TODO: CHECK: A bit strange that this is not a standard function
        private bool canFly()
        {
            bool license;
            switch (StyxWoW.Me.MapId)
            {
                case 0:
                case 1:
                    license = SpellManager.HasSpell("Flight Master's License");
                    break;
                case 571: //NR
                    license = SpellManager.HasSpell("Cold Weather Flying");
                    break;
                case 870: //Pandaria
                    license = SpellManager.HasSpell("Wisdom of the Four Winds");
                    break;
                default:
                    license = true;
                    break;
            }
            //Logger.WriteDebug("Can I fly on map "+StyxWoW.Me.MapId+": CanMount=" + Flightor.MountHelper.CanMount + ", Mounts=" + Mount.FlyingMounts.Count + ", license=" + license + "?");

            return Flightor.MountHelper.CanMount && Mount.FlyingMounts.Count > 0 && license;
        }

        private Composite SelectNewPet_Action()
        {
            return new Styx.TreeSharp.Action(
                ctx =>
                {
                    int slot = PetToSwap();
                    if (slot >= 0)  // slots: 0-2
                    {
                        _petLua.SwapIn(slot + 1);  // swap: 1-3
                    }
                    else
                    {
                        Logger.Write("Nothing to SwapIn, skipping turn");
                        _petLua.SkipTurn();
                    }
                    return RunStatus.Success;
                });
        }

        private bool NeedSwaping()
        {
            bool ret = Moved &&
                (MyPets.ActivePet.HealthPercent <= PluginSettings.SwapTab[MyPets.ActivePetNum]  // 100 should mean swap now
                );
            bool canOut = _petLua.CanActivePetSwapOut();
            //Logger.Write("NeedSwapping: " + MyPets.ActivePetNum + ", Health: " + MyPets.ActivePet.HealthPercent + ", Limit: " + SwapTab[MyPets.ActivePetNum] + ", Moved=" + Moved + ", Need: " + ret + "");
            if( ret )
            { 
                Logger.WriteDebug("CanSwapOut: " + canOut); 
            }  // TODO: separate functions
            return ret && canOut;
        }

        int RoundRobin( int pet )
        {
            pet = pet + 1;
            if (pet > 2) pet = 0;
            return pet;
        }

        private int PetToSwap()
        {
            int active = MyPets.ActivePetNum;

            int candidate1 = RoundRobin(active);
            Logger.WriteDebug(string.Format("CanSwapin {0} = {1}", candidate1, _petLua.CanSwapIn(candidate1 + 1)));
            if (MyPets.Pet(candidate1).HealthPercent > PluginSettings.SwapTab[candidate1] && _petLua.CanSwapIn(candidate1 + 1))
                return candidate1;
            Logger.Write("Swap reject for " + candidate1 + ", health=" + MyPets.Pet(candidate1).HealthPercent + ", SwapTab=" + PluginSettings.SwapTab[candidate1] + ", CanSelect=" + _petLua.CanSwapIn(candidate1 + 1) + "");

            int candidate2 = RoundRobin(candidate1);
            Logger.WriteDebug(string.Format("CanSwapin {0} = {1}", candidate2, _petLua.CanSwapIn(candidate2 + 1)));
            if (MyPets.Pet(candidate2).HealthPercent > PluginSettings.SwapTab[candidate2] && _petLua.CanSwapIn(candidate2 + 1))
                return candidate2;
            Logger.Write("Swap reject for " + candidate2 + ", health=" + MyPets.Pet(candidate2).HealthPercent + ", SwapTab=" + PluginSettings.SwapTab[candidate2] + ", CanSelect=" + _petLua.CanSwapIn(candidate2 + 1) + "");

            Logger.WriteDebug("MustSelect=" + _petLua.MustSelectNew());
            if (!_petLua.MustSelectNew())
            { return -1; }  // do not swap: others are not better

            candidate1 = RoundRobin(active);
            Logger.WriteDebug(string.Format("CanSwapin {0} = {1}", candidate1, _petLua.CanSwapIn(candidate1 + 1)));
            if (_petLua.CanSwapIn(candidate1 + 1)) { return candidate1; }

            candidate2 = RoundRobin(candidate1);
            Logger.WriteDebug(string.Format("CanSwapin {0} = {1}", candidate2, _petLua.CanSwapIn(candidate2 + 1)));
            if (_petLua.CanSwapIn(candidate2 + 1)) { return candidate2; }

            Logger.Alert("Cant's swap in any: Lua does not allow");
            return -1;
        }

        private int buttonWith( string spell )
        {
            int i = 0;
            foreach( string name in MyPets.ButtonNames)
            {
                i = i + 1;
                if (spell == name) return i;  // I wonder if the same order, lol
            }
            return 0;
        }

        private int GetButtonFromStrategyLists()
        {
            List<AandC> abilities = Custom.GetSpellTable(); // Check custom first

            if (abilities == null)
            {
                if (MyPets.ActivePet.PetTypeBase == 1)         // TODO: use PT from PetTacticsBase
                    abilities = Humanoid.GetSpellTable();
                else if (MyPets.ActivePet.PetTypeBase == 2)
                    abilities = Dragonkin.GetSpellTable();
                else if (MyPets.ActivePet.PetTypeBase == 3)
                    abilities = Flying.GetSpellTable();
                else if (MyPets.ActivePet.PetTypeBase == 4)
                    abilities = Undead.GetSpellTable();
                else if (MyPets.ActivePet.PetTypeBase == 5)
                    abilities = Critter.GetSpellTable();
                else if (MyPets.ActivePet.PetTypeBase == 6)
                    abilities = Magic.GetSpellTable();
                else if (MyPets.ActivePet.PetTypeBase == 7)
                    abilities = Elemental.GetSpellTable();
                else if (MyPets.ActivePet.PetTypeBase == 8)
                    abilities = Beast.GetSpellTable();
                else if (MyPets.ActivePet.PetTypeBase == 9)
                    abilities = Aquatic.GetSpellTable();
                else if (MyPets.ActivePet.PetTypeBase == 10)
                    abilities = Mechanical.GetSpellTable();

                if (abilities == null) { return 0; }
            }
            else
            {
                Logger.WriteDebug("Using Custom ability list");
            }

            foreach( AandC ability in abilities )
            {
                if( ability.C() )
                {
                    int button = buttonWith(ability.A);  // TODO: check this first, may be cheaper
                    if (button == 0)
                    {
                        // button not active TODO: how to determine misconfig?
                        // no return yet, other entries may be ok
                    }
                    else
                    {
                        if (_petLua.CanUseAbility(button))
                        {
                            Logger.Write("Using " + ability.A + ", button " + button );
                            return button;
                        }
                    }
                }
            }
            return 0;  // none found
        }

        private Composite PetBattleAttackAction()
        {
            return new Styx.TreeSharp.Action(
                ctx =>
                {
                    ClickWildTimer.Reset();
                    MyPets.updateMyPets();
                    MyPets.updateEnemyActivePet();

                    //Log("Current Health of active pet: " + MyPets.ActivePet.Health + " Enemy pet: " + MyPets.EnemeyActivePet.Health);

                    int nextpet=-1;
                    if (NeedSwaping() && (nextpet = PetToSwap()) != -1)
                    {
                        Logger.Write("Pet to Swap In: " + (nextpet+1).ToString() + "");
                        _petLua.SwapIn( nextpet+1 );
                    }
                    else
                    {
                        int button = GetButtonFromStrategyLists();
                        if (button > 0 && _petLua.CanUseAbility(button))
                        {
                            _petLua.UseAbility(button);
                            Moved = true;  // pet exposed
                        }
                        else
                        {
                            // default button pressing
                            if (_petLua.CanUseAbility(1))
                            {
                                _petLua.UseAbility(1);
                                Moved = true;  // pet exposed
                            }
                            else if (_petLua.CanUseAbility(2))
                            {
                                _petLua.UseAbility(2);
                                Moved = true;  // pet exposed
                            }
                            else if (_petLua.CanUseAbility(3))
                            {
                                _petLua.UseAbility(3);
                                Moved = true;  // pet exposed
                            }

                            else
                            {
                                Logger.Write("No abilities active, skipping turn, Animation =" + AnimationActive);
                                _petLua.SkipTurn();
                            }
                        }
                    }
                    _lastEnemyLevel = MyPets.EnemyActivePet.Level;
                    return RunStatus.Success;
                });
        }


     
        #region EventHandlers
        private void AttachLuaEvents()
        {
            Lua.Events.AttachEvent("PET_BATTLE_CLOSE", LuaEndOfBattle);
            Lua.Events.AttachEvent("PET_BATTLE_OPENING_START", LuaPetBattleStarted);
            /*Lua.Events.AttachEvent("PET_BATTLE_PET_ROUND_PLAYBACK_COMPLETE", LuaEndOfRound);
            Lua.Events.AttachEvent("PET_BATTLE_TURN_STARTED", LuaRoundStart);
            Lua.Events.AttachEvent("CHAT_MSG_PET_BATTLE_COMBAT_LOG", PetChatter);*/

            Lua.Events.AttachEvent("PET_BATTLE_PET_CHANGED", LuaBattlePetChanged);
            Lua.Events.AttachEvent("PET_JOURNAL_LIST_UPDATE", LuaPetJournalListUpdate);
            Lua.Events.AttachEvent("PET_JOURNAL_PETS_HEALED", LuaPetsHealed);
            
            Lua.Events.AttachEvent("PET_BATTLE_CAPTURED", LuaPetCaptured);

            Lua.Events.AttachEvent("PET_BATTLE_PET_ROUND_RESULTS",           LuaPetRoundResults);
            Lua.Events.AttachEvent("PET_BATTLE_PET_ROUND_PLAYBACK_COMPLETE", LuaPetRoundResultsComplete);

            // events used to set/reset battle turn counter
            Lua.Events.AttachEvent("CHAT_MSG_PET_BATTLE_COMBAT_LOG", BattleLogParser.LuaMessage);
            Lua.Events.AttachEvent("PET_BATTLE_CLOSE", Battle.LuaResetRound);
            Lua.Events.AttachEvent("PET_BATTLE_OPENING_START", Battle.LuaResetRound);
        }
        private void DetachLuaEvents()
        {

            Lua.Events.DetachEvent("PET_BATTLE_CLOSE", LuaEndOfBattle);
            Lua.Events.DetachEvent("PET_BATTLE_OPENING_START", LuaPetBattleStarted);
            /*Lua.Events.DetachEvent("PET_BATTLE_PET_ROUND_PLAYBACK_COMPLETE", LuaEndOfRound);
            Lua.Events.DetachEvent("PET_BATTLE_TURN_STARTED", LuaRoundStart);
            Lua.Events.DetachEvent("CHAT_MSG_PET_BATTLE_COMBAT_LOG", PetChatter);*/
            Lua.Events.DetachEvent("PET_BATTLE_PET_CHANGED", LuaBattlePetChanged);
            Lua.Events.DetachEvent("PET_JOURNAL_LIST_UPDATE", LuaPetJournalListUpdate);
            Lua.Events.AttachEvent("PET_JOURNAL_PETS_HEALED", LuaPetsHealed);

            Lua.Events.DetachEvent("PET_BATTLE_CAPTURED", LuaPetCaptured);

            Lua.Events.DetachEvent("PET_BATTLE_PET_ROUND_RESULTS",           LuaPetRoundResults);
            Lua.Events.DetachEvent("PET_BATTLE_PET_ROUND_PLAYBACK_COMPLETE", LuaPetRoundResultsComplete);

            // events used to set/reset battle turn counter
            Lua.Events.DetachEvent("CHAT_MSG_PET_BATTLE_COMBAT_LOG", BattleLogParser.LuaMessage);
            Lua.Events.AttachEvent("PET_BATTLE_CLOSE", Battle.LuaResetRound);
            Lua.Events.AttachEvent("PET_BATTLE_OPENING_START", Battle.LuaResetRound);
        }

        private void LuaPetBattleStarted(object sender, LuaEventArgs args)
        {
            string total = "";
            for( int i=1; i<=3; i++)
            {
                string name = _petLua.GetNameBySlotID_Enemy(i);
                _petReport.AddBattle(name);
                total = total + name + " ";
            }
            Logger.WriteDebug("Battle started with: " + total);
        }

        private void LuaPetRoundResults(object sender, LuaEventArgs args)
        {
            AnimationActive = true;
            //Logger.WriteDebug("RoundResults: Animation Started");
        }

        private void LuaPetRoundResultsComplete(object sender, LuaEventArgs args)
        {
            // we need a timer here, otherwise: a) too fast, b) at dead enemy we may be lua-pressing buttons that we can't press
            RoundStartTimer.Reset();
            RoundStartTimer.Start();
            AnimationActive = false;   // missing this event will get us stuck. TODO: add timer
            //Logger.WriteDebug("RoundResults: Animation Stopped, timer started");
        }
        
        private void LuaPetsHealed(object sender, LuaEventArgs args)
        {
            Log("Healed");
            _petJournal.PopulatePetJournal();
            MyPets.updateMyPets();
        }

        private void LuaPetCaptured(object sender, LuaEventArgs args)
        {
            Log("Captured");
        }

        private int CalculateZoneLevelNeeded()
        {
            if( PluginSettings.Instance.Mode == eMode.Capture )
            {
                return CurrentProfileLevel;
            }
            else
            {
                int lowest = _petJournal.LowestLevel();  // expensive
                int need = ValidLevel( lowest + PluginSettings.ModeInfo.ZoneDiff );
                Logger.WriteDebug(string.Format("CalcZone: lowest={0}, diff={1}, need profile level {2}", lowest, PluginSettings.ModeInfo.ZoneDiff, need));
                return need;
            }
        }

        private void ChangeProfileIfNeeded()
        {
            if (!PluginSettings.Instance.AutoZoneChange)
            {
                return;
            }
            int ZoneLevelNeeded = CalculateZoneLevelNeeded();
            if (ZoneLevelNeeded == CurrentProfileLevel)
            {
                Logger.WriteDebug("Loaded profile level is " + CurrentProfileLevel + ", no need to change");
            }
            else
            {
                Logger.Write("Current Profile level is " + CurrentProfileLevel + ", loading profile for level " + ZoneLevelNeeded);
                Load_ZoneProfile_ForLevel(ZoneLevelNeeded);
            }
        }

        private void LuaEndOfBattle(object sender, LuaEventArgs args)
        {
            //Fires twice. - no more (event corrected)
            //Log("EndOfBattle: still in battle = " + _petLua.IsInBattle() );
            if (_petLua.IsInBattle())
                return;   // can't load pets while still in the battle
            Logger.WriteDebug("EndOfBattle, out of the battle");
            Moved = false;
            battleCount++;
            MyPets.updateMyPets();
            _petJournal.PopulatePetJournal();
            LoadSuccess = LoadPetsForLevel();
            ChangeProfileIfNeeded();
            return;
        }


        public static string GetContinentAbbrev()
        {
            string cont = PetReport.GetContinentName();
            if (cont == "Draenor" || cont.Contains("Garrison")) return "DRA";
            else if (cont == "Kalimdor") return "KALI";
            else if (cont == "Eastern Kingdoms") return "EK";
            else if (cont == "Outland") return "OUT";
            else if (cont == "Northrend") return "NOR";
            else if (cont == "Pandaria") return "PAN";
            else
            {
                Logger.Alert("Continent " + cont + " is UNKNOWN");
                return "UNKNOWN";
            }
        }

        public static string GetContinentAbbrev( string file)
        {
            // "01-02 EK ... "
            char[] delim = new char[] { ' ', '-' };
            string[] parts = file.Split(delim);
            if (parts.Length >= 3)
                return parts[2];
            else
                return "";
        }

        public static void GetRange( string file, out int min, out int max)
        {
            min = 0; max = 0;
            char[] delim = new char[] { ' ', '-' };
            string[] parts = file.Split(delim);
            if( parts.Length > 2)
            {
                min = parts[0].ToInt32();
                max = parts[1].ToInt32();
            }
            //for( int i = 0; i<parts.Length; i++)
            //{
            //    Logger.WriteDebug("part " + i + ": " + parts[i]);
            //}
        }

        public static int GetOverlap(int min1, int max1, int min2, int max2)
        {
            int count = 0;
            if (max1 < min1) return 0;  // sanity check
            for (int i = min1; i <= max1; i++)
            { // this is an absolutely crazy way to compute an overlap of long segments. But we have short segments only 
                if (min2 <= i && i <= max2)
                    count++;
            }
            //Logger.WriteDebug(string.Format("Overlap: [{0}-{1}] and [{2}-{3}] eq {4}", min1, max1, min2, max2, count));
            return count;
        }

        public static int GetOverlap( int min, int max, string file)
        {
            int min2, max2;
            GetRange(file, out min2, out max2);
            return GetOverlap(min, max, min2, max2);
        }

        public static int GetNumHs(string file)
        {
            // 17-18 EK (GrAir) Deadwind Pass (6 Hs,34 Pets) by Prostak.xml
            string[] delim = new string[] { "(", " " };
            int hs = 0;
            string[] parts = file.Split( delim, StringSplitOptions.None );

            //for (int i = 0; i < parts.Length; i++ )
            //{
            //    Logger.WriteDebug("NumHs part" + i + ": " + parts[i]);
            //}

                for (int i = 0; i < parts.Length; i++)
                {
                    if (i > 0 && parts[i].StartsWith("Hs,"))
                        hs = parts[i - 1].ToInt32();
                }
            return hs;
        }

        struct Hotspot
        {
            public float X, Y, Z;
            public Hotspot(Styx.WoWPoint p)
            {
                X = p.X; Y = p.Y; Z = p.Z;
            }
            public override string ToString()
            {
                return string.Format("<X={0}, Y={1}, Z={2}>", X, Y, Z);
            }
        }

        static float SqrDist2x(Hotspot a, Hotspot b)
        {
            return (a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y);
        }

        static bool GetHotSpot(string line, out Hotspot hotspot)
        {
            hotspot = new Hotspot() { X = 0, Y = 0, Z = 0 };
            if (!line.Contains("<Hotspot ")) { return false; }

            string[] sep = new string[] { "X=\"", "Y=\"", "Z=\"", "\"" };
            string[] xBeg = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            if (xBeg.Length < 6) { return false; }
            bool xOk = float.TryParse(xBeg[1], out hotspot.X);
            if (!xOk) { return false; }

            bool yOk = float.TryParse(xBeg[3], out hotspot.Y);
            if (!yOk) { return false; }

            bool zOk = float.TryParse(xBeg[5], out hotspot.Z);
            if (!zOk) { return false; }

            return true;
        }

        public static float GetDistanceToProfile( string file)
        {
            float distance = float.MaxValue;

            string[] lines;
            try
            {
                lines = System.IO.File.ReadAllLines(file);
            }
            catch( Exception e)
            {
                Logger.Alert(e.ToString());
                return float.MaxValue;
            }

            Hotspot me = new Hotspot( StyxWoW.Me.Location );
            
            foreach( string line in lines )
            {
                Hotspot hs;
                if( GetHotSpot( line, out hs) )
                {
                    float hsDist = SqrDist2x(hs, me);
                    if (hsDist < distance)
                    {
                        //Logger.WriteDebug(string.Format("LineDist: {0:f} " + line + " " + hs.ToString(), hsDist));
                        distance = hsDist;
                    }
                }
            }

            return distance;
        }

        public static string FindProfileOnThisContinent(int min, int max)
        {
            string[] files = System.IO.Directory.GetFiles(GetZonesDir());
            //int bestOverlap = 0;
            float minDistance = float.MaxValue;
            string bestProfile = PluginSettings.NotSet;
            string continentAbbrev = GetContinentAbbrev();

            // EK and CALI do not have all zones, bu we want to have something for these two anyway: starters
            if (min == 18) min -= 1;
            if (max == 21) max += 2;

            Logger.WriteDebug("Me: " + StyxWoW.Me.Location.ToString());

            foreach (string fullFile in files)
            {
                string file = System.IO.Path.GetFileName(fullFile);
                if (continentAbbrev == GetContinentAbbrev(file))
                {
                    //Logger.WriteDebug("Abbrev: " + continentAbbrev + " == " + GetContinentAbbrev(file) + " in " + file);

                    int overlap = GetOverlap(min, max, file);
                    int hs = GetNumHs(file);
                    if (hs != 0 && hs > 15) // Ignore small zones TODO: const, 0 means that Hs are not defined in the title
                    {
                        if (overlap > 0)
                        {
                            float distance = GetDistanceToProfile(fullFile);
                            //Logger.WriteDebug(string.Format("Distance: {0:f} to " + file, distance));
                            if( distance < minDistance )
                            {
                                minDistance = distance;
                                bestProfile = fullFile;
                            }
                        }
                    }
                }
                else
                {
                    //Logger.WriteDebug("Abbrev: " + continentAbbrev + " != " + GetContinentAbbrev(file) + " in " + file);
                }
            }

            return bestProfile;
        }

        public static string GetZonesDir()
        {
            return Application.StartupPath + "\\Bots\\Prosto_Pets\\PetZones\\";
        }

        public static string LoadProfile(int min, int max, string filename)
        {
            if( string.IsNullOrEmpty(filename) || filename == PluginSettings.NotSet)
            {
                Logger.WriteDebug("Profile not set, finding one for the continent");
                filename = FindProfileOnThisContinent(min, max);
            }
            else if (GetContinentAbbrev() != GetContinentAbbrev(filename))
            {
                Logger.WriteDebug("Profile not set, finding one for the continent");
                filename = FindProfileOnThisContinent(min, max);
            }

            if (filename == PluginSettings.NotSet)
            {
                Logger.Alert(string.Format("Failed to find a profile with range [{0}-{1}] for the continent {3}", min, max, PetReport.GetContinentName()));
                return filename;
            }
            LoadProfile(filename);
            return filename;
        }

        public static void LoadProfile(string filename)
        {
            Logger.WriteDebug("LoadProfile: '" + filename + "'");
            bool changed = false;
            if (!filename.Contains(":"))
            {
                // relative filename
                filename = GetZonesDir() + filename;
            }
            if (Styx.CommonBot.Profiles.ProfileManager.XmlLocation != filename)
            {
                Styx.CommonBot.Profiles.ProfileManager.LoadNew(filename, true);
                changed = true;
            }
            Logger.WriteDebug("Profile " + (changed ? "changed to " : "remains ") + GetCurrentProfileName());
        }


        private void Load_ZoneProfile_ForLevel( int levelNeeded )
        {
            if( !PluginSettings.Instance.AutoZoneChange )
            {
                return;
            }
            // TODO: do we reaaly need to change the settings? No: they are set by human. We will ignore them if unavoidable, but not change
            if (levelNeeded < 4) LoadProfile(1,3,PluginSettings.Instance.Zone_1to3);
            else if (levelNeeded <= 5)  LoadProfile(4,5,PluginSettings.Instance.Zone_4to5);
            else if (levelNeeded <= 7)  LoadProfile(6,7,PluginSettings.Instance.Zone_6to7);
            else if (levelNeeded <= 9)  LoadProfile(8,9,PluginSettings.Instance.Zone_8to9);
            else if (levelNeeded <= 11) LoadProfile(10,11,PluginSettings.Instance.Zone_10to11);
            else if (levelNeeded <= 13) LoadProfile(12,13,PluginSettings.Instance.Zone_12to13);
            else if (levelNeeded <= 15) LoadProfile(14,15,PluginSettings.Instance.Zone_14to15);
            else if (levelNeeded <= 17) LoadProfile(16,17,PluginSettings.Instance.Zone_16to17);
            else if (levelNeeded <= 19) LoadProfile(18,19,PluginSettings.Instance.Zone_18to19);
            else if (levelNeeded <= 21) LoadProfile(20,21,PluginSettings.Instance.Zone_20to21);
            else LoadProfile(22,25,PluginSettings.Instance.Zone_22to25);

            CurrentProfileLevel = levelNeeded;
            Logger.WriteDebug("Current Profile Level is now " + CurrentProfileLevel);
        }

        private void LuaBattlePetChanged(object sender, LuaEventArgs args)
        {
            //Not sure if this and below are needed
            MyPets.updateMyPets();
            MyPets.updateEnemyActivePet();
        }
        private void LuaPetJournalListUpdate(object sender, LuaEventArgs args)
        {
            //Log("PetJournalListUpdate");
            MyPets.updateMyPets();
            MyPets.updateEnemyActivePet();
            //_petJournal.PopulatePetJournal(); -- too long, too often
        }
        #endregion

#region Pet Selection
        public bool FullySelected( PetPlace[] selection)
        {
            for( int i=0; i<3; i++)
            {
                if (selection[i].opened && !selection[i].selected) return false;
            }
            return true;
        }

        public bool LoadPetsForLevel()
        {
            int levelToLoad;
            if (!_petJournal.IsLoaded) { _petJournal.PopulatePetJournal(); }
            _petJournal.WritePetsByLevel();  // debug
            if (PluginSettings.Instance.Mode == eMode.Capture)
            {
                levelToLoad = _zoneTable.ZoneLevel(PetReport.PlayerZone());  // zone diff will be subtracted in SelectPets
                Logger.WriteDebug("Looking for pets based on zone level: " + levelToLoad);
            }
            else
            {
                levelToLoad = _petJournal.LowestLevel();
                Logger.WriteDebug("Looking for pets based on lowest level among selected: " + levelToLoad);
            }
            PetPlace[] Selectedpets = _petChooser.SelectPetsForLevel( levelToLoad );
            if( !FullySelected(Selectedpets) )
            { 
                Logger.Alert("Failed to fully select pets. Consider making a less restrictive criteria.");
                return false;
            } 
            _petLoader.Load(Selectedpets);
            Selected = true;
            MyPets.updateMyPets();
            return true;
        }

#endregion

    }
}
