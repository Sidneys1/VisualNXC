namespace BlockBuilder.Wizard_Pages
{
    partial class Step_1_Welcome
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.label1.Location = new System.Drawing.Point(-10, -20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 128);
            this.label1.TabIndex = 0;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(66, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 20, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 42);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome to the Visual NXC Block builder! This tool will help you create new block" +
    "s for Visual NXC to use. You get to change the color, type, and code of the bloc" +
    "k yourself.\r\n";
            // 
            // welcomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "welcomePage";
            this.Size = new System.Drawing.Size(400, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
