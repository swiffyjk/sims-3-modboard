using ns;
using s3molib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using KUtility;

namespace s3mo
{
    public partial class ModForm : Form
    {
        ModModel _modModel = null!;

        PackageModel _packageModel = null!;
        Package _package = null!;

        List<ResourceConflictModel> _losingResourceModels = new List<ResourceConflictModel>();
        List<ResourceConflictModel> _winningResourceModels = new List<ResourceConflictModel>();

        public ModForm(ModModel modModel)
        {
            InitializeComponent();
            _modModel = modModel;
        }

        public ModForm(PackageModel packageModel)
        {
            InitializeComponent();
            _packageModel = packageModel;
            _package = _packageModel.Package;
        }

        private void ModForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (resourceDataBackgroundWorker.IsBusy)
                resourceDataBackgroundWorker.CancelAsync();

            if (WindowState == FormWindowState.Maximized)
            {
                Settings.SetSettings("ModFormX", RestoreBounds.Location.X);
                Settings.SetSettings("ModFormY", RestoreBounds.Location.Y);
                Settings.SetSettings("ModFormWidth", RestoreBounds.Size.Width);
                Settings.SetSettings("ModFormHeight", RestoreBounds.Size.Height);
            }
            else
            {
                Settings.SetSettings("ModFormX", Location.X);
                Settings.SetSettings("ModFormY", Location.Y);
                Settings.SetSettings("ModFormWidth", Size.Width);
                Settings.SetSettings("ModFormHeight", Size.Height);
            }
            Settings.SetSettings("ModFormMaximized", (WindowState == FormWindowState.Maximized ? true : false));
            if (tabControl.SelectedTab != null)
            {
                Settings.SetSettings("ModFormTab", tabControl.TabPages.IndexOf(tabControl.SelectedTab));
            }

            Settings.SetSettings("ModFormPackageSplitContainerSplitterDistance", packageSplitContainer.SplitterDistance);
            Settings.SetSettings("ModFormPackageHeaderWidth", packageHeader.Width);
            Settings.SetSettings("ModFormPackageFlagHeaderWidth", packageFlagHeader.Width);
            Settings.SetSettings("ModFormResourceSplitContainerSplitterDistance", resourceSplitContainer.SplitterDistance);
            Settings.SetSettings("ModFormResourceNameHeaderWidth", resourceNameHeader.Width);
            Settings.SetSettings("ModFormResourceTagHeaderWidth", resourceTagHeader.Width);
            Settings.SetSettings("ModFormResourceTypeHeaderWidth", resourceTypeHeader.Width);
            Settings.SetSettings("ModFormResourceGroupHeaderWidth", resourceGroupHeader.Width);
            Settings.SetSettings("ModFormResourceInstanceHeaderWidth", resourceInstanceHeader.Width);

            Settings.SetSettings("ModFormLosingTagHeaderWidth", losingTagHeader.Width);
            Settings.SetSettings("ModFormLosingResourceHeaderWidth", losingResourceHeader.Width);
            Settings.SetSettings("ModFormLosingPackageHeader1Width", losingPackageHeader1.Width);
            Settings.SetSettings("ModFormLosingBlankHeaderWidth", losingBlankHeader.Width);
            Settings.SetSettings("ModFormLosingModHeaderWidth", losingModHeader.Width);
            Settings.SetSettings("ModFormLosingPackageHeader2Width", losingPackageHeader2.Width);

            Settings.SetSettings("ModFormWinningTagHeaderWidth", winningTagHeader.Width);
            Settings.SetSettings("ModFormWinningResourceHeaderWidth", winningResourceHeader.Width);
            Settings.SetSettings("ModFormWinningPackageHeader1Width", winningPackageHeader1.Width);
            Settings.SetSettings("ModFormWinningBlankHeaderWidth", winningBlankHeader.Width);
            Settings.SetSettings("ModFormWinningModHeaderWidth", winningModHeader.Width);
            Settings.SetSettings("ModFormWinningPackageHeader2Width", winningPackageHeader2.Width);
        }

        private void ModForm_Load(object sender, EventArgs e)
        {
            if (Settings.TryGetSettings("ModFormX", out string obj) && Settings.TryGetSettings("ModFormY", out string obj2)
                && int.TryParse(obj, out int i) && int.TryParse(obj2, out int j))
                Location = new Point(i, j);
            if (Settings.TryGetSettings("ModFormWidth", out obj) && Settings.TryGetSettings("ModFormHeight", out obj2)
                && int.TryParse(obj, out i) && int.TryParse(obj2, out j))
                Size = new Size(i, j);
            if (Settings.TryGetSettings("ModFormMaximized", out obj) && bool.TryParse(obj, out bool b))
                WindowState = b ? FormWindowState.Maximized : FormWindowState.Normal;
            if (Settings.TryGetSettings("ModFormTab", out obj) && int.TryParse(obj, out i))
                tabControl.SelectedTab = tabControl.TabPages[i];

            if (Settings.TryGetSettings("ModFormResourceNameHeaderWidth", out obj) && int.TryParse(obj, out i))
                resourceNameHeader.Width = i;
            if (Settings.TryGetSettings("ModFormResourceTagHeaderWidth", out obj) && int.TryParse(obj, out i))
                resourceTagHeader.Width = i;
            if (Settings.TryGetSettings("ModFormResourceTypeHeaderWidth", out obj) && int.TryParse(obj, out i))
                resourceTypeHeader.Width = i;
            if (Settings.TryGetSettings("ModFormResourceGroupHeaderWidth", out obj) && int.TryParse(obj, out i))
                resourceGroupHeader.Width = i;
            if (Settings.TryGetSettings("ModFormResourceInstanceHeaderWidth", out obj) && int.TryParse(obj, out i))
                resourceInstanceHeader.Width = i;

            if (Settings.TryGetSettings("ModFormLosingTagHeaderWidth", out obj) && int.TryParse(obj, out i))
                losingTagHeader.Width = i;
            if (Settings.TryGetSettings("ModFormLosingResourceHeaderWidth", out obj) && int.TryParse(obj, out i))
                losingResourceHeader.Width = i;
            if (Settings.TryGetSettings("ModFormLosingPackageHeader1Width", out obj) && int.TryParse(obj, out i))
                losingPackageHeader1.Width = i;
            if (Settings.TryGetSettings("ModFormLosingBlankHeaderWidth", out obj) && int.TryParse(obj, out i))
                losingBlankHeader.Width = i;
            if (Settings.TryGetSettings("ModFormLosingModHeaderWidth", out obj) && int.TryParse(obj, out i))
                losingModHeader.Width = i;
            if (Settings.TryGetSettings("ModFormLosingPackageHeader2Width", out obj) && int.TryParse(obj, out i))
                losingPackageHeader2.Width = i;

            if (Settings.TryGetSettings("ModFormWinningTagHeaderWidth", out obj) && int.TryParse(obj, out i))
                winningTagHeader.Width = i;
            if (Settings.TryGetSettings("ModFormWinningResourceHeaderWidth", out obj) && int.TryParse(obj, out i))
                winningResourceHeader.Width = i;
            if (Settings.TryGetSettings("ModFormWinningPackageHeader1Width", out obj) && int.TryParse(obj, out i))
                winningPackageHeader1.Width = i;
            if (Settings.TryGetSettings("ModFormWinningBlankHeaderWidth", out obj) && int.TryParse(obj, out i))
                winningBlankHeader.Width = i;
            if (Settings.TryGetSettings("ModFormWinningModHeaderWidth", out obj) && int.TryParse(obj, out i))
                winningModHeader.Width = i;
            if (Settings.TryGetSettings("ModFormWinningPackageHeader2Width", out obj) && int.TryParse(obj, out i))
                winningPackageHeader2.Width = i;

            this.SizeChanged += (s, e) =>
            {
                int width = losingListView.Size.Width - losingTagHeader.Width - losingResourceHeader.Width - losingBlankHeader.Width - losingModHeader.Width - 21;
                width = (int)((float)width * 0.5f);
                losingPackageHeader1.Width = width;
                losingPackageHeader2.Width = width;

                width = winningListView.Size.Width - winningTagHeader.Width - winningResourceHeader.Width - winningBlankHeader.Width - winningModHeader.Width - 21;
                width = (int)((float)width * 0.5f);
                winningPackageHeader1.Width = width;
                winningPackageHeader2.Width = width;
            };

            losingListView.SetDoubleBuffered();
            winningListView.SetDoubleBuffered();
            packageListView.SetDoubleBuffered();
            resourceListView.SetDoubleBuffered();

            if (_modModel != null)
            {
                Text = _modModel.Name;
                CalculateConflictData();
                PopulateModContent();

            }
            else if (_packageModel != null)
            {
                Text = _packageModel.Name;
                CalculateConflictDataForPackageModel();
                PopulateResourceContent();
            }
            else
                throw new Exception("Unknown model to display");
        }

        #region ConflictListViews

        private void CalculateConflictData()
        {
            if (!_modModel.Enabled)
                return;

            List<PackageModel> packageModels = _modModel.PackageModels;

            foreach (PackageModel packageModel in packageModels)
            {
                List<string> conflictingResources = packageModel.GetConflictingResources(); // It should be already sorted in priority

                if (conflictingResources.Count == 0)
                    continue;

                foreach (string resource in conflictingResources)
                {
                    List<PackageModel> conflictingPackageModels = packageModel.GetConflictingPackageModelsByResource(resource);

                    foreach (PackageModel conflictingPackageModel in conflictingPackageModels)
                    {
                        if (!conflictingPackageModel.ModModel.Enabled)
                            continue;

                        ResourceConflictModel resourceModel = new ResourceConflictModel(resource, packageModel.Name, conflictingPackageModel.ModModel.Name, conflictingPackageModel.Name);

                        if (packageModel.ModModel.Priority > conflictingPackageModel.ModModel.Priority)
                            _losingResourceModels.Add(resourceModel);
                        else if (packageModel.ModModel.Priority < conflictingPackageModel.ModModel.Priority)
                            _winningResourceModels.Add(resourceModel);
                        else
                            throw new Exception($"Conflict status unknown between {packageModel.Name} & {conflictingPackageModel.Name}");
                    }
                }
            }
            PopulateListView();
        }

        private void CalculateConflictDataForPackageModel()
        {
            List<PackageModel> conflictingPackageModels = _packageModel.ConflictingPackageModelsInModModel;

            foreach (PackageModel conflictingPackageModel in conflictingPackageModels)
            {
                int r = StringLogicalComparer.Compare(_packageModel.Name, conflictingPackageModel.Name);

                if (!_packageModel.Package.IsConflictingWith(conflictingPackageModel.Package, out var resourceEntries, out _, false))
                    continue;   // This shouldn't happen

                foreach (ResourceEntry resourceEntry in resourceEntries)
                {
                    string resource = resourceEntry.ToString();

                    ResourceConflictModel resourceModel = new ResourceConflictModel(resource, _packageModel.Name, "", conflictingPackageModel.Name);

                    if (r < 0)
                        _winningResourceModels.Add(resourceModel);
                    else if (r > 0)
                        _losingResourceModels.Add(resourceModel);
                    else
                        throw new Exception($"Conflict status unknown between {_packageModel.Name} & {conflictingPackageModel.Name}");
                }
            }

            losingGroupBox.Text = "The list below shows the resources in other packages in the same mod that will be replaced by this package";
            winningGroupBox.Text = "The list below shows the resources in other packages in the same mod that will replace this package";
            PopulateListView();
        }

        private void PopulateListView()
        {
            foreach (ResourceConflictModel resourceModel in _losingResourceModels)
            {
                ListViewItem item = new ListViewItem(resourceModel.ResourceKey);
                if (Helper.TagList.TryGetValue(resourceModel.ResourceKey.Substring(0, 10), out string? type))
                    item.SubItems.Add(type);
                else
                    item.SubItems.Add(string.Empty);
                item.SubItems.Add(resourceModel.PackageName.Substring(0, resourceModel.PackageName.LastIndexOf(".package")));
                item.SubItems.Add(string.Empty);
                item.SubItems.Add(resourceModel.OtherModName);
                item.SubItems.Add(resourceModel.OtherPackageName.Substring(0, resourceModel.OtherPackageName.LastIndexOf(".package")));
                losingListView.Items.Add(item);
            }

            foreach (ResourceConflictModel resourceModel in _winningResourceModels)
            {
                ListViewItem item = new ListViewItem(resourceModel.ResourceKey);
                if (Helper.TagList.TryGetValue(resourceModel.ResourceKey.Substring(0, 10), out string? type))
                    item.SubItems.Add(type);
                else
                    item.SubItems.Add(string.Empty);
                item.SubItems.Add(resourceModel.PackageName.Substring(0, resourceModel.PackageName.LastIndexOf(".package")));
                item.SubItems.Add(string.Empty);
                item.SubItems.Add(resourceModel.OtherModName);
                item.SubItems.Add(resourceModel.OtherPackageName.Substring(0, resourceModel.OtherPackageName.LastIndexOf(".package")));
                winningListView.Items.Add(item);
            }
        }

        private void losingListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void losingListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ItemIndex > 2)
            {
                ListViewItem item = losingListView.Items[e.ItemIndex];
                ListViewItem prevItem = losingListView.Items[e.ItemIndex - 1];

                ResourceConflictModel prevResourceModel = _losingResourceModels[e.ItemIndex - 1];
                ResourceConflictModel resourceModel = _losingResourceModels[e.ItemIndex];

                if (resourceModel.ResourceKey.Equals(prevResourceModel.ResourceKey))
                    e.SubItem!.BackColor = prevItem.BackColor;
                else
                    e.SubItem!.BackColor = prevItem.BackColor.Equals(SystemColors.Window) ? SystemColors.Control : SystemColors.Window;
            }
            else
                e.SubItem!.BackColor = (e.ItemIndex % 2 != 0) ? SystemColors.Control : SystemColors.Window;

            e.DrawDefault = true;
        }

        private void winningListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void winningListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ItemIndex > 2)
            {
                ListViewItem item = winningListView.Items[e.ItemIndex];
                ListViewItem prevItem = winningListView.Items[e.ItemIndex - 1];

                ResourceConflictModel prevResourceModel = _winningResourceModels[e.ItemIndex - 1];
                ResourceConflictModel resourceModel = _winningResourceModels[e.ItemIndex];

                if (resourceModel.ResourceKey.Equals(prevResourceModel.ResourceKey))
                    e.SubItem!.BackColor = prevItem.BackColor;
                else
                    e.SubItem!.BackColor = prevItem.BackColor.Equals(SystemColors.Window) ? SystemColors.Control : SystemColors.Window;
            }
            else
                e.SubItem!.BackColor = (e.ItemIndex % 2 != 0) ? SystemColors.Control : SystemColors.Window;

            e.DrawDefault = true;
        }

        #endregion


        #region ResourceContent

        private List<ResourceModel> _resourceModels = new List<ResourceModel>();
        private Dictionary<string, string> _nameMapLookup = new();
        private Dictionary<string, Bitmap> _ddsBitmaps = new();
        private void PopulateResourceContent()
        {
            if (_packageModel == null)
                return;

            resourceSplitContainer.Visible = true;
            packageSplitContainer.Visible = false;

            if (Settings.TryGetSettings("ModFormResourceSplitContainerSplitterDistance", out string obj) && int.TryParse(obj, out int i))
                resourceSplitContainer.SplitterDistance = i;

            _resourceModels.Clear();

            foreach (ResourceEntry resourceEntry in _package.ResourceEntries)
            {
                _resourceModels.Add(new ResourceModel(resourceEntry));

                if (resourceEntry.Type == 0x0166038C)
                {
                    Dictionary<ulong, string> nameMap = ResourceEntry.DecodeNameMap(resourceEntry);

                    foreach (var kvp in nameMap)
                    {
                        string instance = Helper.UInt64ToHexString(kvp.Key);
                        if (_nameMapLookup.ContainsKey(instance))
                            _nameMapLookup[instance] = kvp.Value;
                        else
                            _nameMapLookup.Add(instance, kvp.Value);
                    }
                }
            }

            _resourceModels.Sort((r1, r2) => r1.ResourceKey.CompareTo(r2.ResourceKey));

            foreach (ResourceModel resourceModel in _resourceModels)
            {
                ListViewItem item = new ListViewItem(resourceModel.ResourceKey);

                if (_nameMapLookup.TryGetValue(resourceModel.Instance, out string? name))
                    item.SubItems.Add(name);
                else
                    item.SubItems.Add(string.Empty);

                item.SubItems.Add(resourceModel.Tag);
                item.SubItems.Add(resourceModel.Type);
                item.SubItems.Add(resourceModel.Group);
                item.SubItems.Add(resourceModel.Instance);
                resourceListView.Items.Add(item);
            }

            resourceProgressLabel.Visible = true;
            resourceProgressBar.Visible = true;
            resourceProgressBar.Maximum = _resourceModels.Count;
            resourceProgressBar.Value = 0;
            resourceDataBackgroundWorker.RunWorkerAsync();
        }

        private void resourceDataBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < _resourceModels.Count; i++)
            {
                if (resourceDataBackgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                resourceDataBackgroundWorker.ReportProgress(i);

                ResourceModel resourceModel = _resourceModels[i];
                byte[] data = _package.GetUncompressedData(resourceModel.ResourceEntry);
                resourceModel.SetData(data);

                if (Helper.DDSTypes.Contains(resourceModel.Type))
                {
                    DDSImage dds = null!;
                    try
                    { dds = new DDSImage(data); }
                    catch
                    { }

                    if (dds != null && dds.images.Length > 0)
                        _ddsBitmaps.Add(resourceModel.ResourceKey, dds.images[0]);
                }
            }
        }

        private void resourceDataBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            resourceProgressLabel.Text = $"Reading {_resourceModels[e.ProgressPercentage].Instance}";
            resourceProgressBar.Value = e.ProgressPercentage;

            if (resourceListView.SelectedItems.Count == 1 && e.ProgressPercentage > 0 && resourceListView.SelectedItems[0].Text.Equals(_resourceModels[e.ProgressPercentage - 1].ResourceKey))
                resourceListView_SelectedIndexChanged(null!, null!);
        }

        private void resourceDataBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            resourceProgressLabel.Visible = false;
            resourceProgressBar.Visible = false;
            resourceListView_SelectedIndexChanged(null!, null!);
        }

        private void resourceListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            resourceDataTextBox.Visible = false;
            resourceDataPictureBox.Visible = false;

            if (resourceListView.SelectedItems.Count != 1)
                return;

            ListViewItem item = resourceListView.SelectedItems[0];
            int i = _resourceModels.FindIndex(r => r.ResourceKey.Equals(item.Text));
            ResourceModel resourceModel = _resourceModels[i];

            string type = resourceModel.Type;
            byte[] data = resourceModel.Data;

            if (data == null)
                return;


            if (Helper.ImageTypes.Contains(type))
            {
                resourceDataPictureBox.Visible = true;
                MemoryStream stream = new MemoryStream(resourceModel.Data);
                resourceDataPictureBox.Image = new Bitmap(stream);
                stream.Close();

            }
            else if (Helper.DDSTypes.Contains(type))
            {
                if (!_ddsBitmaps.TryGetValue(resourceModel.ResourceKey, out Bitmap? img))
                {
                    if (!resourceDataBackgroundWorker.IsBusy)
                    {
                        resourceDataTextBox.Visible = true;
                        resourceDataTextBox.Text = "The DDS image couldn't be loaded.";
                    }
                    return;
                }
                resourceDataPictureBox.Visible = true;
                resourceDataPictureBox.Image = img;
            }
            else
            {
                resourceDataTextBox.Visible = true;
                resourceDataTextBox.Text = resourceModel.ResourceEntry.Decode();
            }
        }

        #endregion


        #region ModContent

        private void PopulateModContent()
        {
            if (_modModel == null)
                return;

            resourceSplitContainer.Visible = false;
            packageSplitContainer.Visible = true;

            // These are down here because setting the control visible/invisible will change those values
            if (Settings.TryGetSettings("ModFormPackageSplitContainerSplitterDistance", out string obj) && int.TryParse(obj, out int i))
                packageSplitContainer.SplitterDistance = i;
            if (Settings.TryGetSettings("ModFormPackageSplitContainerSplitterDistance", out obj) && int.TryParse(obj, out i))
                packageSplitContainer.SplitterDistance = i;
            if (Settings.TryGetSettings("ModFormPackageHeaderWidth", out obj) && int.TryParse(obj, out i))
                packageHeader.Width = i;
            if (Settings.TryGetSettings("ModFormPackageFlagHeaderWidth", out obj) && int.TryParse(obj, out i))
                packageFlagHeader.Width = i;


            List<PackageModel> packageModels = _modModel.PackageModels;
            packageModels.Sort((p1, p2) => StringLogicalComparer.Compare(p1.Name, p2.Name));

            foreach (PackageModel packageModel in packageModels)
            {
                ListViewItem item = new ListViewItem(packageModel.Name);
                item.SubItems.Add(string.Empty);
                packageListView.Items.Add(item);
            }
        }

        List<string> packageListView_conflictLoser = new List<string>();
        List<string> packageListView_conflictWinner = new List<string>();
        private void packageListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            packageListView_conflictLoser.Clear();
            packageListView_conflictWinner.Clear();

            if (packageListView.SelectedItems.Count != 1)
                return;

            ListViewItem item = packageListView.SelectedItems[0];
            List<PackageModel> packageModels = _modModel.PackageModels;
            PackageModel packageModel = packageModels.Find(p => item.Text.Equals(p.Name))!;
            List<PackageModel> conflictingPackageModels = packageModel.ConflictingPackageModelsInModModel;

            if (conflictingPackageModels.Count == 0)
                return;

            foreach (PackageModel conflictingPackageModel in conflictingPackageModels)
            {
                int r = StringLogicalComparer.Compare(packageModel.Name, conflictingPackageModel.Name);

                if (r > 0)
                    packageListView_conflictLoser.Add(conflictingPackageModel.Name);
                else if (r < 0)
                    packageListView_conflictWinner.Add(conflictingPackageModel.Name);
            }
        }

        private void packageListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void packageListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (packageListView.Items.Count == 0)
                return;

            if (e.Item!.Selected)
                e.SubItem!.BackColor = SystemColors.Highlight;
            else if (packageListView_conflictLoser.Contains(e.Item.Text))
                e.SubItem!.BackColor = Color.LightGreen;
            else if (packageListView_conflictWinner.Contains(e.Item.Text))
                e.SubItem!.BackColor = Color.LightCoral;
            else
                e.SubItem!.BackColor = (e.ItemIndex % 2 == 0) ? SystemColors.Window : SystemColors.Control;

            e.DrawBackground();

            if (e.SubItem == e.Item!.SubItems[0])
                e.Graphics.DrawString(e.SubItem.Text, this.Font, e.Item.Selected ? Brushes.White : Brushes.Black, e.Bounds.X + 5, e.Bounds.Y + 1);
            else if (e.SubItem == e.Item.SubItems[1])
            {
                List<PackageModel> packageModels = _modModel.PackageModels;
                PackageModel packageModel = packageModels.Find(p => e.Item.Text.Equals(p.Name))!;
                List<PackageModel> conflictingPackageModels = packageModel.ConflictingPackageModelsInModModel;

                if (conflictingPackageModels.Count == 0)
                    return;

                conflictingPackageModels.Sort((p1, p2) => StringLogicalComparer.Compare(p1.Name, p2.Name));

                Rectangle imageRect = new Rectangle(e.Bounds.X + (int)(e.Bounds.Width / 2f) - 8, e.Bounds.Y + (int)(e.Bounds.Height / 2f) - 8, 16, 16);

                int i = StringLogicalComparer.Compare(packageModel.Name, conflictingPackageModels[0].Name);
                int j = StringLogicalComparer.Compare(packageModel.Name, conflictingPackageModels[conflictingPackageModels.Count - 1].Name);

                if (i < 0 && j < 0)
                    e.Graphics.DrawImage(Properties.Resources.error_minus, imageRect);
                else if (i > 0 && j < 0)
                    e.Graphics.DrawImage(Properties.Resources.error_plusminus, imageRect);
                else if (i > 0 && j > 0)
                    e.Graphics.DrawImage(Properties.Resources.error_plus, imageRect);
            }
        }

        private void packageListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hit = packageListView.HitTest(e.X, e.Y);

            if (hit.Item != null)
            {
                PackageModel? packageModel = _modModel.PackageModels.Find(p => hit.Item.Text.Equals(p.Name));

                if (packageModel == null)
                    return;

                ModForm form = new ModForm(packageModel);
                form.FormClosed += (s, e) => this.Enabled = true;
                this.Enabled = false;
                form.Show();
            }
        }

        #endregion
    }
}
