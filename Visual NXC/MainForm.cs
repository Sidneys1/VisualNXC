using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Visual_NXC
{
    /// <summary>
    /// The main window for VisualNXC
    /// </summary>
    public partial class MainForm : STP.AeroNonClientFormV3
    {
        #region Objects

        /// <summary>
        /// Lets us draw the menus on Aero Glass on Vista/7 systems.
        /// </summary>
        Classes.ExMenuRenderer menuRenderer = new Classes.ExMenuRenderer();

        /// <summary>
        /// The currently loaded project.
        /// </summary>
        Classes.Project proj;

        /// <summary>
        /// We need to add and define these at runtime so that we can access them programatically.
        /// </summary>
        TreeNode ThreadsTN, MethodsTN, StructsTN, EnumsTN;

        #endregion

        #region Methods

        /// <summary>
        /// The main window for Visual NXC
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            #region Init Aero

            mainMenu.Renderer = menuRenderer;
            toolStrip.Renderer = menuRenderer;
            base.AeroOnOff += new Action<bool>(MainForm_AeroOnOff);
            if (IsAero())
            {
#if !MONO //ONLY when not on MONO

                //Prepare the menustrip to be 'docked' into the titlebar...
                menuRenderer.isOnGlass = true;
                //mainMenu.Dock = DockStyle.None;
                //mainMenu.Location = new Point(22, 10);

                //Expand down to envelop the menu.
                //(if ExpandIntoFrame, then it 'sucks up' the menu into the titlebar...)
                this.ExpandAmount = mainMenu.Bottom;

                //dock everything else below it...
                //allDock.Dock = DockStyle.None;
                //allDock.Location = new Point(0, mainMenu.Bottom);
                //allDock.Size = new System.Drawing.Size(this.ClientRectangle.Width, this.ClientRectangle.Height);
                //allDock.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

#else //ONLY when on MONO
				//We don't want to suck it up into the titlebar...
				this.ExpandIntoFrame = false;
				this.ExpandAmount = mainMenu.Bottom;
				menuRenderer.isOnGlass = true;
#endif
                //Enable glass extentions!
                this.ExtensionsEnabled = true;
            }

            #endregion

            #region Init UI

            //Add all of the "Items" parent nodes and specify their icons...
            TreeNode addTask = new TreeNode("Add Task", 4, 4);
            addTask.ToolTipText = "Add a task to the project...";
            addTask.Tag = "ADD_TASK";
            ThreadsTN = new TreeNode("Tasks", 0, 0, new TreeNode[] { addTask });
            itemsTreeView.Nodes.Add(ThreadsTN);
            TreeNode addMethod = new TreeNode("Add Method", 4, 4);
            addMethod.ToolTipText = "Add a method to the project...";
            addMethod.Tag = "ADD_METHOD";
            MethodsTN = new TreeNode("Methods", 1, 1, new TreeNode[] { addMethod });
            itemsTreeView.Nodes.Add(MethodsTN);
            TreeNode addEnum = new TreeNode("Add Enumeration...", 4, 4);
            addEnum.ToolTipText = "Add an enumeration to the project...";
            addEnum.Tag = "ADD_ENUM";
            EnumsTN = new TreeNode("Enumerations", 2, 2, new TreeNode[] { addEnum });
            itemsTreeView.Nodes.Add(EnumsTN);
            TreeNode addStruct = new TreeNode("Add Struct", 4, 4);
            addStruct.ToolTipText = "Add a struct to the project...";
            addStruct.Tag = "ADD_STRUCT";
            StructsTN = new TreeNode("Structs", 3, 3, new TreeNode[] { addStruct });
            itemsTreeView.Nodes.Add(StructsTN);

            itemsTreeView.ExpandAll();
            Tools.SetDoubleBuffered(itemsTreeView);
            Tools.SetDoubleBuffered(blocksTreeView);
            Tools.SetDoubleBuffered(mapDisplay);

            int result = 0;
            result += NativeMethods.SetWindowTheme(itemsTreeView.Handle, "EXPLORER", null);
            result += NativeMethods.SetWindowTheme(blocksTreeView.Handle, "EXPLORER", null);
            if (result != 0)
                Console.WriteLine("Setting TreeView theme to \"EXPLORER\" failed.");

            (toolStrip.Renderer as ToolStripProfessionalRenderer).RoundedEdges = false;

            saveFileDlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            #endregion

            #region project binds

            //Plug into these events so when know when the UI needs to update...
            Classes.Project p = new Classes.Project();
            p.Initialize();
            loadProject(p);

            tabBar.SelectedTabChanged += new Action<TabItem>(tabBar1_SelectedTabChanged);

            #endregion
        }

        private void loadProject(Classes.Project project)
        {
            tabBar.CloseAllTabs();

            proj = project;
            proj.NameChanged += new Action(proj_NameChanged);
            proj.DirtyChanged += new Action<string>(proj_DirtyChanged);
            proj.ElementAdded += new Action<Classes.ICodeBlock>(proj_ElementAdded);
            proj.ElementRemoved += new Action<Classes.ICodeBlock>(proj_ElementRemoved);
            proj_NameChanged();

            RefreshEnums();
            RefreshStructs();
            RefreshTasks();
            //RefreshMethods();
            RefreshUndoMenu();

            tabBar.AddTab(new TabItem("main", Classes.CodeType.Task, proj.GetPage("main")));
            ideCanvas.Page = proj.GetPage("main");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Classes.Task mainTask = (Classes.Task)proj.GetElement("main");
            //mainTask.Actions.Add(new Classes.GenericCodeElement("Rotate Motor Forward (Port A, 100%)", 
            //	"OnFwd(OUT_A, 100);", Color.FromArgb(0, 165, 255)));
            //mainTask.Actions.Add(new Classes.GenericCodeElement("Wait (2.5s)", "Wait(2500);", Color.FromArgb(255, 195, 0)));
        }

        private void GenNxcOutput()
        {
            #region Variables

            //Whether or not the project contains 
            bool enums = proj.Enumerations.Count > 0, structs = proj.Structs.Count > 0;

            Forms.nxcOutput outputForm = new Forms.nxcOutput();

            System.Text.StringBuilder codeBuilder = new System.Text.StringBuilder();

            string enumerations = "", struc = "", pro = "";

            #endregion

            #region Enums.h

            if (enums)
            {
                codeBuilder.AppendLine("//These are the enumerations...\r\n");
                foreach (Classes.Enumeration item in proj.Enumerations)
                {
                    codeBuilder.AppendLine(item.GenerateCode() + "\r\n");
                }
                outputForm.AddTab(codeBuilder.ToString(), "enums.h", Classes.CodeType.Enumerations);
                enumerations = codeBuilder.ToString();
            }

            #endregion

            codeBuilder.Clear();

            #region Structs.h

            if (structs)
            {
                codeBuilder.AppendLine("//These are the structure definitions...\r\n");
                if (enums)
                {
                    codeBuilder.AppendLine("//First include enumeration definitions:");
                    codeBuilder.AppendLine("#include \"enums.h\";\r\n");
                }

                foreach (Classes.Struct item in proj.Structs)
                {
                    codeBuilder.AppendLine(item.GenerateCode() + "\r\n");
                }
                outputForm.AddTab(codeBuilder.ToString(), "structs.h", Classes.CodeType.Structs);
                struc = codeBuilder.ToString();
            }

            #endregion

            codeBuilder.Clear();

            #region Proj.nxc

            codeBuilder.AppendLine("//This is the main code file...\r\n");

            if (structs || enums)
            {
                codeBuilder.AppendLine("//First we must include any struct/enum definitions:");

                if (enums)
                    codeBuilder.AppendLine("#include \"enums.h\";");
                if (structs)
                    codeBuilder.AppendLine("#include \"structs.h\";");

                codeBuilder.AppendLine();
            }

            #region Add Methods...

            List<Classes.ICodeBlock> itemz;
            itemz = proj.CodeElements.FindAll(new Predicate<Classes.ICodeBlock>(isMethod));
            if (itemz.Count > 0)
                codeBuilder.AppendLine("\r\n//The program's method(s):\r\n");
            foreach (Classes.ICodeBlock item in itemz)
            {
                codeBuilder.AppendLine(item.GenerateCode);
                codeBuilder.AppendLine();
            }

            #endregion

            #region Add Threads...

            itemz = proj.CodeElements.FindAll(new Predicate<Classes.ICodeBlock>(isThread));
            if (itemz.Count > 1)
                codeBuilder.AppendLine("//These are the rest of the program's tasks:\r\n");
            foreach (Classes.ICodeBlock item in itemz)
            {
                if (item.Name != "main")
                {
                    codeBuilder.AppendLine(item.GenerateCode);
                    codeBuilder.AppendLine();
                }
            }

            #endregion

            codeBuilder.AppendLine("//This is the program entry point:");
            codeBuilder.AppendLine(proj.GetElement("main").GenerateCode);

            outputForm.AddTab(codeBuilder.ToString(), proj.Name.Trim().Replace(" ", "") + ".nxc", Classes.CodeType.Code);
            pro = codeBuilder.ToString();
            #endregion

            #region Output Files

            if (outputForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                if (!File.Exists(outputForm.SelectedPath + "\\" + proj.Name + ".nxc"))
                {
                    using (TextWriter r = File.CreateText(outputForm.SelectedPath + "\\" + proj.Name + ".nxc"))
                    {
                        r.Write(pro);
                    }
                }
                else
                    MessageBox.Show(this, "This file already exists! Try again, and choose another location. Or rename the project.", "File Already Exists", MessageBoxButtons.OK);

                if (structs && !File.Exists(outputForm.SelectedPath + "\\structs.h"))
                {
                    using (TextWriter r = File.CreateText(outputForm.SelectedPath + "\\structs.h"))
                    {
                        r.Write(struc);
                    }
                }
                else if (File.Exists(outputForm.SelectedPath + "\\structs.h"))
                    MessageBox.Show(this, "This file already exists! Try again, and choose another location. Or rename the project.", "File Already Exists: structs.h", MessageBoxButtons.OK);

                if (structs && !File.Exists(outputForm.SelectedPath + "\\enums.h"))
                {
                    using (TextWriter r = File.CreateText(outputForm.SelectedPath + "\\enums.h"))
                    {
                        r.Write(struc);
                    }
                }
                else if (File.Exists(outputForm.SelectedPath + "\\enums.h"))
                    MessageBox.Show(this, "This file already exists! Try again, and choose another location. Or rename the project.", "File Already Exists: enums.h", MessageBoxButtons.OK);
            }
            #endregion

            outputForm.Dispose();
        }

        #endregion

        #region Aero

        /// <summary>
        /// This is just for if Aero gets turned off while our app is open...
        /// </summary>
        /// <param name="obj">Aero on or off</param>
        void MainForm_AeroOnOff(bool obj)
        {
            menuRenderer.isOnGlass = obj;
        }

        private void mainMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && GlassLib.Dwm.Glass[this].Enabled)
            {
                NativeMethods.MoveForm(base.Handle);
            }
        }

        #endregion

        #region Project Binds

        //An item has been removed from the project... We better take it off of the "Items" treeview.
        void proj_ElementRemoved(Classes.ICodeBlock obj)
        {
            #region Treeviews

            if (obj.Type == Classes.CodeType.Task && obj.Name == "main")
                return;
            switch (obj.Type)
            {
                case Visual_NXC.Classes.CodeType.Task:
                    foreach (TreeNode item in ThreadsTN.Nodes)
                    {
                        if (item.Tag == obj)
                            ThreadsTN.Nodes.Remove(item);
                    }
                    break;
                case Visual_NXC.Classes.CodeType.Method:
                    foreach (TreeNode item in MethodsTN.Nodes)
                    {
                        if (item.Tag == obj)
                            MethodsTN.Nodes.Remove(item);
                    }
                    break;
                case Visual_NXC.Classes.CodeType.Enumerations:
                    foreach (TreeNode item in EnumsTN.Nodes)
                    {
                        if (item.Tag == obj)
                            EnumsTN.Nodes.Remove(item);
                    }
                    break;
                case Visual_NXC.Classes.CodeType.Structs:
                    foreach (TreeNode item in StructsTN.Nodes)
                    {
                        if (item.Tag == obj)
                            StructsTN.Nodes.Remove(item);
                    }
                    break;
            }

            #endregion
        }

        //An item has been added to the project! We better add if to the "Items" treeview!
        void proj_ElementAdded(Classes.ICodeBlock obj)
        {
            obj.GuiChanged += new Action<string>(obj_GuiChanged);
            #region Treeviews

            TreeNode n = new TreeNode(obj.Name);
            n.Tag = obj;
            switch (obj.Type)
            {
                case Visual_NXC.Classes.CodeType.Task:
                    n.ImageIndex = n.SelectedImageIndex = 0;
                    ThreadsTN.Nodes.Insert(0, n);
                    break;
                case Visual_NXC.Classes.CodeType.Method:
                    n.ImageIndex = n.SelectedImageIndex = 1;
                    MethodsTN.Nodes.Insert(0, n);
                    break;
                case Visual_NXC.Classes.CodeType.Enumerations:
                    n.ImageIndex = n.SelectedImageIndex = 2;
                    EnumsTN.Nodes.Insert(0, n);
                    break;
                case Visual_NXC.Classes.CodeType.Structs:
                    n.ImageIndex = n.SelectedImageIndex = 3;
                    StructsTN.Nodes.Insert(0, n);
                    break;
            }

            #endregion
        }

        void obj_GuiChanged(string reason)
        {
            if (mapPanelHost.Visible)
                mapDisplay.Refresh();
        }

        //Just determines whether the project is saved or not.
        //All we need to do here is add the "*" to the titlebar and enable/disable the save button
        void proj_DirtyChanged(string reason)
        {
            saveProjectToolStripMenuItem.Enabled = proj.Dirty;

            proj_NameChanged();

            #region Undo/Redo

            if (proj.Dirty == true)
            {
                Tools.saveUndoLevel(proj, reason);
                RefreshUndoMenu();
            }

            #endregion
        }

        private void RefreshUndoMenu()
        {
            undoMenuStrip.Items.Clear();
            if (proj.currentUndoLevel > 0)
            {
                undoToolStripMenuItem.Enabled = true;
                foreach (undoLevel level in Tools.getUndoLevels(proj))
                {
                    ToolStripMenuItem m = new ToolStripMenuItem((level.levelNumber + 1).ToString() + ") " + level.name);
                    m.Tag = level.levelNumber;
                    m.Checked = proj.currentUndoLevel == level.levelNumber;
                    m.Click += new EventHandler(undoMenuItem_Click);
                    undoMenuStrip.Items.Add(m);
                }

                undoMenuStrip.Items.Add(new ToolStripSeparator());

                ToolStripMenuItem undoMenuButton = new ToolStripMenuItem("Undo");
                undoMenuButton.ShortcutKeys = Keys.Control | Keys.Z;
                undoMenuButton.Click += new EventHandler(undoMenuButton_Click);
                undoMenuStrip.Items.Add(undoMenuButton);

                ToolStripMenuItem redoMenuButton = new ToolStripMenuItem("Redo");
                redoMenuButton.ShortcutKeys = Keys.Control | Keys.Y;
                redoMenuButton.Click += new EventHandler(redoMenuButton_Click);
                undoMenuStrip.Items.Add(redoMenuButton);
            }
            else
                undoToolStripMenuItem.Enabled = false;
        }

        void undoMenuButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void redoMenuButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void undoMenuItem_Click(object sender, EventArgs e)
        {
            //proj = Tools.setUndoLevel(proj, (int)(sender as ToolStripMenuItem).Tag);

            //proj.NameChanged += new Action(proj_NameChanged);
            //proj.DirtyChanged += new Action<string>(proj_DirtyChanged);
            //proj.ElementAdded += new Action<Classes.ICodeBlock>(proj_ElementAdded);
            //proj.ElementRemoved += new Action<Classes.ICodeBlock>(proj_ElementRemoved);

            //RefreshEnums();
            //RefreshStructs();
            //RefreshTasks();
            ////RefreshMethods();
            //RefreshUndoMenu();

            //List<TabItem> itz = tabBar.items;
            //tabBar.CloseAllTabs();
            //foreach (TabItem itm in itz)
            //{
            //    tabBar.AddTab(new TabItem(itm.Title, itm.Type, proj.GetPage(itm.Title)));
            //}
        }


        //Which happens down here. This is just when the name or dirty bit changes.
        void proj_NameChanged()
        {
            this.Text =
                proj.GetTitle() +
                " - " +
                Global.Branding +
                " " +
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
        }

        #endregion

        #region UI Events/Painting

        #region Treeviews

        //When an item is dragged out of the "Available Objects" window
        private void treeView2_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //Only if it's a bottom-level node!
            if ((e.Item as TreeNode).Nodes.Count == 0)
                DoDragDrop(Global.DragDropIdent + (e.Item as TreeNode).Tag.ToString(), DragDropEffects.Move | DragDropEffects.Copy);
        }

        //Only hot track if it's a tagged node!
        private void treeView1_MouseMove(object sender, MouseEventArgs e)
        {
            itemsTreeView.HotTracking = itemsTreeView.GetNodeAt(e.Location).Tag != null;
            itemsTreeView.Cursor = (itemsTreeView.GetNodeAt(e.Location).Tag != null) ? Cursors.Hand : Cursors.Default;
        }

        TreeNode rightClickNode;
        private void itemsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                #region Left Click
                if (e.Node.Nodes.Count == 0)
                {
                    if (e.Node.Tag is Classes.IGuiPage)
                    {
                        if (!tabBar.isPageOpen(e.Node.Tag as Classes.IGuiPage))
                        {
                            tabBar.AddTab(new TabItem(e.Node.Text, (e.Node.Tag as Classes.ICodeBlock).Type,
                                (e.Node.Tag as Classes.IGuiPage)));
                        }
                        else
                            tabBar.SelectTab(e.Node.Tag as Classes.IGuiPage);
                    }
                    else if (e.Node.Tag.ToString() == "ADD_ENUM")
                    {
                        using (Forms.enumEdit newEnum = new Forms.enumEdit(new Classes.Enumeration()))
                        {
                            if (newEnum.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                            {
                                proj.Enumerations.Add(newEnum.returnVal);
                                RefreshEnums();
                            }
                        }
                    }
                    else if (e.Node.Parent == EnumsTN)
                    {
                        using (Forms.enumEdit newEnum = new Forms.enumEdit((Classes.Enumeration)e.Node.Tag))
                        {
                            if (newEnum.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                            {
                                proj.Enumerations.Remove((Classes.Enumeration)e.Node.Tag);
                                proj.Enumerations.Add(newEnum.returnVal);
                                RefreshEnums();
                            }
                        }
                    }
                    else if (e.Node.Tag.ToString() == "ADD_STRUCT")
                    {
                        Classes.Struct newStruct = new Classes.Struct("NewStruct");
                        using (Forms.structConstruct strConstr = new Forms.structConstruct(newStruct, true, proj))
                        {
                            if (strConstr.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                            {
                                proj.Structs.Add(strConstr.returnVal);
                                RefreshStructs();
                            }
                        }
                    }
                    else if (e.Node.Parent == StructsTN)
                    {
                        using (Forms.structConstruct strConstr =
                            new Forms.structConstruct((Classes.Struct)e.Node.Tag, false, proj))
                        {
                            if (strConstr.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                            {
                                proj.Structs.Remove((Classes.Struct)e.Node.Tag);
                                proj.Structs.Add(strConstr.returnVal);
                                RefreshStructs();
                            }
                        }
                    }
                }
                #endregion
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right
                && e.Node.Tag != null
                && e.Node.Tag.ToString() != "ADD_STRUCT"
                && e.Node.Tag.ToString() != "ADD_ENUM"
                && e.Node.Tag.ToString() != "ADD_TASK"
                && e.Node.Tag.ToString() != "ADD_METHOD"
                )
            {
                rightClickNode = e.Node;
                itemEditMenu.Show(itemsTreeView.PointToScreen(e.Location));
                deleteToolStripMenuItem.Enabled = e.Node.Text != "main";
            }
        }

        private void RefreshStructs()
        {
            StructsTN.Nodes.Clear();
            foreach (Classes.Struct str in proj.Structs)
            {
                TreeNode node = new TreeNode(str.Name, 3, 3);
                node.Tag = str;
                StructsTN.Nodes.Add(node);
            }
            TreeNode addStruct = new TreeNode("Add Struct", 4, 4);
            addStruct.ToolTipText = "Add a struct to the project...";
            addStruct.Tag = "ADD_STRUCT";
            StructsTN.Nodes.Add(addStruct);
        }

        private void RefreshEnums()
        {
            EnumsTN.Nodes.Clear();
            foreach (Classes.Enumeration enm in proj.Enumerations)
            {
                TreeNode node = new TreeNode(enm.Name, 2, 2);
                node.Tag = enm;
                EnumsTN.Nodes.Add(node);
            }
            TreeNode addEnum = new TreeNode("Add Enumeration...", 4, 4);
            addEnum.ToolTipText = "Add an enumeration to the project...";
            addEnum.Tag = "ADD_ENUM";
            EnumsTN.Nodes.Add(addEnum);
        }

        private void RefreshTasks()
        {
            ThreadsTN.Nodes.Clear();
            foreach (Classes.Task task in proj.CodeElements)
            {
                TreeNode node = new TreeNode(task.Name, 0, 0);
                node.Tag = task;
                ThreadsTN.Nodes.Add(node);
            }
            TreeNode addTask = new TreeNode("Add Task...", 4, 4);
            addTask.ToolTipText = "Add a new task to the project...";
            addTask.Tag = "ADD_TASK";
            ThreadsTN.Nodes.Add(addTask);
        }


        #endregion

        #region Splitter grippy painting

        //This whole region is pretty straightforward, so I'll let you figure it out yourself..

        private void splitter1_Paint(object sender, PaintEventArgs e)
        {
            float center = ((float)mainSplitter.Height / 2f);

            using (SolidBrush b = new SolidBrush(SystemColors.ControlLight))
            {
                using (Pen p = new Pen(b, 2f))
                {
                    e.Graphics.DrawLine(p, new PointF(2f, center + 6f), new PointF(2f, center + 11f));
                    e.Graphics.DrawLine(p, new PointF(2f, center - 2f), new PointF(2f, center + 3f));
                    e.Graphics.DrawLine(p, new PointF(2f, center - 5f), new PointF(2f, center - 10f));
                }
            }
            using (SolidBrush b = new SolidBrush(SystemColors.ControlDark))
            {
                using (Pen p = new Pen(b, 1.5f))
                {
                    e.Graphics.DrawLine(p, new PointF(1f, center + 6f), new PointF(1f, center + 10f));
                    e.Graphics.DrawLine(p, new PointF(1f, center - 2f), new PointF(1f, center + 2f));
                    e.Graphics.DrawLine(p, new PointF(1f, center - 6f), new PointF(1f, center - 10f));
                }
            }
        }

        private void splitter1_Resize(object sender, EventArgs e)
        {
            mainSplitter.Refresh();
        }

        private void splitter2_Paint(object sender, PaintEventArgs e)
        {
            float center = ((float)blocksItemsSplitter.Width / 2f);

            using (SolidBrush b = new SolidBrush(SystemColors.ControlLight))
            {
                using (Pen p = new Pen(b, 2f))
                {
                    e.Graphics.DrawLine(p, new PointF(center + 6f, 2f), new PointF(center + 11f, 2f));
                    e.Graphics.DrawLine(p, new PointF(center - 2f, 2f), new PointF(center + 3f, 2f));
                    e.Graphics.DrawLine(p, new PointF(center - 5f, 2f), new PointF(center - 10f, 2f));
                }
            }
            using (SolidBrush b = new SolidBrush(SystemColors.ControlDark))
            {
                using (Pen p = new Pen(b, 1.5f))
                {
                    e.Graphics.DrawLine(p, new PointF(center + 6f, 1f), new PointF(center + 10f, 1f));
                    e.Graphics.DrawLine(p, new PointF(center - 2f, 1f), new PointF(center + 2f, 1f));
                    e.Graphics.DrawLine(p, new PointF(center - 6f, 1f), new PointF(center - 10f, 1f));
                }
            }
        }

        private void splitter2_Resize(object sender, EventArgs e)
        {
            blocksItemsSplitter.Refresh();
        }

        #endregion

        #region Menus and Buttons

        //Just UI menu stuff...
        #region File

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (proj.Dirty)
            {
                DialogResult r = MessageBox.Show(this,
                    "The Visual NXC project you are trying to close has not been saved!\r\n\r\nWould you like to save it now?",
                    "Unsaved Project...",
                    MessageBoxButtons.YesNoCancel);

                switch (r)
                {
                    case DialogResult.Cancel:
                        return;
                    case DialogResult.Yes:
                        saveProjectAsToolStripMenuItem_Click(this, null);
                        break;
                }
            }

            Classes.Project p = new Classes.Project();
            p.Initialize();
            loadProject(p);
        }

        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDlg.ShowDialog(this);
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(proj.Path))
            {
                this.saveFileDlg.ShowDialog(this);
            }
            else
            {
                if (!proj.Save(proj.Path))
                    MessageBox.Show(this, "The project failed to save. Try again in a different location.",
                        "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDlg.FileName = proj.Name;
            saveFileDlg.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region View

        private void selectNextTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabBar.SelectNext();
        }

        private void selectPreviousTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabBar.SelectPrevious();
        }

        private void closeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabBar.CloseCurrentTab();
        }

        private void viewGeneratedNXCCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenNxcOutput();
        }

        #endregion

        #region Help

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.AboutBox b = new Forms.AboutBox();
            b.ShowDialog();
            b.Dispose();
        }

        private void helpVisualNXCWikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (System.Diagnostics.Process p = new System.Diagnostics.Process())
            {
                p.StartInfo.FileName = "https://sourceforge.net/p/visualnxc/home/";
                p.Start();
            }
        }

        #endregion

        #region Toobar

        private void compilerToolStripButton_Click(object sender, EventArgs e)
        {
            Forms.Compiler comp = new Forms.Compiler();
            comp.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Options o = new Forms.Options();
            o.ShowDialog(this);
            o.Dispose();
        }

        private void centerToolStripButton_Click(object sender, EventArgs e)
        {
            if (ideCanvas.Page != null)
            {
                ideCanvas.Page.PanOffset = Point.Empty;
                ideCanvas.Refresh();
            }
        }

        #endregion

        #region Tools

        private void toolBtn_Click(object sender, EventArgs e)
        {
            if (sender == toolBtnMouse && ideCanvas.currentTool != Classes.Tool.Cursor)
            {
                #region Cursor

                ideCanvas.currentTool = Classes.Tool.Cursor;
                ideCanvas.Cursor = Cursors.Default;

                toolBtnMouse.Image = Properties.Resources.cursor_dark;
                toolBtnHand.Image = Properties.Resources.hand___gloved_transparent;
                toolBtnErase.Image = Properties.Resources.eraser_transparent;

                toolBtnMouse.Tag = "";
                toolBtnHand.Tag = "TRANS";
                toolBtnErase.Tag = "TRANS";

                toolTipProvider.SetToolTip(mouseDescLeft, "Select Blocks");
                toolTipProvider.SetToolTip(mouseDescMiddle, "Pan Canvas");
                mouseDescLeft.Visible = mouseDescMiddle.Visible = true;
                mouseDescRight.Visible = false;

                #endregion
            }
            else if (sender == toolBtnHand && ideCanvas.currentTool != Classes.Tool.Hand)
            {
                #region Hand

                ideCanvas.currentTool = Classes.Tool.Hand;
                ideCanvas.Cursor = NativeMethods.CreateCursor(Properties.Resources.HandOpen, Global.HandHotspot.X, Global.HandHotspot.Y);

                toolBtnMouse.Image = Properties.Resources.cursor_transparent;
                toolBtnHand.Image = Properties.Resources.hand___gloved;
                toolBtnErase.Image = Properties.Resources.eraser_transparent;

                toolBtnMouse.Tag = "TRANS";
                toolBtnHand.Tag = "";
                toolBtnErase.Tag = "TRANS";

                toolTipProvider.SetToolTip(mouseDescLeft, "Pan Canvas");
                mouseDescLeft.Visible = true;
                mouseDescRight.Visible = mouseDescMiddle.Visible = false;

                #endregion
            }
            else if (sender == toolBtnErase && ideCanvas.currentTool != Classes.Tool.Eraser)
            {
                #region Eraser

                ideCanvas.currentTool = Classes.Tool.Eraser;
                ideCanvas.Cursor = NativeMethods.CreateCursor(Properties.Resources.eraser_crosshairs, 3, 14);

                toolBtnMouse.Image = Properties.Resources.cursor_transparent;
                toolBtnHand.Image = Properties.Resources.hand___gloved_transparent;
                toolBtnErase.Image = Properties.Resources.eraser;

                toolBtnMouse.Tag = "TRANS";
                toolBtnHand.Tag = "TRANS";
                toolBtnErase.Tag = "";

                toolTipProvider.SetToolTip(mouseDescLeft, "Erase Blocks");
                mouseDescLeft.Visible = true;
                mouseDescRight.Visible = mouseDescMiddle.Visible = false;

                #endregion
            }
        }

        private void toolBtns_MouseEnter(object sender, EventArgs e)
        {
            if (sender == toolBtnMouse && toolBtnMouse.Tag.ToString() == "TRANS")
                toolBtnMouse.Image = Properties.Resources.cursor_dark;
            else if (sender == toolBtnHand && toolBtnHand.Tag.ToString() == "TRANS")
                toolBtnHand.Image = Properties.Resources.hand___gloved;
            else if (sender == toolBtnErase && toolBtnErase.Tag.ToString() == "TRANS")
                toolBtnErase.Image = Properties.Resources.eraser;
        }

        private void toolBtns_MouseLeave(object sender, EventArgs e)
        {
            if (sender == toolBtnMouse && toolBtnMouse.Tag.ToString() == "TRANS")
                toolBtnMouse.Image = Properties.Resources.cursor_transparent;
            else if (sender == toolBtnHand && toolBtnHand.Tag.ToString() == "TRANS")
                toolBtnHand.Image = Properties.Resources.hand___gloved_transparent;
            else if (sender == toolBtnErase && toolBtnErase.Tag.ToString() == "TRANS")
                toolBtnErase.Image = Properties.Resources.eraser_transparent;
        }

        private void btnCenter_MouseEnter(object sender, EventArgs e)
        {
            btnCenter.Image = Properties.Resources.layer_resize_actual;
        }

        private void btnCenter_MouseLeave(object sender, EventArgs e)
        {
            btnCenter.Image = Properties.Resources.layer_resize_actual_transparent;
        }

        #endregion

        #region Item Right Click Menu

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (rightClickNode.Tag is Classes.IGuiPage)
            {
                if (!tabBar.isPageOpen(rightClickNode.Tag as Classes.IGuiPage))
                {
                    tabBar.AddTab(new TabItem(rightClickNode.Text,
                        (rightClickNode.Tag as Classes.ICodeBlock).Type,
                        (rightClickNode.Tag as Classes.IGuiPage)
                    ));
                }
                else
                    tabBar.SelectTab(rightClickNode.Tag as Classes.IGuiPage);
            }
            else if (rightClickNode.Parent == EnumsTN)
            {
                using (Forms.enumEdit newEnum = new Forms.enumEdit((Classes.Enumeration)rightClickNode.Tag))
                {
                    if (newEnum.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        proj.Enumerations.Remove((Classes.Enumeration)rightClickNode.Tag);
                        proj.Enumerations.Add(newEnum.returnVal);
                        RefreshEnums();
                    }
                }
            }
            else if (rightClickNode.Parent == StructsTN)
            {
                using (Forms.structConstruct strConstr =
                    new Forms.structConstruct((Classes.Struct)rightClickNode.Tag, false, proj))
                {
                    if (strConstr.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        proj.Structs.Remove((Classes.Struct)rightClickNode.Tag);
                        proj.Structs.Add(strConstr.returnVal);
                        RefreshStructs();
                    }
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rightClickNode.Parent == EnumsTN)
            {
                proj.Enumerations.Remove((Classes.Enumeration)rightClickNode.Tag);
                RefreshEnums();
            }
            else if (rightClickNode.Parent == StructsTN)
            {
                proj.Structs.Remove((Classes.Struct)rightClickNode.Tag);
                RefreshStructs();
            }
            else if (rightClickNode.Parent == ThreadsTN)
            {
                proj.DeleteElement(rightClickNode.Tag as Classes.ICodeBlock);
                //RefreshThreads();
            }
            else if (rightClickNode.Parent == MethodsTN)
            {
                proj.DeleteElement(rightClickNode.Tag as Classes.ICodeBlock);
                //RefreshMethods();
            }
        }

        #endregion

        #endregion

        void tabBar1_SelectedTabChanged(TabItem obj)
        {
            if (obj != null)
            {
                ideCanvas.Page = obj.assocItem as Classes.IGuiPage;
            }
            else
                ideCanvas.Page = null;
        }

        #endregion

        #region Predicates

        bool isThread(Classes.ICodeBlock i)
        {
            return i.Type == Classes.CodeType.Task;
        }

        bool isMethod(Classes.ICodeBlock i)
        {
            return i.Type == Classes.CodeType.Method;
        }

        #endregion

        #region Pop-out panes

        private void popOutButton_MouseEnter(object sender, EventArgs e)
        {
            PictureBox sent = sender as PictureBox;
            if (sent.Tag.ToString() == "out")
                sent.Image = Properties.Resources.pop_out_highlight;
            else if (sent.Tag.ToString() == "right")
                sent.Image = Properties.Resources.dock_right_highlight;
            else
                sent.Image = Properties.Resources.dock_left_highlight;
        }

        private void popOutButton_MouseLeave(object sender, EventArgs e)
        {
            PictureBox sent = sender as PictureBox;
            if (sent.Tag.ToString() == "out")
                sent.Image = Properties.Resources.pop_out;
            else if (sent.Tag.ToString() == "right")
                sent.Image = Properties.Resources.dock_right;
            else
                sent.Image = Properties.Resources.dock_left;
        }

        private void NavMapPopOutBtn_Click(object sender, EventArgs e)
        {
            if (navMapPopOutBtn.Tag.ToString() == "out")
            {
                Forms.popOutForm pop = new Forms.popOutForm(this);
                pop.Height = Height;
                pop.Location = new Point(Location.X - pop.Width, Location.Y);
                pop.Text = "Navigation Map";
                SuspendLayout();
                mapPanel.Parent = pop;
                mapPanelHost.Visible = mapSplitter.Visible = false;
                ResumeLayout();
                pop.FormClosing += new FormClosingEventHandler(mappop_FormClosing);
                pop.Show(this);
                navMapPopOutBtn.Tag = "left";
                popOutNavigationMapToolStripMenuItem.Text = "Pop In Navigation Map";
                navMapPopOutBtn.Image = Properties.Resources.dock_left;
                popOutNavigationMapToolStripMenuItem.Image = Properties.Resources.dock_left_highlight;
            }
            else
            {
                SuspendLayout();
                mapPanelHost.Visible = mapSplitter.Visible = true;
                Forms.popOutForm pop = mapPanel.Parent as Forms.popOutForm;
                mapPanel.Parent = mapPanelHost;
                ResumeLayout();
                pop.Close();
                navMapPopOutBtn.Tag = "out";
                popOutNavigationMapToolStripMenuItem.Text = "Pop Out Navigation Map";
                navMapPopOutBtn.Image = Properties.Resources.pop_out;
                popOutNavigationMapToolStripMenuItem.Image = Properties.Resources.pop_out_highlight;
            }
        }

        void mappop_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((sender as Forms.popOutForm).Controls.Count > 0)
                NavMapPopOutBtn_Click(this, null);
        }

        private void objItmPopOut_Click(object sender, EventArgs e)
        {
            if (objItmPopOutBtn.Tag.ToString() == "out")
            {
                Forms.popOutForm pop = new Forms.popOutForm(this);
                pop.Height = Height;
                pop.Location = new Point(Location.X + Width, Location.Y);
                pop.Text = "Blocks and Items";
                SuspendLayout();
                blocksItemsPanel.Parent = pop;
                blocksItemsPanelHost.Visible =
                mainSplitter.Visible = false;
                ResumeLayout();
                pop.FormClosing += new FormClosingEventHandler(objItmPop_FormClosing);
                pop.Show(this);
                objItmPopOutBtn.Tag = "right";
                objItmPopOutBtn.Image = Properties.Resources.dock_right;
                popOutBlocksItemsToolStripMenuItem.Text = "Pop In Objects/Items Panel";
                popOutBlocksItemsToolStripMenuItem.Image = Properties.Resources.dock_right_highlight;
            }
            else
            {
                SuspendLayout();
                blocksItemsPanelHost.Visible = blocksItemsSplitter.Visible = mainSplitter.Visible = true;
                Forms.popOutForm pop = blocksItemsPanel.Parent as Forms.popOutForm;
                blocksItemsPanel.Parent = blocksItemsPanelHost;
                ResumeLayout();
                pop.Close();
                objItmPopOutBtn.Tag = "out";
                objItmPopOutBtn.Image = Properties.Resources.pop_out;
                popOutBlocksItemsToolStripMenuItem.Text = "Pop Out Objects/Items Panel";
                popOutBlocksItemsToolStripMenuItem.Image = Properties.Resources.pop_out_highlight;
            }
        }

        void objItmPop_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((sender as Forms.popOutForm).Controls.Count > 0)
                objItmPopOut_Click(this, null);
        }

        private void showNavigationMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (navMapPopOutBtn.Tag.ToString() == "left")
            {
                Forms.popOutForm pop = mapPanel.Parent as Forms.popOutForm;
                mapPanel.Parent = mapPanelHost;
                pop.Close();
                navMapPopOutBtn.Tag = "out";
                popOutNavigationMapToolStripMenuItem.Text = "Pop Out Navigation Map";
                navMapPopOutBtn.Image = Properties.Resources.pop_out;
                popOutNavigationMapToolStripMenuItem.Image = Properties.Resources.pop_out_highlight;
            }
            mapPanelHost.Visible = 
                mapSplitter.Visible = 
                popOutNavigationMapToolStripMenuItem.Enabled = 
                showNavigationMapToolStripMenuItem.Checked = 
                !showNavigationMapToolStripMenuItem.Checked;
        }

        #region Mini Map

        private void mapDisplay_Paint(object sender, PaintEventArgs e)
        {
            if (ideCanvas.Page != null)
            {
                ideCanvas.Page.DrawThumb(e.Graphics, (sender as Control).ClientSize);
                using (System.Drawing.Drawing2D.LinearGradientBrush b = new System.Drawing.Drawing2D.LinearGradientBrush(
                    new Point(mapDisplay.Width + 1, 0), new Point(mapDisplay.Width - 16, 0), SystemColors.Window, Color.Transparent))
                {
                    e.Graphics.FillRectangle(b, new Rectangle(new Point(mapDisplay.Width - 15, 0), new Size(15, e.ClipRectangle.Height)));
                }
            }
        }

        private void mapDisplay_Resize(object sender, EventArgs e)
        {
            mapDisplay.Refresh();
        }

        #endregion

        private void navMapCloseBtn_MouseEnter(object sender, EventArgs e)
        {
            navMapCloseBtn.Image = Properties.Resources.cross;
        }

        private void navMapCloseBtn_MouseLeave(object sender, EventArgs e)
        {
            navMapCloseBtn.Image = Properties.Resources.cross_transparent;
        }

        #endregion

        #region I/O

        private void saveFileDlg_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!proj.Save(saveFileDlg.FileName))
                MessageBox.Show(this, "The project failed to save. Try again in a different location.",
                    "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void openFileDlg_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loadProject(Classes.Project.Open(openFileDlg.FileName));
        }

        #endregion
    }
}