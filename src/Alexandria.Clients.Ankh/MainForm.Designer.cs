namespace Telesophy.Alexandria.Clients.Ankh
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				// Dispose other objects here
							
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.PlayPauseButton = new System.Windows.Forms.Button();
			this.StopButton = new System.Windows.Forms.Button();
			this.PlaybackTrackBar = new System.Windows.Forms.TrackBar();
			this.VolumeTrackBar = new System.Windows.Forms.TrackBar();
			this.MuteButton = new System.Windows.Forms.Button();
			this.FileMenuStrip = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.catalogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadCatalogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveSelectedCatalogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteSelectedCatalogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importCatalogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.currentStatusToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.FileOpenDialog = new System.Windows.Forms.OpenFileDialog();
			this.NextButton = new System.Windows.Forms.Button();
			this.PlaybackTimer = new System.Windows.Forms.Timer(this.components);
			this.PlaybackGroupBox = new System.Windows.Forms.GroupBox();
			this.PreviousButton = new System.Windows.Forms.Button();
			this.NowPlayingLabel = new System.Windows.Forms.Label();
			this.NowPlayingTitle = new System.Windows.Forms.Label();
			this.OuterPlaybackQueueSplit = new System.Windows.Forms.SplitContainer();
			this.UpperPlaybackStatusSplit = new System.Windows.Forms.SplitContainer();
			this.TasksGroupBox = new System.Windows.Forms.GroupBox();
			this.submitCheckBox = new System.Windows.Forms.CheckBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.ToolBoxGroupBox = new System.Windows.Forms.GroupBox();
			this.ToolBoxListView = new System.Windows.Forms.ListView();
			this.ToolBoxContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ToolBoxContextMenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolBoxSmallImageList = new System.Windows.Forms.ImageList(this.components);
			this.QueueGroupBox = new System.Windows.Forms.GroupBox();
			this.clearAllSortButton = new System.Windows.Forms.Button();
			this.clearSelectedSortButton = new System.Windows.Forms.Button();
			this.orFilterButton = new System.Windows.Forms.Button();
			this.andFilterButton = new System.Windows.Forms.Button();
			this.notFilterButton = new System.Windows.Forms.Button();
			this.filterListView = new System.Windows.Forms.ListView();
			this.filterContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.filterContextMenuItemAddFilter = new System.Windows.Forms.ToolStripComboBox();
			this.sortListView = new System.Windows.Forms.ListView();
			this.sortContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.sortContextMenuStripItemClearSelected = new System.Windows.Forms.ToolStripMenuItem();
			this.sortContextMenuStripItemClearAll = new System.Windows.Forms.ToolStripMenuItem();
			this.sortSmallImageList = new System.Windows.Forms.ImageList(this.components);
			this.filterButton = new System.Windows.Forms.Button();
			this.sortButton = new System.Windows.Forms.Button();
			this.queueSmallImageList = new System.Windows.Forms.ImageList(this.components);
			this.DirectoryOpenDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.filterContextMenuItemClearAll = new System.Windows.Forms.ToolStripMenuItem();
			this.queueDataGrid = new Telesophy.Alexandria.Clients.Ankh.Views.AdvancedDataGridView();
			this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Type = new System.Windows.Forms.DataGridViewImageColumn();
			this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Artist = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Album = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Format = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.PlaybackTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).BeginInit();
			this.FileMenuStrip.SuspendLayout();
			this.StatusStrip.SuspendLayout();
			this.PlaybackGroupBox.SuspendLayout();
			this.OuterPlaybackQueueSplit.Panel1.SuspendLayout();
			this.OuterPlaybackQueueSplit.Panel2.SuspendLayout();
			this.OuterPlaybackQueueSplit.SuspendLayout();
			this.UpperPlaybackStatusSplit.Panel1.SuspendLayout();
			this.UpperPlaybackStatusSplit.Panel2.SuspendLayout();
			this.UpperPlaybackStatusSplit.SuspendLayout();
			this.TasksGroupBox.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.ToolBoxGroupBox.SuspendLayout();
			this.ToolBoxContextMenuStrip.SuspendLayout();
			this.QueueGroupBox.SuspendLayout();
			this.filterContextMenuStrip.SuspendLayout();
			this.sortContextMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.queueDataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// PlayPauseButton
			// 
			this.PlayPauseButton.BackgroundImage = global::Telesophy.Alexandria.Clients.Ankh.Properties.Resources.control_play_blue;
			resources.ApplyResources(this.PlayPauseButton, "PlayPauseButton");
			this.PlayPauseButton.Name = "PlayPauseButton";
			this.PlayPauseButton.UseVisualStyleBackColor = true;
			// 
			// StopButton
			// 
			this.StopButton.BackgroundImage = global::Telesophy.Alexandria.Clients.Ankh.Properties.Resources.control_stop_blue;
			resources.ApplyResources(this.StopButton, "StopButton");
			this.StopButton.Name = "StopButton";
			this.StopButton.UseVisualStyleBackColor = true;
			// 
			// PlaybackTrackBar
			// 
			resources.ApplyResources(this.PlaybackTrackBar, "PlaybackTrackBar");
			this.PlaybackTrackBar.Name = "PlaybackTrackBar";
			this.PlaybackTrackBar.TickFrequency = 10000;
			this.PlaybackTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.PlaybackTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlaybackTrackBar_MouseDown);
			this.PlaybackTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PlaybackTrackBar_MouseUp);
			// 
			// VolumeTrackBar
			// 
			resources.ApplyResources(this.VolumeTrackBar, "VolumeTrackBar");
			this.VolumeTrackBar.Name = "VolumeTrackBar";
			this.VolumeTrackBar.Value = 10;
			this.VolumeTrackBar.ValueChanged += new System.EventHandler(this.VolumeTrackBar_ValueChanged);
			// 
			// MuteButton
			// 
			resources.ApplyResources(this.MuteButton, "MuteButton");
			this.MuteButton.BackgroundImage = global::Telesophy.Alexandria.Clients.Ankh.Properties.Resources.sound_mute;
			this.MuteButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MuteButton.Name = "MuteButton";
			this.MuteButton.UseVisualStyleBackColor = true;
			// 
			// FileMenuStrip
			// 
			this.FileMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.catalogToolStripMenuItem,
            this.userToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.HelpToolStripMenuItem});
			resources.ApplyResources(this.FileMenuStrip, "FileMenuStrip");
			this.FileMenuStrip.Name = "FileMenuStrip";
			// 
			// FileToolStripMenuItem
			// 
			this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.OpenDirectoryToolStripMenuItem,
            this.ExitToolStripMenuItem});
			this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
			resources.ApplyResources(this.FileToolStripMenuItem, "FileToolStripMenuItem");
			// 
			// OpenToolStripMenuItem
			// 
			this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
			resources.ApplyResources(this.OpenToolStripMenuItem, "OpenToolStripMenuItem");
			// 
			// OpenDirectoryToolStripMenuItem
			// 
			this.OpenDirectoryToolStripMenuItem.Name = "OpenDirectoryToolStripMenuItem";
			resources.ApplyResources(this.OpenDirectoryToolStripMenuItem, "OpenDirectoryToolStripMenuItem");
			this.OpenDirectoryToolStripMenuItem.Click += new System.EventHandler(this.OpenDirectoryToolStripMenuItem_Click);
			// 
			// ExitToolStripMenuItem
			// 
			this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
			resources.ApplyResources(this.ExitToolStripMenuItem, "ExitToolStripMenuItem");
			this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearSelectedToolStripMenuItem,
            this.clearToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
			// 
			// clearSelectedToolStripMenuItem
			// 
			this.clearSelectedToolStripMenuItem.Name = "clearSelectedToolStripMenuItem";
			resources.ApplyResources(this.clearSelectedToolStripMenuItem, "clearSelectedToolStripMenuItem");
			this.clearSelectedToolStripMenuItem.Click += new System.EventHandler(this.clearSelectedToolStripMenuItem_Click);
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			resources.ApplyResources(this.clearToolStripMenuItem, "clearToolStripMenuItem");
			this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
			// 
			// catalogToolStripMenuItem
			// 
			this.catalogToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadCatalogToolStripMenuItem,
            this.saveSelectedCatalogToolStripMenuItem,
            this.deleteSelectedCatalogToolStripMenuItem,
            this.importCatalogToolStripMenuItem});
			this.catalogToolStripMenuItem.Name = "catalogToolStripMenuItem";
			resources.ApplyResources(this.catalogToolStripMenuItem, "catalogToolStripMenuItem");
			// 
			// loadCatalogToolStripMenuItem
			// 
			this.loadCatalogToolStripMenuItem.Name = "loadCatalogToolStripMenuItem";
			resources.ApplyResources(this.loadCatalogToolStripMenuItem, "loadCatalogToolStripMenuItem");
			this.loadCatalogToolStripMenuItem.Click += new System.EventHandler(this.loadCatalogToolStripMenuItem_Click);
			// 
			// saveSelectedCatalogToolStripMenuItem
			// 
			this.saveSelectedCatalogToolStripMenuItem.Name = "saveSelectedCatalogToolStripMenuItem";
			resources.ApplyResources(this.saveSelectedCatalogToolStripMenuItem, "saveSelectedCatalogToolStripMenuItem");
			this.saveSelectedCatalogToolStripMenuItem.Click += new System.EventHandler(this.saveSelectedCatalogToolStripMenuItem_Click);
			// 
			// deleteSelectedCatalogToolStripMenuItem
			// 
			this.deleteSelectedCatalogToolStripMenuItem.Name = "deleteSelectedCatalogToolStripMenuItem";
			resources.ApplyResources(this.deleteSelectedCatalogToolStripMenuItem, "deleteSelectedCatalogToolStripMenuItem");
			this.deleteSelectedCatalogToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedCatalogToolStripMenuItem_Click);
			// 
			// importCatalogToolStripMenuItem
			// 
			this.importCatalogToolStripMenuItem.Name = "importCatalogToolStripMenuItem";
			resources.ApplyResources(this.importCatalogToolStripMenuItem, "importCatalogToolStripMenuItem");
			this.importCatalogToolStripMenuItem.Click += new System.EventHandler(this.importCatalogToolStripMenuItem_Click);
			// 
			// userToolStripMenuItem
			// 
			this.userToolStripMenuItem.Name = "userToolStripMenuItem";
			resources.ApplyResources(this.userToolStripMenuItem, "userToolStripMenuItem");
			// 
			// ToolsToolStripMenuItem
			// 
			this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pluginsToolStripMenuItem,
            this.toolManagerToolStripMenuItem});
			this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
			resources.ApplyResources(this.ToolsToolStripMenuItem, "ToolsToolStripMenuItem");
			// 
			// pluginsToolStripMenuItem
			// 
			this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
			resources.ApplyResources(this.pluginsToolStripMenuItem, "pluginsToolStripMenuItem");
			// 
			// toolManagerToolStripMenuItem
			// 
			this.toolManagerToolStripMenuItem.Name = "toolManagerToolStripMenuItem";
			resources.ApplyResources(this.toolManagerToolStripMenuItem, "toolManagerToolStripMenuItem");
			// 
			// HelpToolStripMenuItem
			// 
			this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
			this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
			resources.ApplyResources(this.HelpToolStripMenuItem, "HelpToolStripMenuItem");
			// 
			// AboutToolStripMenuItem
			// 
			this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
			resources.ApplyResources(this.AboutToolStripMenuItem, "AboutToolStripMenuItem");
			this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusToolStripLabel});
			resources.ApplyResources(this.StatusStrip, "StatusStrip");
			this.StatusStrip.Name = "StatusStrip";
			// 
			// currentStatusToolStripLabel
			// 
			this.currentStatusToolStripLabel.Name = "currentStatusToolStripLabel";
			resources.ApplyResources(this.currentStatusToolStripLabel, "currentStatusToolStripLabel");
			// 
			// NextButton
			// 
			this.NextButton.BackgroundImage = global::Telesophy.Alexandria.Clients.Ankh.Properties.Resources.control_end_blue;
			resources.ApplyResources(this.NextButton, "NextButton");
			this.NextButton.Name = "NextButton";
			this.NextButton.UseVisualStyleBackColor = true;
			// 
			// PlaybackTimer
			// 
			this.PlaybackTimer.Enabled = true;
			this.PlaybackTimer.Interval = 1000;
			this.PlaybackTimer.Tick += new System.EventHandler(this.PlaybackTimer_Tick);
			// 
			// PlaybackGroupBox
			// 
			resources.ApplyResources(this.PlaybackGroupBox, "PlaybackGroupBox");
			this.PlaybackGroupBox.Controls.Add(this.PreviousButton);
			this.PlaybackGroupBox.Controls.Add(this.NowPlayingLabel);
			this.PlaybackGroupBox.Controls.Add(this.NowPlayingTitle);
			this.PlaybackGroupBox.Controls.Add(this.NextButton);
			this.PlaybackGroupBox.Controls.Add(this.MuteButton);
			this.PlaybackGroupBox.Controls.Add(this.VolumeTrackBar);
			this.PlaybackGroupBox.Controls.Add(this.PlayPauseButton);
			this.PlaybackGroupBox.Controls.Add(this.StopButton);
			this.PlaybackGroupBox.Controls.Add(this.PlaybackTrackBar);
			this.PlaybackGroupBox.Name = "PlaybackGroupBox";
			this.PlaybackGroupBox.TabStop = false;
			// 
			// PreviousButton
			// 
			this.PreviousButton.BackgroundImage = global::Telesophy.Alexandria.Clients.Ankh.Properties.Resources.control_start_blue;
			resources.ApplyResources(this.PreviousButton, "PreviousButton");
			this.PreviousButton.Name = "PreviousButton";
			this.PreviousButton.UseVisualStyleBackColor = true;
			// 
			// NowPlayingLabel
			// 
			resources.ApplyResources(this.NowPlayingLabel, "NowPlayingLabel");
			this.NowPlayingLabel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.NowPlayingLabel.Name = "NowPlayingLabel";
			// 
			// NowPlayingTitle
			// 
			resources.ApplyResources(this.NowPlayingTitle, "NowPlayingTitle");
			this.NowPlayingTitle.Name = "NowPlayingTitle";
			// 
			// OuterPlaybackQueueSplit
			// 
			resources.ApplyResources(this.OuterPlaybackQueueSplit, "OuterPlaybackQueueSplit");
			this.OuterPlaybackQueueSplit.Name = "OuterPlaybackQueueSplit";
			// 
			// OuterPlaybackQueueSplit.Panel1
			// 
			this.OuterPlaybackQueueSplit.Panel1.Controls.Add(this.UpperPlaybackStatusSplit);
			// 
			// OuterPlaybackQueueSplit.Panel2
			// 
			this.OuterPlaybackQueueSplit.Panel2.Controls.Add(this.splitContainer1);
			// 
			// UpperPlaybackStatusSplit
			// 
			resources.ApplyResources(this.UpperPlaybackStatusSplit, "UpperPlaybackStatusSplit");
			this.UpperPlaybackStatusSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.UpperPlaybackStatusSplit.Name = "UpperPlaybackStatusSplit";
			// 
			// UpperPlaybackStatusSplit.Panel1
			// 
			this.UpperPlaybackStatusSplit.Panel1.Controls.Add(this.PlaybackGroupBox);
			// 
			// UpperPlaybackStatusSplit.Panel2
			// 
			this.UpperPlaybackStatusSplit.Panel2.Controls.Add(this.TasksGroupBox);
			// 
			// TasksGroupBox
			// 
			resources.ApplyResources(this.TasksGroupBox, "TasksGroupBox");
			this.TasksGroupBox.Controls.Add(this.submitCheckBox);
			this.TasksGroupBox.Name = "TasksGroupBox";
			this.TasksGroupBox.TabStop = false;
			// 
			// submitCheckBox
			// 
			resources.ApplyResources(this.submitCheckBox, "submitCheckBox");
			this.submitCheckBox.Name = "submitCheckBox";
			this.submitCheckBox.UseVisualStyleBackColor = true;
			this.submitCheckBox.CheckedChanged += new System.EventHandler(this.submitCheckBox_CheckedChanged);
			// 
			// splitContainer1
			// 
			resources.ApplyResources(this.splitContainer1, "splitContainer1");
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.ToolBoxGroupBox);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.QueueGroupBox);
			// 
			// ToolBoxGroupBox
			// 
			resources.ApplyResources(this.ToolBoxGroupBox, "ToolBoxGroupBox");
			this.ToolBoxGroupBox.Controls.Add(this.ToolBoxListView);
			this.ToolBoxGroupBox.Name = "ToolBoxGroupBox";
			this.ToolBoxGroupBox.TabStop = false;
			// 
			// ToolBoxListView
			// 
			resources.ApplyResources(this.ToolBoxListView, "ToolBoxListView");
			this.ToolBoxListView.ContextMenuStrip = this.ToolBoxContextMenuStrip;
			this.ToolBoxListView.MultiSelect = false;
			this.ToolBoxListView.Name = "ToolBoxListView";
			this.ToolBoxListView.ShowItemToolTips = true;
			this.ToolBoxListView.SmallImageList = this.ToolBoxSmallImageList;
			this.ToolBoxListView.UseCompatibleStateImageBehavior = false;
			this.ToolBoxListView.View = System.Windows.Forms.View.SmallIcon;
			this.ToolBoxListView.DragLeave += new System.EventHandler(this.ToolBoxListView_DragLeave);
			this.ToolBoxListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ToolBoxListView_ItemDrag);
			this.ToolBoxListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolBoxListView_MouseDown);
			// 
			// ToolBoxContextMenuStrip
			// 
			this.ToolBoxContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolBoxContextMenuItemRefresh});
			this.ToolBoxContextMenuStrip.Name = "ToolBoxContextMenuStrip";
			resources.ApplyResources(this.ToolBoxContextMenuStrip, "ToolBoxContextMenuStrip");
			this.ToolBoxContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolBoxContextMenuStrip_ItemClicked);
			// 
			// ToolBoxContextMenuItemRefresh
			// 
			this.ToolBoxContextMenuItemRefresh.Name = "ToolBoxContextMenuItemRefresh";
			resources.ApplyResources(this.ToolBoxContextMenuItemRefresh, "ToolBoxContextMenuItemRefresh");
			// 
			// ToolBoxSmallImageList
			// 
			this.ToolBoxSmallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ToolBoxSmallImageList.ImageStream")));
			this.ToolBoxSmallImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.ToolBoxSmallImageList.Images.SetKeyName(0, "drive.png");
			this.ToolBoxSmallImageList.Images.SetKeyName(1, "drive_cd.png");
			this.ToolBoxSmallImageList.Images.SetKeyName(2, "drive_cd_empty.png");
			this.ToolBoxSmallImageList.Images.SetKeyName(3, "feed.png");
			// 
			// QueueGroupBox
			// 
			resources.ApplyResources(this.QueueGroupBox, "QueueGroupBox");
			this.QueueGroupBox.Controls.Add(this.clearAllSortButton);
			this.QueueGroupBox.Controls.Add(this.clearSelectedSortButton);
			this.QueueGroupBox.Controls.Add(this.orFilterButton);
			this.QueueGroupBox.Controls.Add(this.andFilterButton);
			this.QueueGroupBox.Controls.Add(this.notFilterButton);
			this.QueueGroupBox.Controls.Add(this.filterListView);
			this.QueueGroupBox.Controls.Add(this.sortListView);
			this.QueueGroupBox.Controls.Add(this.filterButton);
			this.QueueGroupBox.Controls.Add(this.sortButton);
			this.QueueGroupBox.Controls.Add(this.queueDataGrid);
			this.QueueGroupBox.Name = "QueueGroupBox";
			this.QueueGroupBox.TabStop = false;
			// 
			// clearAllSortButton
			// 
			resources.ApplyResources(this.clearAllSortButton, "clearAllSortButton");
			this.clearAllSortButton.Name = "clearAllSortButton";
			this.clearAllSortButton.UseVisualStyleBackColor = true;
			this.clearAllSortButton.Click += new System.EventHandler(this.clearAllSortButton_Click);
			// 
			// clearSelectedSortButton
			// 
			resources.ApplyResources(this.clearSelectedSortButton, "clearSelectedSortButton");
			this.clearSelectedSortButton.Name = "clearSelectedSortButton";
			this.clearSelectedSortButton.UseVisualStyleBackColor = true;
			this.clearSelectedSortButton.Click += new System.EventHandler(this.clearSelectedSortButton_Click);
			// 
			// orFilterButton
			// 
			resources.ApplyResources(this.orFilterButton, "orFilterButton");
			this.orFilterButton.Name = "orFilterButton";
			this.orFilterButton.UseVisualStyleBackColor = true;
			this.orFilterButton.Click += new System.EventHandler(this.orFilterButton_Click);
			// 
			// andFilterButton
			// 
			resources.ApplyResources(this.andFilterButton, "andFilterButton");
			this.andFilterButton.Name = "andFilterButton";
			this.andFilterButton.UseVisualStyleBackColor = true;
			this.andFilterButton.Click += new System.EventHandler(this.andFilterButton_Click);
			// 
			// notFilterButton
			// 
			resources.ApplyResources(this.notFilterButton, "notFilterButton");
			this.notFilterButton.Name = "notFilterButton";
			this.notFilterButton.UseVisualStyleBackColor = true;
			this.notFilterButton.Click += new System.EventHandler(this.notFilterButton_Click);
			// 
			// filterListView
			// 
			this.filterListView.ContextMenuStrip = this.filterContextMenuStrip;
			resources.ApplyResources(this.filterListView, "filterListView");
			this.filterListView.Name = "filterListView";
			this.filterListView.UseCompatibleStateImageBehavior = false;
			this.filterListView.View = System.Windows.Forms.View.List;
			this.filterListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.filterListView_KeyUp);
			// 
			// filterContextMenuStrip
			// 
			this.filterContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterContextMenuItemAddFilter,
            this.filterContextMenuItemClearAll});
			this.filterContextMenuStrip.Name = "filterContextMenuStrip";
			resources.ApplyResources(this.filterContextMenuStrip, "filterContextMenuStrip");
			// 
			// filterContextMenuItemAddFilter
			// 
			this.filterContextMenuItemAddFilter.Name = "filterContextMenuItemAddFilter";
			resources.ApplyResources(this.filterContextMenuItemAddFilter, "filterContextMenuItemAddFilter");
			this.filterContextMenuItemAddFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.filterContextMenuItemAddFilter_KeyUp);
			// 
			// sortListView
			// 
			this.sortListView.AllowDrop = true;
			this.sortListView.ContextMenuStrip = this.sortContextMenuStrip;
			resources.ApplyResources(this.sortListView, "sortListView");
			this.sortListView.MultiSelect = false;
			this.sortListView.Name = "sortListView";
			this.sortListView.SmallImageList = this.sortSmallImageList;
			this.sortListView.UseCompatibleStateImageBehavior = false;
			this.sortListView.View = System.Windows.Forms.View.List;
			this.sortListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.sortListView_DragEnter);
			this.sortListView.ItemActivate += new System.EventHandler(this.sortListView_ItemActivate);
			this.sortListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.sortListView_DragDrop);
			this.sortListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.sortListView_KeyUp);
			this.sortListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.sortListView_ItemDrag);
			// 
			// sortContextMenuStrip
			// 
			this.sortContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortContextMenuStripItemClearSelected,
            this.sortContextMenuStripItemClearAll});
			this.sortContextMenuStrip.Name = "sortContextMenuStrip";
			resources.ApplyResources(this.sortContextMenuStrip, "sortContextMenuStrip");
			this.sortContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.sortContextMenuStrip_Opening);
			// 
			// sortContextMenuStripItemClearSelected
			// 
			this.sortContextMenuStripItemClearSelected.Name = "sortContextMenuStripItemClearSelected";
			resources.ApplyResources(this.sortContextMenuStripItemClearSelected, "sortContextMenuStripItemClearSelected");
			this.sortContextMenuStripItemClearSelected.Click += new System.EventHandler(this.sortContextMenuStripItemClearSelected_Click);
			// 
			// sortContextMenuStripItemClearAll
			// 
			this.sortContextMenuStripItemClearAll.Name = "sortContextMenuStripItemClearAll";
			resources.ApplyResources(this.sortContextMenuStripItemClearAll, "sortContextMenuStripItemClearAll");
			this.sortContextMenuStripItemClearAll.Click += new System.EventHandler(this.sortContextMenuStripItemClearAll_Click);
			// 
			// sortSmallImageList
			// 
			this.sortSmallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("sortSmallImageList.ImageStream")));
			this.sortSmallImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.sortSmallImageList.Images.SetKeyName(0, "arrow_up.png");
			this.sortSmallImageList.Images.SetKeyName(1, "arrow_down.png");
			// 
			// filterButton
			// 
			resources.ApplyResources(this.filterButton, "filterButton");
			this.filterButton.Name = "filterButton";
			this.filterButton.UseVisualStyleBackColor = true;
			this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
			// 
			// sortButton
			// 
			resources.ApplyResources(this.sortButton, "sortButton");
			this.sortButton.Name = "sortButton";
			this.sortButton.UseVisualStyleBackColor = true;
			this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
			// 
			// queueSmallImageList
			// 
			this.queueSmallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("queueSmallImageList.ImageStream")));
			this.queueSmallImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.queueSmallImageList.Images.SetKeyName(0, "music.png");
			this.queueSmallImageList.Images.SetKeyName(1, "picture.png");
			this.queueSmallImageList.Images.SetKeyName(2, "book_open.png");
			this.queueSmallImageList.Images.SetKeyName(3, "film.png");
			this.queueSmallImageList.Images.SetKeyName(4, "television.png");
			// 
			// DirectoryOpenDialog
			// 
			resources.ApplyResources(this.DirectoryOpenDialog, "DirectoryOpenDialog");
			// 
			// filterContextMenuItemClearAll
			// 
			this.filterContextMenuItemClearAll.Name = "filterContextMenuItemClearAll";
			resources.ApplyResources(this.filterContextMenuItemClearAll, "filterContextMenuItemClearAll");
			this.filterContextMenuItemClearAll.Click += new System.EventHandler(this.filterContextMenuItemClearAll_Click);
			// 
			// queueDataGrid
			// 
			this.queueDataGrid.AllowDrop = true;
			this.queueDataGrid.AllowUserToAddRows = false;
			this.queueDataGrid.AllowUserToOrderColumns = true;
			this.queueDataGrid.AllowUserToResizeRows = false;
			resources.ApplyResources(this.queueDataGrid, "queueDataGrid");
			this.queueDataGrid.ColumnDragDropped = null;
			this.queueDataGrid.ColumnDragDropping = null;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.queueDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.queueDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.queueDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status,
            this.Type,
            this.Source,
            this.Number,
            this.Title,
            this.Artist,
            this.Album,
            this.Duration,
            this.Date,
            this.Format,
            this.Path,
            this.Id});
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.queueDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
			this.queueDataGrid.Name = "queueDataGrid";
			this.queueDataGrid.RowDragDropped = null;
			this.queueDataGrid.RowDragDropping = null;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.queueDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.queueDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.queueDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.queueDataGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.queueDataGrid_ColumnHeaderMouseClick);
			this.queueDataGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.queueDataGrid_CellMouseDoubleClick);
			this.queueDataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.queueDataGrid_DataError);
			this.queueDataGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.queueDataGrid_KeyUp);
			// 
			// Status
			// 
			this.Status.DataPropertyName = "Status";
			resources.ApplyResources(this.Status, "Status");
			this.Status.Name = "Status";
			this.Status.ReadOnly = true;
			this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// Type
			// 
			this.Type.DataPropertyName = "Type";
			resources.ApplyResources(this.Type, "Type");
			this.Type.Name = "Type";
			this.Type.ReadOnly = true;
			this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// Source
			// 
			this.Source.DataPropertyName = "Source";
			resources.ApplyResources(this.Source, "Source");
			this.Source.Name = "Source";
			this.Source.ReadOnly = true;
			this.Source.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// Number
			// 
			this.Number.DataPropertyName = "Number";
			resources.ApplyResources(this.Number, "Number");
			this.Number.Name = "Number";
			this.Number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// Title
			// 
			this.Title.DataPropertyName = "Title";
			resources.ApplyResources(this.Title, "Title");
			this.Title.Name = "Title";
			this.Title.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// Artist
			// 
			this.Artist.DataPropertyName = "Artist";
			resources.ApplyResources(this.Artist, "Artist");
			this.Artist.Name = "Artist";
			this.Artist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// Album
			// 
			this.Album.DataPropertyName = "Album";
			resources.ApplyResources(this.Album, "Album");
			this.Album.Name = "Album";
			this.Album.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// Duration
			// 
			this.Duration.DataPropertyName = "Duration";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.Duration.DefaultCellStyle = dataGridViewCellStyle2;
			resources.ApplyResources(this.Duration, "Duration");
			this.Duration.Name = "Duration";
			this.Duration.ReadOnly = true;
			this.Duration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// Date
			// 
			this.Date.DataPropertyName = "Date";
			resources.ApplyResources(this.Date, "Date");
			this.Date.Name = "Date";
			this.Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// Format
			// 
			this.Format.DataPropertyName = "Format";
			resources.ApplyResources(this.Format, "Format");
			this.Format.Name = "Format";
			this.Format.ReadOnly = true;
			this.Format.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// Path
			// 
			this.Path.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Path.DataPropertyName = "Path";
			resources.ApplyResources(this.Path, "Path");
			this.Path.Name = "Path";
			this.Path.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// Id
			// 
			this.Id.DataPropertyName = "Id";
			resources.ApplyResources(this.Id, "Id");
			this.Id.Name = "Id";
			this.Id.ReadOnly = true;
			this.Id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.OuterPlaybackQueueSplit);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.FileMenuStrip);
			this.MainMenuStrip = this.FileMenuStrip;
			this.Name = "MainForm";
			((System.ComponentModel.ISupportInitialize)(this.PlaybackTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).EndInit();
			this.FileMenuStrip.ResumeLayout(false);
			this.FileMenuStrip.PerformLayout();
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.PlaybackGroupBox.ResumeLayout(false);
			this.PlaybackGroupBox.PerformLayout();
			this.OuterPlaybackQueueSplit.Panel1.ResumeLayout(false);
			this.OuterPlaybackQueueSplit.Panel2.ResumeLayout(false);
			this.OuterPlaybackQueueSplit.ResumeLayout(false);
			this.UpperPlaybackStatusSplit.Panel1.ResumeLayout(false);
			this.UpperPlaybackStatusSplit.Panel2.ResumeLayout(false);
			this.UpperPlaybackStatusSplit.ResumeLayout(false);
			this.TasksGroupBox.ResumeLayout(false);
			this.TasksGroupBox.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.ToolBoxGroupBox.ResumeLayout(false);
			this.ToolBoxContextMenuStrip.ResumeLayout(false);
			this.QueueGroupBox.ResumeLayout(false);
			this.filterContextMenuStrip.ResumeLayout(false);
			this.sortContextMenuStrip.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.queueDataGrid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button PlayPauseButton;
		private System.Windows.Forms.Button StopButton;
		private System.Windows.Forms.TrackBar PlaybackTrackBar;
		private System.Windows.Forms.TrackBar VolumeTrackBar;
		private System.Windows.Forms.Button MuteButton;
		private System.Windows.Forms.MenuStrip FileMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
		private System.Windows.Forms.StatusStrip StatusStrip;
		private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog FileOpenDialog;
		private System.Windows.Forms.Button NextButton;
		private System.Windows.Forms.Timer PlaybackTimer;
		private System.Windows.Forms.GroupBox PlaybackGroupBox;
		private System.Windows.Forms.SplitContainer OuterPlaybackQueueSplit;
		private System.Windows.Forms.GroupBox QueueGroupBox;
		private System.Windows.Forms.SplitContainer UpperPlaybackStatusSplit;
		private System.Windows.Forms.GroupBox TasksGroupBox;
		private System.Windows.Forms.Label NowPlayingLabel;
		private System.Windows.Forms.Label NowPlayingTitle;
		private System.Windows.Forms.Button PreviousButton;
		private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem catalogToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.GroupBox ToolBoxGroupBox;
		private System.Windows.Forms.ListView ToolBoxListView;
		private System.Windows.Forms.ImageList ToolBoxSmallImageList;
		private System.Windows.Forms.ContextMenuStrip ToolBoxContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem ToolBoxContextMenuItemRefresh;
		private System.Windows.Forms.ToolStripMenuItem toolManagerToolStripMenuItem;
		private Telesophy.Alexandria.Clients.Ankh.Views.AdvancedDataGridView queueDataGrid;
		private System.Windows.Forms.ImageList queueSmallImageList;
		private System.Windows.Forms.ContextMenuStrip sortContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem sortContextMenuStripItemClearSelected;
		private System.Windows.Forms.ToolStripMenuItem OpenDirectoryToolStripMenuItem;
		private System.Windows.Forms.FolderBrowserDialog DirectoryOpenDialog;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
		private System.Windows.Forms.Button sortButton;
		private System.Windows.Forms.ToolStripMenuItem clearSelectedToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel currentStatusToolStripLabel;
		private System.Windows.Forms.CheckBox submitCheckBox;
		private System.Windows.Forms.ToolStripMenuItem saveSelectedCatalogToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteSelectedCatalogToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadCatalogToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importCatalogToolStripMenuItem;
		private System.Windows.Forms.Button filterButton;
		private System.Windows.Forms.ListView sortListView;
		private System.Windows.Forms.ImageList sortSmallImageList;
		private System.Windows.Forms.ListView filterListView;
		private System.Windows.Forms.ToolStripMenuItem sortContextMenuStripItemClearAll;
		private System.Windows.Forms.DataGridViewTextBoxColumn Status;
		private System.Windows.Forms.DataGridViewImageColumn Type;
		private System.Windows.Forms.DataGridViewTextBoxColumn Source;
		private System.Windows.Forms.DataGridViewTextBoxColumn Number;
		private System.Windows.Forms.DataGridViewTextBoxColumn Title;
		private System.Windows.Forms.DataGridViewTextBoxColumn Artist;
		private System.Windows.Forms.DataGridViewTextBoxColumn Album;
		private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
		private System.Windows.Forms.DataGridViewTextBoxColumn Date;
		private System.Windows.Forms.DataGridViewTextBoxColumn Format;
		private System.Windows.Forms.DataGridViewTextBoxColumn Path;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id;
		private System.Windows.Forms.ContextMenuStrip filterContextMenuStrip;
		private System.Windows.Forms.ToolStripComboBox filterContextMenuItemAddFilter;
		private System.Windows.Forms.Button notFilterButton;
		private System.Windows.Forms.Button orFilterButton;
		private System.Windows.Forms.Button andFilterButton;
		private System.Windows.Forms.Button clearAllSortButton;
		private System.Windows.Forms.Button clearSelectedSortButton;
		private System.Windows.Forms.ToolStripMenuItem filterContextMenuItemClearAll;
	}
}

