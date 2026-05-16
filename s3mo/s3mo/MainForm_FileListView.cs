using ns;
using s3molib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s3mo
{
    partial class MainForm
    {
        List<string> fileListView_conflictLosingPackageModel = new List<string>();
        List<string> fileListView_conflictWinningPackageModel = new List<string>();
        private void fileListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            fileListView_conflictWinningPackageModel.Clear();
            fileListView_conflictLosingPackageModel.Clear();

            if (modListView.SelectedItems.Count != 1)
                throw new InvalidOperationException("Selected items is not 1. Right panel should not show anything so clicking is impossible");

            ModModel modModel = _profileModel.GetModModel(modListView.SelectedItems[0].Text);

            if (e.Item != null)
            {
                if (!modModel.TryGetPackageModel(e.Item.Text, out PackageModel packageModel))
                    return;

                List<PackageModel> conflictingPackageModels = packageModel.ConflictingPackageModelsInModModel;

                foreach (PackageModel p in conflictingPackageModels)
                {
                    int comp = StringLogicalComparer.Compare(p.Name, packageModel.Name);

                    if (comp < 0)
                        fileListView_conflictLosingPackageModel.Add(p.Name);
                    else if (comp > 0)
                        fileListView_conflictWinningPackageModel.Add(p.Name);
                }
            }
        }

        private void fileListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) => e.DrawDefault = true;

        private void fileListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (fileListView.Items.Count == 0)
                return;

            if (fileListView.SelectedItems.Count == 0)
            {
                fileListView_conflictLosingPackageModel.Clear();
                fileListView_conflictWinningPackageModel.Clear();
            }

            if (e.Item!.Selected)
                e.SubItem!.BackColor = SystemColors.Highlight;
            else if (fileListView_conflictLosingPackageModel.Contains(e.Item!.Text))
                e.SubItem!.BackColor = Color.LightGreen;
            else if (fileListView_conflictWinningPackageModel.Contains(e.Item!.Text))
                e.SubItem!.BackColor = Color.LightCoral;
            else
                e.SubItem!.BackColor = (e.ItemIndex % 2 != 0) ? SystemColors.Control : SystemColors.Window;

            e.DrawBackground();

            if (e.SubItem == e.Item.SubItems[0])
            {
                e.Graphics.DrawString(e.SubItem.Text, this.Font, e.Item.Selected ? Brushes.White : Brushes.Black, e.Bounds.X + 5, e.Bounds.Y + 1);
            }
            else if (e.SubItem == e.Item.SubItems[1])
            {
                if (modListView.SelectedItems.Count != 1)
                    throw new InvalidOperationException("Selected items is not 1. Right panel should not show anything so clicking is impossible");

                ModModel modModel = _profileModel.GetModModel(modListView.SelectedItems[0].Text);

                if (!modModel.TryGetPackageModel(e.Item.Text, out PackageModel packageModel))
                    return;

                List<PackageModel> packageModels = modModel.PackageModels;
                List<PackageModel> conflictingPackageModels = packageModel.ConflictingPackageModelsInModModel;

                if (conflictingPackageModels.Count == 0)
                    return;

                conflictingPackageModels.Sort((p1, p2) => StringLogicalComparer.Compare(p1.Name, p2.Name));

                int i = StringLogicalComparer.Compare(packageModel.Name, conflictingPackageModels[0].Name);
                int j = StringLogicalComparer.Compare(packageModel.Name, conflictingPackageModels[conflictingPackageModels.Count - 1].Name);

                Rectangle imageRect = new Rectangle(e.Bounds.X + (int)(e.Bounds.Width / 2f) - 8, e.Bounds.Y + (int)(e.Bounds.Height / 2f) - 8, 16, 16);

                if (i < 0 && j < 0)
                    e.Graphics.DrawImage((Image)Properties.Resources.error_minus, imageRect);
                else if (i > 0 && j < 0)
                    e.Graphics.DrawImage((Image)Properties.Resources.error_plusminus, imageRect);
                else if (i > 0 && j > 0)
                    e.Graphics.DrawImage((Image)Properties.Resources.error_plus, imageRect);
                else
                    throw new Exception($"'{packageModel.Name}' is conflicting with package(s) but couldn't determine its conflict status");
            }
        }

        private void fileListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (modListView.SelectedItems.Count != 1)
                return;

            ListViewHitTestInfo info = fileListView.HitTest(e.X, e.Y);
            ListViewItem? listViewItem = info.Item;

            if (listViewItem == null || !Path.GetExtension(listViewItem.Text).Equals(".package", StringComparison.OrdinalIgnoreCase))
                return;

            while (checkConflictInModModelBackgroundWorker.IsBusy)
                Application.DoEvents();

            if (!_profileModel.GetModModel(modListView.SelectedItems[0].Text).TryGetPackageModel(listViewItem.Text, out PackageModel packageModel))
                throw new Exception($"Couldn't get packageModel from {modListView.SelectedItems[0].Text}");

            this.Enabled = false;
            ModForm modForm = new ModForm(packageModel);
            modForm.FormClosed += (sender, e) => this.Enabled = true;
            modForm.Show();
        }

    }
}
