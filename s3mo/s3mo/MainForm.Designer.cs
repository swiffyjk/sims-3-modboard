namespace s3mo
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.modGroupBox = new System.Windows.Forms.GroupBox();
            this.modListView = new s3mo.ModListView();
            this.modHeader = new System.Windows.Forms.ColumnHeader();
            this.flagHeader = new System.Windows.Forms.ColumnHeader();
            this.priorityHeader = new System.Windows.Forms.ColumnHeader();
            this.fileGroupBox = new System.Windows.Forms.GroupBox();
            this.fileTabControl = new System.Windows.Forms.TabControl();
            this.modTabPage = new System.Windows.Forms.TabPage();
            this.fileListView = new System.Windows.Forms.ListView();
            this.fileHeader = new System.Windows.Forms.ColumnHeader();
            this.fileFlagHeader = new System.Windows.Forms.ColumnHeader();
            this.logGroupBox = new System.Windows.Forms.GroupBox();
            this.logListBox = new System.Windows.Forms.ListBox();
            this.profileComboBox = new System.Windows.Forms.ComboBox();
            this.profileLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.modListViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modListViewToolStripMenuItemEnableSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.modListViewToolStripMenuItemDisableSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.modListViewToolStripMenuItemInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.modListViewToolStripMenuItemOpenInExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.modListViewToolStripMenuItemRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.modListViewToolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.modListViewNonSelectedContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modListViewNonSelectedToolStripMenuItemCreateEmptyMod = new System.Windows.Forms.ToolStripMenuItem();
            this.buildButton = new System.Windows.Forms.Button();
            this.checkConflictBetweenModModelBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.checkConflictInModModelBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.checkDetailedConflictBetweenModModelBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.installButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.clearCacheButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openFolderButton = new System.Windows.Forms.Button();
            this.profileButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.warningButton = new System.Windows.Forms.Button();
            this.openFolderContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openGameFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGameDocumentsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openS3MOFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.md5BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.modGroupBox.SuspendLayout();
            this.fileGroupBox.SuspendLayout();
            this.fileTabControl.SuspendLayout();
            this.modTabPage.SuspendLayout();
            this.logGroupBox.SuspendLayout();
            this.modListViewContextMenuStrip.SuspendLayout();
            this.modListViewNonSelectedContextMenuStrip.SuspendLayout();
            this.openFolderContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 79);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.logGroupBox);
            this.splitContainer1.Size = new System.Drawing.Size(908, 502);
            this.splitContainer1.SplitterDistance = 418;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.modGroupBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.fileGroupBox);
            this.splitContainer2.Size = new System.Drawing.Size(908, 418);
            this.splitContainer2.SplitterDistance = 487;
            this.splitContainer2.TabIndex = 0;
            // 
            // modGroupBox
            // 
            this.modGroupBox.Controls.Add(this.modListView);
            this.modGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modGroupBox.Location = new System.Drawing.Point(0, 0);
            this.modGroupBox.Name = "modGroupBox";
            this.modGroupBox.Size = new System.Drawing.Size(487, 418);
            this.modGroupBox.TabIndex = 5;
            this.modGroupBox.TabStop = false;
            // 
            // modListView
            // 
            this.modListView.AllowColumnReorder = true;
            this.modListView.AllowDrop = true;
            this.modListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modListView.CheckBoxes = true;
            this.modListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.modHeader,
            this.flagHeader,
            this.priorityHeader});
            this.modListView.FullRowSelect = true;
            this.modListView.LabelEdit = true;
            this.modListView.Location = new System.Drawing.Point(6, 14);
            this.modListView.Name = "modListView";
            this.modListView.OwnerDraw = true;
            this.modListView.Size = new System.Drawing.Size(475, 390);
            this.modListView.TabIndex = 2;
            this.modListView.UseCompatibleStateImageBehavior = false;
            this.modListView.View = System.Windows.Forms.View.Details;
            this.modListView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.modListView_AfterLabelEdit);
            this.modListView.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.modListView_BeforeLabelEdit);
            this.modListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.modListView_DrawColumnHeader);
            this.modListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.modListView_DrawSubItem);
            this.modListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.modListView_ItemChecked);
            this.modListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.modListView_ItemSelectionChanged);
            this.modListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.modListView_DragDrop);
            this.modListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.modListView_MouseDoubleClick);
            this.modListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.modListView_MouseDown);
            // 
            // modHeader
            // 
            this.modHeader.Text = "Mod";
            this.modHeader.Width = 345;
            // 
            // flagHeader
            // 
            this.flagHeader.Text = "Flags";
            this.flagHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.flagHeader.Width = 50;
            // 
            // priorityHeader
            // 
            this.priorityHeader.Text = "Priority";
            this.priorityHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.priorityHeader.Width = 50;
            // 
            // fileGroupBox
            // 
            this.fileGroupBox.Controls.Add(this.fileTabControl);
            this.fileGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileGroupBox.Location = new System.Drawing.Point(0, 0);
            this.fileGroupBox.Name = "fileGroupBox";
            this.fileGroupBox.Size = new System.Drawing.Size(417, 418);
            this.fileGroupBox.TabIndex = 5;
            this.fileGroupBox.TabStop = false;
            // 
            // fileTabControl
            // 
            this.fileTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileTabControl.Controls.Add(this.modTabPage);
            this.fileTabControl.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fileTabControl.Location = new System.Drawing.Point(7, 14);
            this.fileTabControl.Name = "fileTabControl";
            this.fileTabControl.SelectedIndex = 0;
            this.fileTabControl.Size = new System.Drawing.Size(404, 390);
            this.fileTabControl.TabIndex = 4;
            // 
            // modTabPage
            // 
            this.modTabPage.Controls.Add(this.fileListView);
            this.modTabPage.Location = new System.Drawing.Point(4, 24);
            this.modTabPage.Name = "modTabPage";
            this.modTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.modTabPage.Size = new System.Drawing.Size(396, 362);
            this.modTabPage.TabIndex = 0;
            this.modTabPage.Text = "Files";
            this.modTabPage.UseVisualStyleBackColor = true;
            // 
            // fileListView
            // 
            this.fileListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileHeader,
            this.fileFlagHeader});
            this.fileListView.FullRowSelect = true;
            this.fileListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.fileListView.Location = new System.Drawing.Point(-4, -1);
            this.fileListView.Name = "fileListView";
            this.fileListView.OwnerDraw = true;
            this.fileListView.Size = new System.Drawing.Size(402, 367);
            this.fileListView.TabIndex = 0;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            this.fileListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.fileListView_DrawColumnHeader);
            this.fileListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.fileListView_DrawSubItem);
            this.fileListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.fileListView_ItemSelectionChanged);
            this.fileListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fileListView_MouseDoubleClick);
            // 
            // fileHeader
            // 
            this.fileHeader.Text = "File";
            this.fileHeader.Width = 330;
            // 
            // fileFlagHeader
            // 
            this.fileFlagHeader.Text = "Flag";
            this.fileFlagHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fileFlagHeader.Width = 50;
            // 
            // logGroupBox
            // 
            this.logGroupBox.Controls.Add(this.logListBox);
            this.logGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logGroupBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.logGroupBox.Location = new System.Drawing.Point(0, 0);
            this.logGroupBox.Name = "logGroupBox";
            this.logGroupBox.Padding = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.logGroupBox.Size = new System.Drawing.Size(908, 80);
            this.logGroupBox.TabIndex = 2;
            this.logGroupBox.TabStop = false;
            this.logGroupBox.Text = "Log";
            // 
            // logListBox
            // 
            this.logListBox.BackColor = System.Drawing.SystemColors.Window;
            this.logListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logListBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logListBox.FormattingEnabled = true;
            this.logListBox.ItemHeight = 15;
            this.logListBox.Location = new System.Drawing.Point(5, 19);
            this.logListBox.Name = "logListBox";
            this.logListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.logListBox.Size = new System.Drawing.Size(898, 56);
            this.logListBox.TabIndex = 0;
            // 
            // profileComboBox
            // 
            this.profileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileComboBox.FormattingEnabled = true;
            this.profileComboBox.Location = new System.Drawing.Point(59, 61);
            this.profileComboBox.Name = "profileComboBox";
            this.profileComboBox.Size = new System.Drawing.Size(282, 23);
            this.profileComboBox.TabIndex = 4;
            this.profileComboBox.SelectedIndexChanged += new System.EventHandler(this.profileComboBox_SelectedIndexChanged);
            // 
            // profileLabel
            // 
            this.profileLabel.AutoSize = true;
            this.profileLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.profileLabel.Location = new System.Drawing.Point(13, 65);
            this.profileLabel.Name = "profileLabel";
            this.profileLabel.Size = new System.Drawing.Size(41, 15);
            this.profileLabel.TabIndex = 5;
            this.profileLabel.Text = "Profile";
            // 
            // refreshButton
            // 
            this.refreshButton.FlatAppearance.BorderSize = 0;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Image = global::s3mo.Properties.Resources.icons8_refresh_32;
            this.refreshButton.Location = new System.Drawing.Point(297, 8);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(42, 42);
            this.refreshButton.TabIndex = 1;
            this.toolTip.SetToolTip(this.refreshButton, "Refresh");
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // playButton
            // 
            this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.playButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.playButton.Image = global::s3mo.Properties.Resources.icons8_play_32;
            this.playButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.playButton.Location = new System.Drawing.Point(822, 28);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(91, 41);
            this.playButton.TabIndex = 2;
            this.playButton.Text = "      Play";
            this.playButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "File|*.package;*.sims3pack;*.zip";
            this.openFileDialog.Multiselect = true;
            // 
            // modListViewContextMenuStrip
            // 
            this.modListViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modListViewToolStripMenuItemEnableSelected,
            this.modListViewToolStripMenuItemDisableSelected,
            this.toolStripSeparator1,
            this.modListViewToolStripMenuItemInformation,
            this.modListViewToolStripMenuItemOpenInExplorer,
            this.modListViewToolStripMenuItemRename,
            this.toolStripSeparator2,
            this.modListViewToolStripMenuItemDelete});
            this.modListViewContextMenuStrip.Name = "modListViewContextMenuStrip";
            this.modListViewContextMenuStrip.Size = new System.Drawing.Size(163, 148);
            // 
            // modListViewToolStripMenuItemEnableSelected
            // 
            this.modListViewToolStripMenuItemEnableSelected.Name = "modListViewToolStripMenuItemEnableSelected";
            this.modListViewToolStripMenuItemEnableSelected.Size = new System.Drawing.Size(162, 22);
            this.modListViewToolStripMenuItemEnableSelected.Text = "Enable Selected";
            this.modListViewToolStripMenuItemEnableSelected.Click += new System.EventHandler(this.modListViewToolStripMenuItemEnableSelected_Click);
            // 
            // modListViewToolStripMenuItemDisableSelected
            // 
            this.modListViewToolStripMenuItemDisableSelected.Name = "modListViewToolStripMenuItemDisableSelected";
            this.modListViewToolStripMenuItemDisableSelected.Size = new System.Drawing.Size(162, 22);
            this.modListViewToolStripMenuItemDisableSelected.Text = "Disable Selected";
            this.modListViewToolStripMenuItemDisableSelected.Click += new System.EventHandler(this.modListViewToolStripMenuItemDisableSelected_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // modListViewToolStripMenuItemInformation
            // 
            this.modListViewToolStripMenuItemInformation.Name = "modListViewToolStripMenuItemInformation";
            this.modListViewToolStripMenuItemInformation.Size = new System.Drawing.Size(162, 22);
            this.modListViewToolStripMenuItemInformation.Text = "Information";
            this.modListViewToolStripMenuItemInformation.Click += new System.EventHandler(this.modListViewToolStripMenuItemInformation_Click);
            // 
            // modListViewToolStripMenuItemOpenInExplorer
            // 
            this.modListViewToolStripMenuItemOpenInExplorer.Name = "modListViewToolStripMenuItemOpenInExplorer";
            this.modListViewToolStripMenuItemOpenInExplorer.Size = new System.Drawing.Size(162, 22);
            this.modListViewToolStripMenuItemOpenInExplorer.Text = "Open in Explorer";
            this.modListViewToolStripMenuItemOpenInExplorer.Click += new System.EventHandler(this.modListViewToolStripMenuItemOpenInExplorer_Click);
            // 
            // modListViewToolStripMenuItemRename
            // 
            this.modListViewToolStripMenuItemRename.Name = "modListViewToolStripMenuItemRename";
            this.modListViewToolStripMenuItemRename.Size = new System.Drawing.Size(162, 22);
            this.modListViewToolStripMenuItemRename.Text = "Rename Mod";
            this.modListViewToolStripMenuItemRename.Click += new System.EventHandler(this.modListViewToolStripMenuItemRenameMod_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // modListViewToolStripMenuItemDelete
            // 
            this.modListViewToolStripMenuItemDelete.Name = "modListViewToolStripMenuItemDelete";
            this.modListViewToolStripMenuItemDelete.Size = new System.Drawing.Size(162, 22);
            this.modListViewToolStripMenuItemDelete.Text = "Delete Mod";
            this.modListViewToolStripMenuItemDelete.Click += new System.EventHandler(this.modListViewToolStripMenuItemDeleteMod_Click);
            // 
            // modListViewNonSelectedContextMenuStrip
            // 
            this.modListViewNonSelectedContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modListViewNonSelectedToolStripMenuItemCreateEmptyMod});
            this.modListViewNonSelectedContextMenuStrip.Name = "modListViewNonSelectedContextMenuStrip";
            this.modListViewNonSelectedContextMenuStrip.Size = new System.Drawing.Size(174, 26);
            // 
            // modListViewNonSelectedToolStripMenuItemCreateEmptyMod
            // 
            this.modListViewNonSelectedToolStripMenuItemCreateEmptyMod.Name = "modListViewNonSelectedToolStripMenuItemCreateEmptyMod";
            this.modListViewNonSelectedToolStripMenuItemCreateEmptyMod.Size = new System.Drawing.Size(173, 22);
            this.modListViewNonSelectedToolStripMenuItemCreateEmptyMod.Text = "Create Empty Mod";
            this.modListViewNonSelectedToolStripMenuItemCreateEmptyMod.Click += new System.EventHandler(this.modListViewToolStripMenuItemCreateEmptyMod_Click);
            // 
            // buildButton
            // 
            this.buildButton.FlatAppearance.BorderSize = 0;
            this.buildButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buildButton.Image = global::s3mo.Properties.Resources.icons8_hammer_32;
            this.buildButton.Location = new System.Drawing.Point(345, 8);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(42, 42);
            this.buildButton.TabIndex = 6;
            this.toolTip.SetToolTip(this.buildButton, "Build Merge");
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // checkConflictBetweenModModelBackgroundWorker
            // 
            this.checkConflictBetweenModModelBackgroundWorker.WorkerSupportsCancellation = true;
            this.checkConflictBetweenModModelBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.checkConflictBetweenModModelBackgroundWorker_DoWork);
            this.checkConflictBetweenModModelBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.checkConflictBetweenModModelBackgroundWorker_RunWorkerCompleted);
            // 
            // checkConflictInModModelBackgroundWorker
            // 
            this.checkConflictInModModelBackgroundWorker.WorkerSupportsCancellation = true;
            this.checkConflictInModModelBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.checkConflictInModModelBackgroundWorker_DoWork);
            this.checkConflictInModModelBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.checkConflictInModModelBackgroundWorker_RunWorkerCompleted);
            // 
            // checkDetailedConflictBetweenModModelBackgroundWorker
            // 
            this.checkDetailedConflictBetweenModModelBackgroundWorker.WorkerSupportsCancellation = true;
            this.checkDetailedConflictBetweenModModelBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.checkDetailedConflictBetweenModModelBackgroundWorker_DoWork);
            this.checkDetailedConflictBetweenModModelBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.checkDetailedConflictBetweenModModelBackgroundWorker_RunWorkerCompleted);
            // 
            // installButton
            // 
            this.installButton.BackColor = System.Drawing.Color.Transparent;
            this.installButton.FlatAppearance.BorderSize = 0;
            this.installButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.installButton.Image = global::s3mo.Properties.Resources.icons8_software_installer_32;
            this.installButton.Location = new System.Drawing.Point(57, 8);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(42, 42);
            this.installButton.TabIndex = 7;
            this.toolTip.SetToolTip(this.installButton, "Install");
            this.installButton.UseVisualStyleBackColor = false;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.BackColor = System.Drawing.Color.Transparent;
            this.optionsButton.FlatAppearance.BorderSize = 0;
            this.optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionsButton.Image = global::s3mo.Properties.Resources.icons8_settings_32;
            this.optionsButton.Location = new System.Drawing.Point(105, 8);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(42, 42);
            this.optionsButton.TabIndex = 8;
            this.toolTip.SetToolTip(this.optionsButton, "Settings");
            this.optionsButton.UseVisualStyleBackColor = false;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // clearCacheButton
            // 
            this.clearCacheButton.FlatAppearance.BorderSize = 0;
            this.clearCacheButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearCacheButton.Image = global::s3mo.Properties.Resources.icons8_broom_32;
            this.clearCacheButton.Location = new System.Drawing.Point(249, 8);
            this.clearCacheButton.Name = "clearCacheButton";
            this.clearCacheButton.Size = new System.Drawing.Size(42, 42);
            this.clearCacheButton.TabIndex = 9;
            this.toolTip.SetToolTip(this.clearCacheButton, "Clear Caches");
            this.clearCacheButton.UseVisualStyleBackColor = true;
            this.clearCacheButton.Click += new System.EventHandler(this.clearCacheButton_Click);
            // 
            // openFolderButton
            // 
            this.openFolderButton.FlatAppearance.BorderSize = 0;
            this.openFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFolderButton.Image = global::s3mo.Properties.Resources.icons8_browse_folder_32;
            this.openFolderButton.Location = new System.Drawing.Point(201, 8);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(42, 42);
            this.openFolderButton.TabIndex = 11;
            this.toolTip.SetToolTip(this.openFolderButton, "Folder");
            this.openFolderButton.UseVisualStyleBackColor = true;
            this.openFolderButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.openFolderButton_MouseClick);
            // 
            // profileButton
            // 
            this.profileButton.FlatAppearance.BorderSize = 0;
            this.profileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profileButton.Image = global::s3mo.Properties.Resources.icons8_profiles_32;
            this.profileButton.Location = new System.Drawing.Point(153, 8);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(42, 42);
            this.profileButton.TabIndex = 12;
            this.toolTip.SetToolTip(this.profileButton, "Profiles");
            this.profileButton.UseVisualStyleBackColor = true;
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.FlatAppearance.BorderSize = 0;
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutButton.Image = global::s3mo.Properties.Resources.icons8_info_32;
            this.aboutButton.Location = new System.Drawing.Point(9, 8);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(42, 42);
            this.aboutButton.TabIndex = 13;
            this.toolTip.SetToolTip(this.aboutButton, "Info");
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // warningButton
            // 
            this.warningButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.warningButton.FlatAppearance.BorderSize = 0;
            this.warningButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.warningButton.Image = global::s3mo.Properties.Resources.icons8_general_warning_sign_32;
            this.warningButton.Location = new System.Drawing.Point(758, 27);
            this.warningButton.Name = "warningButton";
            this.warningButton.Size = new System.Drawing.Size(42, 42);
            this.warningButton.TabIndex = 14;
            this.toolTip.SetToolTip(this.warningButton, "Need rebuild");
            this.warningButton.UseVisualStyleBackColor = true;
            // 
            // openFolderContextMenuStrip
            // 
            this.openFolderContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGameFolderToolStripMenuItem,
            this.openGameDocumentsFolderToolStripMenuItem,
            this.openS3MOFolderToolStripMenuItem});
            this.openFolderContextMenuStrip.Name = "openFolderContextMenuStrip";
            this.openFolderContextMenuStrip.Size = new System.Drawing.Size(204, 70);
            // 
            // openGameFolderToolStripMenuItem
            // 
            this.openGameFolderToolStripMenuItem.Name = "openGameFolderToolStripMenuItem";
            this.openGameFolderToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.openGameFolderToolStripMenuItem.Text = "Open Game Folder";
            this.openGameFolderToolStripMenuItem.Click += new System.EventHandler(this.openGameFolderToolStripMenuItem_Click);
            // 
            // openGameDocumentsFolderToolStripMenuItem
            // 
            this.openGameDocumentsFolderToolStripMenuItem.Name = "openGameDocumentsFolderToolStripMenuItem";
            this.openGameDocumentsFolderToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.openGameDocumentsFolderToolStripMenuItem.Text = "Open Documents Folder";
            this.openGameDocumentsFolderToolStripMenuItem.Click += new System.EventHandler(this.openGameDocumentsFolderToolStripMenuItem_Click);
            // 
            // openS3MOFolderToolStripMenuItem
            // 
            this.openS3MOFolderToolStripMenuItem.Name = "openS3MOFolderToolStripMenuItem";
            this.openS3MOFolderToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.openS3MOFolderToolStripMenuItem.Text = "Open S3MO Folder";
            this.openS3MOFolderToolStripMenuItem.Click += new System.EventHandler(this.openS3MOFolderToolStripMenuItem_Click);
            // 
            // validateBackgroundWorker
            // 
            this.validateBackgroundWorker.WorkerSupportsCancellation = true;
            this.validateBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.validateBackgroundWorker_DoWork);
            this.validateBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.validateBackgroundWorker_RunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(769, 585);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(151, 15);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 15;
            this.progressBar.Visible = false;
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressLabel.Location = new System.Drawing.Point(15, 583);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(750, 18);
            this.progressLabel.TabIndex = 16;
            this.progressLabel.Text = "ProgressLabel";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.progressLabel.Visible = false;
            // 
            // md5BackgroundWorker
            // 
            this.md5BackgroundWorker.WorkerSupportsCancellation = true;
            this.md5BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.md5BackgroundWorker_DoWork);
            this.md5BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.md5BackgroundWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 606);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.warningButton);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.profileButton);
            this.Controls.Add(this.openFolderButton);
            this.Controls.Add(this.clearCacheButton);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.profileComboBox);
            this.Controls.Add(this.installButton);
            this.Controls.Add(this.profileLabel);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Sims 3 Mod Organizer v1.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.modGroupBox.ResumeLayout(false);
            this.fileGroupBox.ResumeLayout(false);
            this.fileTabControl.ResumeLayout(false);
            this.modTabPage.ResumeLayout(false);
            this.logGroupBox.ResumeLayout(false);
            this.modListViewContextMenuStrip.ResumeLayout(false);
            this.modListViewNonSelectedContextMenuStrip.ResumeLayout(false);
            this.openFolderContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private ListBox logListBox;
        private Button refreshButton;
        private s3mo.ModListView modListView;
        private ColumnHeader modHeader;
        private ColumnHeader priorityHeader;
        private Button playButton;
        private OpenFileDialog openFileDialog;
        private TabControl fileTabControl;
        private ComboBox profileComboBox;
        private Label profileLabel;
        private ColumnHeader flagHeader;
        private ContextMenuStrip modListViewContextMenuStrip;
        private ToolStripMenuItem modListViewToolStripMenuItemOpenInExplorer;
        private ToolStripMenuItem modListViewToolStripMenuItemDelete;
        private ToolStripMenuItem modListViewToolStripMenuItemRename;
        private ToolStripSeparator toolStripSeparator2;
        private TabPage modTabPage;
        private ListView fileListView;
        private ColumnHeader fileHeader;
        private ContextMenuStrip modListViewNonSelectedContextMenuStrip;
        private ToolStripMenuItem modListViewNonSelectedToolStripMenuItemCreateEmptyMod;
        private ColumnHeader fileFlagHeader;
        private Button buildButton;
        private System.ComponentModel.BackgroundWorker checkConflictBetweenModModelBackgroundWorker;
        private System.ComponentModel.BackgroundWorker checkConflictInModModelBackgroundWorker;
        private System.ComponentModel.BackgroundWorker checkDetailedConflictBetweenModModelBackgroundWorker;
        private GroupBox logGroupBox;
        private GroupBox modGroupBox;
        private GroupBox fileGroupBox;
        private Button installButton;
        private Button optionsButton;
        private Button clearCacheButton;
        private ToolTip toolTip;
        private ContextMenuStrip openFolderContextMenuStrip;
        private ToolStripMenuItem openGameFolderToolStripMenuItem;
        private ToolStripMenuItem openGameDocumentsFolderToolStripMenuItem;
        private ToolStripMenuItem openS3MOFolderToolStripMenuItem;
        private Button openFolderButton;
        private Button profileButton;
        private Button aboutButton;
        private Button warningButton;
        private System.ComponentModel.BackgroundWorker validateBackgroundWorker;
        private ProgressBar progressBar;
        private Label progressLabel;
        private System.ComponentModel.BackgroundWorker md5BackgroundWorker;
        private ToolStripMenuItem modListViewToolStripMenuItemEnableSelected;
        private ToolStripMenuItem modListViewToolStripMenuItemDisableSelected;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem modListViewToolStripMenuItemInformation;
    }
}