namespace Visual_NXC
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
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("While");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Loops", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Set Ultrasonic Sensor");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Sensors", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewGeneratedNXCCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCompilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectNextTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectPreviousTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeCurrentTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.centerCanvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpVisualNXCWikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutQuickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsQuickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showNavigationMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.popOutNavigationMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.popOutBlocksItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canvasPanel = new System.Windows.Forms.Panel();
            this.ideCanvas = new Visual_NXC.IdeCanvas();
            this.toolsPanel = new System.Windows.Forms.Panel();
            this.btnCenter = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolBtnErase = new System.Windows.Forms.PictureBox();
            this.mouseDescLeft = new System.Windows.Forms.PictureBox();
            this.toolBtnHand = new System.Windows.Forms.PictureBox();
            this.toolBtnMouse = new System.Windows.Forms.PictureBox();
            this.mouseDescMiddle = new System.Windows.Forms.PictureBox();
            this.mouseDescRight = new System.Windows.Forms.PictureBox();
            this.mainSplitter = new System.Windows.Forms.Splitter();
            this.itemsTreeView = new System.Windows.Forms.TreeView();
            this.Items = new System.Windows.Forms.ImageList(this.components);
            this.blocksItemsPanelHost = new System.Windows.Forms.Panel();
            this.blocksItemsPanel = new System.Windows.Forms.Panel();
            this.blocksItemsSplitter = new System.Windows.Forms.Splitter();
            this.blocksPanel = new System.Windows.Forms.Panel();
            this.blocksTreeView = new System.Windows.Forms.TreeView();
            this.blocksTopDock = new System.Windows.Forms.Panel();
            this.objectsLbl = new System.Windows.Forms.Label();
            this.objItmPopOutBtn = new System.Windows.Forms.PictureBox();
            this.objectsImg = new System.Windows.Forms.PictureBox();
            this.itemsPanel = new System.Windows.Forms.Panel();
            this.itmsPnlTopDock = new System.Windows.Forms.Panel();
            this.itemsLbl = new System.Windows.Forms.Label();
            this.itemsImg = new System.Windows.Forms.PictureBox();
            this.mapPanelHost = new System.Windows.Forms.Panel();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.mapDisplay = new System.Windows.Forms.Panel();
            this.topDock = new System.Windows.Forms.Panel();
            this.mapLbl = new System.Windows.Forms.Label();
            this.navMapPopOutBtn = new System.Windows.Forms.PictureBox();
            this.navMapIcon = new System.Windows.Forms.PictureBox();
            this.navMapCloseBtn = new System.Windows.Forms.PictureBox();
            this.allDock = new System.Windows.Forms.Panel();
            this.mapSplitter = new System.Windows.Forms.Splitter();
            this.tabBar = new Visual_NXC.tabBar();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripSplitBtn = new System.Windows.Forms.ToolStripSplitButton();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.outputToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.compilerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolTipProvider = new System.Windows.Forms.ToolTip(this.components);
            this.itemEditMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.newProjectToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.mainMenu.SuspendLayout();
            this.canvasPanel.SuspendLayout();
            this.toolsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBtnErase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mouseDescLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBtnHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBtnMouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mouseDescMiddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mouseDescRight)).BeginInit();
            this.blocksItemsPanelHost.SuspendLayout();
            this.blocksItemsPanel.SuspendLayout();
            this.blocksPanel.SuspendLayout();
            this.blocksTopDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objItmPopOutBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsImg)).BeginInit();
            this.itemsPanel.SuspendLayout();
            this.itmsPnlTopDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemsImg)).BeginInit();
            this.mapPanelHost.SuspendLayout();
            this.mapPanel.SuspendLayout();
            this.topDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navMapPopOutBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navMapIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navMapCloseBtn)).BeginInit();
            this.allDock.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.itemEditMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.Color.White;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutQuickToolStripMenuItem,
            this.optionsQuickToolStripMenuItem,
            this.windowsToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.ShowItemToolTips = true;
            this.mainMenu.Size = new System.Drawing.Size(784, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            this.mainMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainMenu_MouseDown);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.loadProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.saveProjectAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fileToolStripMenuItem.Image")));
            this.fileToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(30, 20);
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newProjectToolStripMenuItem.Image")));
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.newProjectToolStripMenuItem.Text = "New Project...";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // loadProjectToolStripMenuItem
            // 
            this.loadProjectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadProjectToolStripMenuItem.Image")));
            this.loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
            this.loadProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadProjectToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.loadProjectToolStripMenuItem.Text = "Load Project...";
            this.loadProjectToolStripMenuItem.Click += new System.EventHandler(this.loadProjectToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveProjectToolStripMenuItem.Image")));
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // saveProjectAsToolStripMenuItem
            // 
            this.saveProjectAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveProjectAsToolStripMenuItem.Image")));
            this.saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
            this.saveProjectAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveProjectAsToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.saveProjectAsToolStripMenuItem.Text = "Save Project As...";
            this.saveProjectAsToolStripMenuItem.Click += new System.EventHandler(this.saveProjectAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(232, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.toolStripSeparator7,
            this.optionsToolStripMenuItem});
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(32, 20);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.DropDown = this.undoMenuStrip;
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.undoToolStripMenuItem.Text = "History";
            // 
            // undoMenuStrip
            // 
            this.undoMenuStrip.Name = "undoMenuStrip";
            this.undoMenuStrip.OwnerItem = this.undoToolStripMenuItem;
            this.undoMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(150, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("optionsToolStripMenuItem.Image")));
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.optionsToolStripMenuItem.Text = "Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewGeneratedNXCCodeToolStripMenuItem,
            this.viewCompilerToolStripMenuItem,
            this.toolStripSeparator1,
            this.selectNextTabToolStripMenuItem,
            this.selectPreviousTabToolStripMenuItem,
            this.closeCurrentTabToolStripMenuItem,
            this.toolStripSeparator9,
            this.centerCanvasToolStripMenuItem});
            this.viewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewToolStripMenuItem.Image")));
            this.viewToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            // 
            // viewGeneratedNXCCodeToolStripMenuItem
            // 
            this.viewGeneratedNXCCodeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewGeneratedNXCCodeToolStripMenuItem.Image")));
            this.viewGeneratedNXCCodeToolStripMenuItem.Name = "viewGeneratedNXCCodeToolStripMenuItem";
            this.viewGeneratedNXCCodeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.viewGeneratedNXCCodeToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.viewGeneratedNXCCodeToolStripMenuItem.Text = "View Generated NXC Code";
            this.viewGeneratedNXCCodeToolStripMenuItem.Click += new System.EventHandler(this.viewGeneratedNXCCodeToolStripMenuItem_Click);
            // 
            // viewCompilerToolStripMenuItem
            // 
            this.viewCompilerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewCompilerToolStripMenuItem.Image")));
            this.viewCompilerToolStripMenuItem.Name = "viewCompilerToolStripMenuItem";
            this.viewCompilerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.viewCompilerToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.viewCompilerToolStripMenuItem.Text = "View Compiler";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(259, 6);
            // 
            // selectNextTabToolStripMenuItem
            // 
            this.selectNextTabToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("selectNextTabToolStripMenuItem.Image")));
            this.selectNextTabToolStripMenuItem.Name = "selectNextTabToolStripMenuItem";
            this.selectNextTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Tab)));
            this.selectNextTabToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.selectNextTabToolStripMenuItem.Text = "Select Next Tab";
            this.selectNextTabToolStripMenuItem.Click += new System.EventHandler(this.selectNextTabToolStripMenuItem_Click);
            // 
            // selectPreviousTabToolStripMenuItem
            // 
            this.selectPreviousTabToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("selectPreviousTabToolStripMenuItem.Image")));
            this.selectPreviousTabToolStripMenuItem.Name = "selectPreviousTabToolStripMenuItem";
            this.selectPreviousTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Tab)));
            this.selectPreviousTabToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.selectPreviousTabToolStripMenuItem.Text = "Select Previous Tab";
            this.selectPreviousTabToolStripMenuItem.Click += new System.EventHandler(this.selectPreviousTabToolStripMenuItem_Click);
            // 
            // closeCurrentTabToolStripMenuItem
            // 
            this.closeCurrentTabToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeCurrentTabToolStripMenuItem.Image")));
            this.closeCurrentTabToolStripMenuItem.Name = "closeCurrentTabToolStripMenuItem";
            this.closeCurrentTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeCurrentTabToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.closeCurrentTabToolStripMenuItem.Text = "Close Current Tab";
            this.closeCurrentTabToolStripMenuItem.Click += new System.EventHandler(this.closeCurrentTabToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(259, 6);
            // 
            // centerCanvasToolStripMenuItem
            // 
            this.centerCanvasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("centerCanvasToolStripMenuItem.Image")));
            this.centerCanvasToolStripMenuItem.Name = "centerCanvasToolStripMenuItem";
            this.centerCanvasToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.centerCanvasToolStripMenuItem.Text = "Center Canvas";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpVisualNXCWikiToolStripMenuItem,
            this.toolStripSeparator4,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripMenuItem.Image")));
            this.helpToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            // 
            // helpVisualNXCWikiToolStripMenuItem
            // 
            this.helpVisualNXCWikiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("helpVisualNXCWikiToolStripMenuItem.Image")));
            this.helpVisualNXCWikiToolStripMenuItem.Name = "helpVisualNXCWikiToolStripMenuItem";
            this.helpVisualNXCWikiToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpVisualNXCWikiToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.helpVisualNXCWikiToolStripMenuItem.Text = "Help (Visual NXC Wiki)";
            this.helpVisualNXCWikiToolStripMenuItem.Click += new System.EventHandler(this.helpVisualNXCWikiToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(210, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // aboutQuickToolStripMenuItem
            // 
            this.aboutQuickToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutQuickToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutQuickToolStripMenuItem.Image")));
            this.aboutQuickToolStripMenuItem.Name = "aboutQuickToolStripMenuItem";
            this.aboutQuickToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.aboutQuickToolStripMenuItem.ToolTipText = "About";
            this.aboutQuickToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // optionsQuickToolStripMenuItem
            // 
            this.optionsQuickToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.optionsQuickToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("optionsQuickToolStripMenuItem.Image")));
            this.optionsQuickToolStripMenuItem.Name = "optionsQuickToolStripMenuItem";
            this.optionsQuickToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.optionsQuickToolStripMenuItem.ToolTipText = "Options";
            this.optionsQuickToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.windowsToolStripMenuItem.AutoToolTip = true;
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showNavigationMapToolStripMenuItem,
            this.toolStripSeparator6,
            this.popOutNavigationMapToolStripMenuItem,
            this.popOutBlocksItemsToolStripMenuItem});
            this.windowsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("windowsToolStripMenuItem.Image")));
            this.windowsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.windowsToolStripMenuItem.ToolTipText = "Windows";
            // 
            // showNavigationMapToolStripMenuItem
            // 
            this.showNavigationMapToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showNavigationMapToolStripMenuItem.Image")));
            this.showNavigationMapToolStripMenuItem.Name = "showNavigationMapToolStripMenuItem";
            this.showNavigationMapToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.showNavigationMapToolStripMenuItem.Text = "Show Navigation Map";
            this.showNavigationMapToolStripMenuItem.Click += new System.EventHandler(this.showNavigationMapToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(218, 6);
            // 
            // popOutNavigationMapToolStripMenuItem
            // 
            this.popOutNavigationMapToolStripMenuItem.Enabled = false;
            this.popOutNavigationMapToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("popOutNavigationMapToolStripMenuItem.Image")));
            this.popOutNavigationMapToolStripMenuItem.Name = "popOutNavigationMapToolStripMenuItem";
            this.popOutNavigationMapToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.popOutNavigationMapToolStripMenuItem.Text = "Pop Out Navigation Map";
            this.popOutNavigationMapToolStripMenuItem.Click += new System.EventHandler(this.NavMapPopOutBtn_Click);
            // 
            // popOutBlocksItemsToolStripMenuItem
            // 
            this.popOutBlocksItemsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("popOutBlocksItemsToolStripMenuItem.Image")));
            this.popOutBlocksItemsToolStripMenuItem.Name = "popOutBlocksItemsToolStripMenuItem";
            this.popOutBlocksItemsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.popOutBlocksItemsToolStripMenuItem.Text = "Pop Out Blocks/Items Panel";
            this.popOutBlocksItemsToolStripMenuItem.Click += new System.EventHandler(this.objItmPopOut_Click);
            // 
            // canvasPanel
            // 
            this.canvasPanel.Controls.Add(this.ideCanvas);
            this.canvasPanel.Controls.Add(this.toolsPanel);
            this.canvasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasPanel.Location = new System.Drawing.Point(179, 50);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(401, 487);
            this.canvasPanel.TabIndex = 2;
            // 
            // ideCanvas
            // 
            this.ideCanvas.AllowDrop = true;
            this.ideCanvas.BackColor = System.Drawing.SystemColors.Control;
            this.ideCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ideCanvas.InsertionPoint = null;
            this.ideCanvas.Location = new System.Drawing.Point(0, 20);
            this.ideCanvas.Name = "ideCanvas";
            this.ideCanvas.Page = null;
            this.ideCanvas.Size = new System.Drawing.Size(401, 467);
            this.ideCanvas.TabIndex = 2;
            // 
            // toolsPanel
            // 
            this.toolsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolsPanel.Controls.Add(this.btnCenter);
            this.toolsPanel.Controls.Add(this.label1);
            this.toolsPanel.Controls.Add(this.toolBtnErase);
            this.toolsPanel.Controls.Add(this.mouseDescLeft);
            this.toolsPanel.Controls.Add(this.toolBtnHand);
            this.toolsPanel.Controls.Add(this.toolBtnMouse);
            this.toolsPanel.Controls.Add(this.mouseDescMiddle);
            this.toolsPanel.Controls.Add(this.mouseDescRight);
            this.toolsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolsPanel.Location = new System.Drawing.Point(0, 0);
            this.toolsPanel.Name = "toolsPanel";
            this.toolsPanel.Size = new System.Drawing.Size(401, 20);
            this.toolsPanel.TabIndex = 3;
            // 
            // btnCenter
            // 
            this.btnCenter.BackColor = System.Drawing.Color.Transparent;
            this.btnCenter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCenter.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCenter.Image = global::Visual_NXC.Properties.Resources.layer_resize_actual_transparent;
            this.btnCenter.Location = new System.Drawing.Point(60, 0);
            this.btnCenter.Name = "btnCenter";
            this.btnCenter.Size = new System.Drawing.Size(20, 20);
            this.btnCenter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnCenter.TabIndex = 7;
            this.btnCenter.TabStop = false;
            this.btnCenter.Tag = "";
            this.toolTipProvider.SetToolTip(this.btnCenter, "Center Canvas");
            this.btnCenter.Click += new System.EventHandler(this.centerToolStripButton_Click);
            this.btnCenter.MouseEnter += new System.EventHandler(this.btnCenter_MouseEnter);
            this.btnCenter.MouseLeave += new System.EventHandler(this.btnCenter_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(60, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hover for Controls:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolBtnErase
            // 
            this.toolBtnErase.BackColor = System.Drawing.Color.Transparent;
            this.toolBtnErase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toolBtnErase.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolBtnErase.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnErase.Image")));
            this.toolBtnErase.Location = new System.Drawing.Point(40, 0);
            this.toolBtnErase.Name = "toolBtnErase";
            this.toolBtnErase.Size = new System.Drawing.Size(20, 20);
            this.toolBtnErase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.toolBtnErase.TabIndex = 6;
            this.toolBtnErase.TabStop = false;
            this.toolBtnErase.Tag = "TRANS";
            this.toolTipProvider.SetToolTip(this.toolBtnErase, "Eraser Tool");
            this.toolBtnErase.Click += new System.EventHandler(this.toolBtn_Click);
            this.toolBtnErase.MouseEnter += new System.EventHandler(this.toolBtns_MouseEnter);
            this.toolBtnErase.MouseLeave += new System.EventHandler(this.toolBtns_MouseLeave);
            // 
            // mouseDescLeft
            // 
            this.mouseDescLeft.BackColor = System.Drawing.Color.Transparent;
            this.mouseDescLeft.Cursor = System.Windows.Forms.Cursors.Default;
            this.mouseDescLeft.Dock = System.Windows.Forms.DockStyle.Right;
            this.mouseDescLeft.Image = ((System.Drawing.Image)(resources.GetObject("mouseDescLeft.Image")));
            this.mouseDescLeft.Location = new System.Drawing.Point(341, 0);
            this.mouseDescLeft.Name = "mouseDescLeft";
            this.mouseDescLeft.Size = new System.Drawing.Size(20, 20);
            this.mouseDescLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mouseDescLeft.TabIndex = 2;
            this.mouseDescLeft.TabStop = false;
            this.mouseDescLeft.Tag = "";
            this.toolTipProvider.SetToolTip(this.mouseDescLeft, "Select");
            // 
            // toolBtnHand
            // 
            this.toolBtnHand.BackColor = System.Drawing.Color.Transparent;
            this.toolBtnHand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toolBtnHand.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolBtnHand.Image = global::Visual_NXC.Properties.Resources.hand___gloved_transparent;
            this.toolBtnHand.Location = new System.Drawing.Point(20, 0);
            this.toolBtnHand.Name = "toolBtnHand";
            this.toolBtnHand.Size = new System.Drawing.Size(20, 20);
            this.toolBtnHand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.toolBtnHand.TabIndex = 1;
            this.toolBtnHand.TabStop = false;
            this.toolBtnHand.Tag = "TRANS";
            this.toolTipProvider.SetToolTip(this.toolBtnHand, "Pan Tool");
            this.toolBtnHand.Click += new System.EventHandler(this.toolBtn_Click);
            this.toolBtnHand.MouseEnter += new System.EventHandler(this.toolBtns_MouseEnter);
            this.toolBtnHand.MouseLeave += new System.EventHandler(this.toolBtns_MouseLeave);
            // 
            // toolBtnMouse
            // 
            this.toolBtnMouse.BackColor = System.Drawing.Color.Transparent;
            this.toolBtnMouse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toolBtnMouse.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolBtnMouse.Image = global::Visual_NXC.Properties.Resources.cursor_dark;
            this.toolBtnMouse.Location = new System.Drawing.Point(0, 0);
            this.toolBtnMouse.Name = "toolBtnMouse";
            this.toolBtnMouse.Size = new System.Drawing.Size(20, 20);
            this.toolBtnMouse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.toolBtnMouse.TabIndex = 0;
            this.toolBtnMouse.TabStop = false;
            this.toolBtnMouse.Tag = " ";
            this.toolTipProvider.SetToolTip(this.toolBtnMouse, "Cursor Tool");
            this.toolBtnMouse.Click += new System.EventHandler(this.toolBtn_Click);
            this.toolBtnMouse.MouseEnter += new System.EventHandler(this.toolBtns_MouseEnter);
            this.toolBtnMouse.MouseLeave += new System.EventHandler(this.toolBtns_MouseLeave);
            // 
            // mouseDescMiddle
            // 
            this.mouseDescMiddle.BackColor = System.Drawing.Color.Transparent;
            this.mouseDescMiddle.Cursor = System.Windows.Forms.Cursors.Default;
            this.mouseDescMiddle.Dock = System.Windows.Forms.DockStyle.Right;
            this.mouseDescMiddle.Image = ((System.Drawing.Image)(resources.GetObject("mouseDescMiddle.Image")));
            this.mouseDescMiddle.Location = new System.Drawing.Point(361, 0);
            this.mouseDescMiddle.Name = "mouseDescMiddle";
            this.mouseDescMiddle.Size = new System.Drawing.Size(20, 20);
            this.mouseDescMiddle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mouseDescMiddle.TabIndex = 3;
            this.mouseDescMiddle.TabStop = false;
            this.mouseDescMiddle.Tag = "";
            this.toolTipProvider.SetToolTip(this.mouseDescMiddle, "Pan");
            // 
            // mouseDescRight
            // 
            this.mouseDescRight.BackColor = System.Drawing.Color.Transparent;
            this.mouseDescRight.Cursor = System.Windows.Forms.Cursors.Default;
            this.mouseDescRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.mouseDescRight.Image = ((System.Drawing.Image)(resources.GetObject("mouseDescRight.Image")));
            this.mouseDescRight.Location = new System.Drawing.Point(381, 0);
            this.mouseDescRight.Name = "mouseDescRight";
            this.mouseDescRight.Size = new System.Drawing.Size(20, 20);
            this.mouseDescRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mouseDescRight.TabIndex = 4;
            this.mouseDescRight.TabStop = false;
            this.mouseDescRight.Tag = "";
            this.mouseDescRight.Visible = false;
            // 
            // mainSplitter
            // 
            this.mainSplitter.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.mainSplitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.mainSplitter.Location = new System.Drawing.Point(580, 50);
            this.mainSplitter.MinExtra = 200;
            this.mainSplitter.MinSize = 200;
            this.mainSplitter.Name = "mainSplitter";
            this.mainSplitter.Size = new System.Drawing.Size(4, 487);
            this.mainSplitter.TabIndex = 3;
            this.mainSplitter.TabStop = false;
            this.mainSplitter.Paint += new System.Windows.Forms.PaintEventHandler(this.splitter1_Paint);
            this.mainSplitter.Resize += new System.EventHandler(this.splitter1_Resize);
            // 
            // itemsTreeView
            // 
            this.itemsTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsTreeView.ImageIndex = 0;
            this.itemsTreeView.ImageList = this.Items;
            this.itemsTreeView.Location = new System.Drawing.Point(0, 20);
            this.itemsTreeView.Name = "itemsTreeView";
            this.itemsTreeView.SelectedImageIndex = 0;
            this.itemsTreeView.ShowLines = false;
            this.itemsTreeView.Size = new System.Drawing.Size(200, 180);
            this.itemsTreeView.TabIndex = 4;
            this.itemsTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.itemsTreeView_NodeMouseClick);
            this.itemsTreeView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseMove);
            // 
            // Items
            // 
            this.Items.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Items.ImageStream")));
            this.Items.TransparentColor = System.Drawing.Color.Transparent;
            this.Items.Images.SetKeyName(0, "thread.png");
            this.Items.Images.SetKeyName(1, "method.png");
            this.Items.Images.SetKeyName(2, "enum.png");
            this.Items.Images.SetKeyName(3, "struct.png");
            this.Items.Images.SetKeyName(4, "plus-small.png");
            // 
            // blocksItemsPanelHost
            // 
            this.blocksItemsPanelHost.BackColor = System.Drawing.SystemColors.Control;
            this.blocksItemsPanelHost.Controls.Add(this.blocksItemsPanel);
            this.blocksItemsPanelHost.Dock = System.Windows.Forms.DockStyle.Right;
            this.blocksItemsPanelHost.Location = new System.Drawing.Point(584, 50);
            this.blocksItemsPanelHost.Name = "blocksItemsPanelHost";
            this.blocksItemsPanelHost.Size = new System.Drawing.Size(200, 487);
            this.blocksItemsPanelHost.TabIndex = 2;
            // 
            // blocksItemsPanel
            // 
            this.blocksItemsPanel.BackColor = System.Drawing.SystemColors.Window;
            this.blocksItemsPanel.Controls.Add(this.blocksItemsSplitter);
            this.blocksItemsPanel.Controls.Add(this.blocksPanel);
            this.blocksItemsPanel.Controls.Add(this.itemsPanel);
            this.blocksItemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blocksItemsPanel.Location = new System.Drawing.Point(0, 0);
            this.blocksItemsPanel.Name = "blocksItemsPanel";
            this.blocksItemsPanel.Size = new System.Drawing.Size(200, 487);
            this.blocksItemsPanel.TabIndex = 10;
            // 
            // blocksItemsSplitter
            // 
            this.blocksItemsSplitter.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.blocksItemsSplitter.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.blocksItemsSplitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.blocksItemsSplitter.Location = new System.Drawing.Point(0, 283);
            this.blocksItemsSplitter.MinExtra = 100;
            this.blocksItemsSplitter.MinSize = 100;
            this.blocksItemsSplitter.Name = "blocksItemsSplitter";
            this.blocksItemsSplitter.Size = new System.Drawing.Size(200, 4);
            this.blocksItemsSplitter.TabIndex = 10;
            this.blocksItemsSplitter.TabStop = false;
            this.blocksItemsSplitter.Paint += new System.Windows.Forms.PaintEventHandler(this.splitter2_Paint);
            this.blocksItemsSplitter.Resize += new System.EventHandler(this.splitter2_Resize);
            // 
            // blocksPanel
            // 
            this.blocksPanel.Controls.Add(this.blocksTreeView);
            this.blocksPanel.Controls.Add(this.blocksTopDock);
            this.blocksPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blocksPanel.Location = new System.Drawing.Point(0, 0);
            this.blocksPanel.Name = "blocksPanel";
            this.blocksPanel.Size = new System.Drawing.Size(200, 287);
            this.blocksPanel.TabIndex = 11;
            // 
            // blocksTreeView
            // 
            this.blocksTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.blocksTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blocksTreeView.Location = new System.Drawing.Point(0, 20);
            this.blocksTreeView.Name = "blocksTreeView";
            treeNode5.Name = "whileLoop";
            treeNode5.Tag = "while";
            treeNode5.Text = "While";
            treeNode5.ToolTipText = "Loops until a logical condition is met";
            treeNode6.Name = "loopNode";
            treeNode6.Text = "Loops";
            treeNode7.Name = "initUS";
            treeNode7.Tag = "USInit";
            treeNode7.Text = "Set Ultrasonic Sensor";
            treeNode7.ToolTipText = "Initializes the Unltrasonic Sensor for Use";
            treeNode8.Name = "Node0";
            treeNode8.Text = "Sensors";
            this.blocksTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode8});
            this.blocksTreeView.ShowLines = false;
            this.blocksTreeView.ShowNodeToolTips = true;
            this.blocksTreeView.Size = new System.Drawing.Size(200, 267);
            this.blocksTreeView.TabIndex = 6;
            this.blocksTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView2_ItemDrag);
            // 
            // blocksTopDock
            // 
            this.blocksTopDock.Controls.Add(this.objectsLbl);
            this.blocksTopDock.Controls.Add(this.objItmPopOutBtn);
            this.blocksTopDock.Controls.Add(this.objectsImg);
            this.blocksTopDock.Dock = System.Windows.Forms.DockStyle.Top;
            this.blocksTopDock.Location = new System.Drawing.Point(0, 0);
            this.blocksTopDock.Name = "blocksTopDock";
            this.blocksTopDock.Size = new System.Drawing.Size(200, 20);
            this.blocksTopDock.TabIndex = 9;
            // 
            // objectsLbl
            // 
            this.objectsLbl.AutoEllipsis = true;
            this.objectsLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectsLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.objectsLbl.ForeColor = System.Drawing.SystemColors.GrayText;
            this.objectsLbl.Location = new System.Drawing.Point(20, 0);
            this.objectsLbl.Name = "objectsLbl";
            this.objectsLbl.Size = new System.Drawing.Size(160, 20);
            this.objectsLbl.TabIndex = 11;
            this.objectsLbl.Text = "Available Blocks:";
            this.objectsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // objItmPopOutBtn
            // 
            this.objItmPopOutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.objItmPopOutBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.objItmPopOutBtn.Image = global::Visual_NXC.Properties.Resources.pop_out;
            this.objItmPopOutBtn.Location = new System.Drawing.Point(180, 0);
            this.objItmPopOutBtn.Name = "objItmPopOutBtn";
            this.objItmPopOutBtn.Size = new System.Drawing.Size(20, 20);
            this.objItmPopOutBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.objItmPopOutBtn.TabIndex = 9;
            this.objItmPopOutBtn.TabStop = false;
            this.objItmPopOutBtn.Tag = "out";
            this.toolTipProvider.SetToolTip(this.objItmPopOutBtn, "Pop Out Window");
            this.objItmPopOutBtn.Click += new System.EventHandler(this.objItmPopOut_Click);
            this.objItmPopOutBtn.MouseEnter += new System.EventHandler(this.popOutButton_MouseEnter);
            this.objItmPopOutBtn.MouseLeave += new System.EventHandler(this.popOutButton_MouseLeave);
            // 
            // objectsImg
            // 
            this.objectsImg.Dock = System.Windows.Forms.DockStyle.Left;
            this.objectsImg.Image = ((System.Drawing.Image)(resources.GetObject("objectsImg.Image")));
            this.objectsImg.Location = new System.Drawing.Point(0, 0);
            this.objectsImg.Name = "objectsImg";
            this.objectsImg.Size = new System.Drawing.Size(20, 20);
            this.objectsImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.objectsImg.TabIndex = 10;
            this.objectsImg.TabStop = false;
            // 
            // itemsPanel
            // 
            this.itemsPanel.Controls.Add(this.itemsTreeView);
            this.itemsPanel.Controls.Add(this.itmsPnlTopDock);
            this.itemsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.itemsPanel.Location = new System.Drawing.Point(0, 287);
            this.itemsPanel.Name = "itemsPanel";
            this.itemsPanel.Size = new System.Drawing.Size(200, 200);
            this.itemsPanel.TabIndex = 8;
            // 
            // itmsPnlTopDock
            // 
            this.itmsPnlTopDock.Controls.Add(this.itemsLbl);
            this.itmsPnlTopDock.Controls.Add(this.itemsImg);
            this.itmsPnlTopDock.Dock = System.Windows.Forms.DockStyle.Top;
            this.itmsPnlTopDock.Location = new System.Drawing.Point(0, 0);
            this.itmsPnlTopDock.Name = "itmsPnlTopDock";
            this.itmsPnlTopDock.Size = new System.Drawing.Size(200, 20);
            this.itmsPnlTopDock.TabIndex = 8;
            // 
            // itemsLbl
            // 
            this.itemsLbl.AutoEllipsis = true;
            this.itemsLbl.BackColor = System.Drawing.SystemColors.Window;
            this.itemsLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsLbl.ForeColor = System.Drawing.SystemColors.GrayText;
            this.itemsLbl.Location = new System.Drawing.Point(20, 0);
            this.itemsLbl.Name = "itemsLbl";
            this.itemsLbl.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.itemsLbl.Size = new System.Drawing.Size(180, 20);
            this.itemsLbl.TabIndex = 7;
            this.itemsLbl.Text = "Project Items:";
            this.itemsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // itemsImg
            // 
            this.itemsImg.Dock = System.Windows.Forms.DockStyle.Left;
            this.itemsImg.Image = ((System.Drawing.Image)(resources.GetObject("itemsImg.Image")));
            this.itemsImg.Location = new System.Drawing.Point(0, 0);
            this.itemsImg.Name = "itemsImg";
            this.itemsImg.Size = new System.Drawing.Size(20, 20);
            this.itemsImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.itemsImg.TabIndex = 9;
            this.itemsImg.TabStop = false;
            // 
            // mapPanelHost
            // 
            this.mapPanelHost.BackColor = System.Drawing.SystemColors.Window;
            this.mapPanelHost.Controls.Add(this.mapPanel);
            this.mapPanelHost.Dock = System.Windows.Forms.DockStyle.Left;
            this.mapPanelHost.Location = new System.Drawing.Point(0, 50);
            this.mapPanelHost.Name = "mapPanelHost";
            this.mapPanelHost.Size = new System.Drawing.Size(175, 487);
            this.mapPanelHost.TabIndex = 8;
            this.mapPanelHost.Visible = false;
            // 
            // mapPanel
            // 
            this.mapPanel.BackColor = System.Drawing.SystemColors.Window;
            this.mapPanel.Controls.Add(this.mapDisplay);
            this.mapPanel.Controls.Add(this.topDock);
            this.mapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPanel.Location = new System.Drawing.Point(0, 0);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(175, 487);
            this.mapPanel.TabIndex = 0;
            // 
            // mapDisplay
            // 
            this.mapDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapDisplay.Location = new System.Drawing.Point(0, 20);
            this.mapDisplay.Name = "mapDisplay";
            this.mapDisplay.Size = new System.Drawing.Size(175, 467);
            this.mapDisplay.TabIndex = 9;
            this.mapDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.mapDisplay_Paint);
            this.mapDisplay.Resize += new System.EventHandler(this.mapDisplay_Resize);
            // 
            // topDock
            // 
            this.topDock.Controls.Add(this.mapLbl);
            this.topDock.Controls.Add(this.navMapPopOutBtn);
            this.topDock.Controls.Add(this.navMapIcon);
            this.topDock.Controls.Add(this.navMapCloseBtn);
            this.topDock.Dock = System.Windows.Forms.DockStyle.Top;
            this.topDock.Location = new System.Drawing.Point(0, 0);
            this.topDock.Name = "topDock";
            this.topDock.Size = new System.Drawing.Size(175, 20);
            this.topDock.TabIndex = 0;
            // 
            // mapLbl
            // 
            this.mapLbl.AutoEllipsis = true;
            this.mapLbl.BackColor = System.Drawing.SystemColors.Window;
            this.mapLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapLbl.ForeColor = System.Drawing.SystemColors.GrayText;
            this.mapLbl.Location = new System.Drawing.Point(20, 0);
            this.mapLbl.Name = "mapLbl";
            this.mapLbl.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.mapLbl.Size = new System.Drawing.Size(115, 20);
            this.mapLbl.TabIndex = 8;
            this.mapLbl.Text = "Navigation Map";
            this.mapLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // navMapPopOutBtn
            // 
            this.navMapPopOutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.navMapPopOutBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.navMapPopOutBtn.Image = global::Visual_NXC.Properties.Resources.pop_out;
            this.navMapPopOutBtn.Location = new System.Drawing.Point(135, 0);
            this.navMapPopOutBtn.Name = "navMapPopOutBtn";
            this.navMapPopOutBtn.Size = new System.Drawing.Size(20, 20);
            this.navMapPopOutBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.navMapPopOutBtn.TabIndex = 9;
            this.navMapPopOutBtn.TabStop = false;
            this.navMapPopOutBtn.Tag = "out";
            this.toolTipProvider.SetToolTip(this.navMapPopOutBtn, "Pop Out Window");
            this.navMapPopOutBtn.Click += new System.EventHandler(this.NavMapPopOutBtn_Click);
            this.navMapPopOutBtn.MouseEnter += new System.EventHandler(this.popOutButton_MouseEnter);
            this.navMapPopOutBtn.MouseLeave += new System.EventHandler(this.popOutButton_MouseLeave);
            // 
            // navMapIcon
            // 
            this.navMapIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.navMapIcon.Image = ((System.Drawing.Image)(resources.GetObject("navMapIcon.Image")));
            this.navMapIcon.Location = new System.Drawing.Point(0, 0);
            this.navMapIcon.Name = "navMapIcon";
            this.navMapIcon.Size = new System.Drawing.Size(20, 20);
            this.navMapIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.navMapIcon.TabIndex = 0;
            this.navMapIcon.TabStop = false;
            // 
            // navMapCloseBtn
            // 
            this.navMapCloseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.navMapCloseBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.navMapCloseBtn.Image = ((System.Drawing.Image)(resources.GetObject("navMapCloseBtn.Image")));
            this.navMapCloseBtn.Location = new System.Drawing.Point(155, 0);
            this.navMapCloseBtn.Name = "navMapCloseBtn";
            this.navMapCloseBtn.Size = new System.Drawing.Size(20, 20);
            this.navMapCloseBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.navMapCloseBtn.TabIndex = 10;
            this.navMapCloseBtn.TabStop = false;
            this.navMapCloseBtn.Tag = "out";
            this.toolTipProvider.SetToolTip(this.navMapCloseBtn, "Close Navigation Map");
            this.navMapCloseBtn.Click += new System.EventHandler(this.showNavigationMapToolStripMenuItem_Click);
            this.navMapCloseBtn.MouseEnter += new System.EventHandler(this.navMapCloseBtn_MouseEnter);
            this.navMapCloseBtn.MouseLeave += new System.EventHandler(this.navMapCloseBtn_MouseLeave);
            // 
            // allDock
            // 
            this.allDock.Controls.Add(this.canvasPanel);
            this.allDock.Controls.Add(this.mainSplitter);
            this.allDock.Controls.Add(this.blocksItemsPanelHost);
            this.allDock.Controls.Add(this.mapSplitter);
            this.allDock.Controls.Add(this.mapPanelHost);
            this.allDock.Controls.Add(this.tabBar);
            this.allDock.Controls.Add(this.toolStrip);
            this.allDock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allDock.Location = new System.Drawing.Point(0, 24);
            this.allDock.Name = "allDock";
            this.allDock.Size = new System.Drawing.Size(784, 537);
            this.allDock.TabIndex = 3;
            // 
            // mapSplitter
            // 
            this.mapSplitter.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.mapSplitter.Location = new System.Drawing.Point(175, 50);
            this.mapSplitter.MinExtra = 100;
            this.mapSplitter.MinSize = 100;
            this.mapSplitter.Name = "mapSplitter";
            this.mapSplitter.Size = new System.Drawing.Size(4, 487);
            this.mapSplitter.TabIndex = 5;
            this.mapSplitter.TabStop = false;
            this.mapSplitter.Visible = false;
            this.mapSplitter.Paint += new System.Windows.Forms.PaintEventHandler(this.splitter1_Paint);
            // 
            // tabBar
            // 
            this.tabBar.BackColor = System.Drawing.Color.White;
            this.tabBar.BottomColor = System.Drawing.Color.Gainsboro;
            this.tabBar.BottomLine = true;
            this.tabBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabBar.Location = new System.Drawing.Point(0, 25);
            this.tabBar.Name = "tabBar";
            this.tabBar.Size = new System.Drawing.Size(784, 25);
            this.tabBar.TabIndex = 1;
            this.tabBar.TopColor = System.Drawing.SystemColors.Control;
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripBtn,
            this.openButton,
            this.saveToolStripSplitBtn,
            this.toolStripSeparator5,
            this.outputToolStripBtn,
            this.compilerToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(784, 25);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
            // 
            // openButton
            // 
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(23, 22);
            this.openButton.Text = "Open Project";
            this.openButton.Click += new System.EventHandler(this.loadProjectToolStripMenuItem_Click);
            // 
            // saveToolStripSplitBtn
            // 
            this.saveToolStripSplitBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripSplitBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem});
            this.saveToolStripSplitBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripSplitBtn.Image")));
            this.saveToolStripSplitBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripSplitBtn.Name = "saveToolStripSplitBtn";
            this.saveToolStripSplitBtn.Size = new System.Drawing.Size(32, 22);
            this.saveToolStripSplitBtn.Text = "Save Project";
            this.saveToolStripSplitBtn.ButtonClick += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+S";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveProjectAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // outputToolStripBtn
            // 
            this.outputToolStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.outputToolStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("outputToolStripBtn.Image")));
            this.outputToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.outputToolStripBtn.Name = "outputToolStripBtn";
            this.outputToolStripBtn.Size = new System.Drawing.Size(23, 22);
            this.outputToolStripBtn.Text = "View Generated NXC Code";
            this.outputToolStripBtn.Click += new System.EventHandler(this.viewGeneratedNXCCodeToolStripMenuItem_Click);
            // 
            // compilerToolStripButton
            // 
            this.compilerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.compilerToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("compilerToolStripButton.Image")));
            this.compilerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.compilerToolStripButton.Name = "compilerToolStripButton";
            this.compilerToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.compilerToolStripButton.Text = "Compiler";
            this.compilerToolStripButton.Click += new System.EventHandler(this.compilerToolStripButton_Click);
            // 
            // itemEditMenu
            // 
            this.itemEditMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem1,
            this.toolStripSeparator8,
            this.deleteToolStripMenuItem});
            this.itemEditMenu.Name = "itemEditMenu";
            this.itemEditMenu.Size = new System.Drawing.Size(117, 54);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem1.Image")));
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.editToolStripMenuItem1.Text = "Edit...";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(113, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Visual_NXC.Properties.Resources.cross;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.deleteToolStripMenuItem.Text = "Delete...";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // saveFileDlg
            // 
            this.saveFileDlg.DefaultExt = "vpf";
            this.saveFileDlg.FileName = "Untitled Project.vpf";
            this.saveFileDlg.Filter = "Visual NXC Project File|*.vpf|All Files|*.*";
            this.saveFileDlg.Title = "Save Visual NXC Project File";
            this.saveFileDlg.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDlg_FileOk);
            // 
            // openFileDlg
            // 
            this.openFileDlg.DefaultExt = "vpf";
            this.openFileDlg.Filter = "Visual NXC Project Files|*.vpf|All Files|*.*";
            this.openFileDlg.Title = "Open Visual NXC Project Files";
            this.openFileDlg.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDlg_FileOk);
            // 
            // newProjectToolStripBtn
            // 
            this.newProjectToolStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newProjectToolStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("newProjectToolStripBtn.Image")));
            this.newProjectToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newProjectToolStripBtn.Name = "newProjectToolStripBtn";
            this.newProjectToolStripBtn.Size = new System.Drawing.Size(23, 22);
            this.newProjectToolStripBtn.Text = "toolStripButton1";
            this.newProjectToolStripBtn.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.allDock);
            this.Controls.Add(this.mainMenu);
            this.ExpandAmount = 24;
            this.ExpandIntoFrame = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Untitled Project* - Visual NXC 0.2";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.canvasPanel.ResumeLayout(false);
            this.toolsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBtnErase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mouseDescLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBtnHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBtnMouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mouseDescMiddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mouseDescRight)).EndInit();
            this.blocksItemsPanelHost.ResumeLayout(false);
            this.blocksItemsPanel.ResumeLayout(false);
            this.blocksPanel.ResumeLayout(false);
            this.blocksTopDock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objItmPopOutBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsImg)).EndInit();
            this.itemsPanel.ResumeLayout(false);
            this.itmsPnlTopDock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemsImg)).EndInit();
            this.mapPanelHost.ResumeLayout(false);
            this.mapPanel.ResumeLayout(false);
            this.topDock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navMapPopOutBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navMapIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navMapCloseBtn)).EndInit();
            this.allDock.ResumeLayout(false);
            this.allDock.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.itemEditMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewGeneratedNXCCodeToolStripMenuItem;
		private tabBar tabBar;
		private System.Windows.Forms.Panel canvasPanel;
		private System.Windows.Forms.Splitter mainSplitter;
		private System.Windows.Forms.TreeView itemsTreeView;
		private System.Windows.Forms.Panel blocksItemsPanelHost;
		private System.Windows.Forms.TreeView blocksTreeView;
		private System.Windows.Forms.Label itemsLbl;
		private IdeCanvas ideCanvas;
		private System.Windows.Forms.Panel allDock;
		private System.Windows.Forms.ImageList Items;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem selectNextTabToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectPreviousTabToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeCurrentTabToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveProjectAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton openButton;
		private System.Windows.Forms.ToolStripSplitButton saveToolStripSplitBtn;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton outputToolStripBtn;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpVisualNXCWikiToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.Splitter blocksItemsSplitter;
		private System.Windows.Forms.Panel mapPanelHost;
		private System.Windows.Forms.ToolStripButton compilerToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem optionsQuickToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutQuickToolStripMenuItem;
		private System.Windows.Forms.Panel mapDisplay;
		private System.Windows.Forms.Label mapLbl;
		private System.Windows.Forms.Splitter mapSplitter;
		private System.Windows.Forms.Panel topDock;
		private System.Windows.Forms.PictureBox navMapPopOutBtn;
		private System.Windows.Forms.ToolTip toolTipProvider;
		private System.Windows.Forms.Panel mapPanel;
		private System.Windows.Forms.Panel blocksPanel;
		private System.Windows.Forms.Panel blocksTopDock;
		private System.Windows.Forms.Panel itemsPanel;
		private System.Windows.Forms.Panel itmsPnlTopDock;
		private System.Windows.Forms.PictureBox objItmPopOutBtn;
		private System.Windows.Forms.Panel blocksItemsPanel;
		private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showNavigationMapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem popOutNavigationMapToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem popOutBlocksItemsToolStripMenuItem;
		private System.Windows.Forms.PictureBox objectsImg;
		private System.Windows.Forms.PictureBox itemsImg;
		private System.Windows.Forms.PictureBox navMapIcon;
		private System.Windows.Forms.Label objectsLbl;
		private System.Windows.Forms.PictureBox navMapCloseBtn;
		private System.Windows.Forms.Panel toolsPanel;
		private System.Windows.Forms.PictureBox toolBtnHand;
		private System.Windows.Forms.PictureBox toolBtnMouse;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox mouseDescLeft;
		private System.Windows.Forms.PictureBox mouseDescMiddle;
		private System.Windows.Forms.PictureBox mouseDescRight;
		private System.Windows.Forms.PictureBox toolBtnErase;
		private System.Windows.Forms.ContextMenuStrip itemEditMenu;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.SaveFileDialog saveFileDlg;
		private System.Windows.Forms.OpenFileDialog openFileDlg;
		private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip undoMenuStrip;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem viewCompilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem centerCanvasToolStripMenuItem;
        private System.Windows.Forms.PictureBox btnCenter;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton newProjectToolStripBtn;
	}
}

