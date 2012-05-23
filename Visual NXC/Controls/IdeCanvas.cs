using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Visual_NXC
{
	internal partial class IdeCanvas : UserControl
	{
		Point panDisplacement = Point.Empty;
		Classes.IGuiPage page;
		public Classes.IGuiPage Page
		{
			get { return page; }
			set
			{
				page = value;
				if (value != null)
					value.GuiChanged +=new Action<string>(p_GuiChanged);
				this.Refresh();
			}
		}
		Classes.ICodeBlock insertionPoint;
		public Classes.Tool currentTool = Classes.Tool.Cursor;

		public Classes.ICodeBlock InsertionPoint
		{
			get { return insertionPoint; }
			set { insertionPoint = value; Invalidate(); }
		}

		public IdeCanvas()
		{
			InitializeComponent();
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | /*ControlStyles.UserMouse |*/ ControlStyles.UserPaint, true);
		}

		void p_GuiChanged(string reason)
		{
			this.Refresh();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			Point offset = Point.Empty;
			if (page != null)
			{
				offset = page.PanOffset;

				while (Math.Abs(offset.X) >= 100)
				{
					offset.X -= (offset.X > 0) ? 100 : -100;
				}
				while (Math.Abs(offset.Y) >= 100)
				{
					offset.Y -= (offset.Y > 0) ? 100 : -100;
				}

				#region Gridlines
				using (SolidBrush b = new SolidBrush(Color.FromArgb(100, SystemColors.ControlDark)))
				{
					using (Pen p = new Pen(b, 1.2f))
					{
						p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
						p.DashOffset = offset.Y * -1;
						for (int i = offset.X; i < this.Width; i += 100)
						{
							e.Graphics.DrawLine(p, new Point(i, 0), new Point(i, this.Height));
						}
						p.DashOffset = offset.X * -1;
						for (int i = offset.Y; i < this.Height; i += 100)
						{
							e.Graphics.DrawLine(p, new Point(0, i), new Point(this.Width, i));
						}
					}
				}

				using (SolidBrush b = new SolidBrush(Color.FromArgb(50, SystemColors.ControlDark)))
				{
					using (Pen p = new Pen(b, .5f))
					{
						p.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
						p.DashPattern = new float[] { 5f, 5f };
						p.DashOffset = offset.Y * -1;

						for (int i = offset.X - 50; i < this.Width; i += 100)
						{
							e.Graphics.DrawLine(p, new Point(i, 0), new Point(i, this.Height));
						}
						p.DashOffset = offset.X * -1;
						for (int i = offset.Y - 50; i < this.Height; i += 100)
						{
							e.Graphics.DrawLine(p, new Point(0, i), new Point(this.Width, i));
						}
					}
				}
				#endregion

				e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;

				if (page != null)
					page.DrawGUI(e.Graphics, insertionPoint);

				using (System.Drawing.Drawing2D.LinearGradientBrush grad =
					new System.Drawing.Drawing2D.LinearGradientBrush(
						Point.Empty, new Point(0, 20),
						this.BackColor, Color.Transparent))
				{
					e.Graphics.FillRectangle(grad, new Rectangle(0, 0, e.ClipRectangle.Right, 20));
				}
			}
		}

		#region Mouse Handling

		Point _click = Point.Empty;
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if (page != null)
			{
				_click = e.Location;

				if (currentTool == Classes.Tool.Cursor)
				{
					if (e.Button == System.Windows.Forms.MouseButtons.Middle)
						Cursor = NativeMethods.CreateCursor(Properties.Resources.HandClosed, Global.HandHotspot.X, Global.HandHotspot.Y);
				}
				else if (currentTool == Classes.Tool.Hand)
				{
					Cursor = NativeMethods.CreateCursor(Properties.Resources.HandClosed, Global.HandHotspot.X, Global.HandHotspot.Y);
				}

				page.OnMouseDown(e);
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			if (page != null)
			{
				if (currentTool == Classes.Tool.Cursor)
				{
					if (e.Button == System.Windows.Forms.MouseButtons.Middle)
					{
						page.PanOffset = new Point(page.PanOffset.X + (e.Location.X - _click.X), page.PanOffset.Y + (e.Location.Y - _click.Y));
						_click = e.Location;
						Refresh();
					}
				}
				else if (currentTool == Classes.Tool.Hand)
				{
					if (e.Button == System.Windows.Forms.MouseButtons.Left || e.Button == System.Windows.Forms.MouseButtons.Middle)
					{
						page.PanOffset = new Point(page.PanOffset.X + (e.Location.X - _click.X), page.PanOffset.Y + (e.Location.Y - _click.Y));
						_click = e.Location;
						Refresh();
					}
				}
				page.OnMouseMove(e);
			}			
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			if (page != null)
			{
				if (currentTool == Classes.Tool.Cursor)
				{
					if (e.Button == System.Windows.Forms.MouseButtons.Middle)
						Cursor = Cursors.Default;
				}
				else if (currentTool == Classes.Tool.Hand)
				{
					Cursor = NativeMethods.CreateCursor(Properties.Resources.HandOpen, Global.HandHotspot.X, Global.HandHotspot.Y);
				}
				else if (currentTool == Classes.Tool.Eraser)
				{
					Point mouse = new Point(e.X, e.Y);
					//mouse = this.PointToClient(mouse);
					mouse.Offset(panDisplacement);
					Classes.ICodeBlock ipo = insertionPoint;
					List<Classes.ICodeBlock> actions = new List<Classes.ICodeBlock>();
					actions.Add(page as Classes.Task);
					ipo = CheckBlock(mouse, actions);
					if (ipo != null && ipo != page)
					{
                        page.RemoveBlock(ipo);
					}
					actions.Clear();
				}
			}
		}

		#endregion

		#region Drag-Drop

		private void IdeCanvas_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.StringFormat)
				&& (e.Data.GetData(DataFormats.StringFormat)
				as string).StartsWith(Global.DragDropIdent))
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}

		private void IdeCanvas_DragLeave(object sender, EventArgs e)
		{
		}

		private void IdeCanvas_DragOver(object sender, DragEventArgs e)
		{
			Point mouse = new Point(e.X, e.Y);
			mouse = this.PointToClient(mouse);
			mouse.Offset(panDisplacement);
			List<Classes.ICodeBlock> actions = new List<Classes.ICodeBlock>();
			actions.Add(page as Classes.Task);
			insertionPoint = CheckBlock(mouse, actions);
			if (insertionPoint != null)
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
			actions.Clear();
			Invalidate();
			this.Update();
		}

		private Classes.ICodeBlock CheckBlock(Point mouse, List<Classes.ICodeBlock> top)
		{
			foreach (Classes.ICodeBlock item in top)
			{
				if (item != null)
				{
					if (item.IsLoop)
					{
						Rectangle area = item.Area;
						if (item.Actions.Count == 0)
							area.Height += 30;
						Rectangle area2 = item.Area;
						area2.Y += item.GuiSize.Height - 30;
						if (area.Contains(mouse))
						{
							item.Tag = "before";
							return item;
						}
						else if (area2.Contains(mouse))
						{
							item.Tag = "after";
							return item;
						}
						else if (item.Actions != null && item.Actions.Count > 0)
						{
							Classes.ICodeBlock retVal = CheckBlock(mouse, item.Actions);
							if (retVal != null)
								return retVal;
						}
					}
					else if (item.Area.Contains(mouse) && !item.IsLoop)
					{
						item.Tag = "after";
						return item;
					}
					else if (item.Actions != null && item.Actions.Count > 0)
					{
						Classes.ICodeBlock retVal = CheckBlock(mouse, item.Actions);
						if (retVal != null)
							return retVal;
					}
				}
			}
			return null;
		}

		private void IdeCanvas_DragDrop(object sender, DragEventArgs e)
		{
			//insert at insertion point...
			Console.WriteLine(e.Data.ToString());
			string data = (string)e.Data.GetData(typeof(string));
			data = data.Remove(0, Global.DragDropIdent.Length);
			if (data == "while")
				page.InsertBlock(insertionPoint, new Classes.GenericCodeElement("While", "while (true)\r\n{\r\n{CODE}}", Color.GreenYellow, true));
			else if (data == "USInit")
				page.InsertBlock(insertionPoint, new Classes.GenericCodeElement("Set Ultrasonic Sensor (Port 1)", "SetSensorUltrasonic(S1);", Color.LightBlue));

			insertionPoint = null;
			Invalidate();
		}

		#endregion
	}
}