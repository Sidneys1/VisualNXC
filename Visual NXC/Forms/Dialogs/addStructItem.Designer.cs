namespace Visual_NXC.Forms
{
	partial class addStructItemDlg
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addStructItemDlg));
			this.bottomDock = new System.Windows.Forms.Panel();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.okBtn = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.addNewLbl = new System.Windows.Forms.Label();
			this.nameTxtBx = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.bottomDock.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// bottomDock
			// 
			this.bottomDock.Controls.Add(this.cancelBtn);
			this.bottomDock.Controls.Add(this.okBtn);
			this.bottomDock.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bottomDock.Location = new System.Drawing.Point(0, 98);
			this.bottomDock.Name = "bottomDock";
			this.bottomDock.Size = new System.Drawing.Size(350, 29);
			this.bottomDock.TabIndex = 3;
			this.bottomDock.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bottomDock_MouseDown);
			// 
			// cancelBtn
			// 
			this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(272, 3);
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
			this.okBtn.Location = new System.Drawing.Point(191, 3);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(75, 23);
			this.okBtn.TabIndex = 0;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(3, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(16, 16);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// addNewLbl
			// 
			this.addNewLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.addNewLbl.AutoEllipsis = true;
			this.addNewLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addNewLbl.Location = new System.Drawing.Point(12, 5);
			this.addNewLbl.Name = "addNewLbl";
			this.addNewLbl.Size = new System.Drawing.Size(326, 30);
			this.addNewLbl.TabIndex = 5;
			this.addNewLbl.Text = "Add New: ";
			// 
			// nameTxtBx
			// 
			this.nameTxtBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nameTxtBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nameTxtBx.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.nameTxtBx.Location = new System.Drawing.Point(78, 38);
			this.nameTxtBx.Name = "nameTxtBx";
			this.nameTxtBx.Size = new System.Drawing.Size(260, 24);
			this.nameTxtBx.TabIndex = 6;
			this.nameTxtBx.Tag = "Enter Name...";
			this.nameTxtBx.Text = "Enter Name...";
			this.nameTxtBx.TextChanged += new System.EventHandler(this.nameTxtBx_TextChanged);
			this.nameTxtBx.Enter += new System.EventHandler(this.textBox1_Enter);
			this.nameTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			this.nameTxtBx.Leave += new System.EventHandler(this.textBox1_Leave);
			// 
			// checkBox1
			// 
			this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(269, 68);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(69, 17);
			this.checkBox1.TabIndex = 7;
			this.checkBox1.Text = "unsigned";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(12, 68);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(50, 17);
			this.checkBox2.TabIndex = 8;
			this.checkBox2.Text = "Array";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Enabled = false;
			this.checkBox3.Location = new System.Drawing.Point(68, 68);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(136, 17);
			this.checkBox3.TabIndex = 9;
			this.checkBox3.Text = "Default Array Elements:";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDown1.Enabled = false;
			this.numericUpDown1.Location = new System.Drawing.Point(210, 67);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(53, 20);
			this.numericUpDown1.TabIndex = 10;
			this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 18);
			this.label2.TabIndex = 11;
			this.label2.Text = "Named:";
			// 
			// addStructItemDlg
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(350, 127);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.nameTxtBx);
			this.Controls.Add(this.addNewLbl);
			this.Controls.Add(this.bottomDock);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "addStructItemDlg";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Item...";
			this.bottomDock.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel bottomDock;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label addNewLbl;
		private System.Windows.Forms.TextBox nameTxtBx;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label2;
	}
}