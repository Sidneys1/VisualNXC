using System;
using System.Drawing;
using System.Windows.Forms;

namespace Visual_NXC.Forms
{
	internal partial class structConstruct : Form
	{
		#region Items

		public Classes.Struct returnVal;

		TreeNode builtIn, Enums, Structs;

		#endregion

		public structConstruct(Classes.Struct structToEdit, bool New, Classes.Project currProj)
		{
			InitializeComponent();

			#region Init UI

			Tools.SetDoubleBuffered(itemsTreeVw);
			
			if (NativeMethods.SetWindowTheme(itemsTreeVw.Handle, "EXPLORER", null) != 0)
				Console.WriteLine("Setting TreeView theme to \"EXPLORER\" failed.");
			

			if (GlassLib.Dwm.IsFeatureAvailable())
			{
				bottomDock.BackColor = Color.Black;
				okBtn.Top += 3;
				cancelBtn.Top += 3;
				GlassLib.Dwm.Glass[this].Margins = new GlassLib.DwmMargins(0, 0, 0, bottomDock.Height);
			}

			builtIn = new TreeNode("Built-In Types", 0, 0);
			Structs = new TreeNode("Your Structs", 2, 2);
			Enums = new TreeNode("Your Enumerations", 1, 1);
			itemsTreeVw.Nodes.AddRange(new TreeNode[] { builtIn, Structs, Enums });

			#endregion

			#region Load Built In Types

			TreeNode tn1, tn2, tn3, tn4, tn5, tn6, tn7, tn8;

			tn1 = new TreeNode("Boolean") { Tag = "bool" };
			tn2 = new TreeNode("Byte") { Tag = "byte" };
			tn3 = new TreeNode("Character") { Tag = "char" };
			tn4 = new TreeNode("Integer") { Tag = "int" };
			tn5 = new TreeNode("Short Integer") { Tag = "short" };
			tn6 = new TreeNode("Long Integer") { Tag = "long" };
			tn7 = new TreeNode("Floating Point (Number)") { Tag = "float" };
			tn8 = new TreeNode("String") { Tag = "string" };

			builtIn.Nodes.AddRange(new TreeNode[] { tn1, tn2, tn3, tn4, tn5, tn6, tn7, tn8 });

			#endregion

			#region Load Project Types

			if (currProj.Enumerations.Count == 0)
				Enums.Nodes.Add("", "(None)", 4, 4);
			else
				foreach (Classes.Enumeration Enum in currProj.Enumerations)
					Enums.Nodes.Add(new TreeNode(Enum.Name) { Tag = Enum.Name });

			if (currProj.Structs.Count == 0 || (currProj.Structs.Count == 1 && currProj.Structs[0].Name == structToEdit.Name))
				Structs.Nodes.Add("", "(None)", 4, 4);
			else
				foreach (Classes.Struct Struct in currProj.Structs)
					if (Struct.Name != structToEdit.Name)
						Structs.Nodes.Add(new TreeNode(Struct.Name) { Tag = Struct.Name });

			#endregion

			itemsTreeVw.ExpandAll();

			if (!New)
			{
				nameTxtBx.Text = structToEdit.Name;
				itemsLstBx.Items.AddRange(structToEdit.Members.ToArray());
				nameTxtBx.Font = new Font(nameTxtBx.Font, FontStyle.Regular);
				nameTxtBx.ForeColor = SystemColors.WindowText;
			}
			returnVal = structToEdit;
		}

		#region Mouse

		private void itemsTreeVw_MouseMove(object sender, MouseEventArgs e)
		{
			TreeNode node = itemsTreeVw.GetNodeAt(e.Location);
			if (node != null)
			{
				itemsTreeVw.HotTracking = node.Tag != null;
				itemsTreeVw.Cursor = node.Tag != null ? Cursors.Hand : Cursors.Default;
			}
		}

		private void itemsTreeVw_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.Tag != null)
			{
				Classes.StructMember mem = new Classes.StructMember(e.Node.Tag.ToString(), e.Node.Text);
				using (Forms.addStructItemDlg d = new addStructItemDlg(mem))
				{
					if (d.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
					{
						returnVal.Members.Add(d.retVal);
						itemsLstBx.Items.Add(d.retVal);
					}
				}
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

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			returnVal.Name = nameTxtBx.Text;
		}

		#endregion

		#region Glass

		private void bottomDock_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left && GlassLib.Dwm.IsFeatureAvailable())
			{
				NativeMethods.MoveForm(base.Handle);
			}
		}

		#endregion

		private void removeItmBtn_Click(object sender, EventArgs e)
		{
			if (itemsLstBx.SelectedIndex != -1)
			{
				returnVal.Members.RemoveAt(itemsLstBx.SelectedIndex);
				itemsLstBx.Items.RemoveAt(itemsLstBx.SelectedIndex);
			}
		}
	}
}