using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Visual_NXC.Controls
{
	[DefaultEvent("Selected"), DefaultProperty("ControlText")]
	internal partial class selectCheck : UserControl
	{
		#region Settings

		SelectedState selec = SelectedState.None;

		[Browsable(true), Description("The selection state of the control.")]
		public SelectedState SelectedState
		{
			get { return selec; }
			set 
			{ 
				selec = value;
				if (value == SelectedState.Selected && Selected != null)
					Selected(this, new EventArgs());
				Refresh();
			}
		}

		[Browsable(true), Description("The image displayed for this Select Check.")]
		public Image Image
		{
			get { return pictureBox1.Image; }
			set { pictureBox1.Image = value; }
		}

		[Browsable(true), DefaultValue("SelectCheck")]
		public string ControlText
		{
			get
			{
				return label1.Text;
			}
			set
			{
				label1.Text = value;
			}
		}

		[Browsable(true), DefaultValue(false), Description("Whether or not the control is checkmarked.")]
		public bool Checked
		{
			get { return checkBox1.Checked; }
			set { checkBox1.Checked = value; }
		}

		[Browsable(true), DefaultValue(true), Description("Whether or not the control is checkmarkable.")]
		public bool ShowCheck
		{
			get { return checkBox1.Visible; }
			set { checkBox1.Visible = value; }
		}

		[Description("Occurs when the item is selected.")]
		public event EventHandler Selected;

		public event EventHandler CheckChanged;

		#endregion

		public selectCheck()
		{
			InitializeComponent();
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.FixedHeight | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.UserPaint, true);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			Bitmap tile = null;

			switch (selec)
			{
				case SelectedState.None:
					return;
				case SelectedState.Over:
					tile = Properties.Resources.TileBg_HalfOpac;
					break;
				case SelectedState.Selected:
					tile = Properties.Resources.TileBg;
					break;
			}

			Size tS = new Size(tile.Width / 3, tile.Height / 3);
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
			//Top left corner
			e.Graphics.DrawImage(tile,
				new Rectangle(Point.Empty, tS),
				new Rectangle(Point.Empty, tS),
				GraphicsUnit.Pixel);
			//Top edge
			e.Graphics.DrawImage(tile,
				new Rectangle(tS.Width, 0, this.Width - (tS.Width * 2), tS.Height),
				new Rectangle(new Point(tS.Width, 0), tS),
				GraphicsUnit.Pixel);
			//top right corner
			e.Graphics.DrawImage(tile,
				new Rectangle(new Point(this.Width - tS.Width, 0), tS),
				new Rectangle(new Point(tS.Width * 2, 0), tS),
				GraphicsUnit.Pixel);
			//right edge
			e.Graphics.DrawImage(tile,
				new Rectangle(this.Width - tS.Width, tS.Height, tS.Width, this.Height - (tS.Height - 2)),
				new Rectangle(new Point(tS.Width * 2, tS.Height), tS),
				GraphicsUnit.Pixel);
			//bottom right corner
			e.Graphics.DrawImage(tile,
				new Rectangle(this.Width - tS.Width, this.Height - tS.Height, tS.Width, tS.Height),
				new Rectangle(new Point(tS.Width * 2, tS.Height * 2), tS),
				GraphicsUnit.Pixel);
			//bottom edge
			e.Graphics.DrawImage(tile,
				new Rectangle(tS.Width, this.Height - tS.Height, this.Width - (tS.Width * 2), tS.Height),
				new Rectangle(tS.Width, tS.Height * 2, tS.Width, tS.Height),
				GraphicsUnit.Pixel);
			//bottom left corner
			e.Graphics.DrawImage(tile,
				new Rectangle(0, this.Height - tS.Height, tS.Width, tS.Height),
				new Rectangle(0, tS.Height * 2, tS.Width, tS.Height),
				GraphicsUnit.Pixel);
			//left edge
			e.Graphics.DrawImage(tile,
				new Rectangle(0, tS.Height, tS.Width, this.Height - (tS.Height * 2)),
				new Rectangle(0, tS.Height, tS.Width, tS.Height),
				GraphicsUnit.Pixel);
			//fill
			//e.Graphics.DrawImage(tile,
			//    new Rectangle(tS.Width, tS.Height, this.Width - (tS.Width * 2), this.Height - (tS.Height * 2)),
			//    new Rectangle(new Point(tS), tS),
			//    GraphicsUnit.Pixel);
			if (selec == SelectedState.Selected)
			{
				e.Graphics.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(Point.Empty, new Point(0, this.Height), Color.FromArgb(221, 236, 253), Color.FromArgb(194, 220, 253)), new Rectangle(tS.Width, tS.Height, this.Width - (tS.Width * 2), this.Height - (tS.Height * 2)));
			}
			else
			{
				e.Graphics.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(Point.Empty, new Point(0, this.Height), Color.FromArgb(127, 221, 236, 253), Color.FromArgb(127, 194, 220, 253)), new Rectangle(tS.Width, tS.Height, this.Width - (tS.Width * 2), this.Height - (tS.Height * 2)));
			}
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			if (selec != SelectedState.Selected)
			{
				selec = SelectedState.Over;
				Refresh();
			}
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			if (selec != SelectedState.Selected)
			{
				selec = SelectedState.None;
				Refresh();
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (selec != SelectedState.Selected)
			{
				selec = SelectedState.Selected;
				Refresh();
			}
		}

		private void pictureBox1_MouseEnter(object sender, EventArgs e)
		{
			if (selec != SelectedState.Selected)
			{
				selec = SelectedState.Over;
				Refresh();
			}
		}

		private void pictureBox1_MouseLeave(object sender, EventArgs e)
		{
			if (selec != SelectedState.Selected)
			{
				selec = SelectedState.None;
				Refresh();
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if (selec != SelectedState.Selected)
			{
				selec = SelectedState.Selected;
				if (Selected != null)
					Selected(this, new EventArgs());
				Refresh();
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (CheckChanged != null)
				CheckChanged(this, new EventArgs());
		}
	}

	enum SelectedState
	{
		None,
		Over,
		Selected
	}
}
