namespace Visual_NXC.Forms
{
	partial class nxcOutput
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nxcOutput));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.tabBar1 = new Visual_NXC.tabBar();
			this.folderBrwsDlg = new System.Windows.Forms.FolderBrowserDialog();
			this.toolStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(26, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton4.Text = "Save NXC Files";
			this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 25);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(760, 367);
			this.panel1.TabIndex = 6;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tabBar1);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(760, 25);
			this.panel2.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.toolStrip1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(23, 25);
			this.panel3.TabIndex = 6;
			// 
			// tabBar1
			// 
			this.tabBar1.BackColor = System.Drawing.Color.White;
			this.tabBar1.BottomColor = System.Drawing.SystemColors.Control;
			this.tabBar1.BottomLine = false;
			this.tabBar1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabBar1.Location = new System.Drawing.Point(23, 0);
			this.tabBar1.Name = "tabBar1";
			this.tabBar1.Size = new System.Drawing.Size(737, 25);
			this.tabBar1.TabIndex = 5;
			this.tabBar1.TopColor = System.Drawing.SystemColors.Window;
			this.tabBar1.SelectedTabChanged += new System.Action<Visual_NXC.TabItem>(this.tabBar1_SelectedTabChanged);
			// 
			// folderBrwsDlg
			// 
			this.folderBrwsDlg.Description = "Select a folder to place the saved files in...";
			// 
			// nxcOutput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(760, 392);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(500, 300);
			this.Name = "nxcOutput";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "NXC Output";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private tabBar tabBar1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.FolderBrowserDialog folderBrwsDlg;
	}
}