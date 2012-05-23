using System;
using System.Drawing;
using System.Windows.Forms;

namespace Visual_NXC.Forms
{
	internal partial class enumEdit : Form
	{
		STP.FormResizeAnimator_v2 frs;
		bool useHex = false;
		int smallHeight = 270;
		public Classes.Enumeration returnVal;

		public enumEdit(Classes.Enumeration enumToEdit)
		{
			InitializeComponent();
			textBox1.Text = enumToEdit.Name;
			smallHeight = this.Height;
			frs = new STP.FormResizeAnimator_v2(this, 25);
			frs.ResizeSpeed = 25;
			frs.Done += new EventHandler(formResize_Done);
			frs.SmoothResize = true;
			if (GlassLib.Dwm.IsFeatureAvailable())
			{
				dlgBtnsPnl.BackColor = Color.Black;
				dlgBtnsPnl.Height = 30;
				GlassLib.Dwm.Glass[this].Margins = new GlassLib.DwmMargins(0, 0, 0, dlgBtnsPnl.Height);
			}

			foreach (Classes.EnumValue val in enumToEdit.Values)
			{
				enumBox.Items.Add(val);
			}
		}

		void formResize_Done(object sender, EventArgs e)
		{
			advOptsPnl.Visible = this.Height != 272;
		}

		private void graphBox_Paint(object sender, PaintEventArgs e)
		{
			using (SolidBrush b = new SolidBrush(Color.FromArgb(50, SystemColors.ControlDark)))
			{
				using (Pen p = new Pen(b, .5f))
				{
					p.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
					p.DashPattern = new float[] { 5f, 5f };

					for (int i = 25; i < this.Width; i += 25)
					{
						e.Graphics.DrawLine(p, new Point(i, 0), new Point(i, this.Height));
					}
					for (int i = 25; i < this.Height; i += 25)
					{
						e.Graphics.DrawLine(p, new Point(0, i), new Point(this.Width, i));
					}
				}
			}

			if (enumBox.Items.Count > 0)
			{
				using (SolidBrush b = new SolidBrush(SystemColors.ControlDark))
				{
					using (Pen p = new Pen(b, 3f))
					{
						p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
						e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
						e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

						Classes.EnumValue enval = (Classes.EnumValue)enumBox.Items[0];
						float scaleY = GetScaleVal();
						float lastY = enval.value*scaleY;
						float lastX = 0;
						float xStep = (float)graphBox.Width / ((float)enumBox.Items.Count - 1);

						for (int i = 1; i < enumBox.Items.Count; i++)
						{
							enval = (Classes.EnumValue)enumBox.Items[i];
							e.Graphics.DrawLine(p, new PointF(lastX, graphBox.Height - lastY),
													new PointF(lastX+xStep, ((float)graphBox.Height - ((float)enval.value * scaleY))));

e.Graphics.FillEllipse(b, new RectangleF(lastX + xStep - 4f, ((float)graphBox.Height - ((float)enval.value * scaleY))-4f, 8, 8));

							lastY = enval.value*scaleY;
							lastX += xStep;
						}
					}
				}
			}
		}

		private float GetScaleVal()
		{
			float retVal = -1;
			foreach (Classes.EnumValue item in enumBox.Items)
			{
				if (item.value > retVal)
					retVal = item.value;
			}

			return (float)graphBox.Height / retVal;
		}

		private void accordian_Click(object sender, EventArgs e)
		{
			if (this.Height == smallHeight)
			{
				frs.ResizeHeight(398);
				advOptsAccPicBx.Image = Properties.Resources.chevronUp;
				advOptsPnl.Visible = useHex = true;
			}
			else
			{
				frs.ResizeHeight(smallHeight);
				useHex = false;
				advOptsAccPicBx.Image = Properties.Resources.chevronDown;
			}
			rebuildListbox2();
		}

		private void accordianLbl_Click(object sender, LinkLabelLinkClickedEventArgs e)
		{
			accordian_Click(this, null);
		}

		#region Glass

		private void dlbBtnsPnl_MouseDown(object sender, MouseEventArgs e)
		{
				if (e.Button == System.Windows.Forms.MouseButtons.Left && GlassLib.Dwm.IsFeatureAvailable())
				{
					NativeMethods.MoveForm(base.Handle);
				}
		}

		#endregion

		private void addBtn_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(addValTxtBx.Text))
			{
				Classes.EnumValue v = new Classes.EnumValue(addValTxtBx.Text.Trim().Replace(" ", ""), enumBox.Items.Count);
				v.displayHex = useHex;
				enumBox.Items.Add(v);
				rebuildListbox1();
			}
		}

		private void advOpts_CheckedChanged(object sender, EventArgs e)
		{
			manualGrpBx.Enabled = linearRdBtn.Checked;
			for (int i = 0; i < enumBox.Items.Count; i++)
			{
				Classes.EnumValue value = (Classes.EnumValue)enumBox.Items[i];
				value.value = i;
				enumBox.Items[i] = value;
			}
			enumBox.Refresh();
			graphBox.Refresh();
		}

		#region Listboxes

		void rebuildListbox1()
		{
			graphBox.Refresh();
		}

		void rebuildListbox2()
		{
			for (int i = 0; i < enumBox.Items.Count; i++)
			{
				Classes.EnumValue value = (Classes.EnumValue)enumBox.Items[i];
				value.displayHex = useHex;
				enumBox.Items[i] = value;
			}
			enumBox.Refresh();
		}

		#endregion

		private void button1_Click(object sender, EventArgs e)
		{
			if (enumBox.SelectedIndex != -1)
			{
				Classes.EnumValue enval = (Classes.EnumValue)enumBox.Items[enumBox.SelectedIndex];
				enval.value = (int)manValUpDwn.Value;
				enumBox.Items[enumBox.SelectedIndex] = enval;
				enumBox.Refresh();
				rebuildListbox1();
				graphBox.Refresh();
			}
		}

		private void valueBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (enumBox.SelectedItem != null)
			{
				Classes.EnumValue enval = (Classes.EnumValue)enumBox.Items[enumBox.SelectedIndex];
				manValUpDwn.Value = (Decimal)(enval.value);
			}
		}

		private void addValTxtBx_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				e.Handled = true;
				addBtn_Click(this, null);
				addValTxtBx.SelectAll();
			}
		}

		private void addValTxtBx_KeyDown(object sender, KeyEventArgs e)
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

		private void okButton_Click(object sender, EventArgs e)
		{
			returnVal = new Classes.Enumeration(textBox1.Text);
			foreach (Classes.EnumValue val in enumBox.Items)
			{
				returnVal.Values.Add(val);
			}
		}

		private void removeButton_Click(object sender, EventArgs e)
		{
			if (enumBox.SelectedIndex != -1)
				enumBox.Items.RemoveAt(enumBox.SelectedIndex);
		}
	}
}