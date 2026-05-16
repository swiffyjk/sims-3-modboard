using ns;
using s3molib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s3mo
{
    partial class MainForm
    {
        #region modListView

        private void modListView_DragDrop(object sender, DragEventArgs e) => UpdateModModelPriority();

        private void modListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ModModel mod = _profileModel.GetModModel(e.Item.Text);
            mod.Update(mod.Name, e.Item.Checked, mod.Priority);
            UpdateModModelPriority();
        }

        private bool modListView_isEditingText = false; // Use to hide the drawn string on subitem.
        private string modListView_preLabelEditBuffer = string.Empty;
        private void modListView_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            modListView_isEditingText = true;
            modListView_preLabelEditBuffer = modListView.SelectedItems[0].Text;
        }
        private void modListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            string? newFolderName = e.Label;
            modListView_isEditingText = false;

            if (!Helper.CheckValidFolderName(newFolderName!))
            {
                e.CancelEdit = true;
                return;
            }

            Logger.LogDebug($"Renaming mod folder from '{modListView_preLabelEditBuffer}' to '{newFolderName}'");
            _profileModel.RenameMod(modListView_preLabelEditBuffer, newFolderName);
        }

        private List<string> modListView_losingConflictingModModels = new List<string>();
        private List<string> modListView_winningConflictingModModels = new List<string>();
        private void modListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            // Populate the packages panel on the right
            fileListView.Items.Clear();

            if (modListView.SelectedItems.Count != 1)
                return;
            if (e.Item != null)
            {
                List<PackageModel> packageModels = _profileModel.GetModModel(e.Item.Text).PackageModels;

                packageModels.Sort((p1, p2) => StringLogicalComparer.Compare(p1.Name, p2.Name));

                foreach (PackageModel packageModel in packageModels)
                {
                    ListViewItem listViewItem = new ListViewItem(packageModel.Name);
                    listViewItem.SubItems.Add(String.Empty);
                    fileListView.Items.Add(listViewItem);
                }

                string[] otherFiles = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Mods\\{e.Item.Text}"))
                                                        .Where(f => !f.EndsWith(".package")).Select(p => Path.GetFileName(p)).ToArray();


                foreach (string otherFile in otherFiles)
                {
                    ListViewItem listViewItem = new ListViewItem(otherFile);
                    listViewItem.SubItems.Add(String.Empty);
                    fileListView.Items.Add(listViewItem);
                }

                // Responsible for conflict row color change
                modListView_losingConflictingModModels.Clear();
                modListView_winningConflictingModModels.Clear();

                ModModel modModel = _profileModel.GetModModel(e.Item.Text);

                if (!modModel.Enabled)
                    return;

                List<ModModel> conflictingModModels = modModel.ConflictingModModels.FindAll(m => m.Enabled);

                if (conflictingModModels.Count == 0)
                    return;

                foreach (ModModel conflict in conflictingModModels)
                {
                    if (conflict.Priority < modModel.Priority)
                        modListView_losingConflictingModModels.Add(conflict.Name);
                    else if (modModel.Priority < conflict.Priority)
                        modListView_winningConflictingModModels.Add(conflict.Name);
                }
            }
        }

        private void modListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) => e.DrawDefault = true;
        private void modListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (modListView.SelectedItems.Count == 0)
            {
                modListView_losingConflictingModModels.Clear();
                modListView_winningConflictingModModels.Clear();
            }

            // Draw background color
            if (e.Item!.Selected)
                e.SubItem!.BackColor = SystemColors.Highlight;
            else if (modListView_losingConflictingModModels.Contains(e.Item!.Text))
                e.SubItem!.BackColor = Color.LightGreen;
            else if (modListView_winningConflictingModModels.Contains(e.Item!.Text))
                e.SubItem!.BackColor = Color.LightCoral;
            else
                e.SubItem!.BackColor = (e.ItemIndex % 2 != 0) ? SystemColors.Control : SystemColors.Window;

            e.DrawBackground();

            // Draw Subitems
            if (e.SubItem == e.Item.SubItems[0]) // Name
            {
                CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(e.Bounds.X + 7, e.Bounds.Y + 3), e.Item.Checked ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal : System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
                if (!(modListView_isEditingText && e.Item.Selected))
                    e.Graphics.DrawString(e.SubItem.Text, this.Font, e.Item.Selected ? Brushes.White : Brushes.Black, e.Bounds.X + 25, e.Bounds.Y + 1);
            }
            else if (e.SubItem == e.Item.SubItems[2]) // Priority
            {
                e.Graphics.DrawString(e.SubItem.Text, this.Font, e.Item.Selected ? Brushes.White : Brushes.Black, e.Bounds.X - (4 * e.SubItem.Text.Length) + e.Bounds.Width / 2, e.Bounds.Y + 1);
            }
            else if (e.SubItem == e.Item.SubItems[1]) // Icons
            {
                ModModel modModel = _profileModel.GetModModel(e.Item.Text);

                if (!modModel.Enabled)
                    return;

                List<ModModel> conflictingModModels = modModel.ConflictingModModels.FindAll(m => m.Enabled);

                if (conflictingModModels.Count == 0)
                    return;

                conflictingModModels.Sort(new ModModelComparer(ModModelComparer.SortBy.Priority));

                int iconCount = 0;

                if (modModel.PackageModels.Count(p => p.ConflictingPackageModelsInModModel.Count > 0) > 0)
                {
                    e.Graphics.DrawImage((Image)Properties.Resources.package_minus, e.Bounds.X + 2, e.Bounds.Y, 16, 16);
                    iconCount += 1;
                }

                int priority = modModel.Priority;
                int firstConflictPriority = conflictingModModels[0].Priority;
                int lastConflictPriority = conflictingModModels[conflictingModModels.Count - 1].Priority;

                Rectangle imageRect = new Rectangle(e.Bounds.X + 2 + (16 * iconCount), e.Bounds.Y, 16, 16);

                if (priority < firstConflictPriority)
                    e.Graphics.DrawImage((Image)Properties.Resources.error_minus, imageRect);
                else if (firstConflictPriority < modModel.Priority && priority < lastConflictPriority)
                    e.Graphics.DrawImage((Image)Properties.Resources.error_plusminus, imageRect);
                else if (lastConflictPriority < modModel.Priority)
                    e.Graphics.DrawImage((Image)Properties.Resources.error_plus, imageRect);
                else
                    throw new Exception($"ModModel '{Path.GetFileName(modModel.FolderPath)}' is conflicting with '{e.Item.Text}' but unable to determine its conflict status");
            }
        }

        private void modListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point mousePoint = new Point(e.X, e.Y);
                bool found = false;

                foreach (ListViewItem listViewItem in modListView.Items)
                {
                    if (listViewItem.Bounds.Contains(mousePoint))
                        found = true;
                }

                if (found)
                    modListViewContextMenuStrip.Show(Cursor.Position);
                else
                    modListViewNonSelectedContextMenuStrip.Show(Cursor.Position);
            }
        }

        private void modListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = modListView.HitTest(e.X, e.Y);
            ListViewItem? listViewItem = info.Item;

            if (listViewItem == null)
                return;

            listViewItem.Checked = !listViewItem.Checked;
            this.Enabled = false;

            while (checkDetailedConflictBetweenModModelBackgroundWorker.IsBusy)
                Application.DoEvents();

            ModForm modForm = new ModForm(_profileModel.GetModModel(listViewItem.Text));
            modForm.FormClosed += (sender, e) => this.Enabled = true;
            modForm.Show();
        }

        #endregion


        #region modListView ContextMenu

        private void modListViewToolStripMenuItemCreateEmptyMod_Click(object sender, EventArgs e)
        {
            string modName = _profileModel.CreateEmptyMod();
            _profileModel.Save(_currentProfile);

            ListViewItem listViewItem = new ListViewItem(modName);
            listViewItem.Checked = false;
            listViewItem.SubItems.Add(modListView.Items.Count.ToString());
            listViewItem.SubItems.Add("");
            modListView.Items.Add(listViewItem);

            UpdateModModelPriority();

            modListView.SelectedItems.Clear();
            listViewItem.BeginEdit();
        }


        private void modListViewToolStripMenuItemEnableSelected_Click(object sender, EventArgs e)
        {
            if (modListView.SelectedItems.Count == 0)
                return;

            foreach (ListViewItem item in modListView.SelectedItems)
            {
                item.Checked = true;
                ModModel modModel = _profileModel.GetModModel(item.Text);
                modModel.Update(modModel.Name, true, modModel.Priority);
            }
            UpdateModModelPriority();
        }

        private void modListViewToolStripMenuItemDisableSelected_Click(object sender, EventArgs e)
        {
            if (modListView.SelectedItems.Count == 0)
                return;

            foreach (ListViewItem item in modListView.SelectedItems)
            {
                item.Checked = false;
                ModModel modModel = _profileModel.GetModModel(item.Text);
                modModel.Update(modModel.Name, false, modModel.Priority);
            }
            UpdateModModelPriority();
        }

        private void modListViewToolStripMenuItemInformation_Click(object sender, EventArgs e)
        {
            if (modListView.SelectedItems.Count != 1)
                return;

            this.Enabled = false;

            while (checkDetailedConflictBetweenModModelBackgroundWorker.IsBusy)
                Application.DoEvents();

            ModForm modForm = new ModForm(_profileModel.GetModModel(modListView.SelectedItems[0].Text));
            modForm.FormClosed += (sender, e) => this.Enabled = true;
            modForm.Show();
        }

        private void modListViewToolStripMenuItemOpenInExplorer_Click(object sender, EventArgs e)
        {
            if (modListView.SelectedItems.Count == 0)
                return;

            string modName = modListView.SelectedItems[0].Text;
            string path = _profileModel.GetModModel(modName).FolderPath;

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.Arguments = path;
            startInfo.FileName = "explorer.exe";
            try
            { Process.Start(startInfo); }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void modListViewToolStripMenuItemRenameMod_Click(object sender, EventArgs e)
        {
            if (modListView.SelectedItems.Count == 0)
                return;

            modListView.SelectedItems[0].BeginEdit();
        }

        private void modListViewToolStripMenuItemDeleteMod_Click(object sender, EventArgs e)
        {
            if (modListView.SelectedItems.Count == 0)
                return;

            string s = $"Delete the following mod(s) permanently?{Environment.NewLine}";
            foreach (ListViewItem item in modListView.SelectedItems)
                s += $"- {item.Text}{Environment.NewLine}";

            DialogResult r = MessageBox.Show(s, "Delete Mod(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                foreach (ListViewItem item in modListView.SelectedItems)
                {
                    string name = item.Text;
                    modListView.Items.Remove(item);
                    _profileModel.DeleteMod(name);
                }

                this.UpdateModModelPriority();
            }
        }

        #endregion


    }
}
