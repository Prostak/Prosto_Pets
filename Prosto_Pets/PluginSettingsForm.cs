using System;
using System.Windows.Forms;
using Styx.Common;

namespace Prosto_Pets
{
    public partial class PluginSettingsForm : Form
    {

        public PluginSettingsForm()
        {
            InitializeComponent();
            propertyGrid.SelectedObject = PluginSettings.Instance;
            Logging.Write(System.Windows.Media.Colors.Gold, "[PetsForm] " + "Test" + (PluginSettings.Instance.ToString()) + " -in");
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            PluginSettings.Instance.ConvertsPropertiesToSettings();
            Logging.Write(System.Windows.Media.Colors.Gold, "[PetsForm] " + "Saving settings.");
            PluginSettings.Instance.Save();
            this.Close();
        }

        private void CancelButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void PluginSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PluginSettings.Instance.ConvertSettingsToProperties();
            Logging.Write(System.Windows.Media.Colors.Gold, "[PetsForm] " + PluginSettings.Instance.ToString());
        }

        private void propertyGrid_Click(object sender, EventArgs e)
        {

        }
    }
}
