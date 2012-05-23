namespace Visual_NXC.Forms
{
	partial class structConstruct
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(structConstruct));
			this.leftDock = new System.Windows.Forms.Panel();
			this.itemsTreeVw = new System.Windows.Forms.TreeView();
			this.treeViewImages = new System.Windows.Forms.ImageList(this.components);
			this.leftPnlHeadr = new System.Windows.Forms.Panel();
			this.itemsLbl = new System.Windows.Forms.Label();
			this.itemsIco = new System.Windows.Forms.PictureBox();
			this.seperator = new STP.SeperatorControl();
			this.bottomDock = new System.Windows.Forms.Panel();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.okBtn = new System.Windows.Forms.Button();
			this.headerLbl = new System.Windows.Forms.Label();
			this.nameTxtBx = new System.Windows.Forms.TextBox();
			this.tblLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
			this.itemsLstBx = new System.Windows.Forms.ListBox();
			this.removeItmBtn = new System.Windows.Forms.Button();
			this.leftDock.SuspendLayout();
			this.leftPnlHeadr.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.itemsIco)).BeginInit();
			this.bottomDock.SuspendLayout();
			this.tblLayoutPnl.SuspendLayout();
			this.SuspendLayout();
			// 
			// leftDock
			// 
			this.leftDock.BackColor = System.Drawing.SystemColors.Window;
			this.leftDock.Controls.Add(this.itemsTreeVw);
			this.leftDock.Controls.Add(this.leftPnlHeadr);
			this.leftDock.Dock = System.Windows.Forms.DockStyle.Left;
			this.leftDock.Location = new System.Drawing.Point(0, 0);
			this.leftDock.Name = "leftDock";
			this.leftDock.Size = new System.Drawing.Size(175, 373);
			this.leftDock.TabIndex = 0;
			// 
			// itemsTreeVw
			// 
			this.itemsTreeVw.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.itemsTreeVw.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemsTreeVw.ImageIndex = 3;
			this.itemsTreeVw.ImageList = this.treeViewImages;
			this.itemsTreeVw.Location = new System.Drawing.Point(0, 16);
			this.itemsTreeVw.Name = "itemsTreeVw";
			this.itemsTreeVw.SelectedImageIndex = 3;
			this.itemsTreeVw.ShowLines = false;
			this.itemsTreeVw.ShowNodeToolTips = true;
			this.itemsTreeVw.Size = new System.Drawing.Size(175, 357);
			this.itemsTreeVw.TabIndex = 1;
			this.itemsTreeVw.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.itemsTreeVw_NodeMouseClick);
			this.itemsTreeVw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.itemsTreeVw_MouseMove);
			// 
			// treeViewImages
			// 
			this.treeViewImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewImages.ImageStream")));
			this.treeViewImages.TransparentColor = System.Drawing.Color.Transparent;
			this.treeViewImages.Images.SetKeyName(0, "folder-open.png");
			this.treeViewImages.Images.SetKeyName(1, "enums.png");
			this.treeViewImages.Images.SetKeyName(2, "structs.png");
			this.treeViewImages.Images.SetKeyName(3, "plus.png");
			this.treeViewImages.Images.SetKeyName(4, "cross.png");
			// 
			// leftPnlHeadr
			// 
			this.leftPnlHeadr.Controls.Add(this.itemsLbl);
			this.leftPnlHeadr.Controls.Add(this.itemsIco);
			this.leftPnlHeadr.Dock = System.Windows.Forms.DockStyle.Top;
			this.leftPnlHeadr.Location = new System.Drawing.Point(0, 0);
			this.leftPnlHeadr.Name = "leftPnlHeadr";
			this.leftPnlHeadr.Size = new System.Drawing.Size(175, 16);
			this.leftPnlHeadr.TabIndex = 0;
			// 
			// itemsLbl
			// 
			this.itemsLbl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemsLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.itemsLbl.ForeColor = System.Drawing.SystemColors.GrayText;
			this.itemsLbl.Location = new System.Drawing.Point(16, 0);
			this.itemsLbl.Name = "itemsLbl";
			this.itemsLbl.Size = new System.Drawing.Size(159, 16);
			this.itemsLbl.TabIndex = 12;
			this.itemsLbl.Text = "Available Types:";
			// 
			// itemsIco
			// 
			this.itemsIco.Dock = System.Windows.Forms.DockStyle.Left;
			this.itemsIco.Image = ((System.Drawing.Image)(resources.GetObject("itemsIco.Image")));
			this.itemsIco.Location = new System.Drawing.Point(0, 0);
			this.itemsIco.Name = "itemsIco";
			this.itemsIco.Size = new System.Drawing.Size(16, 16);
			this.itemsIco.TabIndex = 0;
			this.itemsIco.TabStop = false;
			// 
			// seperator
			// 
			this.seperator.BackColor = System.Drawing.SystemColors.Window;
			this.seperator.BottomLineColor = System.Drawing.SystemColors.ControlLightLight;
			this.seperator.Dock = System.Windows.Forms.DockStyle.Left;
			this.seperator.InternalPadding = 0;
			this.seperator.Location = new System.Drawing.Point(175, 0);
			this.seperator.Name = "seperator";
			this.seperator.orientation = STP.Orientation.Vertical;
			this.seperator.RaisedOrSunken = true;
			this.seperator.Size = new System.Drawing.Size(3, 373);
			this.seperator.TabIndex = 1;
			this.seperator.TopLineColor = System.Drawing.SystemColors.ControlDark;
			// 
			// bottomDock
			// 
			this.bottomDock.Controls.Add(this.cancelBtn);
			this.bottomDock.Controls.Add(this.okBtn);
			this.bottomDock.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bottomDock.Location = new System.Drawing.Point(0, 373);
			this.bottomDock.Name = "bottomDock";
			this.bottomDock.Size = new System.Drawing.Size(672, 29);
			this.bottomDock.TabIndex = 2;
			this.bottomDock.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bottomDock_MouseDown);
			// 
			// cancelBtn
			// 
			this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(594, 3);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 1;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			// 
			// okBtn
			// 
			this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn.Location = new System.Drawing.Point(513, 3);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(75, 23);
			this.okBtn.TabIndex = 0;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = true;
			// 
			// headerLbl
			// 
			this.headerLbl.AutoEllipsis = true;
			this.headerLbl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.headerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
			this.headerLbl.Location = new System.Drawing.Point(3, 0);
			this.headerLbl.Name = "headerLbl";
			this.headerLbl.Size = new System.Drawing.Size(124, 29);
			this.headerLbl.TabIndex = 3;
			this.headerLbl.Text = "Current Items Of:";
			this.headerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nameTxtBx
			// 
			this.nameTxtBx.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nameTxtBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nameTxtBx.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.nameTxtBx.Location = new System.Drawing.Point(133, 3);
			this.nameTxtBx.Name = "nameTxtBx";
			this.nameTxtBx.Size = new System.Drawing.Size(358, 24);
			this.nameTxtBx.TabIndex = 4;
			this.nameTxtBx.Tag = "Enter Name...";
			this.nameTxtBx.Text = "Enter Name...";
			this.nameTxtBx.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			this.nameTxtBx.Enter += new System.EventHandler(this.textBox1_Enter);
			this.nameTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			this.nameTxtBx.Leave += new System.EventHandler(this.textBox1_Leave);
			// 
			// tblLayoutPnl
			// 
			this.tblLayoutPnl.ColumnCount = 2;
			this.tblLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
			this.tblLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tblLayoutPnl.Controls.Add(this.nameTxtBx, 0, 0);
			this.tblLayoutPnl.Controls.Add(this.headerLbl, 0, 0);
			this.tblLayoutPnl.Controls.Add(this.itemsLstBx, 0, 1);
			this.tblLayoutPnl.Controls.Add(this.removeItmBtn, 1, 2);
			this.tblLayoutPnl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblLayoutPnl.Location = new System.Drawing.Point(178, 0);
			this.tblLayoutPnl.Name = "tblLayoutPnl";
			this.tblLayoutPnl.RowCount = 3;
			this.tblLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.tblLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.tblLayoutPnl.Size = new System.Drawing.Size(494, 373);
			this.tblLayoutPnl.TabIndex = 5;
			// 
			// itemsLstBx
			// 
			this.tblLayoutPnl.SetColumnSpan(this.itemsLstBx, 2);
			this.itemsLstBx.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemsLstBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.itemsLstBx.FormattingEnabled = true;
			this.itemsLstBx.ItemHeight = 16;
			this.itemsLstBx.Location = new System.Drawing.Point(3, 32);
			this.itemsLstBx.Name = "itemsLstBx";
			this.itemsLstBx.ScrollAlwaysVisible = true;
			this.itemsLstBx.Size = new System.Drawing.Size(488, 309);
			this.itemsLstBx.TabIndex = 5;
			// 
			// removeItmBtn
			// 
			this.removeItmBtn.Dock = System.Windows.Forms.DockStyle.Right;
			this.removeItmBtn.Image = ((System.Drawing.Image)(resources.GetObject("removeItmBtn.Image")));
			this.removeItmBtn.Location = new System.Drawing.Point(388, 347);
			this.removeItmBtn.Name = "removeItmBtn";
			this.removeItmBtn.Size = new System.Drawing.Size(103, 23);
			this.removeItmBtn.TabIndex = 6;
			this.removeItmBtn.Text = "Remove Item";
			this.removeItmBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.removeItmBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.removeItmBtn.UseVisualStyleBackColor = true;
			this.removeItmBtn.Click += new System.EventHandler(this.removeItmBtn_Click);
			// 
			// structConstruct
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(672, 402);
			this.Controls.Add(this.tblLayoutPnl);
			this.Controls.Add(this.seperator);
			this.Controls.Add(this.leftDock);
			this.Controls.Add(this.bottomDock);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "structConstruct";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Struct Editor";
			this.leftDock.ResumeLayout(false);
			this.leftPnlHeadr.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.itemsIco)).EndInit();
			this.bottomDock.ResumeLayout(false);
			this.tblLayoutPnl.ResumeLayout(false);
			this.tblLayoutPnl.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel leftDock;
		private System.Windows.Forms.Panel leftPnlHeadr;
		private System.Windows.Forms.PictureBox itemsIco;
		private System.Windows.Forms.Label itemsLbl;
		private System.Windows.Forms.TreeView itemsTreeVw;
		private STP.SeperatorControl seperator;
		private System.Windows.Forms.Panel bottomDock;
		private System.Windows.Forms.ImageList treeViewImages;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Label headerLbl;
		private System.Windows.Forms.TextBox nameTxtBx;
		private System.Windows.Forms.TableLayoutPanel tblLayoutPnl;
		private System.Windows.Forms.ListBox itemsLstBx;
		private System.Windows.Forms.Button removeItmBtn;
	}
}