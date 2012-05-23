namespace Visual_NXC.Forms
{
	partial class Options
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
			this.tabsPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.optionHeaderLbl = new System.Windows.Forms.Label();
			this.outputCheck = new Visual_NXC.Controls.selectCheck();
			this.compilerCheck = new Visual_NXC.Controls.selectCheck();
			this.codeAppearanceCheck = new Visual_NXC.Controls.selectCheck();
			this.seperatorCtrl = new STP.SeperatorControl();
			this.footerPnl = new System.Windows.Forms.Panel();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.okBtn = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.contentPanel = new System.Windows.Forms.Panel();
			this.headerPanel = new System.Windows.Forms.Panel();
			this.optionLbl = new System.Windows.Forms.Label();
			this.defaultLbl = new System.Windows.Forms.Label();
			this.tabsPanel.SuspendLayout();
			this.footerPnl.SuspendLayout();
			this.panel2.SuspendLayout();
			this.headerPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabsPanel
			// 
			this.tabsPanel.BackColor = System.Drawing.SystemColors.Window;
			this.tabsPanel.Controls.Add(this.optionHeaderLbl);
			this.tabsPanel.Controls.Add(this.outputCheck);
			this.tabsPanel.Controls.Add(this.compilerCheck);
			this.tabsPanel.Controls.Add(this.codeAppearanceCheck);
			this.tabsPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.tabsPanel.Location = new System.Drawing.Point(0, 0);
			this.tabsPanel.Name = "tabsPanel";
			this.tabsPanel.Size = new System.Drawing.Size(130, 371);
			this.tabsPanel.TabIndex = 0;
			// 
			// optionHeaderLbl
			// 
			this.optionHeaderLbl.AutoSize = true;
			this.optionHeaderLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.optionHeaderLbl.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.optionHeaderLbl.Location = new System.Drawing.Point(3, 0);
			this.optionHeaderLbl.Name = "optionHeaderLbl";
			this.optionHeaderLbl.Size = new System.Drawing.Size(99, 13);
			this.optionHeaderLbl.TabIndex = 3;
			this.optionHeaderLbl.Text = "Options Categories:";
			// 
			// outputCheck
			// 
			this.outputCheck.BackColor = System.Drawing.SystemColors.Window;
			this.outputCheck.ControlText = "Output";
			this.outputCheck.Dock = System.Windows.Forms.DockStyle.Top;
			this.outputCheck.Image = ((System.Drawing.Image)(resources.GetObject("outputCheck.Image")));
			this.outputCheck.Location = new System.Drawing.Point(3, 16);
			this.outputCheck.Name = "outputCheck";
			this.outputCheck.SelectedState = Visual_NXC.Controls.SelectedState.Selected;
			this.outputCheck.ShowCheck = false;
			this.outputCheck.Size = new System.Drawing.Size(124, 24);
			this.outputCheck.TabIndex = 0;
			this.outputCheck.Selected += new System.EventHandler(this.tabSelected);
			// 
			// compilerCheck
			// 
			this.compilerCheck.BackColor = System.Drawing.SystemColors.Window;
			this.compilerCheck.ControlText = "Compiler";
			this.compilerCheck.Dock = System.Windows.Forms.DockStyle.Top;
			this.compilerCheck.Image = ((System.Drawing.Image)(resources.GetObject("compilerCheck.Image")));
			this.compilerCheck.Location = new System.Drawing.Point(3, 46);
			this.compilerCheck.Name = "compilerCheck";
			this.compilerCheck.SelectedState = Visual_NXC.Controls.SelectedState.None;
			this.compilerCheck.ShowCheck = false;
			this.compilerCheck.Size = new System.Drawing.Size(124, 24);
			this.compilerCheck.TabIndex = 1;
			this.compilerCheck.Selected += new System.EventHandler(this.tabSelected);
			// 
			// codeAppearanceCheck
			// 
			this.codeAppearanceCheck.BackColor = System.Drawing.SystemColors.Window;
			this.codeAppearanceCheck.ControlText = "Code Appearance";
			this.codeAppearanceCheck.Dock = System.Windows.Forms.DockStyle.Top;
			this.codeAppearanceCheck.Image = ((System.Drawing.Image)(resources.GetObject("codeAppearanceCheck.Image")));
			this.codeAppearanceCheck.Location = new System.Drawing.Point(3, 76);
			this.codeAppearanceCheck.Name = "codeAppearanceCheck";
			this.codeAppearanceCheck.SelectedState = Visual_NXC.Controls.SelectedState.None;
			this.codeAppearanceCheck.ShowCheck = false;
			this.codeAppearanceCheck.Size = new System.Drawing.Size(124, 24);
			this.codeAppearanceCheck.TabIndex = 2;
			this.codeAppearanceCheck.Selected += new System.EventHandler(this.tabSelected);
			// 
			// seperatorCtrl
			// 
			this.seperatorCtrl.BackColor = System.Drawing.SystemColors.Window;
			this.seperatorCtrl.BottomLineColor = System.Drawing.SystemColors.ControlLightLight;
			this.seperatorCtrl.Dock = System.Windows.Forms.DockStyle.Left;
			this.seperatorCtrl.InternalPadding = 0;
			this.seperatorCtrl.Location = new System.Drawing.Point(130, 0);
			this.seperatorCtrl.Name = "seperatorCtrl";
			this.seperatorCtrl.orientation = STP.Orientation.Vertical;
			this.seperatorCtrl.RaisedOrSunken = true;
			this.seperatorCtrl.Size = new System.Drawing.Size(3, 371);
			this.seperatorCtrl.TabIndex = 1;
			this.seperatorCtrl.TopLineColor = System.Drawing.SystemColors.ControlDark;
			// 
			// footerPnl
			// 
			this.footerPnl.Controls.Add(this.cancelBtn);
			this.footerPnl.Controls.Add(this.okBtn);
			this.footerPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.footerPnl.Location = new System.Drawing.Point(0, 342);
			this.footerPnl.Name = "footerPnl";
			this.footerPnl.Size = new System.Drawing.Size(461, 29);
			this.footerPnl.TabIndex = 2;
			// 
			// cancelBtn
			// 
			this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(374, 3);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 0;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			// 
			// okBtn
			// 
			this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn.Location = new System.Drawing.Point(293, 3);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(75, 23);
			this.okBtn.TabIndex = 0;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = true;
			this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.contentPanel);
			this.panel2.Controls.Add(this.headerPanel);
			this.panel2.Controls.Add(this.footerPnl);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(133, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(461, 371);
			this.panel2.TabIndex = 0;
			// 
			// contentPanel
			// 
			this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.contentPanel.Location = new System.Drawing.Point(0, 13);
			this.contentPanel.Name = "contentPanel";
			this.contentPanel.Size = new System.Drawing.Size(461, 329);
			this.contentPanel.TabIndex = 3;
			// 
			// headerPanel
			// 
			this.headerPanel.Controls.Add(this.optionLbl);
			this.headerPanel.Controls.Add(this.defaultLbl);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Location = new System.Drawing.Point(0, 0);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Size = new System.Drawing.Size(461, 13);
			this.headerPanel.TabIndex = 0;
			// 
			// optionLbl
			// 
			this.optionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.optionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.optionLbl.ForeColor = System.Drawing.SystemColors.GrayText;
			this.optionLbl.Location = new System.Drawing.Point(0, 0);
			this.optionLbl.Name = "optionLbl";
			this.optionLbl.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this.optionLbl.Size = new System.Drawing.Size(408, 13);
			this.optionLbl.TabIndex = 0;
			this.optionLbl.Text = "Option...";
			this.optionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// defaultLbl
			// 
			this.defaultLbl.AutoSize = true;
			this.defaultLbl.Dock = System.Windows.Forms.DockStyle.Right;
			this.defaultLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.defaultLbl.ForeColor = System.Drawing.SystemColors.GrayText;
			this.defaultLbl.Location = new System.Drawing.Point(408, 0);
			this.defaultLbl.Name = "defaultLbl";
			this.defaultLbl.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
			this.defaultLbl.Size = new System.Drawing.Size(53, 13);
			this.defaultLbl.TabIndex = 1;
			this.defaultLbl.Text = "Default";
			// 
			// Options
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(594, 371);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.seperatorCtrl);
			this.Controls.Add(this.tabsPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Options";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Visual NXC Options";
			this.tabsPanel.ResumeLayout(false);
			this.tabsPanel.PerformLayout();
			this.footerPnl.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.headerPanel.ResumeLayout(false);
			this.headerPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel tabsPanel;
		private Controls.selectCheck outputCheck;
		private STP.SeperatorControl seperatorCtrl;
		private System.Windows.Forms.Panel footerPnl;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel headerPanel;
		private System.Windows.Forms.Label optionLbl;
		private System.Windows.Forms.Label defaultLbl;
		private Controls.selectCheck compilerCheck;
		private Controls.selectCheck codeAppearanceCheck;
		private System.Windows.Forms.Panel contentPanel;
		private System.Windows.Forms.Label optionHeaderLbl;
	}
}