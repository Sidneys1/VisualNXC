namespace Visual_NXC.Forms
{
	partial class enumEdit
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(enumEdit));
			this.accordianBtn = new System.Windows.Forms.Panel();
			this.advOptsAccLbl = new System.Windows.Forms.Label();
			this.advOptsAccPicBx = new System.Windows.Forms.PictureBox();
			this.mainPnl = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.enumBox = new System.Windows.Forms.ListBox();
			this.removeButton = new System.Windows.Forms.Button();
			this.addValTxtBx = new System.Windows.Forms.TextBox();
			this.advOptsPnl = new System.Windows.Forms.Panel();
			this.linearRdBtn = new System.Windows.Forms.RadioButton();
			this.manualRdBtn = new System.Windows.Forms.RadioButton();
			this.graphBox = new System.Windows.Forms.Panel();
			this.manualGrpBx = new System.Windows.Forms.GroupBox();
			this.manValUpDwn = new System.Windows.Forms.NumericUpDown();
			this.hexPrefixLbl = new System.Windows.Forms.Label();
			this.manValSetBtn = new System.Windows.Forms.Button();
			this.manValLbl = new System.Windows.Forms.Label();
			this.dlgBtnsPnl = new System.Windows.Forms.Panel();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.accordianBtn.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.advOptsAccPicBx)).BeginInit();
			this.mainPnl.SuspendLayout();
			this.advOptsPnl.SuspendLayout();
			this.manualGrpBx.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.manValUpDwn)).BeginInit();
			this.dlgBtnsPnl.SuspendLayout();
			this.SuspendLayout();
			// 
			// accordianBtn
			// 
			this.accordianBtn.Controls.Add(this.advOptsAccLbl);
			this.accordianBtn.Controls.Add(this.advOptsAccPicBx);
			this.accordianBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.accordianBtn.Location = new System.Drawing.Point(0, 193);
			this.accordianBtn.Name = "accordianBtn";
			this.accordianBtn.Size = new System.Drawing.Size(469, 16);
			this.accordianBtn.TabIndex = 0;
			// 
			// advOptsAccLbl
			// 
			this.advOptsAccLbl.Dock = System.Windows.Forms.DockStyle.Left;
			this.advOptsAccLbl.Location = new System.Drawing.Point(21, 0);
			this.advOptsAccLbl.Name = "advOptsAccLbl";
			this.advOptsAccLbl.Size = new System.Drawing.Size(104, 16);
			this.advOptsAccLbl.TabIndex = 1;
			this.advOptsAccLbl.Text = "Advanced Options";
			// 
			// advOptsAccPicBx
			// 
			this.advOptsAccPicBx.Cursor = System.Windows.Forms.Cursors.Hand;
			this.advOptsAccPicBx.Dock = System.Windows.Forms.DockStyle.Left;
			this.advOptsAccPicBx.Image = global::Visual_NXC.Properties.Resources.chevronDown;
			this.advOptsAccPicBx.Location = new System.Drawing.Point(0, 0);
			this.advOptsAccPicBx.Name = "advOptsAccPicBx";
			this.advOptsAccPicBx.Size = new System.Drawing.Size(21, 16);
			this.advOptsAccPicBx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.advOptsAccPicBx.TabIndex = 0;
			this.advOptsAccPicBx.TabStop = false;
			this.advOptsAccPicBx.Click += new System.EventHandler(this.accordian_Click);
			// 
			// mainPnl
			// 
			this.mainPnl.Controls.Add(this.textBox1);
			this.mainPnl.Controls.Add(this.label2);
			this.mainPnl.Controls.Add(this.label1);
			this.mainPnl.Controls.Add(this.enumBox);
			this.mainPnl.Controls.Add(this.removeButton);
			this.mainPnl.Controls.Add(this.addValTxtBx);
			this.mainPnl.Controls.Add(this.accordianBtn);
			this.mainPnl.Dock = System.Windows.Forms.DockStyle.Top;
			this.mainPnl.Location = new System.Drawing.Point(0, 0);
			this.mainPnl.Name = "mainPnl";
			this.mainPnl.Size = new System.Drawing.Size(469, 209);
			this.mainPnl.TabIndex = 1;
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
			this.textBox1.Location = new System.Drawing.Point(139, 9);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(318, 24);
			this.textBox1.TabIndex = 7;
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.addValTxtBx_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
			this.label2.Location = new System.Drawing.Point(12, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(121, 18);
			this.label2.TabIndex = 6;
			this.label2.Text = "Current Items Of:";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
			this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Location = new System.Drawing.Point(12, 167);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Add Item:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// enumBox
			// 
			this.enumBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.enumBox.FormattingEnabled = true;
			this.enumBox.ItemHeight = 16;
			this.enumBox.Location = new System.Drawing.Point(12, 38);
			this.enumBox.Name = "enumBox";
			this.enumBox.Size = new System.Drawing.Size(445, 116);
			this.enumBox.TabIndex = 4;
			this.enumBox.SelectedIndexChanged += new System.EventHandler(this.valueBox_SelectedIndexChanged);
			// 
			// removeButton
			// 
			this.removeButton.Image = global::Visual_NXC.Properties.Resources.cross;
			this.removeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.removeButton.Location = new System.Drawing.Point(361, 163);
			this.removeButton.Name = "removeButton";
			this.removeButton.Size = new System.Drawing.Size(96, 24);
			this.removeButton.TabIndex = 3;
			this.removeButton.Text = "Remove Item";
			this.removeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.removeButton.UseVisualStyleBackColor = true;
			this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
			// 
			// addValTxtBx
			// 
			this.addValTxtBx.AcceptsReturn = true;
			this.addValTxtBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addValTxtBx.Location = new System.Drawing.Point(101, 164);
			this.addValTxtBx.Name = "addValTxtBx";
			this.addValTxtBx.Size = new System.Drawing.Size(254, 22);
			this.addValTxtBx.TabIndex = 2;
			this.addValTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.addValTxtBx_KeyDown);
			this.addValTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.addValTxtBx_KeyPress);
			// 
			// advOptsPnl
			// 
			this.advOptsPnl.Controls.Add(this.linearRdBtn);
			this.advOptsPnl.Controls.Add(this.manualRdBtn);
			this.advOptsPnl.Controls.Add(this.graphBox);
			this.advOptsPnl.Controls.Add(this.manualGrpBx);
			this.advOptsPnl.Dock = System.Windows.Forms.DockStyle.Top;
			this.advOptsPnl.Location = new System.Drawing.Point(0, 209);
			this.advOptsPnl.Name = "advOptsPnl";
			this.advOptsPnl.Size = new System.Drawing.Size(469, 129);
			this.advOptsPnl.TabIndex = 2;
			this.advOptsPnl.Visible = false;
			// 
			// linearRdBtn
			// 
			this.linearRdBtn.AutoSize = true;
			this.linearRdBtn.Location = new System.Drawing.Point(12, 29);
			this.linearRdBtn.Name = "linearRdBtn";
			this.linearRdBtn.Size = new System.Drawing.Size(101, 17);
			this.linearRdBtn.TabIndex = 2;
			this.linearRdBtn.Text = "Assign Manually";
			this.linearRdBtn.UseVisualStyleBackColor = true;
			// 
			// manualRdBtn
			// 
			this.manualRdBtn.AutoSize = true;
			this.manualRdBtn.Checked = true;
			this.manualRdBtn.Location = new System.Drawing.Point(12, 6);
			this.manualRdBtn.Name = "manualRdBtn";
			this.manualRdBtn.Size = new System.Drawing.Size(130, 17);
			this.manualRdBtn.TabIndex = 1;
			this.manualRdBtn.TabStop = true;
			this.manualRdBtn.Text = "Assign Values Linearly";
			this.manualRdBtn.UseVisualStyleBackColor = true;
			this.manualRdBtn.CheckedChanged += new System.EventHandler(this.advOpts_CheckedChanged);
			// 
			// graphBox
			// 
			this.graphBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.graphBox.Location = new System.Drawing.Point(260, 6);
			this.graphBox.Name = "graphBox";
			this.graphBox.Size = new System.Drawing.Size(200, 117);
			this.graphBox.TabIndex = 0;
			this.graphBox.Paint += new System.Windows.Forms.PaintEventHandler(this.graphBox_Paint);
			// 
			// manualGrpBx
			// 
			this.manualGrpBx.Controls.Add(this.manValUpDwn);
			this.manualGrpBx.Controls.Add(this.hexPrefixLbl);
			this.manualGrpBx.Controls.Add(this.manValSetBtn);
			this.manualGrpBx.Controls.Add(this.manValLbl);
			this.manualGrpBx.Enabled = false;
			this.manualGrpBx.Location = new System.Drawing.Point(6, 32);
			this.manualGrpBx.Name = "manualGrpBx";
			this.manualGrpBx.Size = new System.Drawing.Size(248, 91);
			this.manualGrpBx.TabIndex = 3;
			this.manualGrpBx.TabStop = false;
			// 
			// manValUpDwn
			// 
			this.manValUpDwn.Hexadecimal = true;
			this.manValUpDwn.Location = new System.Drawing.Point(21, 64);
			this.manValUpDwn.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.manValUpDwn.Name = "manValUpDwn";
			this.manValUpDwn.Size = new System.Drawing.Size(174, 20);
			this.manValUpDwn.TabIndex = 1;
			// 
			// hexPrefixLbl
			// 
			this.hexPrefixLbl.AutoSize = true;
			this.hexPrefixLbl.Location = new System.Drawing.Point(6, 66);
			this.hexPrefixLbl.Name = "hexPrefixLbl";
			this.hexPrefixLbl.Size = new System.Drawing.Size(18, 13);
			this.hexPrefixLbl.TabIndex = 3;
			this.hexPrefixLbl.Text = "0x";
			// 
			// manValSetBtn
			// 
			this.manValSetBtn.Location = new System.Drawing.Point(201, 64);
			this.manValSetBtn.Name = "manValSetBtn";
			this.manValSetBtn.Size = new System.Drawing.Size(44, 20);
			this.manValSetBtn.TabIndex = 2;
			this.manValSetBtn.Text = "Set";
			this.manValSetBtn.UseVisualStyleBackColor = true;
			this.manValSetBtn.Click += new System.EventHandler(this.button1_Click);
			// 
			// manValLbl
			// 
			this.manValLbl.Dock = System.Windows.Forms.DockStyle.Top;
			this.manValLbl.Location = new System.Drawing.Point(3, 16);
			this.manValLbl.Name = "manValLbl";
			this.manValLbl.Size = new System.Drawing.Size(242, 49);
			this.manValLbl.TabIndex = 4;
			this.manValLbl.Text = "Select an item above to edit its hexadecimal value. Setting two or more items to " +
    "the same value results in their being synonymous.";
			// 
			// dlgBtnsPnl
			// 
			this.dlgBtnsPnl.Controls.Add(this.cancelButton);
			this.dlgBtnsPnl.Controls.Add(this.okButton);
			this.dlgBtnsPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dlgBtnsPnl.Location = new System.Drawing.Point(0, 209);
			this.dlgBtnsPnl.Name = "dlgBtnsPnl";
			this.dlgBtnsPnl.Size = new System.Drawing.Size(469, 35);
			this.dlgBtnsPnl.TabIndex = 3;
			this.dlgBtnsPnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dlbBtnsPnl_MouseDown);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(391, 6);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(310, 6);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// enumEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(469, 244);
			this.Controls.Add(this.dlgBtnsPnl);
			this.Controls.Add(this.advOptsPnl);
			this.Controls.Add(this.mainPnl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "enumEdit";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Enumeration Editor";
			this.accordianBtn.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.advOptsAccPicBx)).EndInit();
			this.mainPnl.ResumeLayout(false);
			this.mainPnl.PerformLayout();
			this.advOptsPnl.ResumeLayout(false);
			this.advOptsPnl.PerformLayout();
			this.manualGrpBx.ResumeLayout(false);
			this.manualGrpBx.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.manValUpDwn)).EndInit();
			this.dlgBtnsPnl.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel accordianBtn;
		private System.Windows.Forms.PictureBox advOptsAccPicBx;
		private System.Windows.Forms.Panel mainPnl;
		private System.Windows.Forms.Panel advOptsPnl;
		private System.Windows.Forms.RadioButton linearRdBtn;
		private System.Windows.Forms.RadioButton manualRdBtn;
		private System.Windows.Forms.Panel graphBox;
		private System.Windows.Forms.GroupBox manualGrpBx;
		private System.Windows.Forms.Button manValSetBtn;
		private System.Windows.Forms.NumericUpDown manValUpDwn;
		private System.Windows.Forms.ListBox enumBox;
		private System.Windows.Forms.TextBox addValTxtBx;
		private System.Windows.Forms.Panel dlgBtnsPnl;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label advOptsAccLbl;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.Label hexPrefixLbl;
		private System.Windows.Forms.Label manValLbl;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
	}
}