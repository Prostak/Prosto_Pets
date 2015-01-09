using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

// TODO:    - add pet levels distribution
//          - dbl-click refreshes some

namespace Prosto_Pets.UI
{
    public partial class FormMP : Form
    {
        public FormMP()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void petProgress_test_Load(object sender, EventArgs e)
        {
        }


        private string AddInfo( BattlePet pet)
        {
            string info = pet.Name;
            if (pet.PetType == 1)
                info += " (Hum)";
            else if (pet.PetType == 2)
                info += " (Drag)";
            else if (pet.PetType == 3)
                info += " (Fly)";
            else if (pet.PetType == 4)
                info += " (Und)";
            else if (pet.PetType == 5)
                info += " (Crit)";
            else if (pet.PetType == 6)
                info += " (Mag)";
            else if (pet.PetType == 7)
                info += " (Elem)";
            else if (pet.PetType == 8)
                info += " (Beast)";
            else if (pet.PetType == 9)
                info += " (Aqua)";
            else if (pet.PetType == 10)
                info += " (Mech)";
            return info;
        }

        private void PB_Pet_Load(PBwithText_v2 pB, Label label, BattlePet pet)
        {

            if (pet.Name == "nil") { pB.Text = ""; }
            else
            {
                pB.Text = AddInfo(pet);
            }
            pB.Favourite = pet.IsFavorite;
            pB.Percent = pet.HealthPercent;
            label.Text = pet.Level.ToString();
            if (pet.Rarity > 3)
                { pB.ForeColor = label.ForeColor = Color.DarkBlue; }
            else if (pet.Rarity > 2)
            { pB.ForeColor = label.ForeColor = Color.DarkGreen; }
            else
            {
                pB.ForeColor = Color.Black;
                label.ForeColor = Color.Gray;
            }
            pB.Invalidate(); label.Invalidate();
        }
        
        private void pB_pet1_Load(object sender, EventArgs e)
        {
            PB_Pet_Load(pB_pet1, label_Pet1, MyPets.Pet(0));
        }

        private void pB_pet2_Load(object sender, EventArgs e)
        {
            PB_Pet_Load(pB_pet2, label_Pet2, MyPets.Pet(1));
        }

        private void pB_pet3_Load(object sender, EventArgs e)
        {
            PB_Pet_Load(pB_pet3, label_Pet3, MyPets.Pet(2));
        }

        private void UpdateTeamStatus(object sender, EventArgs e)
        {
            Logger.WriteDebug("UpdateTeamStatus");
            MyPets.updateMyPets();
            pB_pet1_Load(sender, e);
            pB_pet2_Load(sender, e);
            pB_pet3_Load(sender, e);
        }

        private void UpdateByLevelsLabel()
        {
            string text = PetJournal.Instance.GetPetsByLevel();
            label_byLevel.Text = text;
            label_byLevel.Invalidate();
        }

        private void FormMP_Load(object sender, EventArgs e)
        {
            // PB's are loaded separately
            // Let's define the states according to the current settings

            Prosto_Pets.Instance.Initialize();  // we need all the settings just to show the form

            #region Main / General

            label_Version.Text = "Version " + Prosto_Pets.Instance.Version + "        ";

            checkBox_Manual.Checked = PluginSettings.Instance.MovementByPlayer;
            checkBox_LockPet1.Checked = PluginSettings.Instance.LockFirstSlot;
            checkBox_LockPet2.Checked = PluginSettings.Instance.LockSecondSlot;
            checkBox_LockPet3.Checked = PluginSettings.Instance.LockThirdSlot;

            SetMode_ProperyToButton();

            checkBox_RecordPets.Checked = PluginSettings.Instance.RecordPets;
            checkBox_DoNotEngage.Checked = PluginSettings.Instance.DoNotEngage;

            numericUpDown_MinLevel.Value = PluginSettings.Instance.MinLevel;
            numericUpDown_MaxLevel.Value = PluginSettings.Instance.MaxLevel;
            numericUpDown_MinPetHealth.Value = PluginSettings.Instance.MinPetHealth;
            numericUpDown_MinRingerHealth.Value = PluginSettings.Instance.MinRingerPetHealth;

            checkBox_UseWild.Checked = PluginSettings.Instance.UseWildPets;
            checkBox_BluesOnly.Checked = PluginSettings.Instance.OnlyBluePets;
            checkBox_FavOnlyPets.Checked = PluginSettings.Instance.UseFavouritePetsOnly;
            checkBox_FavOnlyRingers.Checked = PluginSettings.Instance.UseFavouriteRingers;

            checkBox_CaptureRares.Checked = PluginSettings.Instance.CaptureRares;
            NotOwnedType_PropertyToButton();   // and color

            Relative_PropertiesToButtons();
            Ringer_PropertiesToButtons();
            Ringerx2_PropertiesToButtons();
            Capture_PropertiesToButtons();
            Custom_PropertiesToButtons();

            checkBox_AutoZones.Checked = PluginSettings.Instance.AutoZoneChange;
            Zone_PropertiesToButtons();  // no need to load back - trunkcated to filenames, full paths will be stored directly in the settings/properties

            Credits_Load();

            UpdateByLevelsLabel();  // do not let exception here break Load of other buttons

            #endregion
        }

        private void Credits_Load()
        {
            richTextBox1.Rtf = @"{\rtf1\ansi\deff3\adeflang1025
{\fonttbl{\f0\froman\fprq2\fcharset0 Times New Roman;}{\f1\froman\fprq2\fcharset2 Symbol;}{\f2\fswiss\fprq2\fcharset0 Arial;}{\f3\froman\fprq2\fcharset0 Liberation Serif{\*\falt Times New Roman};}{\f4\fswiss\fprq2\fcharset0 Liberation Sans{\*\falt Arial};}{\f5\fnil\fprq0\fcharset0 Verdana{\*\falt Arial};}{\f6\froman\fprq2\fcharset128 Liberation Serif{\*\falt Times New Roman};}{\f7\fmodern\fprq1\fcharset128 Courier New;}{\f8\fnil\fprq2\fcharset0 Microsoft YaHei;}{\f9\fnil\fprq2\fcharset0 Mangal;}{\f10\fnil\fprq0\fcharset128 Mangal;}}
{\colortbl;\red0\green0\blue0;\red0\green0\blue128;\red128\green0\blue0;\red51\green51\blue51;\red128\green128\blue128;}
{\stylesheet{\s0\snext0\nowidctlpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf0\kerning1\dbch\af11\langfe2052\dbch\af9\afs24\alang1081\loch\f3\fs24\lang1033 Normal;}
{\*\cs15\snext15 Footnote Characters;}
{\*\cs16\snext16 Endnote Characters;}
{\*\cs17\snext17\cf2\ul\ulc0\langfe255\alang255\lang255 Internet Link;}
{\*\cs18\snext18\cf3\ul\ulc0\langfe255\alang255\lang255 Visited Internet Link;}
{\s19\sbasedon0\snext20\sb240\sa120\keepn\dbch\af8\dbch\af9\afs28\loch\f4\fs28 Heading;}
{\s20\sbasedon0\snext20\sl288\slmult1\sb0\sa140 Text Body;}
{\s21\sbasedon20\snext21\sl288\slmult1\sb0\sa140\dbch\af10 List;}
{\s22\sbasedon0\snext22\sb120\sa120\noline\i\dbch\af10\afs24\ai\fs24 Caption;}
{\s23\sbasedon0\snext23\noline\dbch\af10 Index;}
{\s24\sbasedon0\snext24\li567\ri0\lin567\rin0\fi0 List Contents;}
}{\info{\creatim\yr2015\mo1\dy1\hr23\min40}{\revtim\yr2015\mo1\dy2\hr3\min35}{\printim\yr0\mo0\dy0\hr0\min0}{\comment LibreOffice}{\vern67305986}}\deftab709
\viewscale100
{\*\pgdsctbl
{\pgdsc0\pgdscuse451\pgwsxn12240\pghsxn15840\marglsxn1134\margrsxn1134\margtsxn1134\margbsxn1134\pgdscnxt0 Default Style;}}
\formshade\paperh15840\paperw12240\margl1134\margr1134\margt1134\margb1134\sectd\sbknone\sectunlocked1\pgndec\pgwsxn12240\pghsxn15840\marglsxn1134\margrsxn1134\margtsxn1134\margbsxn1134\ftnbj\ftnstart1\ftnrstcont\ftnnar\aenddoc\aftnrstcont\aftnstart1\aftnnrlc
{\*\ftnsep\chftnsep}\pgndec\pard\plain \s0\nowidctlpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf0\kerning1\dbch\af11\langfe2052\dbch\af9\afs24\alang1081\loch\f3\fs24\lang1033\qc{\rtlch \ltrch\loch\loch\f6
CREDITS}
\par \pard\plain \s0\nowidctlpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf0\kerning1\dbch\af11\langfe2052\dbch\af9\afs24\alang1081\loch\f3\fs24\lang1033\rtlch \ltrch\loch\loch\f6

\par \pard\plain \s0\nowidctlpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf0\kerning1\dbch\af11\langfe2052\dbch\af9\afs24\alang1081\loch\f3\fs24\lang1033{\rtlch \ltrch\loch\loch\f6
This work was greatly helped and influenced by:}
\par \pard\plain \s0\nowidctlpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf0\kerning1\dbch\af11\langfe2052\dbch\af9\afs24\alang1081\loch\f3\fs24\lang1033{\rtlch \ltrch\loch\loch\f6
1. }{{\field{\*\fldinst HYPERLINK ""https://github.com/tropicdome/MyPetBattle"" }{\fldrslt {\cf2\ul\ulc0\langfe255\alang255\lang255\rtlch \ltrch\loch\loch\f6
MyPetBattle}{}}}\rtlch \ltrch\loch\loch\f6
 protected Lua addon by tropicdome. Some config choices, internal tactics representation, battle pet tactics themselves.}
\par \pard\plain \s0\nowidctlpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf0\kerning1\dbch\af11\langfe2052\dbch\af9\afs24\alang1081\loch\f3\fs24\lang1033{\rtlch \ltrch\loch\loch\f6
2. }{{\field{\*\fldinst HYPERLINK ""https://www.thebuddyforum.com/honorbuddy-forum/botbases/186192-botbase-pokehbuddy-revised-wod.html"" }{\fldrslt {\cf2\ul\ulc0\langfe255\alang255\lang255\rtlch \ltrch\loch\loch\f6
Pokehbuddy}{}}}\rtlch \ltrch\loch\loch\f6
 botbase by hackersrage. This code was originally a plugin by }{{\field{\*\fldinst HYPERLINK ""https://www.thebuddyforum.com/members/19630-maybe.html"" \\t ""_blank"" }{\fldrslt {\cf2\ul\ulc0\langfe255\alang255\lang255\rtlch \ltrch\loch\loch\f6
maybe}{}}}\rtlch \ltrch\loch\loch\f6
, and then converted into a botbase by }{{\field{\*\fldinst HYPERLINK ""https://www.thebuddyforum.com/members/246761-sychotix.html"" \\t ""_blank"" }{\fldrslt {\cf2\ul\ulc0\langfe255\alang255\lang255\rtlch \ltrch\loch\loch\f6
sychotix}{}}}\rtlch \ltrch\loch\loch\f6
. BotBase organization, movement, pet attacking.}
\par \pard\plain \s0\nowidctlpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf0\kerning1\dbch\af11\langfe2052\dbch\af9\afs24\alang1081\loch\f3\fs24\lang1033{\rtlch \ltrch\loch\loch\f6
3. }{{\field{\*\fldinst HYPERLINK ""https://www.thebuddyforum.com/honorbuddy-forum/plugins/uncataloged/96169-plugin-battle-pet-swapper.html"" }{\fldrslt {\cf2\ul\ulc0\langfe255\alang255\lang255\rtlch \ltrch\loch\loch\f6
Battle Pet Swapper}{}}}\rtlch \ltrch\loch\loch\f6
 plugin. Organization of Lua code, at lot of Lua code itself.}
\par \pard\plain \s0\nowidctlpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf0\kerning1\dbch\af11\langfe2052\dbch\af9\afs24\alang1081\loch\f3\fs24\lang1033{\rtlch \ltrch\loch\loch\f6
4. PetArea plugin by }{{\field{\*\fldinst HYPERLINK ""https://code.google.com/p/team-random/"" }{\fldrslt {\cf2\ul\ulc0\langfe255\alang255\lang255\rtlch \ltrch\loch\loch\f6
team-random}{}}}\rtlch \ltrch\loch\loch\f6
. Changing profiles according to a pet level. Some profiles.}
\par \pard\plain \s0\nowidctlpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf0\kerning1\dbch\af11\langfe2052\dbch\af9\afs24\alang1081\loch\f3\fs24\lang1033{\rtlch \ltrch\loch\loch\f6
5. }{{\field{\*\fldinst HYPERLINK ""https://www.thebuddyforum.com/archives/150049-fpswares-raf-bot.html"" }{\fldrslt {\cf2\ul\ulc0\langfe255\alang255\lang255\rtlch \ltrch\loch\loch\f6
FPSware's RAF}{}}}\rtlch \ltrch\loch\loch\f6
 botbase. Botbase organization, GUI organization.}
\par \pard\plain \s0\nowidctlpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf0\kerning1\dbch\af11\langfe2052\dbch\af9\afs24\alang1081\loch\f3\fs24\lang1033{\rtlch \ltrch\loch\loch\f6
6. }{{\field{\*\fldinst HYPERLINK ""https://github.com/cyotek/Cyotek.Windows.Forms.TabList"" }{\fldrslt {\cf2\ul\ulc0\langfe255\alang255\lang255\rtlch \ltrch\loch\loch\f6
Cyotec}{}}}\rtlch \ltrch\loch\loch\f6
 Windows.Forms.Tablist. }
\par \pard\plain \s0\nowidctlpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf0\kerning1\dbch\af11\langfe2052\dbch\af9\afs24\alang1081\loch\f3\fs24\lang1033\rtlch \ltrch\loch\loch\f6

\par \pard\plain \s0\nowidctlpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf0\kerning1\dbch\af11\langfe2052\dbch\af9\afs24\alang1081\loch\f3\fs24\lang1033\rtlch \ltrch\loch\loch\f6

\par }";

            richTextBox1.ReadOnly = true;
            richTextBox1.DetectUrls = true;
        }


        private void SetMode_ProperyToButton()
        {
            if (PluginSettings.Instance.Mode == eMode.Relative)
            {
                comboBox_Mode.SelectedItem = "Relative";
            }
            else if (PluginSettings.Instance.Mode == eMode.Ringer)
            {
                comboBox_Mode.SelectedItem = "Ringer";
            }
            else if (PluginSettings.Instance.Mode == eMode.Ringerx2)
            {
                comboBox_Mode.SelectedItem = "Ringer x2";
            }
            else if (PluginSettings.Instance.Mode == eMode.Capture)
            {
                comboBox_Mode.SelectedItem = "Capture";
            }
            else if (PluginSettings.Instance.Mode == eMode.Custom)
            {
                comboBox_Mode.SelectedItem = "Custom";

            }
            EnablePanelsPerMode();
            PluginSettings.Instance.SetSwapByCurrentMode();  // TODO: move to swapping routine?
        }

        private void EnablePanelsPerMode()
        {
            // TODO: implement, note that mode button should be enabled on the Panel
            if (PluginSettings.Instance.Mode == eMode.Relative)
            {

            }
            else if (PluginSettings.Instance.Mode == eMode.Ringer)
            {
            }
            else if (PluginSettings.Instance.Mode == eMode.Ringerx2)
            {
            }
            else if (PluginSettings.Instance.Mode == eMode.Capture)
            {
            }
            else if (PluginSettings.Instance.Mode == eMode.Custom)
            {
            }

        }

        #region Buttons -> Properties

        private void SetPropertiesByButtons()
        {
            PluginSettings.Instance.MovementByPlayer = checkBox_Manual.Checked;
            PluginSettings.Instance.LockFirstSlot = checkBox_LockPet1.Checked;
            PluginSettings.Instance.LockSecondSlot = checkBox_LockPet2.Checked;
            PluginSettings.Instance.LockThirdSlot = checkBox_LockPet3.Checked;

            Mode_ButtonToProperty();

            PluginSettings.Instance.RecordPets = checkBox_RecordPets.Checked;
            PluginSettings.Instance.DoNotEngage = checkBox_DoNotEngage.Checked;

            PluginSettings.Instance.MinLevel = (int) numericUpDown_MinLevel.Value;
            PluginSettings.Instance.MaxLevel = (int)numericUpDown_MaxLevel.Value;
            PluginSettings.Instance.MinPetHealth = (int) numericUpDown_MinPetHealth.Value;
            PluginSettings.Instance.MinRingerPetHealth = (int) numericUpDown_MinRingerHealth.Value;

            PluginSettings.Instance.UseWildPets = checkBox_UseWild.Checked;
            PluginSettings.Instance.OnlyBluePets = checkBox_BluesOnly.Checked;
            PluginSettings.Instance.UseFavouritePetsOnly = checkBox_FavOnlyPets.Checked;
            PluginSettings.Instance.UseFavouriteRingers = checkBox_FavOnlyRingers.Checked;

            PluginSettings.Instance.CaptureRares = checkBox_CaptureRares.Checked;

            if ((string)comboBox_CaptureNotOwned.SelectedItem == "Rares")
                PluginSettings.Instance.CaptureNotOwnRarity = 4;
            else if ((string)comboBox_CaptureNotOwned.SelectedItem == "Uncommons")
                PluginSettings.Instance.CaptureNotOwnRarity = 3;
            else if ((string)comboBox_CaptureNotOwned.SelectedItem == "Commons")
                PluginSettings.Instance.CaptureNotOwnRarity = 2;
            else if ((string)comboBox_CaptureNotOwned.SelectedItem == "All")
                PluginSettings.Instance.CaptureNotOwnRarity = 1;
            else if ((string)comboBox_CaptureNotOwned.SelectedItem == "None")
                PluginSettings.Instance.CaptureNotOwnRarity = 5;  // do not complain if you ever capture one though, lol
            NotOwnedType_PropertyToButton();  // OTHER direction: to change color

            Relative_ButtonsToProperties();
            Ringer_ButtonsToProperties();
            Ringerx2_ButtonsToProperties();
            Capture_ButtonsToProperties();
            Custom_ButtonsToProperties();

            PluginSettings.Instance.AutoZoneChange = checkBox_AutoZones.Checked;
            // no need to load back Zone Names - trunkcated to filenames, full paths will be stored directly in the settings/properties

        }

        private void Relative_ButtonsToProperties()
        {
            //Logger.WriteDebug("Relative_ButtonsToProperties");
            PluginSettings.Instance.Pet2_Differ_Relative = (int) pet2Diff_Relative.Value;
            PluginSettings.Instance.Pet3_Differ_Relative = (int) pet3Diff_Relative.Value;
            PluginSettings.Instance.Zone_Diff_Relative = (int) zoneDiff_Relative.Value;
            PluginSettings.Instance.Swap1_Health_Relative = (int)swapPet1_Relative.Value;
            PluginSettings.Instance.Swap2_Health_Relative = (int)swapPet2_Relative.Value;
            PluginSettings.Instance.Swap3_Health_Relative = (int) swapPet3_Relative.Value;
        }
        private void Ringer_ButtonsToProperties()
        {
            //Logger.WriteDebug("Ringer_ButtonsToProperties");
            PluginSettings.Instance.Pet2_Differ_Ringer = (int)pet2Diff_Ringer.Value;
            PluginSettings.Instance.Pet3_Differ_Ringer = (int)pet3Diff_Ringer.Value;
            PluginSettings.Instance.Zone_Diff_Ringer = (int)zoneDiff_Ringer.Value;
            PluginSettings.Instance.Swap1_Health_Ringer = (int)swapPet1_Ringer.Value;
            PluginSettings.Instance.Swap2_Health_Ringer = (int)swapPet2_Ringer.Value;
            PluginSettings.Instance.Swap3_Health_Ringer = (int)swapPet3_Ringer.Value;
        }
        private void Ringerx2_ButtonsToProperties()
        {
            //Logger.WriteDebug("Ringerx2_ButtonsToProperties");
            PluginSettings.Instance.Pet2_Differ_Ringerx2 = (int)pet2Diff_Ringerx2.Value;
            PluginSettings.Instance.Pet3_Differ_Ringerx2 = (int)pet3Diff_Ringerx2.Value;
            PluginSettings.Instance.Zone_Diff_Ringerx2 = (int)zoneDiff_Ringerx2.Value;
            PluginSettings.Instance.Swap1_Health_Ringerx2 = (int)swapPet1_Ringerx2.Value;
            PluginSettings.Instance.Swap2_Health_Ringerx2 = (int)swapPet2_Ringerx2.Value;
            PluginSettings.Instance.Swap3_Health_Ringerx2 = (int)swapPet3_Ringerx2.Value;
        }
        private void Capture_ButtonsToProperties()
        {
            //Logger.WriteDebug("Capture_ButtonsToProperties");
            PluginSettings.Instance.Pet2_Differ_Capture = (int)pet2Diff_Capture.Value;
            PluginSettings.Instance.Pet3_Differ_Capture = (int)pet3Diff_Capture.Value;
            PluginSettings.Instance.Zone_Diff_Capture = (int)zoneDiff_Capture.Value;
            PluginSettings.Instance.Swap1_Health_Capture = (int)swapPet1_Capture.Value;
            PluginSettings.Instance.Swap2_Health_Capture = (int)swapPet2_Capture.Value;
            PluginSettings.Instance.Swap3_Health_Capture = (int)swapPet3_Capture.Value;
        }
        private void Custom_ButtonsToProperties()
        {
            //Logger.WriteDebug("Custom_ButtonsToProperties");
            PluginSettings.Instance.Pet2_Differ_Custom = (int)pet2Diff_Custom.Value;
            PluginSettings.Instance.Pet3_Differ_Custom = (int)pet3Diff_Custom.Value;
            PluginSettings.Instance.Zone_Diff_Custom = (int)zoneDiff_Custom.Value;
            PluginSettings.Instance.Swap1_Health_Custom = (int)swapPet1_Custom.Value;
            PluginSettings.Instance.Swap2_Health_Custom = (int)swapPet2_Custom.Value;
            PluginSettings.Instance.Swap3_Health_Custom = (int)swapPet3_Custom.Value;
        }
        #endregion


        private void Relative_PropertiesToButtons()
        {
            //Logger.WriteDebug("Relative_PropertiesToButtons");
            pet2Diff_Relative.Value = PluginSettings.Instance.Pet2_Differ_Relative;
            pet3Diff_Relative.Value = PluginSettings.Instance.Pet3_Differ_Relative;
            zoneDiff_Relative.Value = PluginSettings.Instance.Zone_Diff_Relative;
            //Logger.WriteDebug("before Swap1: button:" + swapPet1_Relative.Value + "<- setting:" + PluginSettings.Instance.Swap1_Health_Relative);
            swapPet1_Relative.Value = PluginSettings.Instance.Swap1_Health_Relative;
            //Logger.WriteDebug("after Swap1: button:" + swapPet1_Relative.Value + "<- setting:" + PluginSettings.Instance.Swap1_Health_Relative);
            swapPet2_Relative.Value = PluginSettings.Instance.Swap2_Health_Relative;
            swapPet3_Relative.Value = PluginSettings.Instance.Swap3_Health_Relative;
        }
        private void Ringer_PropertiesToButtons()
        {
            //Logger.WriteDebug("Ringer_PropertiesToButtons");
            pet2Diff_Ringer.Value = PluginSettings.Instance.Pet2_Differ_Ringer;
            pet3Diff_Ringer.Value = PluginSettings.Instance.Pet3_Differ_Ringer;
            zoneDiff_Ringer.Value = PluginSettings.Instance.Zone_Diff_Ringer;
            swapPet1_Ringer.Value = PluginSettings.Instance.Swap1_Health_Ringer;
            swapPet2_Ringer.Value = PluginSettings.Instance.Swap2_Health_Ringer;
            swapPet3_Ringer.Value = PluginSettings.Instance.Swap3_Health_Ringer;
        }

        private void Ringerx2_PropertiesToButtons()
        {
            //Logger.WriteDebug("Ringerx2_PropertiesToButtons");
            pet2Diff_Ringerx2.Value = PluginSettings.Instance.Pet3_Differ_Ringerx2;  // pet2_Diff not used in this mode
            pet2Diff_Ringerx2.Enabled = false;
            pet3Diff_Ringerx2.Value = PluginSettings.Instance.Pet3_Differ_Ringerx2;
            zoneDiff_Ringerx2.Value = PluginSettings.Instance.Zone_Diff_Ringerx2;
            swapPet1_Ringerx2.Value = PluginSettings.Instance.Swap1_Health_Ringerx2;
            swapPet2_Ringerx2.Value = PluginSettings.Instance.Swap2_Health_Ringerx2;
            swapPet3_Ringerx2.Value = PluginSettings.Instance.Swap3_Health_Ringerx2;
        }

        private void Capture_PropertiesToButtons()
        {
            //Logger.WriteDebug("Capture_PropertiesToButtons");
            pet2Diff_Capture.Value = PluginSettings.Instance.Pet2_Differ_Capture;
            pet3Diff_Capture.Value = PluginSettings.Instance.Pet3_Differ_Capture;
            zoneDiff_Capture.Value = PluginSettings.Instance.Zone_Diff_Capture;
            swapPet1_Capture.Value = PluginSettings.Instance.Swap1_Health_Capture;
            swapPet2_Capture.Value = PluginSettings.Instance.Swap2_Health_Capture;
            swapPet3_Capture.Value = PluginSettings.Instance.Swap3_Health_Capture;
        }

        private void Custom_PropertiesToButtons()
        {
            //Logger.WriteDebug("Custom_PropertiesToButtons");
            pet2Diff_Custom.Value = PluginSettings.Instance.Pet2_Differ_Custom;
            pet3Diff_Custom.Value = PluginSettings.Instance.Pet3_Differ_Custom;
            zoneDiff_Custom.Value = PluginSettings.Instance.Zone_Diff_Custom;
            swapPet1_Custom.Value = PluginSettings.Instance.Swap1_Health_Custom;
            swapPet2_Custom.Value = PluginSettings.Instance.Swap2_Health_Custom;
            swapPet3_Custom.Value = PluginSettings.Instance.Swap3_Health_Custom;
        }

        private string FileNameFrom( string path)
        {
            try
            {
                return Path.GetFileName(path);
            }
            catch
            {
                return "invalid file name";
            }
        }

        private void Zone_PropertiesToButtons()
        {
            button_Zone_1to3.Text = FileNameFrom( PluginSettings.Instance.Zone_1to3 );
            button_Zone_4to5.Text = FileNameFrom(PluginSettings.Instance.Zone_4to5);
            button_Zone_6to7.Text = FileNameFrom(PluginSettings.Instance.Zone_6to7);
            button_Zone_8to9.Text = FileNameFrom(PluginSettings.Instance.Zone_8to9);
            button_Zone_10to11.Text = FileNameFrom(PluginSettings.Instance.Zone_10to11);
            button_Zone_12to13.Text = FileNameFrom(PluginSettings.Instance.Zone_12to13);
            button_Zone_14to15.Text = FileNameFrom(PluginSettings.Instance.Zone_14to15);
            button_Zone_16to17.Text = FileNameFrom(PluginSettings.Instance.Zone_16to17);
            button_Zone_18to19.Text = FileNameFrom(PluginSettings.Instance.Zone_18to19);
            button_Zone_20to21.Text = FileNameFrom(PluginSettings.Instance.Zone_20to21);
            button_Zone_22to25.Text = FileNameFrom(PluginSettings.Instance.Zone_22to25);
        }


        private void Mode_ButtonToProperty()
        {
            if (NotFocused(comboBox_Mode)) return;
            if ((string)comboBox_Mode.SelectedItem == "Relative")
                PluginSettings.Instance.SetMode( eMode.Relative );
            else if ((string)comboBox_Mode.SelectedItem == "Ringer x2")
                PluginSettings.Instance.SetMode( eMode.Ringerx2 );
            else if ((string)comboBox_Mode.SelectedItem == "Capture")
                PluginSettings.Instance.SetMode( eMode.Capture );
            else if ((string)comboBox_Mode.SelectedItem == "Ringer")
                PluginSettings.Instance.SetMode( eMode.Ringer );
            else if ((string)comboBox_Mode.SelectedItem == "Custom")
                PluginSettings.Instance.SetMode( eMode.Custom );
        }

        private void FormMP_FormClosing(object sender, FormClosingEventArgs e)
        {

            SetPropertiesByButtons();

            PluginSettings.Instance.ConvertsPropertiesToSettings();
            PluginSettings.Instance.Save();

            // Make reverse reading
            Logger.Write(" [PetsForm] " + PluginSettings.Instance.ToString());
        }

        private bool NotFocused(object sender)
        {
            return !(sender is Control && ((Control)sender).Focused);
        }

        private void comboBox_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NotFocused(sender)) return;
            Mode_ButtonToProperty();
        }

        private void checkBox_LockPet2_CheckedChanged(object sender, EventArgs e)
        {
            PluginSettings.Instance.LockSecondSlot = checkBox_LockPet2.Checked;
        }

        private void checkBox_LockPet1_CheckedChanged(object sender, EventArgs e)
        {
            PluginSettings.Instance.LockFirstSlot = checkBox_LockPet1.Checked;
        }

        private void checkBox_LockPet3_CheckedChanged(object sender, EventArgs e)
        {
            PluginSettings.Instance.LockThirdSlot = checkBox_LockPet3.Checked;
        }

        private void numericUpDown_MinLevel_ValueChanged(object sender, EventArgs e)
        {
            PluginSettings.Instance.MinLevel = (int) numericUpDown_MinLevel.Value;
            UpdateByLevelsLabel();
        }

        private void numericUpDown_MaxLevel_ValueChanged(object sender, EventArgs e)
        {
            PluginSettings.Instance.MaxLevel = (int)numericUpDown_MaxLevel.Value;
            UpdateByLevelsLabel();
        }

        private void numericUpDown_MinPetHealth_ValueChanged(object sender, EventArgs e)
        {
            PluginSettings.Instance.MinPetHealth = (int)numericUpDown_MinPetHealth.Value;
        }

        private void numericUpDown_MinRingerHealth_ValueChanged(object sender, EventArgs e)
        {
            PluginSettings.Instance.MinRingerPetHealth = (int)numericUpDown_MinRingerHealth.Value;
        }

        private void checkBox_UseWild_CheckedChanged(object sender, EventArgs e)
        {
            PluginSettings.Instance.UseWildPets = checkBox_UseWild.Checked;
            UpdateByLevelsLabel();
        }

        private void checkBox_BluesOnly_CheckedChanged(object sender, EventArgs e)
        {
            PluginSettings.Instance.OnlyBluePets = checkBox_BluesOnly.Checked;
            UpdateByLevelsLabel();
        }


        private void FavOnly_DependencyAction()
        {
            // preserving existing behavior
            if (PluginSettings.Instance.UseFavouritePetsOnly)
            {                   PluginSettings.Instance.UseFavouriteRingers = true;
                checkBox_FavOnlyRingers.Checked = true;
            }
            UpdateByLevelsLabel();
        }

        private void checkBox_FavOnlyPets_CheckedChanged(object sender, EventArgs e)
        {
            if (NotFocused(sender)) return;
            PluginSettings.Instance.UseFavouritePetsOnly = checkBox_FavOnlyPets.Checked;
            FavOnly_DependencyAction();
        }

        private void checkBox_FavOnlyRingers_CheckedChanged(object sender, EventArgs e)
        {
            if (NotFocused(sender)) return;
            PluginSettings.Instance.UseFavouriteRingers = checkBox_FavOnlyRingers.Checked;
            FavOnly_DependencyAction();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Select New Team, show it
            if( Prosto_Pets.Instance == null )
            {
                Logger.Alert("Prosto_Pets not started yet");
                return;
            }
            button1.Enabled = false;  // just in case: 1st op can take long
            Prosto_Pets.Instance.LoadPetsForLevel();   // TODO: check rc, show alarm
            pB_pet1_Load(sender, e);
            pB_pet2_Load(sender, e);
            pB_pet3_Load(sender, e);
            button1.Enabled = true;
        }

        private void checkBox_Manual_CheckedChanged(object sender, EventArgs e)
        {
            PluginSettings.Instance.MovementByPlayer = checkBox_Manual.Checked;
        }

        private void NotOwnedType_PropertyToButton()
        {
            if (PluginSettings.Instance.CaptureNotOwnRarity == 4)
            {
                comboBox_CaptureNotOwned.SelectedItem = "Rares";
                comboBox_CaptureNotOwned.ForeColor = checkBox_BluesOnly.ForeColor;
            }
            else if (PluginSettings.Instance.CaptureNotOwnRarity == 3)
            {
                comboBox_CaptureNotOwned.SelectedItem = "Uncommons";
                comboBox_CaptureNotOwned.ForeColor = label_MinPetH.ForeColor;
            }
            else if (PluginSettings.Instance.CaptureNotOwnRarity == 2)
            {
                comboBox_CaptureNotOwned.SelectedItem = "Commons";
                comboBox_CaptureNotOwned.ForeColor = Color.Gray;
            }
            else if (PluginSettings.Instance.CaptureNotOwnRarity == 1)
            {
                comboBox_CaptureNotOwned.SelectedItem = "All";
                comboBox_CaptureNotOwned.ForeColor = Color.Gray;
            }
            else if (PluginSettings.Instance.CaptureNotOwnRarity == 5)
            {
                comboBox_CaptureNotOwned.SelectedItem = "None";
                comboBox_CaptureNotOwned.ForeColor = Color.Black;
            }
        }
        private void NotOwnedType_ButtonToProperty()
        {
            if ((string)comboBox_CaptureNotOwned.SelectedItem == "Rares")
                PluginSettings.Instance.CaptureNotOwnRarity = 4;
            else if ((string)comboBox_CaptureNotOwned.SelectedItem == "Uncommons")
                PluginSettings.Instance.CaptureNotOwnRarity = 3;
            else if ((string)comboBox_CaptureNotOwned.SelectedItem == "Commons")
                PluginSettings.Instance.CaptureNotOwnRarity = 2;
            else if ((string)comboBox_CaptureNotOwned.SelectedItem == "All")
                PluginSettings.Instance.CaptureNotOwnRarity = 1;
            else if ((string)comboBox_CaptureNotOwned.SelectedItem == "None")
                PluginSettings.Instance.CaptureNotOwnRarity = 5;
        }


        private void comboBox_CaptureNotOwned_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This value is not immediately needed, just playing with chnaging the color of filename box
            if (NotFocused(sender)) return;
            NotOwnedType_ButtonToProperty();
            NotOwnedType_PropertyToButton();
        }

        private void button_DefailtsRelative_Click(object sender, EventArgs e)
        {
            PluginSettings.Instance.SetRelativesToDefault();
            Relative_PropertiesToButtons();
        }

        private void button_DefailtsRinger_Click(object sender, EventArgs e)
        {
            PluginSettings.Instance.SetRingersToDefault();
            Ringer_PropertiesToButtons();
        }

        private void button_DefailtsRingerx2_Click(object sender, EventArgs e)
        {
            PluginSettings.Instance.SetRingerx2sToDefault();
            Ringerx2_PropertiesToButtons();
        }

        private void button_DefailtsCapture_Click(object sender, EventArgs e)
        {
            PluginSettings.Instance.SetCapturesToDefault();
            Capture_PropertiesToButtons();
        }

        private void button_DefailtsCustom_Click(object sender, EventArgs e)
        {
            PluginSettings.Instance.SetCustomsToDefault();
            Custom_PropertiesToButtons();
        }


        private string OpenFile(string name)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            // Store full path in our property, set file name as button text
            openFileDialog1.FileName = name;
            openFileDialog1.InitialDirectory = Path.GetDirectoryName(name);
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }
            return "";
        }

        private void button_Zone_1to3_Click(object sender, EventArgs e)
        {
            string newName = OpenFile(PluginSettings.Instance.Zone_1to3);
            if( newName != "" )
            {
                PluginSettings.Instance.Zone_1to3 = newName; // full name goes to settings
                button_Zone_1to3.Text = Path.GetFileName(newName); // file name goes on button
            }
        }

        private void button_Zone_4to5_Click(object sender, EventArgs e)
        {
            string newName = OpenFile(PluginSettings.Instance.Zone_4to5);
            if (newName != "")
            {
                PluginSettings.Instance.Zone_4to5 = newName; // full name goes to settings
                button_Zone_4to5.Text = Path.GetFileName(newName); // file name goes on button
            }
        }

        private void button_Zone_6to7_Click(object sender, EventArgs e)
        {
            string newName = OpenFile(PluginSettings.Instance.Zone_6to7);
            if (newName != "")
            {
                PluginSettings.Instance.Zone_6to7 = newName; // full name goes to settings
                button_Zone_6to7.Text = Path.GetFileName(newName); // file name goes on button
            }
        }

        private void button_Zone_8to9_Click(object sender, EventArgs e)
        {
            string newName = OpenFile(PluginSettings.Instance.Zone_8to9);
            if (newName != "")
            {
                PluginSettings.Instance.Zone_8to9 = newName; // full name goes to settings
                button_Zone_8to9.Text = Path.GetFileName(newName); // file name goes on button
            }
        }

        private void button_Zone_10to11_Click(object sender, EventArgs e)
        {
            string newName = OpenFile(PluginSettings.Instance.Zone_10to11);
            if (newName != "")
            {
                PluginSettings.Instance.Zone_10to11 = newName; // full name goes to settings
                button_Zone_10to11.Text = Path.GetFileName(newName); // file name goes on button
            }
        }

        private void button_Zone_12to13_Click(object sender, EventArgs e)
        {
            string newName = OpenFile(PluginSettings.Instance.Zone_12to13);
            if (newName != "")
            {
                PluginSettings.Instance.Zone_12to13 = newName; // full name goes to settings
                button_Zone_12to13.Text = Path.GetFileName(newName); // file name goes on button
            }
        }

        private void button_Zone_14to15_Click(object sender, EventArgs e)
        {
            string newName = OpenFile(PluginSettings.Instance.Zone_14to15);
            if (newName != "")
            {
                PluginSettings.Instance.Zone_14to15 = newName; // full name goes to settings
                button_Zone_14to15.Text = Path.GetFileName(newName); // file name goes on button
            }
        }

        private void button_Zone_16to17_Click(object sender, EventArgs e)
        {
            string newName = OpenFile(PluginSettings.Instance.Zone_16to17);
            if (newName != "")
            {
                PluginSettings.Instance.Zone_16to17 = newName; // full name goes to settings
                button_Zone_16to17.Text = Path.GetFileName(newName); // file name goes on button
            }
        }

        private void button_Zone_18to19_Click(object sender, EventArgs e)
        {
            string newName = OpenFile(PluginSettings.Instance.Zone_18to19);
            if (newName != "")
            {
                PluginSettings.Instance.Zone_18to19 = newName; // full name goes to settings
                button_Zone_18to19.Text = Path.GetFileName(newName); // file name goes on button
            }
        }

        private void button_Zone_20to21_Click(object sender, EventArgs e)
        {
            string newName = OpenFile(PluginSettings.Instance.Zone_20to21);
            if (newName != "")
            {
                PluginSettings.Instance.Zone_20to21 = newName; // full name goes to settings
                button_Zone_20to21.Text = Path.GetFileName(newName); // file name goes on button
            }
        }

        private void button_Zone_22to25_Click(object sender, EventArgs e)
        {
            string newName = OpenFile(PluginSettings.Instance.Zone_22to25);
            if (newName != "")
            {
                PluginSettings.Instance.Zone_22to25 = newName; // full name goes to settings
                button_Zone_22to25.Text = Path.GetFileName(newName); // file name goes on button
            }
        }

        private void button_SetRelative_Click(object sender, EventArgs e)
        {
            PluginSettings.Instance.SetMode( eMode.Relative );
            SetMode_ProperyToButton();        
    }

        private void button_SetRinger_Click(object sender, EventArgs e)
        {
            PluginSettings.Instance.SetMode( eMode.Ringer );
            SetMode_ProperyToButton();        
        }

        private void button_SetRingerx2_Click(object sender, EventArgs e)
        {
            PluginSettings.Instance.SetMode( eMode.Ringerx2);
            SetMode_ProperyToButton();        
        }

        private void button_SetCapture_Click(object sender, EventArgs e)
        {
            PluginSettings.Instance.SetMode(eMode.Capture);
            SetMode_ProperyToButton();        
        }

        private void button_SetCustom_Click(object sender, EventArgs e)
        {
            PluginSettings.Instance.SetMode(eMode.Custom);
            SetMode_ProperyToButton();
        }

        #region Mode Value Changed handlers

        private void Relative_Value_Changed( object sender )
        {
            if( NotFocused(sender) ) return;
            Relative_ButtonsToProperties();
        }

        private void Ringer_Value_Changed(object sender)
        {
            if (NotFocused(sender)) return;
            Ringer_ButtonsToProperties();
        }

        private void Ringerx2_Value_Changed(object sender)
        {
            if (NotFocused(sender)) return;
            Ringerx2_ButtonsToProperties();
        }

        private void Capture_Value_Changed(object sender)
        {
            if (NotFocused(sender)) return;
            Capture_ButtonsToProperties();
        }

        private void Custom_Value_Changed(object sender)
        {
            if (NotFocused(sender)) return;
            Custom_ButtonsToProperties();
        }

        private void pet2Diff_Relative_ValueChanged(object sender, EventArgs e)
        {
            if (NotFocused(sender)) return;
            Relative_Value_Changed(sender);
        }

        private void pet3Diff_Relative_ValueChanged(object sender, EventArgs e)
        {
            if (NotFocused(sender)) return;
            Relative_Value_Changed(sender);
        }

        private void zoneDiff_Relative_ValueChanged(object sender, EventArgs e)
        {
            if (NotFocused(sender)) return;
            Relative_Value_Changed(sender);
        }

        private void pet2Diff_Ringer_ValueChanged(object sender, EventArgs e)
        {
            if (NotFocused(sender)) return;
            Ringer_Value_Changed(sender);
        }

        private void pet3Diff_Ringer_ValueChanged(object sender, EventArgs e)
        {
            if (NotFocused(sender)) return;
            Ringer_Value_Changed(sender);
        }

        private void pet2Diff_Ringerx2_ValueChanged(object sender, EventArgs e)
        {
            if (NotFocused(sender)) return;
            Ringerx2_Value_Changed(sender);
        }

        private void pet3Diff_Ringerx2_ValueChanged(object sender, EventArgs e)
        {
            if (NotFocused(sender)) return;
            Ringerx2_Value_Changed(sender);
        }

        private void pet2Diff_Capture_ValueChanged(object sender, EventArgs e)
        {
            if (NotFocused(sender)) return;
            Capture_Value_Changed(sender);
        }

        private void pet3Diff_Capture_ValueChanged(object sender, EventArgs e)
        {
            if (NotFocused(sender)) return;
            Capture_Value_Changed(sender);
        }

        private void pet2Diff_Custom_ValueChanged(object sender, EventArgs e)
        {
            if (NotFocused(sender)) return;
            Custom_Value_Changed(sender);
        }

        private void pet3Diff_Custom_ValueChanged(object sender, EventArgs e)
        {
            if (NotFocused(sender)) return;
            Custom_Value_Changed(sender);
        }

        #endregion

        private void FormMP_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logger.WriteDebug(string.Format("Memory used before collection:       {0:N0}",
                        GC.GetTotalMemory(false)));
            // Collect all generations of memory.
            GC.Collect();
            Logger.WriteDebug(string.Format("Memory used after full collection:   {0:N0}",
                              GC.GetTotalMemory(true)));
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            // Team Selection button - renew
            Logger.WriteDebug("Label2 [Double]Click");
            UpdateTeamStatus(sender,e);
        }

        private void label_byLevel_DoubleClick(object sender, EventArgs e)
        {
            UpdateByLevelsLabel();
        }

        private void checkBox_DoNotEngage_CheckedChanged(object sender, EventArgs e)
        {
            PluginSettings.Instance.DoNotEngage = checkBox_DoNotEngage.Checked;
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", e.LinkText);  //  explorer.exe passes the arguments to a singleton, which is guaranteed running un-elevated. 
        }



    }
}
