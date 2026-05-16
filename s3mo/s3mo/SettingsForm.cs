using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s3mo
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.SetSettings("GameExecutablePath", gamePathTextBox.Text);
            Settings.SetSettings("DocumentsFolderPath", documentsTextBox.Text);
            Settings.SetSettings("BuildSizeLimit", buildSizeLimitNumericUpDown.Value);
            Settings.SetSettings("BuildPriority", buildPrioirtyNumbericUpDown.Value);
            Settings.SetSettings("BuildResourceCFG", resourcecfgTextBox.Text.Replace(Environment.NewLine, "\\n"));
            Settings.SetSettings("ClearCASPartCache", casPartCacheCheckBox.Checked);
            Settings.SetSettings("ClearCompositorCache", compositorCacheCheckBox.Checked);
            Settings.SetSettings("ClearScriptCache", scriptCacheCheckBox.Checked);
            Settings.SetSettings("ClearSimCompositorCache", simCompositorCacheCheckBox.Checked);
            Settings.SetSettings("ClearSocialCache", socialCacheCheckBox.Checked);
            Settings.SetSettings("ClearDCCacheDCC", dcCacheDccCheckBox.Checked);
            Settings.SetSettings("ClearDCCacheMissingdeps", dcCacheMissingdepsCheckBox.Checked);
            Settings.SetSettings("ClearDownloadsBin", downloadsBinCheckBox.Checked);
            Settings.SetSettings("ClearFeaturedItems", featuredItemCheckbox.Checked);
            Settings.SetSettings("ClearIGACache", igaCacheCheckBox.Checked);
            Settings.SetSettings("ClearSavedSimsDownloadedSims", savedSimsDownloadedsimsCheckBox.Checked);
            Settings.SetSettings("ClearSigsCacheBin", sigsCacheBinCheckBox.Checked);
            Settings.SetSettings("ClearThumbnails", thumbnailCheckBox.Checked);
            Settings.SetSettings("ClearWorldCaches", worldCacheCheckBox.Checked);
            Settings.SetSettings("ClearNRaasScriptErrors", nraasScriptErrorCheckBox.Checked);
            Settings.SetSettings("SettingsX", Location.X);
            Settings.SetSettings("SettingsY", Location.Y);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (Settings.TryGetSettings("SettingsX", out string obj) && int.TryParse(obj, out int i))
                if (Settings.TryGetSettings("SettingsY", out string obj2) && int.TryParse(obj2, out int j))
                    Location = new Point(i, j);
            if (Settings.TryGetSettings("GameExecutablePath", out obj))
                gamePathTextBox.Text = obj;
            if (Settings.TryGetSettings("DocumentsFolderPath", out obj))
                documentsTextBox.Text = obj;
            if (Settings.TryGetSettings("BuildSizeLimit", out obj) && int.TryParse(obj, out i))
                buildSizeLimitNumericUpDown.Value = i;
            if (Settings.TryGetSettings("BuildPriority", out obj) && int.TryParse(obj, out i))
                buildPrioirtyNumbericUpDown.Value = i;
            if (Settings.TryGetSettings("BuildResourceCFG", out obj))
                resourcecfgTextBox.Text = obj.Replace("\\n", Environment.NewLine);
            if (Settings.TryGetSettings("ClearCASPartCache", out obj) && bool.TryParse(obj, out bool b))
                casPartCacheCheckBox.Checked = b;
            if (Settings.TryGetSettings("ClearCompositorCache", out obj) && bool.TryParse(obj, out b))
                compositorCacheCheckBox.Checked = b;
            if (Settings.TryGetSettings("ClearScriptCache", out obj) && bool.TryParse(obj, out b))
                scriptCacheCheckBox.Checked = b;
            if (Settings.TryGetSettings("ClearSimCompositorCache", out obj) && bool.TryParse(obj, out b))
                simCompositorCacheCheckBox.Checked = b;
            if (Settings.TryGetSettings("ClearSocialCache", out obj) && bool.TryParse(obj, out b))
                socialCacheCheckBox.Checked = b;
            if (Settings.TryGetSettings("ClearDCCacheDCC", out obj) && bool.TryParse(obj, out b))
                dcCacheDccCheckBox.Checked = b;
            if (Settings.TryGetSettings("ClearDCCacheMissingdeps", out obj) && bool.TryParse(obj, out b))
                dcCacheMissingdepsCheckBox.Checked = b;
            if (Settings.TryGetSettings("ClearDownloadsBin", out obj) && bool.TryParse(obj, out b))
                downloadsBinCheckBox.Checked = b;
            if (Settings.TryGetSettings("ClearFeaturedItems", out obj) && bool.TryParse(obj, out b))
                featuredItemCheckbox.Checked = b;
            if (Settings.TryGetSettings("ClearIGACache", out obj) && bool.TryParse(obj, out b))
                igaCacheCheckBox.Checked = b;
            if (Settings.TryGetSettings("ClearSavedSimsDownloadedSims", out obj) && bool.TryParse(obj, out b))
                savedSimsDownloadedsimsCheckBox.Checked = b;
            if (Settings.TryGetSettings("ClearSigsCacheBin", out obj) && bool.TryParse(obj, out b))
                sigsCacheBinCheckBox.Checked = b;
            if (Settings.TryGetSettings("ClearThumbnails", out obj) && bool.TryParse(obj, out b))
                thumbnailCheckBox.Checked = b;
            if (Settings.TryGetSettings("ClearWorldCaches", out obj) && bool.TryParse(obj, out b))
                worldCacheCheckBox.Checked = b;
            if (Settings.TryGetSettings("ClearNRaasScriptErrors", out obj) && bool.TryParse(obj, out b))
                nraasScriptErrorCheckBox.Checked = b;
        }

        private void gamePathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Sims 3 Executables|Sims3Launcher.exe;Sims3LauncherW.exe;TS3.exe;TS3W.exe;|All Executables|*.exe";
            if (dialog.ShowDialog() == DialogResult.OK)
                gamePathTextBox.Text = dialog.FileName;
        }

        private void documentsButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                documentsTextBox.Text = dialog.SelectedPath;
        }
    }
}
