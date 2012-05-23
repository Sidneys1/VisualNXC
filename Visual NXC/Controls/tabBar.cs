using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Visual_NXC
{
	internal partial class tabBar : UserControl
	{
		#region Items

		internal List<TabItem> items = new List<TabItem>();
		TabItem selectedItem
		{
			get { return _selectedItem; }
			set
			{ 
				_selectedItem = value;
				if (SelectedTabChanged != null)
					SelectedTabChanged(_selectedItem);
			}
		}
		TabItem _selectedItem = null;
		TabItem hoverItem = null;
		TabItem xHoverItem = null;
		TabItem xClickItem = null;
		Point lastPoint = Point.Empty;

		bool plusHover = false;

		bool bottomLine = true;
		public bool BottomLine
		{
			get { return bottomLine; }
			set { bottomLine = value; this.Refresh(); }
		}

		Color _top = SystemColors.Control;
		public Color TopColor
		{
			get { return _top; }
			set { _top = value; this.Refresh(); }
		}

		Color _bottom = Color.Gainsboro;
		public Color BottomColor
		{
			get { return _bottom; }
			set { _bottom = value; this.Refresh(); }
		}

		#endregion

		public event Action<TabItem> SelectedTabChanged;

		public tabBar()
		{
			InitializeComponent();
			SetStyle(ControlStyles.AllPaintingInWmPaint 
				| ControlStyles.FixedHeight 
				| ControlStyles.OptimizedDoubleBuffer 
				| ControlStyles.ResizeRedraw 
				| ControlStyles.UserMouse 
				| ControlStyles.UserPaint, true);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			//base.OnPaintBackground(e);
			using (System.Drawing.Drawing2D.LinearGradientBrush b = 
				new System.Drawing.Drawing2D.LinearGradientBrush(
					e.ClipRectangle.Location, new Point(e.ClipRectangle.Left, e.ClipRectangle.Bottom),
					_top, _bottom))
			{
				e.Graphics.FillRectangle(b, e.ClipRectangle);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			int drawPos = 0;


			if (items.Count == 0)
			{
				#region No Items

				using (Font f = new Font("Segoe UI", 9.5f, FontStyle.Italic))
				{
					using (SolidBrush b = new SolidBrush(SystemColors.GrayText))
					{
						e.Graphics.DrawString("No tabs open...", f, b, new PointF(5, 3f));
					}
				}

				#endregion
			}
			else
			{		
				#region Draw Items

				foreach (TabItem item in items)
				{
					if (drawPos < this.Width)
					{
						using (Font f = new Font("Segoe UI", 9.5f,
							(selectedItem == item) ? FontStyle.Regular : FontStyle.Italic))
						{
							string title = item.Title;
							SizeF s = e.Graphics.MeasureString(title, f);

							while (s.Width > ((hoverItem == item || selectedItem == item) ? 120 : 136))
							{
								title = title.Substring(0, title.Length - 1);

								s = e.Graphics.MeasureString(title + "...", f);

								if (s.Width < 120)
									title += "...";
							}
							if (s.Width < 50)
								s.Width = 50;
							s.Width += 37;
							Bitmap source = Properties.Resources.TabDeselected;


							if (selectedItem == item)
								source = Properties.Resources.TabSelected;
							else if (hoverItem == item)
								source = Properties.Resources.TabHover;

							e.Graphics.InterpolationMode =
								System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
							e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

							e.Graphics.DrawImage(source,
								new Rectangle(drawPos, 0, 2, 24),
								new RectangleF(0, 0, 2, 24), GraphicsUnit.Pixel);
							e.Graphics.DrawImage(source,
								new Rectangle(drawPos + 2, 0, (int)s.Width, 24),
								new RectangleF(2, 0, 2, 24), GraphicsUnit.Pixel);
							e.Graphics.DrawImage(source,
								new Rectangle(drawPos + (int)s.Width + 2, 0, 2, 24),
								new RectangleF(4, 0, 2, 24), GraphicsUnit.Pixel);

							e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
							e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Default;

							item.dispRect = new Rectangle(drawPos, 0, (int)s.Width, 24);

							using (SolidBrush b = new SolidBrush(SystemColors.WindowText))
							{
								e.Graphics.DrawString(title, f, b,
									new RectangleF(drawPos + 23f, 3f, s.Width - 32, 20));
							}

							if (selectedItem == item || hoverItem == item)
							{
								Bitmap x = Properties.Resources.x;

								if (xHoverItem == item)
									x = Properties.Resources.x_hover;
								else if (xClickItem == item)
									x = Properties.Resources.x_click;

								e.Graphics.DrawImage(x,
									new Point(drawPos + (int)s.Width - 14, ((selectedItem != item) ? 6 : 4)));
							}

							Bitmap icon = null;

							switch (item.Type)
							{
								case Classes.CodeType.Task:
									icon = Properties.Resources.thread;
									break;
								case Classes.CodeType.Method:
									icon = Properties.Resources.method;
									break;
								case Classes.CodeType.Enumerations:
									icon = Properties.Resources._enum;
									break;
								case Classes.CodeType.Structs:
									icon = Properties.Resources._struct;
									break;
								case Classes.CodeType.Code:
									icon = Properties.Resources.receipts_text;
									break;
							}

							e.Graphics.DrawImage(icon,
							new Rectangle(drawPos + 2, ((selectedItem != item) ? 6 : 4), 16, 16));

							drawPos += (int)s.Width + 4;
						}
					}
				}	

				#endregion

				#region

				using (System.Drawing.Drawing2D.LinearGradientBrush b =
					new System.Drawing.Drawing2D.LinearGradientBrush(
						new Point(this.Width - 32, 0), new Point(this.Width - 16, 0),
						Color.Transparent, SystemColors.Control
					))
				{
					e.Graphics.FillRectangle(b, new Rectangle(this.Width - 32, 0, 16, 26));
				}

				using (SolidBrush b = new SolidBrush(SystemColors.Control))
				{
					e.Graphics.FillRectangle(b, new Rectangle(this.Width - 16, 0, 16, 26));
				}

				e.Graphics.DrawImage((plusHover || contextMenuStrip1.Visible) ?
					Properties.Resources.control_270 : Properties.Resources.control_270_disabled,
					new Point(this.Width - 21, 5));

				#endregion
			}

			#region Plus

			if (items.Count > 0)
			{
			}

			#endregion

			if (bottomLine)
			{
				using (SolidBrush b = new SolidBrush(SystemColors.ControlDarkDark))
				{
					using (Pen p = new Pen(b, 1.0f))
					{
						e.Graphics.DrawLine(p, new Point(0, this.Height - 1),
							new Point(this.Width, this.Height - 1));
					}
				}
			}
		}

		#region Public Methods

		public TabItem SelectNext()
		{
			if (items.Count > 1)
			{
				int i = items.IndexOf(selectedItem);

				if (i >= 0 && i < items.Count-1)
					i++;
				else
					i = 0;

				selectedItem = items[i];
				Refresh();
			}
			return selectedItem;
		}

		public TabItem SelectPrevious()
		{
			if (items.Count > 1)
			{
				int i = items.IndexOf(selectedItem);

				if (i >= 1)
					i--;
				else
					i = items.Count - 1;

				selectedItem = items[i];
				Refresh();
			}
			return selectedItem;
		}

		public TabItem CloseCurrentTab()
		{
			int pos = items.IndexOf(selectedItem);


			if (pos == items.Count-1)
				pos--;

			items.Remove(selectedItem);
			if (pos >= 0)
				selectedItem = items[pos];
			else
				selectedItem = null;
			Refresh();
			return selectedItem;
		}

		#endregion

		#region Mouse Handlers

		protected override void OnMouseMove(MouseEventArgs e)
		{
			lastPoint = e.Location;

			if (e.Button == System.Windows.Forms.MouseButtons.None && items.Count>0)
			{
				bool intersectsPlus = e.Location.X >= this.Width - 26;
				bool refresh = false;

				if (intersectsPlus)
				{
					hoverItem = null;
					plusHover = true;
					refresh = true;
				}
				else
				{
					if (plusHover)
					{
						plusHover = false;
						refresh = true;
					}
					bool isOnX = false;
					TabItem i = GetHoverItem(e.Location, out isOnX);
					if (hoverItem != i || (hoverItem == null && i != null))
					{
						hoverItem = i;
						if (i != null && toolTip1.GetToolTip(this) != i.Type.ToString() + ": " + i.Title)
							toolTip1.Show(i.Type.ToString() + ": " + i.Title, this, new Point(e.Location.X, e.Location.Y + 20));
						refresh = true;
					}

					if ((isOnX && xHoverItem != i) || (!isOnX && xHoverItem != null))
					{
						if (isOnX)
							xHoverItem = i;
						else
							xHoverItem = null;
						refresh = true;
					}

				}
				if (refresh)
					Refresh();
			}
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			hoverItem = xHoverItem = xClickItem = null;
			plusHover = false;
			lastPoint = Point.Empty;
			if (toolTip1.Active)
				toolTip1.Hide(this);
			Refresh();
			base.OnMouseLeave(e);
		}

		protected override void OnMouseHover(EventArgs e)
		{
			if (!lastPoint.IsEmpty && string.IsNullOrEmpty(toolTip1.GetToolTip(this)))
			{
				TabItem i = GetHoverItem(lastPoint);
				if (i != null)
					toolTip1.Show(i.Type.ToString() + ": " + i.Title, this, new Point(lastPoint.X, lastPoint.Y + 20));
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == System.Windows.Forms.MouseButtons.Left && items.Count>0)
			{
				if (e.Location.X < this.Width - 16)
				{
					bool x = false;
					TabItem i = GetHoverItem(e.Location, out x);

					if (i != null && x)
					{
						xHoverItem = null;
						xClickItem = i;
						Refresh();
					}
				}
			}
		}

		void tabBar_Click(object sender, EventArgs e)
		{
			while (items.Count > 0)
				CloseCurrentTab();
		}

		void i_Click(object sender, EventArgs e)
		{
			selectedItem = (sender as ToolStripMenuItem).Tag as TabItem;
			Refresh();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			if (e.Location.X >= this.Width - 26 && items.Count>0 && e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				if (!contextMenuStrip1.Visible && items.Count > 0)
				{
					contextMenuStrip1.Items.Clear();
					foreach (TabItem item in items)
					{
						ToolStripMenuItem i = new ToolStripMenuItem(item.Title);
						i.Tag = item;
						switch (item.Type)
						{
							case Classes.CodeType.Task:
								i.Image = Properties.Resources.thread;
								break;
							case Classes.CodeType.Method:
								i.Image = Properties.Resources.method;
								break;
							//case Classes.CodeType.Enum:
							//    i.Image = Properties.Resources._enum;
							//    break;
							//case Classes.CodeType.Struct:
							//    i.Image = Properties.Resources._struct;
							//    break;
						}
						i.Click += new EventHandler(i_Click);
						if (selectedItem == item)
							i.Checked = true;
						contextMenuStrip1.Items.Add(i);
					}
					contextMenuStrip1.Items.Add(new ToolStripSeparator());
					contextMenuStrip1.Items.Add("Close All").Click += new EventHandler(tabBar_Click);

					contextMenuStrip1.Show(this.PointToScreen(e.Location));
				}
			}
			else
			{
				bool x = false;
				TabItem i = GetHoverItem(e.Location, out x);

				if (i != null && x && e.Button == System.Windows.Forms.MouseButtons.Left)
				{
					xHoverItem = null;
					xClickItem = null;
					if (selectedItem == i)
					{
						int pos = items.IndexOf(i);
						if (pos < items.Count - 1)
							selectedItem = items[pos + 1];
						else if (pos > 0)
							selectedItem = items[pos - 1];
						else
							selectedItem = null;
					}
					items.Remove(i);
					Refresh();
				}
				else if (i != null)
				{
					if (e.Button == System.Windows.Forms.MouseButtons.Left)
						selectedItem = i;
					else if (e.Button == System.Windows.Forms.MouseButtons.Middle)
					{
						if (i == selectedItem)
							this.CloseCurrentTab();
						else
							items.Remove(i);
					}
					Refresh();
				}
			}
		}

		private TabItem GetHoverItem(Point point, out bool isOnX)
		{
			foreach (TabItem item in items)
			{
				if (item.dispRect.IntersectsWith(new Rectangle(point, new Size(1, 1))))
				{
					Rectangle Xrect = new Rectangle(item.dispRect.Right - 16, 4, 16, 18);
					isOnX = Xrect.IntersectsWith(new Rectangle(point, new Size(1, 1)));
					return item;
				}
			}
			isOnX = false;
			return null;
		}

		private TabItem GetHoverItem(Point point)
		{
			foreach (TabItem item in items)
			{
				if (item.dispRect.IntersectsWith(new Rectangle(point, new Size(1, 1))))
				{
					return item;
				}
			}
			return null;
		}

		#endregion

		public void AddTab(TabItem m)
		{
			items.Add(m);
			selectedItem = m;
			this.Refresh();
		}

		public bool isPageOpen(Classes.IGuiPage e)
		{
			bool retVal = false;
			foreach (TabItem item in items)
			{
				if (item.assocItem == e)
				{
					retVal = true;
					break;
				}
			}
			return retVal;
		}

		public void SelectTab(Classes.IGuiPage e)
		{
			foreach (TabItem item in items)
			{
				if (item.assocItem == e)
				{
					selectedItem = item;
					this.Refresh();
					return;
				}
			}
		}

		internal void CloseAllTabs()
		{
			items.Clear();
			Refresh();
		}
	}

	internal class TabItem
	{
		public string Title = "New Tab";
		public Classes.CodeType Type = Classes.CodeType.Task;
		public Rectangle dispRect = new Rectangle(0, 0, 1, 1);
		public object assocItem;

		public TabItem(string Name, Classes.CodeType Kind, object Page)
		{
			Title = Name;
			Type = Kind;
			assocItem = Page;
		}
	}
}
