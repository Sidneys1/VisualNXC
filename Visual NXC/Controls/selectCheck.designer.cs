namespace Visual_NXC.Controls
{
	partial class selectCheck
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.BackColor = System.Drawing.Color.Transparent;
			this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBox1.Dock = System.Windows.Forms.DockStyle.Right;
			this.checkBox1.Location = new System.Drawing.Point(230, 0);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
			this.checkBox1.Size = new System.Drawing.Size(18, 24);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.UseVisualStyleBackColor = false;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			this.checkBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
			this.checkBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
			// 
			// label1
			// 
			this.label1.AutoEllipsis = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(22, 0);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 1);
			this.label1.Size = new System.Drawing.Size(208, 24);
			this.label1.TabIndex = 2;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Click += new System.EventHandler(this.pictureBox1_Click);
			this.label1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
			this.label1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(22, 24);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
			this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
			// 
			// selectCheck
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.checkBox1);
			this.Name = "selectCheck";
			this.Size = new System.Drawing.Size(248, 24);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
	}
}
