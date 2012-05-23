using System;
using System.Drawing;
using System.Windows.Forms;

namespace Visual_NXC.Forms
{
	internal partial class addStructItemDlg : Form
	{
		public Classes.StructMember retVal;
		public addStructItemDlg(Classes.StructMember mem)
		{
			InitializeComponent();
			addNewLbl.Text += mem.FriendlyType;
			retVal = mem;
			if (GlassLib.Dwm.IsFeatureAvailable())
			{
				bottomDock.BackColor = Color.Black;
				okBtn.Top += 3;
				cancelBtn.Top += 3;
				GlassLib.Dwm.Glass[this].Margins = new GlassLib.DwmMargins(0, 0, 0, bottomDock.Height);
			}
		}

		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			numericUpDown1.Enabled = checkBox3.Checked && checkBox3.Enabled;
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			checkBox3.Enabled = checkBox2.Checked;
		}

		#region Glass

		private void bottomDock_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left && GlassLib.Dwm.IsFeatureAvailable())
			{
				NativeMethods.MoveForm(base.Handle);
			}
		}

		#endregion

		#region NameBox

		private void textBox1_Enter(object sender, EventArgs e)
		{
			if (nameTxtBx.Text == nameTxtBx.Tag.ToString())
			{
				nameTxtBx.Text = "";
				nameTxtBx.Font = new Font(nameTxtBx.Font, FontStyle.Regular);
				nameTxtBx.ForeColor = SystemColors.WindowText;
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(nameTxtBx.Text))
			{
				nameTxtBx.Text = nameTxtBx.Tag.ToString();
				nameTxtBx.Font = new Font(nameTxtBx.Font, FontStyle.Italic);
				nameTxtBx.ForeColor = SystemColors.ControlDark;
			}
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			Keys key = e.KeyCode;
			if (key == Keys.Space)
			{
				e.SuppressKeyPress = true;
				e.Handled = true;
			}
			else
				base.OnKeyDown(e);
		}

		private void nameTxtBx_TextChanged(object sender, EventArgs e)
		{
			retVal.Name = nameTxtBx.Text;
		}

		#endregion

		
	}
}
