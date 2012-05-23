using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockBuilder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void wizardHeader_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.Black, 1f))
            {
                e.Graphics.DrawLine(p, 0, wizardHeaderPanel.Height, wizardHeaderPanel.Width, wizardHeaderPanel.Height);
            }
        }
    }
}
