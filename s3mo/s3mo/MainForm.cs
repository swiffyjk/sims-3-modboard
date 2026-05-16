using ns;
using s3molib;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace s3mo
{
    public partial class MainForm : Form
    {
        private ProfileModel _profileModel = null!;
        private string _currentProfile = string.Empty;

        public MainForm()
        {
            InitializeComponent();
            this.Text = "Sims 3 Mod Organizer v" + Program.Version;

            string profilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Profiles");
            if (!Directory.Exists(profilePath))
            {
                string path = Path.Combine(profilePath, "Default");
                Directory.CreateDirectory(path);
                _currentProfile = "Default";
            }

            if (Settings.TryGetSettings("Profile", out string obj))
                _currentProfile = (string)obj;
            else
                Settings.SetSettings("Profile", _currentProfile = "Default");

            string modsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mods");
            if (!Directory.Exists(modsPath))
                Directory.CreateDirectory(modsPath);

            ResetModel();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized || WindowState == FormWindowState.Maximized)
            {
                Settings.SetSettings("WindowX", RestoreBounds.Location.X);
                Settings.SetSettings("WindowY", RestoreBounds.Location.Y);
                Settings.SetSettings("WindowHeight", RestoreBounds.Size.Height);
                Settings.SetSettings("WindowWidth", RestoreBounds.Size.Width);
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Settings.SetSettings("WindowX", Location.X);
                Settings.SetSettings("WindowY", Location.Y);
                Settings.SetSettings("WindowWidth", Size.Width);
                Settings.SetSettings("WindowHeight", Size.Height);
            }
            Settings.SetSettings("WindowMaximized", WindowState == FormWindowState.Maximized);

            Settings.SetSettings("WindowSplitContainer1SplitterDistance", splitContainer1.SplitterDistance);
            Settings.SetSettings("WindowSplitContainer2SplitterDistance", splitContainer2.SplitterDistance);
            Settings.SetSettings("WindowModListViewModHeaderWidth", modHeader.Width);
            Settings.SetSettings("WindowModListViewFlagHeaderWidth", flagHeader.Width);
            Settings.SetSettings("WindowModListViewPriorityHeaderWidth", priorityHeader.Width);
            Settings.SetSettings("WindowFileListViewFileHeaderWidth", fileHeader.Width);
            Settings.SetSettings("WindowFileListViewFlagHeaderWidth", fileFlagHeader.Width);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Settings.TryGetSettings("WindowX", out string obj) && int.TryParse(obj, out int i) &&
                Settings.TryGetSettings("WindowY", out string obj2) && int.TryParse(obj2, out int j))
                Location = new Point(i, j);
            if (Settings.TryGetSettings("WindowWidth", out obj) && int.TryParse(obj, out i) &&
                Settings.TryGetSettings("WindowHeight", out obj2) && int.TryParse(obj2, out j))
                Size = new Size(i, j);
            if (Settings.TryGetSettings("WindowMaximized", out obj) && bool.TryParse(obj, out bool b))
                WindowState = b ? FormWindowState.Maximized : FormWindowState.Normal;
            if (Settings.TryGetSettings("WindowSplitContainer1SplitterDistance", out obj) && int.TryParse(obj, out i))
                splitContainer1.SplitterDistance = i;
            if (Settings.TryGetSettings("WindowSplitContainer2SplitterDistance", out obj) && int.TryParse(obj, out i))
                splitContainer2.SplitterDistance = i;
            if (Settings.TryGetSettings("WindowModListViewModHeaderWidth", out obj) && int.TryParse(obj, out i))
                modHeader.Width = i;
            if (Settings.TryGetSettings("WindowModListViewFlagHeaderWidth", out obj) && int.TryParse(obj, out i))
                flagHeader.Width = i;
            if (Settings.TryGetSettings("WindowModListViewPriorityHeaderWidth", out obj) && int.TryParse(obj, out i))
                priorityHeader.Width = i;
            if (Settings.TryGetSettings("WindowFileListViewFileHeaderWidth", out obj) && int.TryParse(obj, out i))
                fileHeader.Width = i;
            if (Settings.TryGetSettings("WindowFileListViewFlagHeaderWidth", out obj) && int.TryParse(obj, out i))
                fileFlagHeader.Width = i;

            this.SizeChanged += (s, e) =>
            {
                modHeader.Width = modListView.Width - 21 - flagHeader.Width - priorityHeader.Width;
                fileHeader.Width = fileListView.Width - 21 - fileFlagHeader.Width;
            };
            splitContainer2.SplitterMoved += (s, e) =>
            {
                modHeader.Width = modListView.Width - 21 - flagHeader.Width - priorityHeader.Width;
                fileHeader.Width = fileListView.Width - 21 - fileFlagHeader.Width;
            };

            modListView.SetDoubleBuffered();
            fileListView.SetDoubleBuffered();

            Logger.InfoLoggedEvent += s => { logListBox.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + s); logListBox.TopIndex = logListBox.Items.Count - 1; };
            Logger.DebugLoggedEvent += s => { logListBox.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + s); logListBox.TopIndex = logListBox.Items.Count - 1; };
            Logger.WarningLoggedEvent += s => { logListBox.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + s); logListBox.TopIndex = logListBox.Items.Count - 1; };
            Logger.ErrorLoggedEvent += s => { logListBox.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + s); logListBox.TopIndex = logListBox.Items.Count - 1; };
        }

        private void ResetModel()
        {
            _profileModel = new ProfileModel();
            _profileModel.Setup(_currentProfile);
            CheckConflictsBetweenModModels();
            CheckConflictsInModModels();
            ComputeMD5();
            RefreshListViews(false);
        }

        private void RefreshListViews(bool setupModel = true)
        {
            if (setupModel)
                _profileModel.Setup(_currentProfile);

            List<ModModel> mods = _profileModel.ModModels;
            mods.Sort(new ModModelComparer(ModModelComparer.SortBy.Priority));

            modListView.Items.Clear();
            fileListView.Items.Clear();

            foreach (ModModel m in mods)
            {
                ListViewItem item = new ListViewItem(m.Name);
                item.Checked = m.Enabled;
                item.SubItems.Add(string.Empty); // Placeholder for icon, else will throw exception.
                item.SubItems.Add(m.Priority.ToString());
                modListView.Items.Add(item);
            }

            string[] profiles = Directory.GetDirectories(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Profiles"));
            Array.Sort(profiles, new NumericComparer());
            profileComboBox.Items.Clear();

            foreach (string path in profiles)
                profileComboBox.Items.Add(Path.GetFileName(path));

            profileComboBox.SelectedItem = _currentProfile;
        }

        private void UpdateModModelPriority()
        {
            int realIndex = 0; // Used so that the order is preserved when saved in modlist.txt
            int displayIndex = 0;

            foreach (ListViewItem item in modListView.Items)
            {
                ModModel mod = _profileModel.GetModModel(item.Text);
                mod.Update(mod.Name, mod.Enabled, realIndex);

                if (mod.Enabled)
                    item.SubItems[2].Text = displayIndex++.ToString();
                else
                    item.SubItems[2].Text = string.Empty;

                realIndex++;
            }
            _profileModel.Save(_currentProfile);

            ValidateModBuild();
        }

        private void BuildMods()
        {
            if (!Settings.TryGetSettings("DocumentsFolderPath", out string sims3FolderPath))
            {
                MessageBox.Show("No Sims 3 Documents folder path is entered in settings, aborting merge process.", "Invalid Folder Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Logger.Log("Build started");

            this.Enabled = false;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string modsFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mods");
            string sims3ModsFolderPath = Path.Combine(sims3FolderPath, "Mods");

            if (!Directory.Exists(sims3ModsFolderPath))
                Directory.CreateDirectory(sims3ModsFolderPath);

            string modBuildFolderPath = Path.Combine(sims3ModsFolderPath, "ModBuilds");
            if (Directory.Exists(modBuildFolderPath))
                Directory.Delete(modBuildFolderPath, true);

            Directory.CreateDirectory(modBuildFolderPath);

            string resourceCfgPath = Path.Combine(sims3ModsFolderPath, "Resource.cfg");
            StreamWriter w = new StreamWriter(resourceCfgPath);

            string buildPriority = Settings.TryGetSettings("BuildPriority", out string obj) ? obj : "495";

            string[] modSetupLines = new string[]
            {
                $"Priority {buildPriority}",
                "PackedFile \"ModBuilds/*.package\"",
                "",
            };

            if (Settings.TryGetSettings("BuildResourceCFG", out string resourcecfg))
                modSetupLines = modSetupLines.Concat(resourcecfg.Split("\\n")).ToArray();

            foreach (string l in modSetupLines)
                w.WriteLine(l);

            w.Close();
            w.BaseStream.Close();

            FileStream stream = null!;
            try
            { stream = new FileStream(Path.Combine(modBuildFolderPath, "Merge.bin"), FileMode.Create, FileAccess.Write, FileShare.None); }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Could not write packages meta. Aborting.", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            BinaryWriter bw = new BinaryWriter(stream);


            List<ModModel> mods = _profileModel.ModModels;
            mods.Sort(new ModModelComparer(ModModelComparer.SortBy.Priority));

            List<Package> packagesToMerge = new List<Package>();

            foreach (ModModel mod in mods)
            {
                if (!mod.Enabled)
                    continue;

                List<PackageModel> packageModels = mod.PackageModels;
                packageModels.Sort((p1, p2) => StringLogicalComparer.Compare(p1.Name, p2.Name));

                foreach (PackageModel packageModel in packageModels)
                {
                    packagesToMerge.Add(packageModel.Package);

                    while (checkDetailedConflictBetweenModModelBackgroundWorker.IsBusy || checkDetailedConflictBetweenModModelBackgroundWorker.IsBusy)
                    {
                        Logger.Log("Waiting for conflict calculation to complete.");
                        Application.DoEvents();
                        Thread.Sleep(1000);
                    }

                    if (packageModel.HashBytes == null)
                    {
                        bw.Close();
                        stream.Close();
                        stopwatch.Stop();
                        this.Enabled = true;
                        MessageBox.Show("Wait for MD5 hashbytes to compute or refresh if it's not computing.", "No hashbyte to write", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.Log("Build canceled due to lack of hashbytes.");
                        return;
                    }

                    bw.Write(mod.ConflictingModModels.FindAll(m => m.Enabled).Count > 0);
                    bw.Write(packageModel.HashBytes!);
                }
            }
            bw.Close();
            stream.Close();


            uint buildLimit = 1000;
            if (Settings.TryGetSettings("BuildSizeLimit", out obj))
                uint.TryParse(obj, out buildLimit);

            buildLimit *= 1000000;


            int count = packagesToMerge.Count;
            progressLabel.Visible = true;
            progressBar.Visible = true;
            progressBar.Maximum = count;

            BackgroundWorker mergeBackgroundWorker = new BackgroundWorker();
            mergeBackgroundWorker.WorkerReportsProgress = true;
            mergeBackgroundWorker.DoWork += (s, e) => Package.Merge(modBuildFolderPath, packagesToMerge, buildLimit, i => mergeBackgroundWorker.ReportProgress(i));
            mergeBackgroundWorker.ProgressChanged += (s, e) =>
            {
                string text = $"Merging {Path.GetFileName(packagesToMerge[e.ProgressPercentage].FilePath)}";
                Logger.Log(text);
                progressLabel.Text = text;
                progressBar.Value = count - e.ProgressPercentage;
            };
            mergeBackgroundWorker.RunWorkerCompleted += (s, e) =>
            {
                Logger.Log($"Build process finished in {stopwatch.ElapsedMilliseconds} ms for {count} packages.");
                stopwatch.Stop();

                progressLabel.Visible = false;
                progressBar.Visible = false;
                this.Enabled = true;

                warningButton.Enabled = false;
                ComputeMergedBuildMD5();
            };
            mergeBackgroundWorker.RunWorkerAsync();
        }


        private void profileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string profileName = (string)profileComboBox.SelectedItem;
            if (_currentProfile.Equals(profileName))
                return;

            _currentProfile = profileName;
            Settings.SetSettings("Profile", _currentProfile);
            RefreshListViews();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.FormClosed += (s, e) => this.Enabled = true;
            this.Enabled = false;
            form.Show();
        }

        private void installButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            this.Enabled = false;

            string tempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");
            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);

            string[] paths = openFileDialog.FileNames;

            foreach (string path in paths)
            {
                try
                {
                    string extension = Path.GetExtension(path);

                    if (extension.Equals(".sims3pack", StringComparison.OrdinalIgnoreCase))
                        Sims3Pack.Unpack(path, tempPath);

                    else if (extension.Equals(".package", StringComparison.OrdinalIgnoreCase))
                        File.Copy(path, Path.Combine(tempPath, $"{Path.GetFileName(path)}"));

                    else if (extension.Equals(".zip", StringComparison.OrdinalIgnoreCase))
                    {
                        ZipFile.ExtractToDirectory(path, tempPath);

                        string[] sims3packsPath = Directory.GetFiles(tempPath, "*.sims3pack");

                        foreach (string p in sims3packsPath)
                        {
                            Sims3Pack.Unpack(p, tempPath);
                            File.Delete(p);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Couldn't install file at '{path}' - {ex.Message}");
                }
            }

            InstallForm form = new InstallForm();
            form.FormClosed += (s, e) =>
            {
                this.Enabled = true;
                ResetModel();
            };
            form.Show();
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.FormClosed += (s, e) => this.Enabled = true;
            this.Enabled = false;
            settingsForm.Show();
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            ProfileForm form = new ProfileForm(_currentProfile);
            this.Enabled = false;
            form.FormClosed += (s, e) =>
            {
                RefreshListViews();
                this.Enabled = true;
            };
            form.Show();
        }

        private void openFolderButton_MouseClick(object sender, MouseEventArgs e)
        {
            openFolderContextMenuStrip.Show(Cursor.Position);
        }

        #region openFolderToolStip

        private void openGameFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Settings.TryGetSettings("GameExecutablePath", out string path) || path.Length == 0)
            {
                MessageBox.Show("No path entered for Sims 3 executable in settings");
                return;
            }
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                MessageBox.Show($"Folder at '{path}' does not exists");
                return;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.Arguments = Path.GetDirectoryName(path);
            startInfo.FileName = "explorer.exe";
            try
            { Process.Start(startInfo); }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void openGameDocumentsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Settings.TryGetSettings("DocumentsFolderPath", out string path) || path.Length == 0)
            {
                MessageBox.Show("No path entered for Sims 3 documents folder in settings");
                return;
            }
            if (!Directory.Exists(path))
            {
                MessageBox.Show($"Folder at '{path}' does not exists");
                return;
            }
            if (!Path.GetFileName(path).Equals("The Sims 3"))
            {
                MessageBox.Show($"Folder at '{path}' is not a Sims 3 folder");
                return;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.Arguments = path;
            startInfo.FileName = "explorer.exe";
            try
            { Process.Start(startInfo); }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void openS3MOFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.Arguments = AppDomain.CurrentDomain.BaseDirectory;
            startInfo.FileName = "explorer.exe";
            try
            { Process.Start(startInfo); }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        #endregion

        private void clearCacheButton_Click(object sender, EventArgs e)
        {
            if (!Settings.TryGetSettings("DocumentsFolderPath", out string path) || path.Length == 0)
            {
                MessageBox.Show("No path entered for Sims 3 documents folder in settings");
                return;
            }
            if (!Directory.Exists(path))
            {
                MessageBox.Show($"Folder at '{path}' does not exists");
                return;
            }
            //if (!Path.GetFileName(path).Equals("The Sims 3"))  Commented so it works for foreign languages
            //{
            //    MessageBox.Show($"Folder at '{path}' is not a Sims 3 folder");
            //    return;
            //}

            List<string> deleteFileList = new List<string>();
            List<string> deleteFolderList = new List<string>();

            if (Settings.TryGetSettings("ClearCASPartCache", out string obj) && bool.TryParse(obj, out bool b) && b)
                deleteFileList.Add(Path.Combine(path, "CASPartCache.package"));
            if (Settings.TryGetSettings("ClearCompositorCache", out obj) && bool.TryParse(obj, out b) && b)
                deleteFileList.Add(Path.Combine(path, "compositorCache.package"));
            if (Settings.TryGetSettings("ClearScriptCache", out obj) && bool.TryParse(obj, out b) && b)
                deleteFileList.Add(Path.Combine(path, "scriptCache.package"));
            if (Settings.TryGetSettings("ClearSimCompositorCache", out obj) && bool.TryParse(obj, out b) && b)
                deleteFileList.Add(Path.Combine(path, "simCompositorCache.package"));
            if (Settings.TryGetSettings("ClearSocialCache", out obj) && bool.TryParse(obj, out b) && b)
                deleteFileList.Add(Path.Combine(path, "socialCache.package"));
            if (Settings.TryGetSettings("ClearDCCacheDCC", out obj) && bool.TryParse(obj, out b) && b)
                deleteFileList.Add(Path.Combine(path, "DCCache\\dcc.ent"));
            if (Settings.TryGetSettings("ClearDCCacheMissingdeps", out obj) && bool.TryParse(obj, out b) && b)
                deleteFileList.Add(Path.Combine(path, "DCCache\\missingdeps.idx"));
            if (Settings.TryGetSettings("ClearDownloadsBin", out obj) && bool.TryParse(obj, out b) && b)
                foreach (string p in Directory.GetFiles(Path.Combine(path, "Downloads"), "*.bin"))
                    deleteFileList.Add(p);
            if (Settings.TryGetSettings("ClearFeaturedItems", out obj) && bool.TryParse(obj, out b) && b)
                deleteFolderList.Add(Path.Combine(path, "FeaturedItems"));
            if (Settings.TryGetSettings("ClearIGACache", out obj) && bool.TryParse(obj, out b) && b)
                deleteFolderList.Add(Path.Combine(path, "IGACache"));
            if (Settings.TryGetSettings("ClearSavedSimsDownloadedSims", out obj) && bool.TryParse(obj, out b) && b)
                deleteFileList.Add(Path.Combine(path, "SavedSims\\downloadedsims.index"));
            if (Settings.TryGetSettings("ClearSigsCacheBin", out obj) && bool.TryParse(obj, out b) && b)
                foreach (string p in Directory.GetFiles(Path.Combine(path, "SigsCache"), "*.bin"))
                    deleteFileList.Add(p);
            if (Settings.TryGetSettings("ClearThumbnails", out obj) && bool.TryParse(obj, out b) && b)
                deleteFolderList.Add(Path.Combine(path, "Thumbnails"));
            if (Settings.TryGetSettings("ClearWorldCaches", out obj) && bool.TryParse(obj, out b) && b)
                deleteFolderList.Add(Path.Combine(path, "WorldCaches"));
            if (Settings.TryGetSettings("ClearNRaasScriptErrors", out obj) && bool.TryParse(obj, out b) && b)
                foreach (string p in Directory.GetFiles(path, "ScriptError*.xml"))
                    deleteFileList.Add(p);

            foreach (string p in deleteFileList)
            {
                if (File.Exists(p))
                {
                    Logger.Log("Deleting File " + Path.GetFileName(p));
                    File.Delete(p);
                }
            }
            foreach (string p in deleteFolderList)
            {
                if (Directory.Exists(p))
                {
                    Logger.Log("Deleting Folder " + Path.GetFileName(p));
                    Directory.Delete(p, true);
                }
            }
        }

        private void refreshButton_Click(object sender, EventArgs e) => ResetModel();

        private void buildButton_Click(object sender, EventArgs e) => BuildMods();

        private void playButton_Click(object sender, EventArgs e)
        {
            if (!Settings.TryGetSettings("GameExecutablePath", out string path) || path.Length == 0)
            {
                MessageBox.Show($"No path is entered for game executable in settings");
                return;
            }
            if (!File.Exists(path))
            {
                MessageBox.Show($"'{path}' is not a valid path to the game executable.");
                return;
            }

            if (warningButton.Enabled)
            {
                var r = MessageBox.Show("Start game without rebuilding?", "Build Unmatch", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.No)
                    return;
            }

            //BuildMods();
            Process process = new Process();
            process.StartInfo.FileName = path;
            try
            { process.Start(); }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Couldn't start game process", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


    }

}