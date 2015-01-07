using System;
using System.ComponentModel;
using System.Text;
using Styx;
using Styx.Helpers;

namespace Prosto_Pets
{
    public enum eMode
    {
        Relative,
        Ringer,
        Ringerx2,
        Capture,
        Custom
    }

    [DefaultPropertyAttribute("Mode")]
    public class PluginSettings : Settings, IPluginProperties, IPluginSettings
    {
        public static PluginSettings Instance { get; private set; }

        static PluginSettings()  // static constructor
        {
            Instance = new PluginSettings();
        }

        const string NAMESPACE = "Prosto_Pets";

        public PluginSettings()
            : base(Styx.Helpers.Settings.SettingsDirectory + "\\" + NAMESPACE + "_" + (StyxWoW.Me != null ? StyxWoW.Me.Name : "") + ".xml")
        {
            Logger.Write("Loading Settings file:" + Styx.Helpers.Settings.SettingsDirectory + "\\"+NAMESPACE+"_*****.xml");

            Instance = this;
            Load();

            ConvertSettingsToProperties();
        }

        #region Convert settings to properties and back again

        public void ConvertSettingsToProperties()
        {
            // Main - General
            LockFirstSlot   = ToBoolValue(LockFirstSlotSetting, false);
            LockSecondSlot  = ToBoolValue(LockSecondSlotSetting, false);
            LockThirdSlot   = ToBoolValue(LockThirdSlotSetting, false);
            MinLevel = ToIntValue(MinLevelSetting, 1);
            MinPetHealth = ToIntValue(MinPetHealthSetting, 90);
            MaxLevel = ToIntValue(MaxLevelSetting, 25);
            UseWildPets = ToBoolValue(UseWildPetsSetting, true);
            OnlyBluePets = ToBoolValue(OnlyBluePetsSetting, false);
            UseFavouritePetsOnly = ToBoolValue(UseFavouritePetsOnlySetting, false);
            UseFavouriteRingers = ToBoolValue(UseFavouriteRingersSetting, false);
            if (UseFavouritePetsOnly) { UseFavouriteRingers = true; }
            MinRingerPetHealth = ToIntValue(MinRingerPetHealthSetting, 90);
            CaptureRares = ToBoolValue(CaptureRaresSetting, true);
            CaptureNotOwnRarity = ToIntValue(CaptureNotOwnRaritySetting, 3);
            MovementByPlayer = ToBoolValue(MovementByPlayerSetting, false);
            RecordPets = ToBoolValue(RecordPetsSetting, false);
            DoNotEngage = ToBoolValue(DoNotEngageSetting, false);

            Pet2_Differ_Relative = ToIntValue( Pet2_Differ_Relative_Setting, 2);
            Pet3_Differ_Relative = ToIntValue( Pet3_Differ_Relative_Setting, 2);
            Zone_Diff_Relative = ToIntValue( Zone_Diff_Relative_Setting, 2);
            Swap1_Health_Relative = ToIntValue(Swap1_Health_Relative_Setting, 30);
            Swap2_Health_Relative = ToIntValue(Swap2_Health_Relative_Setting, 30);
            Swap3_Health_Relative = ToIntValue(Swap3_Health_Relative_Setting, 30);

            Pet2_Differ_Ringer = ToIntValue(Pet2_Differ_Ringer_Setting, 2);
            Pet3_Differ_Ringer = ToIntValue(Pet3_Differ_Ringer_Setting, 25);
            Zone_Diff_Ringer = ToIntValue(Zone_Diff_Ringer_Setting, 10);
            Swap1_Health_Ringer = ToIntValue(Swap1_Health_Ringer_Setting, 60);
            Swap2_Health_Ringer = ToIntValue(Swap2_Health_Ringer_Setting, 40);
            Swap3_Health_Ringer = ToIntValue(Swap3_Health_Ringer_Setting, 0);

            Pet2_Differ_Ringerx2 = ToIntValue(Pet2_Differ_Ringerx2_Setting, 25);
            Pet3_Differ_Ringerx2 = ToIntValue(Pet3_Differ_Ringerx2_Setting, 25);
            Zone_Diff_Ringerx2 = ToIntValue(Zone_Diff_Ringerx2_Setting, 15);
            Swap1_Health_Ringerx2 = ToIntValue(Swap1_Health_Ringerx2_Setting, 100);
            Swap2_Health_Ringerx2 = ToIntValue(Swap2_Health_Ringerx2_Setting, 0);
            Swap3_Health_Ringerx2 = ToIntValue(Swap3_Health_Ringerx2_Setting, 0);

            Pet2_Differ_Capture = ToIntValue(Pet2_Differ_Capture_Setting, 2);
            Pet3_Differ_Capture = ToIntValue(Pet3_Differ_Capture_Setting, 2);
            Zone_Diff_Capture = ToIntValue(Zone_Diff_Capture_Setting, 0);
            Swap1_Health_Capture = ToIntValue(Swap1_Health_Capture_Setting, 30);
            Swap2_Health_Capture = ToIntValue(Swap2_Health_Capture_Setting, 30);
            Swap3_Health_Capture = ToIntValue(Swap3_Health_Capture_Setting, 30);

            Pet2_Differ_Custom = ToIntValue(Pet2_Differ_Custom_Setting, 2);
            Pet3_Differ_Custom = ToIntValue(Pet3_Differ_Custom_Setting, 2);
            Zone_Diff_Custom = ToIntValue(Zone_Diff_Custom_Setting, 2);
            Swap1_Health_Custom = ToIntValue(Swap1_Health_Custom_Setting, 30);
            Swap2_Health_Custom = ToIntValue(Swap2_Health_Custom_Setting, 30);
            Swap3_Health_Custom = ToIntValue(Swap3_Health_Custom_Setting, 30);

            AutoZoneChange = ToBoolValue(AutoZoneChangeSetting, true);

            // uses Mode settings, should go after them
            foreach (eMode mode in System.Enum.GetValues(typeof(eMode)))
            {
                if (mode.ToString() == ModeSetting) { SetMode(mode); }
            }
        }

        public void ConvertsPropertiesToSettings()
        {
            // Main - General
            ModeSetting = Mode.ToString();
            LockFirstSlotSetting    = LockFirstSlot.ToString();
            LockSecondSlotSetting   = LockSecondSlot.ToString();
            LockThirdSlotSetting    = LockThirdSlot.ToString();
            MinLevelSetting = MinLevel.ToString();
            MinPetHealthSetting = MinPetHealth.ToString();
            MaxLevelSetting = MaxLevel.ToString();
            UseWildPetsSetting = UseWildPets.ToString();
            OnlyBluePetsSetting = OnlyBluePets.ToString();
            UseFavouritePetsOnlySetting = UseFavouritePetsOnly.ToString();
            UseFavouriteRingersSetting = UseFavouriteRingers.ToString();
            if (UseFavouritePetsOnly) { UseFavouriteRingersSetting = UseFavouritePetsOnly.ToString(); }
            MinRingerPetHealthSetting = MinRingerPetHealth.ToString();
            CaptureRaresSetting = CaptureRares.ToString();
            CaptureNotOwnRaritySetting = CaptureNotOwnRarity.ToString();
            MovementByPlayerSetting = MovementByPlayer.ToString();
            RecordPetsSetting = RecordPets.ToString();
            DoNotEngageSetting = DoNotEngage.ToString();

            Pet2_Differ_Relative_Setting = Pet2_Differ_Relative.ToString();
            Pet3_Differ_Relative_Setting = Pet3_Differ_Relative.ToString();
            Zone_Diff_Relative_Setting = Zone_Diff_Relative.ToString();
            Swap1_Health_Relative_Setting = Swap1_Health_Relative.ToString();
            Swap2_Health_Relative_Setting = Swap2_Health_Relative.ToString();
            Swap3_Health_Relative_Setting = Swap3_Health_Relative.ToString();

            Pet2_Differ_Ringer_Setting = Pet2_Differ_Ringer.ToString();
            Pet3_Differ_Ringer_Setting = Pet3_Differ_Ringer.ToString();
            Zone_Diff_Ringer_Setting = Zone_Diff_Ringer.ToString();
            Swap1_Health_Ringer_Setting = Swap1_Health_Ringer.ToString();
            Swap2_Health_Ringer_Setting = Swap2_Health_Ringer.ToString();
            Swap3_Health_Ringer_Setting = Swap3_Health_Ringer.ToString();

            Pet2_Differ_Ringerx2_Setting = Pet2_Differ_Ringerx2.ToString();
            Pet3_Differ_Ringerx2_Setting = Pet3_Differ_Ringerx2.ToString();
            Zone_Diff_Ringerx2_Setting = Zone_Diff_Ringerx2.ToString();
            Swap1_Health_Ringerx2_Setting = Swap1_Health_Ringerx2.ToString();
            Swap2_Health_Ringerx2_Setting = Swap2_Health_Ringerx2.ToString();
            Swap3_Health_Ringerx2_Setting = Swap3_Health_Ringerx2.ToString();

            Pet2_Differ_Capture_Setting = Pet2_Differ_Capture.ToString();
            Pet3_Differ_Capture_Setting = Pet3_Differ_Capture.ToString();
            Zone_Diff_Capture_Setting = Zone_Diff_Capture.ToString();
            Swap1_Health_Capture_Setting = Swap1_Health_Capture.ToString();
            Swap2_Health_Capture_Setting = Swap2_Health_Capture.ToString();
            Swap3_Health_Capture_Setting = Swap3_Health_Capture.ToString();

            Pet2_Differ_Custom_Setting = Pet2_Differ_Custom.ToString();
            Pet3_Differ_Custom_Setting = Pet3_Differ_Custom.ToString();
            Zone_Diff_Custom_Setting = Zone_Diff_Custom.ToString();
            Swap1_Health_Custom_Setting = Swap1_Health_Custom.ToString();
            Swap2_Health_Custom_Setting = Swap2_Health_Custom.ToString();
            Swap3_Health_Custom_Setting = Swap3_Health_Custom.ToString();

            AutoZoneChangeSetting = AutoZoneChange.ToString();

            SetSwapByCurrentMode();  // TODO: why it is here, lol?
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Settings:");
            // General - Main
            sb.Append(" Mode=" + Mode.ToString());
            sb.Append(", Lock1st=" + LockFirstSlot.ToString());
            sb.Append(", Lock2nd=" + LockSecondSlot.ToString());
            sb.Append(", Lock3rd=" + LockThirdSlot.ToString());
            sb.Append(string.Format(", pet Levels={0}-{1} ", MinLevel, MaxLevel));
            if (!UseWildPets) { sb.Append(", UseWildPets=" + UseWildPets.ToString()); }
            if (OnlyBluePets) { sb.Append(", OnlyBluePets=" + OnlyBluePets.ToString()); }
            sb.Append(", Min pet Health=" + MinPetHealth.ToString());
            if (UseFavouritePetsOnly) { sb.Append(", Use Favourite Pets Only=" + UseFavouritePetsOnly.ToString()); }
            else if (UseFavouriteRingers) { sb.Append(", Use Favourite Ringer Pets Only=" + UseFavouriteRingers.ToString()); }
            sb.Append(", CaptureRares=" + CaptureRares.ToString());
            sb.Append(", CaptureNotOwn=" + CaptureNotOwnRarity.ToString());
            sb.Append(", MoveByMan=" + MovementByPlayer.ToString());
            sb.Append(", Record=" + RecordPets.ToString());
            sb.Append(", NotEngage=" + DoNotEngage.ToString());
            sb.Append(", AutoZone=" + AutoZoneChange.ToString());
            return sb.ToString();
            // Per mode setting not logged here, but rather when mode is selected
        }

        private int ToIntValue(string s, int defaultValue)
        {
            if (string.IsNullOrEmpty(s)) { return defaultValue; }
            int value = 0;
            if (!int.TryParse(s, out value)) { return defaultValue; }
            return value;
        }

        private bool ToBoolValue(string s, bool defaultValue)
        {
            if (string.IsNullOrEmpty(s)) { return defaultValue; }
            bool value = false;
            if (!bool.TryParse(s, out value)) { return defaultValue; }
            return value;
        }

        #endregion

        #region Validation

        private static void ValidateIntRange(int value, int min, int max)
        {
            if (value < min || value > max) throw new ArgumentException(string.Format("Value must be between {0} and {1}", min, max));
        }

        #endregion

        #region Property - Mode

        [Setting, Styx.Helpers.DefaultValue("Relative")]
        [Browsable(false)]
        public string ModeSetting { get; set; }

        [CategoryAttribute("Mode"),
        System.ComponentModel.DefaultValueAttribute(eMode.Relative)]
        [DescriptionAttribute("Relative - will choose 3 pets 2 with slighty lower than zone level + 1 slightly higher.\r\nRinger - will choose 2 lowest level pets with 1 of the highest level. e.g. 1,1,25.\r\nRingerX2 - will choose 1 lowest level pet with 2 of the highest level. e.g. 1,25,25.\r\nCapture - will choose 3 pets from 1 level above the zone pet level.")]
        public eMode Mode { get;set; }

        #endregion

        #region Property -LockFirstSlot

        [Setting, Styx.Helpers.DefaultValue("-1")]
        [Browsable(false)]
        public string LockFirstSlotSetting { get; set; }

        [CategoryAttribute("Pets to Choose")]
        [DescriptionAttribute("Lock the 1st Slot?")]
        [DisplayName("Lock the First Slot")]
        public bool LockFirstSlot { get; set; }

        #endregion
        #region Property -Lock 2nd Slot

        [Setting, Styx.Helpers.DefaultValue("-1")]
        [Browsable(false)]
        public string LockSecondSlotSetting { get; set; }

        [CategoryAttribute("Pets to Choose")]
        [DescriptionAttribute("Lock the 2nd Slot?")]
        [DisplayName("Lock the Second Slot")]
        public bool LockSecondSlot { get; set; }

        #endregion
        #region Property -Lock 3rd Slot

        [Setting, Styx.Helpers.DefaultValue("-1")]
        [Browsable(false)]
        public string LockThirdSlotSetting { get; set; }

        [CategoryAttribute("Pets to Choose")]
        [DescriptionAttribute("Lock the 3rd Slot?")]
        [DisplayName("Lock the Third Slot")]
        public bool LockThirdSlot { get; set; }

        #endregion

        #region Property -MinLevel

        [Setting, Styx.Helpers.DefaultValue("1")]
        [Browsable(false)]
        public string MinLevelSetting { get; set; }

        int _minLevelOfPetToChoose=1;
        [CategoryAttribute("Pets to Choose")]
        [DescriptionAttribute("The minimum pet level which will be chosen")]
        [DisplayName("Minimum Level")]
        public int MinLevel
        {
            get { return _minLevelOfPetToChoose; }
            set { ValidateIntRange(value, 1, 25); _minLevelOfPetToChoose = value; }
        }

        #endregion

        #region Property -MinPetHealth

        [Setting, Styx.Helpers.DefaultValue("90")]
        [Browsable(false)]
        public string MinPetHealthSetting { get; set; }

        int _minPetHealth = 90;
        [CategoryAttribute("Pets to Choose")]
        [DescriptionAttribute("The minimum pet health filename pet can have to be chosen")]
        [DisplayName("Minimum Health %")]
        public int MinPetHealth
        {
            get { return _minPetHealth; }
            set { ValidateIntRange(value,1,100); _minPetHealth = value; }
        }

        #endregion

        #region Property -MaxLevel

        [Setting, Styx.Helpers.DefaultValue("25")]
        [Browsable(false)]
        public string MaxLevelSetting { get; set; }

        int _maxLevelOfPetToChoose=25;
        [CategoryAttribute("Pets to Choose")]
        [DescriptionAttribute("The maximum pet level which will be chosen")]
        [DisplayName("Maximum Level")]
        public int MaxLevel
        {
            get { return _maxLevelOfPetToChoose; }
            set 
            {
                ValidateIntRange(value,1,25);
                _maxLevelOfPetToChoose = value; 
            }
        }

        #endregion

        #region Property -UseWildPets

        [Setting, Styx.Helpers.DefaultValue("-1")]
        [Browsable(false)]
        public string UseWildPetsSetting { get; set; }

        [CategoryAttribute("Pets to Choose")]
        [DescriptionAttribute("Choose wild caught pets?")]
        [DisplayName("Use Wild Pets")]
        public bool UseWildPets { get;set; }

        #endregion

        #region Property -OnlyBluePets

        [Setting, Styx.Helpers.DefaultValue("1")]
        [Browsable(false)]
        public string OnlyBluePetsSetting { get; set; }

        [CategoryAttribute("Pets to Choose")]
        [DescriptionAttribute("Choose only blue pets?")]
        [DisplayName("Only Blue Pets")]
        public bool OnlyBluePets { get; set; }

        #endregion

        #region Property -UseFavourites

        [Setting, Styx.Helpers.DefaultValue("-1")]
        [Browsable(false)]
        public string UseFavouritePetsOnlySetting { get; set; }

        [CategoryAttribute("Pets to Choose")]
        [DescriptionAttribute("Choose only favourite pets, if set to true this will set 'Only favourite ringer pets' to true.")]
        [DisplayName("Only favourite pets")]
        public bool UseFavouritePetsOnly { get; set; }

        #endregion#

        #region Property -UseFavouriteRingers

        [Setting, Styx.Helpers.DefaultValue("-1")]
        [Browsable(false)]
        public string UseFavouriteRingersSetting { get; set; }

        [CategoryAttribute("Ringer")]
        [DescriptionAttribute("Choose only favourite pets as ringers.")]
        [DisplayName("Only favourite ringer pets")]
        public bool UseFavouriteRingers { get; set; }

        #endregion

        #region Property -MinRingerPetHealth

        [Setting, Styx.Helpers.DefaultValue("90")]
        [Browsable(false)]
        public string MinRingerPetHealthSetting { get; set; }

        int _minRingerPetHealth = 90;
        [CategoryAttribute("Ringer")]
        [DescriptionAttribute("The minimum pet health filename ringer pet can have to be chosen")]
        [DisplayName("Ringer Minimum Health %")]
        public int MinRingerPetHealth
        {
            get { return _minRingerPetHealth; }
            set { ValidateIntRange(value, 1, 100); _minRingerPetHealth = value; }
        }

        #endregion

        #region CaptureNotOwnRarity

        [Setting, Styx.Helpers.DefaultValue("2")]
        [Browsable(false)]
        public string CaptureNotOwnRaritySetting { get; set; }

        int _notOwnRarity = 2;
        [CategoryAttribute("What to Capture")]
        [DescriptionAttribute("0: Anything, 1: Ordinary, 2: Common, 3: Uncommon, 4: Rare")]
        [DisplayName("Minimum Rarity of Not owned to capture")]
        public int CaptureNotOwnRarity
        {
            get { return _notOwnRarity; }
            set { ValidateIntRange(value, 0, 6); _notOwnRarity = value; }
        }
        #endregion

        #region CaptureRares

        [Setting, Styx.Helpers.DefaultValue("-1")]
        [Browsable(false)]
        public string CaptureRaresSetting { get; set; }

        [CategoryAttribute("What to Capture")]
        [DescriptionAttribute("Capture Rares instead of killing")]
        [DisplayName("Capture Rares")]
        public bool CaptureRares { get; set; }

        #endregion

        #region MovementByPlayer

        [Setting, Styx.Helpers.DefaultValue("-1")]
        [Browsable(false)]
        public string MovementByPlayerSetting { get; set; }

        [CategoryAttribute("- Zone Movement by Player's hand")]
        [DescriptionAttribute("Manual movement until filename pet is found")]
        [DisplayName("Manual Zone movement")]
        public bool MovementByPlayer { get; set; }

        #endregion

        // Newly addded controls, not present in the std form

        [Setting, Styx.Helpers.DefaultValue("-1")]
        [Browsable(false)]
        public string RecordPetsSetting  { get; set; }
        public bool RecordPets { get; set; }

        [Setting, Styx.Helpers.DefaultValue("-1")]
        [Browsable(false)]
        public string DoNotEngageSetting  { get; set; }
        public bool DoNotEngage { get; set; }               

        #region Per Mode Settings

        #region Relative Mode
        public int Pet2_Differ_Relative { get; set; }
        [Setting, Styx.Helpers.DefaultValue("2")]
        [CategoryAttribute("Settings for Relative Mode")]
        [Browsable(false)]
        public string Pet2_Differ_Relative_Setting { get; set; }
        public int Pet3_Differ_Relative { get; set; }
        [Setting, Styx.Helpers.DefaultValue("4")]
        [Browsable(false)]
        public string Pet3_Differ_Relative_Setting { get; set; }

        public int Zone_Diff_Relative { get; set; }
        [Setting, Styx.Helpers.DefaultValue("2")]
        [Browsable(false)]
        public string Zone_Diff_Relative_Setting { get; set; }

        public int Swap1_Health_Relative { get; set; }
        [Setting, Styx.Helpers.DefaultValue("30")]
        [Browsable(false)]
        public string Swap1_Health_Relative_Setting { get; set; }
        public int Swap2_Health_Relative { get; set; }
        [Setting, Styx.Helpers.DefaultValue("30")]
        [Browsable(false)]
        public string Swap2_Health_Relative_Setting { get; set; }
        public int Swap3_Health_Relative { get; set; }
        [Setting, Styx.Helpers.DefaultValue("30")]
        [Browsable(false)]
        public string Swap3_Health_Relative_Setting { get; set; }
        #endregion

        #region Ringer Mode
        public int Pet2_Differ_Ringer { get; set; }
        [Setting, Styx.Helpers.DefaultValue("2")]
        [CategoryAttribute("Settings for Ringer Mode")]
        [Browsable(false)]
        public string Pet2_Differ_Ringer_Setting { get; set; }
        public int Pet3_Differ_Ringer { get; set; }
        [Setting, Styx.Helpers.DefaultValue("25")]
        [Browsable(false)]
        public string Pet3_Differ_Ringer_Setting { get; set; }

        public int Zone_Diff_Ringer { get; set; }
        [Setting, Styx.Helpers.DefaultValue("10")]
        [Browsable(false)]
        public string Zone_Diff_Ringer_Setting { get; set; }

        public int Swap1_Health_Ringer { get; set; }
        [Setting, Styx.Helpers.DefaultValue("80")]
        [Browsable(false)]
        public string Swap1_Health_Ringer_Setting { get; set; }
        public int Swap2_Health_Ringer { get; set; }
        [Setting, Styx.Helpers.DefaultValue("40")]
        [Browsable(false)]
        public string Swap2_Health_Ringer_Setting { get; set; }
        public int Swap3_Health_Ringer { get; set; }
        [Setting, Styx.Helpers.DefaultValue("0")]
        [Browsable(false)]
        public string Swap3_Health_Ringer_Setting { get; set; }
        #endregion


        #region Ringerx2 Mode
        public int Pet2_Differ_Ringerx2 { get; set; }
        [Setting, Styx.Helpers.DefaultValue("25")]
        [CategoryAttribute("Settings for Ringerx2 Mode")]
        [Browsable(false)]
        public string Pet2_Differ_Ringerx2_Setting { get; set; }
        public int Pet3_Differ_Ringerx2 { get; set; }
        [Setting, Styx.Helpers.DefaultValue("25")]
        [Browsable(false)]
        public string Pet3_Differ_Ringerx2_Setting { get; set; }

        public int Zone_Diff_Ringerx2 { get; set; }
        [Setting, Styx.Helpers.DefaultValue("20")]
        [Browsable(false)]
        public string Zone_Diff_Ringerx2_Setting { get; set; }

        public int Swap1_Health_Ringerx2 { get; set; }
        [Setting, Styx.Helpers.DefaultValue("100")]
        [Browsable(false)]
        public string Swap1_Health_Ringerx2_Setting { get; set; }
        public int Swap2_Health_Ringerx2 { get; set; }
        [Setting, Styx.Helpers.DefaultValue("0")]
        [Browsable(false)]
        public string Swap2_Health_Ringerx2_Setting { get; set; }
        public int Swap3_Health_Ringerx2 { get; set; }
        [Setting, Styx.Helpers.DefaultValue("0")]
        [Browsable(false)]
        public string Swap3_Health_Ringerx2_Setting { get; set; }
        #endregion


        #region Capture Mode
        public int Pet2_Differ_Capture { get; set; }
        [Setting, Styx.Helpers.DefaultValue("2")]
        [CategoryAttribute("Settings for Capture Mode")]
        [Browsable(false)]
        public string Pet2_Differ_Capture_Setting { get; set; }
        public int Pet3_Differ_Capture { get; set; }
        [Setting, Styx.Helpers.DefaultValue("2")]
        [Browsable(false)]
        public string Pet3_Differ_Capture_Setting { get; set; }

        public int Zone_Diff_Capture { get; set; }
        [Setting, Styx.Helpers.DefaultValue("0")]
        [Browsable(false)]
        public string Zone_Diff_Capture_Setting { get; set; }

        public int Swap1_Health_Capture { get; set; }
        [Setting, Styx.Helpers.DefaultValue("30")]
        [Browsable(false)]
        public string Swap1_Health_Capture_Setting { get; set; }
        public int Swap2_Health_Capture { get; set; }
        [Setting, Styx.Helpers.DefaultValue("30")]
        [Browsable(false)]
        public string Swap2_Health_Capture_Setting { get; set; }
        public int Swap3_Health_Capture { get; set; }
        [Setting, Styx.Helpers.DefaultValue("30")]
        [Browsable(false)]
        public string Swap3_Health_Capture_Setting { get; set; }
        #endregion
        
        
        #region Custom Mode
        public int Pet2_Differ_Custom { get; set; }
        [Setting, Styx.Helpers.DefaultValue("2")]
        [CategoryAttribute("Settings for Custom Mode")]
        [Browsable(false)]
        public string Pet2_Differ_Custom_Setting { get; set; }
        public int Pet3_Differ_Custom { get; set; }
        [Setting, Styx.Helpers.DefaultValue("4")]
        [Browsable(false)]
        public string Pet3_Differ_Custom_Setting { get; set; }

        public int Zone_Diff_Custom { get; set; }
        [Setting, Styx.Helpers.DefaultValue("2")]
        [Browsable(false)]
        public string Zone_Diff_Custom_Setting { get; set; }

        public int Swap1_Health_Custom { get; set; }
        [Setting, Styx.Helpers.DefaultValue("60")]
        [Browsable(false)]
        public string Swap1_Health_Custom_Setting { get; set; }
        public int Swap2_Health_Custom { get; set; }
        [Setting, Styx.Helpers.DefaultValue("40")]
        [Browsable(false)]
        public string Swap2_Health_Custom_Setting { get; set; }
        public int Swap3_Health_Custom { get; set; }
        [Setting, Styx.Helpers.DefaultValue("20")]
        [Browsable(false)]
        public string Swap3_Health_Custom_Setting { get; set; }
        #endregion
        #endregion

        #region Zone Profiles
        public bool AutoZoneChange { get; set; }
        [Setting, Styx.Helpers.DefaultValue("-1")]
        [CategoryAttribute("Zone Profiles")]
        [Browsable(false)]
        public string AutoZoneChangeSetting { get; set; }

        // Need a script that will correct Defaults before build
        [Setting, Styx.Helpers.DefaultValue("01-02 EK Elwynn Forest (87 Hs,321 Pets) by Prostak.xml")]
        [Browsable(false)]
        public string Zone_1to3 { get; set; }

        [Setting, Styx.Helpers.DefaultValue("04-06 EK Redridge Mountains (46 Hs,111 Pets) by Prostak.xml")]
        [Browsable(false)]
        public string Zone_4to5 { get; set; }

        [Setting, Styx.Helpers.DefaultValue("05-07 EK Duskwood (72 Hs,190 Pets) by Prostak.xml")]
        [Browsable(false)]
        public string Zone_6to7 { get; set; }

        [Setting, Styx.Helpers.DefaultValue("07-09 EK Northern Stranglethorn (114 Hs,301 Pets) by Prostak.xml")]
        [Browsable(false)]
        public string Zone_8to9 { get; set; }

        [Setting, Styx.Helpers.DefaultValue("09-10 EK The Cape of Stranglethorn (56 Hs,143 Pets) by Prostak.xml")]
        [Browsable(false)]
        public string Zone_10to11 { get; set; }

        [Setting, Styx.Helpers.DefaultValue("14-15 EK Swamp of Sorrows (44 Hs,121 Pets) by Prostak.xml")]
        [Browsable(false)]
        public string Zone_12to13 { get; set; }

        [Setting, Styx.Helpers.DefaultValue("14-15 EK Swamp of Sorrows (44 Hs,121 Pets) by Prostak.xml")]
        [Browsable(false)]
        public string Zone_14to15 { get; set; }

        [Setting, Styx.Helpers.DefaultValue("16-17 EK Blasted Lands (44 Hs,63 Pets) by Prostak.xml")]
        [Browsable(false)]
        public string Zone_16to17 { get; set; }

        [Setting, Styx.Helpers.DefaultValue("16-17 EK Blasted Lands (44 Hs,63 Pets) by Prostak.xml")]
        [Browsable(false)]
        public string Zone_18to19 { get; set; }

        [Setting, Styx.Helpers.DefaultValue("23-24 CAT Twilight Highlands (68 Hs,198 Pets) by Prostak.xml")]
        [Browsable(false)]
        public string Zone_20to21 { get; set; }

        [Setting, Styx.Helpers.DefaultValue("23-24 CAT Twilight Highlands (68 Hs,198 Pets) by Prostak.xml")]
        [Browsable(false)]
        public string Zone_22to25 { get; set; }

        #endregion

        #region Mode Change

        public struct TModeInfo
        {
            public int ZoneDiff;
            public int Pet2_Diff;
            public int Pet3_Diff;
        }

        public static TModeInfo ModeInfo;

        public static int[] SwapTab;

        public void SetMode( eMode mode )
        {
            Logger.Write("setMode: " + mode.ToString());
            Mode = mode;
            SetSwapByCurrentMode();
        }

        public void SetSwapByCurrentMode()
        {
            if (Mode == eMode.Relative)
            {
                SwapTab = new int[3] { Swap1_Health_Relative, Swap2_Health_Relative, Swap3_Health_Relative};
                ModeInfo = new TModeInfo { Pet2_Diff = Pet2_Differ_Relative, Pet3_Diff = Pet3_Differ_Relative, ZoneDiff = Zone_Diff_Relative };
            }
            else if (Mode == eMode.Ringer )
            {
                SwapTab = new int[3] { Swap1_Health_Ringer, Swap2_Health_Ringer, Swap3_Health_Ringer};
                ModeInfo = new TModeInfo { Pet2_Diff = Pet2_Differ_Ringer, Pet3_Diff = Pet3_Differ_Ringer, ZoneDiff = Zone_Diff_Ringer };
            }
            else if( Mode == eMode.Ringerx2)
            {
                SwapTab = new int[3] { Swap1_Health_Ringerx2, Swap2_Health_Ringerx2, Swap3_Health_Ringerx2 };
                ModeInfo = new TModeInfo { Pet2_Diff = Pet2_Differ_Ringerx2, Pet3_Diff = Pet3_Differ_Ringerx2, ZoneDiff = Zone_Diff_Ringerx2 };
            }
            else if (Mode == eMode.Capture)
            {
                SwapTab = new int[3] { Swap1_Health_Capture, Swap2_Health_Capture, Swap3_Health_Capture };
                ModeInfo = new TModeInfo { Pet2_Diff = Pet2_Differ_Capture, Pet3_Diff = Pet3_Differ_Capture, ZoneDiff = Zone_Diff_Capture };

            }
            else if (Mode == eMode.Custom)
            {
                SwapTab = new int[3] { Swap1_Health_Custom, Swap2_Health_Custom, Swap3_Health_Custom };
                ModeInfo = new TModeInfo { Pet2_Diff = Pet2_Differ_Custom, Pet3_Diff = Pet3_Differ_Custom, ZoneDiff = Zone_Diff_Custom };
            }
            
            Logger.WriteDebug("SwapTab:  [" + SwapTab[0] + ", " + SwapTab[1] + ", " + SwapTab[2] + "]");
            Logger.WriteDebug("ModeInfo: [ 2_diff=" + ModeInfo.Pet2_Diff + ", 3_diff=" + ModeInfo.Pet3_Diff + ", zoneDiff=" + ModeInfo.ZoneDiff + "]");

        }

        #endregion


        #region defaults
        // Unfortunately, I do not see a way to keep this in just this one place: defaults should be set on XML-reading attr too. Third place is filename bool parsing.
        public void SetRelativesToDefault()
        {
            Pet2_Differ_Relative = 2;
            Pet3_Differ_Relative = 4;
            Zone_Diff_Relative = 2;
            Swap1_Health_Relative = 30;
            Swap2_Health_Relative = 30;
            Swap3_Health_Relative = 30;
        }
        public void SetRingersToDefault()
        {
            Pet2_Differ_Ringer = 2;
            Pet3_Differ_Ringer = 25;
            Zone_Diff_Ringer = 10;
            Swap1_Health_Ringer = 80;
            Swap2_Health_Ringer = 40;
            Swap3_Health_Ringer = 0;
        }
        public void SetRingerx2sToDefault()
        {
            Pet2_Differ_Ringerx2 = 25;
            Pet3_Differ_Ringerx2 = 25;
            Zone_Diff_Ringerx2 = 20;
            Swap1_Health_Ringerx2 = 100;
            Swap2_Health_Ringerx2 = 0;
            Swap3_Health_Ringerx2 = 0;
        }
        public void SetCapturesToDefault()
        {
            Pet2_Differ_Capture = 2;
            Pet3_Differ_Capture = 2;
            Zone_Diff_Capture = 0;
            Swap1_Health_Capture = 30;
            Swap2_Health_Capture = 30;
            Swap3_Health_Capture = 30;
        }
        public void SetCustomsToDefault()
        {
            Pet2_Differ_Custom = 2;
            Pet3_Differ_Custom = 4;
            Zone_Diff_Custom = 2;
            Swap1_Health_Custom = 60;
            Swap2_Health_Custom = 40;
            Swap3_Health_Custom = 20;
        }
        #endregion
    }
}
