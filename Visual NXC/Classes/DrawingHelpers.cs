using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Visual_NXC.Classes
{
	internal static class DrawingHelpers
	{
		public static void DrawBlockBG(Graphics g, Rectangle bounds, Color blockColor)
		{
			using (Pen p = new Pen(Color.Black))
			{
				Rectangle innerRect = new Rectangle(bounds.X + 1, bounds.Y + 1, bounds.Width - 2, bounds.Height - 2);

				using (SolidBrush b = new SolidBrush(blockColor))
				{
					g.FillRectangle(b, bounds);
				}
				g.DrawRectangle(p, bounds);

				using (LinearGradientBrush b = new LinearGradientBrush(bounds.Location, new Point(bounds.X, bounds.Bottom),
					Color.FromArgb(137, Color.White), Color.FromArgb(0, Color.White)))
				{
					g.FillRectangle(b, innerRect);
				}

				p.Color = Color.FromArgb(58, Color.Black);

				g.DrawRectangle(p, innerRect);
			}
		}

		public static void DrawLoopTop(Graphics g, Rectangle bounds, Color blockColor)
		{
			using (Pen p = new Pen(Color.Black))
			{
				Rectangle innerRect = new Rectangle(bounds.X + 1, bounds.Y + 1, bounds.Width - 2, bounds.Height - 2);

				using (SolidBrush b = new SolidBrush(blockColor))
				{
					g.FillRectangle(b, bounds);
				}

				#region Outline

				g.DrawLine(p, bounds.Location, new Point(bounds.Right, bounds.Top));
				g.DrawLine(p, new Point(bounds.Right, bounds.Top), new Point(bounds.Right, bounds.Bottom));
				g.DrawLine(p, new Point(bounds.Right, bounds.Bottom), new Point(bounds.Left + 10, bounds.Bottom));
				g.DrawLine(p, new Point(bounds.Left, bounds.Bottom), new Point(bounds.Left, bounds.Top));

				#endregion

				using (LinearGradientBrush b = new LinearGradientBrush(bounds.Location, new Point(bounds.X, bounds.Bottom),
					Color.FromArgb(137, Color.White), Color.FromArgb(0, Color.White)))
				{
					g.FillRectangle(b, innerRect);
				}

				p.Color = Color.FromArgb(58, Color.Black);

				g.DrawLine(p, innerRect.Location, new Point(innerRect.Right, innerRect.Top));
				g.DrawLine(p, new Point(innerRect.Right, innerRect.Top), new Point(innerRect.Right, innerRect.Bottom));
				g.DrawLine(p, new Point(innerRect.Right, innerRect.Bottom), new Point(innerRect.Left + 9, innerRect.Bottom));
				g.DrawLine(p, new Point(innerRect.Left, innerRect.Bottom + 1), new Point(innerRect.Left, innerRect.Top));

			}
		}

		public static void DrawLoopBottom(Graphics g, Rectangle bounds, Color blockColor)
		{
			using (Pen p = new Pen(Color.Black))
			{
				Rectangle innerRect = new Rectangle(bounds.X + 1, bounds.Y + 1, bounds.Width - 2, bounds.Height - 2);

				using (SolidBrush b = new SolidBrush(blockColor))
				{
					g.FillRectangle(b, bounds);
				}

				#region Outline

				g.DrawLine(p, new Point(bounds.Left + 10, bounds.Top), new Point(bounds.Right, bounds.Top));
				g.DrawLine(p, new Point(bounds.Right, bounds.Top), new Point(bounds.Right, bounds.Bottom));
				g.DrawLine(p, new Point(bounds.Right, bounds.Bottom), new Point(bounds.Left, bounds.Bottom));
				g.DrawLine(p, new Point(bounds.Left, bounds.Bottom), new Point(bounds.Left, bounds.Top));

				#endregion

				p.Color = Color.FromArgb(58, Color.Black);


				g.DrawLine(p, new Point(innerRect.Left + 9, innerRect.Top), new Point(innerRect.Right, innerRect.Top));
				g.DrawLine(p, new Point(innerRect.Right, innerRect.Top), new Point(innerRect.Right, innerRect.Bottom));
				g.DrawLine(p, new Point(innerRect.Right, innerRect.Bottom), new Point(innerRect.Left, innerRect.Bottom));
				g.DrawLine(p, new Point(innerRect.Left, innerRect.Bottom), new Point(innerRect.Left, innerRect.Top - 1));

			}
		}

		public static void DrawLoopLeft(Graphics g, Rectangle bounds, Color blockColor)
		{
			using (Pen p = new Pen(Color.Black))
			{
				using (SolidBrush b = new SolidBrush(blockColor))
				{
					g.FillRectangle(b, new Rectangle(bounds.X, bounds.Y - 1, bounds.Width, bounds.Height + 2));
				}

				g.DrawLine(p, new Point(bounds.Left, bounds.Top-1), new Point(bounds.Left, bounds.Bottom));
				g.DrawLine(p, new Point(bounds.Right, bounds.Top), new Point(bounds.Right, bounds.Bottom));
				p.Color = Color.FromArgb(58, Color.Black);
				g.DrawLine(p, new Point(bounds.Left+1, bounds.Top-1), new Point(bounds.Left+1, bounds.Bottom));
				g.DrawLine(p, new Point(bounds.Right-1, bounds.Top), new Point(bounds.Right-1, bounds.Bottom));

			}
		}

		public static void DrawTab(Graphics g, PointF p, Color pc, bool ins = false, float scale = 1f)
		{
			using (SolidBrush b = new SolidBrush(pc))
			{
				g.FillPolygon(b, new PointF[] { 
					new PointF(p.X*scale, p.Y*scale), new PointF((p.X + 49)*scale, p.Y*scale), 
					new PointF((p.X + 46)*scale, (p.Y+6)*scale), new PointF((p.X+3)*scale, (p.Y+6)*scale) });
				g.DrawImage(ins ? blockParts.tab_ins : blockParts.tab, new RectangleF(p, new SizeF(blockParts.tab.Width * scale, blockParts.tab.Height * scale)));
			}
		}
	}
}
