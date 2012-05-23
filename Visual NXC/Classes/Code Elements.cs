using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace Visual_NXC.Classes
{
	/// <summary>
	/// Represents a tab.
	/// </summary>
	internal interface IGuiPage: ICodeBlock //Task or Method
	{
		Point PanOffset { get; set;  }

		void DrawGUI(System.Drawing.Graphics g, ICodeBlock insertPoint);
		void DrawThumb(System.Drawing.Graphics g, Size size);

		void OnMouseMove(System.Windows.Forms.MouseEventArgs e);
		void OnMouseDown(System.Windows.Forms.MouseEventArgs e);
		void OnMouseUp(System.Windows.Forms.MouseEventArgs e);
		void OnMouseHover(System.Drawing.Point p);

		void InsertBlock(ICodeBlock index, ICodeBlock block);
        void RemoveBlock(ICodeBlock block);
	}

	/// <summary>
	/// Represents a code block
	/// </summary>
	internal interface ICodeBlock //Base of everything...
	{
		List<ICodeBlock> Actions { get; } //For Loops

		event Action<string> GuiChanged; //Any graphical representation needs to be updated
		event Action<string> NameChanged; //Any lists need to be updated

		//Drawing
		Rectangle Area { get; }
		System.Drawing.Point LoopPos(System.Drawing.Point location);
		void DrawGuiBlock(System.Drawing.Graphics g, System.Drawing.Point orgin, out System.Drawing.Point end, ICodeBlock dropPoint);
		Size GuiSize { get; }

		//Properties
		System.Drawing.Color Color { get; }
		string Name { get; set; }
		bool IsLoop { get; }
		string Tag { get; set; }

		//Code
		string GenerateCode { get; }
		CodeType Type { get; }

		//Events
	}

	[Serializable]
	internal class Task : IGuiPage, ICodeBlock, ISerializable
	{
		#region Properties

		List<ICodeBlock> _actions = new List<ICodeBlock>();
		public List<ICodeBlock> Actions
		{
			get { return _actions; }
		}

		string _name = "newTask";
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				string nv = value.Replace(" ", "");
				if (nv != _name)
				{
					_name = nv;
					if (NameChanged != null)
						NameChanged(_name);
				}
			}
		}

		public CodeType Type
		{
			get { return CodeType.Task; }
		}
		public bool IsLoop
		{
			get { return false; }
		}
		public System.Drawing.Point LoopPos(System.Drawing.Point location)
		{
			//Not used.
			return System.Drawing.Point.Empty;
		}
		public System.Drawing.Color Color
		{
			get { return Color.FromArgb(0, 191, 35); }
		}

		Point _pan = Point.Empty;
		public Point PanOffset
		{
			get
			{
				return _pan;
			}
			set
			{
				_pan = value;
			}
		}

		Rectangle area = new Rectangle(0, 0, 10, 10);
		public Rectangle Area { get { return area; } }

		string tag;
		public string Tag
		{
			get
			{
				return tag;
			}
			set
			{
				tag = value;
			}
		}

		Size guiSize = new Size(100,100);
		public Size GuiSize
		{
			get { return guiSize; }
		}

		#endregion

		#region Ctor

		public Task(string name)
		{
			_name = name;
		}

		public Task(SerializationInfo info, StreamingContext context)
		{
			Name = info.GetString("name");
			string[] blocks = (string[])info.GetValue("blocks", typeof(string[]));
			foreach (string str in blocks)
			{
				Classes.ICodeBlock b = (Classes.ICodeBlock)info.GetValue(str, typeof(Classes.ICodeBlock));
				_actions.Add(b);
			}
		}

		#endregion

		#region Methods

		public string GenerateCode
		{
			get 
			{
				System.Text.StringBuilder b = new System.Text.StringBuilder("task main()\r\n{\r\n");
				foreach (ICodeBlock item in _actions)
				{
					string[] s = item.GenerateCode.Split(new string[] { "\r\n" }, StringSplitOptions.None);
					foreach (string itemS in s)
					{
						b.AppendLine(SettingsManager.TabString + itemS); //fix?
					}
				}
				if (_actions.Count == 0)
					b.AppendLine(SettingsManager.TabString+ "//No code...");
				b.Append("}");

				return b.ToString();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("name", _name);
			string[] blocks = new string[_actions.Count];
			for (int i = 0; i < _actions.Count; i++)
			{
				Guid g = Guid.NewGuid();
				blocks[i] = g.ToString();
				info.AddValue(g.ToString(), _actions[i], typeof(Classes.ICodeBlock));
			}
			info.AddValue("blocks", blocks, typeof(string[]));
		}

		public bool searchBlocks(ICodeBlock insert, ICodeBlock block, ICodeBlock root)
		{
			if (insert == null)
				return false;
			foreach (ICodeBlock pblock in root.Actions)
			{
				if (pblock == insert)
				{
					if (insert.Tag.ToString() == "after")
					{
						root.Actions.Insert(root.Actions.IndexOf(insert) + 1, block);

						return true;
					}
					else if (insert.Tag.ToString() == "before" && insert.IsLoop)
					{
						insert.Actions.Insert(0, block);
						return true;
					}
				}
				else if (pblock.IsLoop) //aka, has subblocks
					if (searchBlocks(insert, block, pblock))
						return true;
			}
			return false;
		}

		public void InsertBlock(ICodeBlock insert, ICodeBlock block)
		{
            if (insert == this)
            {
                this._actions.Insert(0, block);
            }
            else
                searchBlocks(insert, block, this);

            GuiChanged("Block Added (" + block.Name + ")");
			block.GuiChanged += new Action<string>(block_GuiRefreshRequired);
		}

        #region GUI

        public void DrawGUI(System.Drawing.Graphics g, ICodeBlock insertPoint)
		{
			using (Font f = new Font("Segoe UI", 10f))
			{
				using (SolidBrush b = new SolidBrush(Color.FromArgb(103, Color.Black)))
				{
					if (Global.Debug && insertPoint != null)
						g.DrawString(insertPoint.Name + ", " + insertPoint.Tag != null ? insertPoint.Tag.ToString() : "", f, b, Point.Empty);
					SizeF textRect = g.MeasureString("Start: " + _name + "()", f);

					Rectangle r = normalizeRect(new Rectangle(new Point(PanOffset.X + 150, PanOffset.Y + 50), new Size((int)textRect.Width + 10, (int)textRect.Height + 10)));
					area = r;
					guiSize = r.Size;
					Point[] connector = new Point[4];

					#region Start

					b.Color = Color.FromArgb(103, Color.White);
					
					connector[0] = new Point(r.X, r.Y + 15);
					connector[1] = new Point(r.X - 15, r.Y + 15);

					Classes.DrawingHelpers.DrawBlockBG(g, r, this.Color);
					g.DrawString("Start: " + _name + "()", f, b, new Point(r.Left + 6, r.Top + 6));
					b.Color = Color.Black;
					g.DrawString("Start: " + _name + "()", f, b, new Point(r.Left + 5, r.Top + 5));

					#endregion

					#region Code!

					ICodeBlock lastBlock = this;
					Point end = new Point(r.Left, r.Bottom);
					//if (Actions.Count > 0)
						//area.children = new List<BlockArea>();
					foreach (ICodeBlock item in Actions)
					{
						Point nEnd;
						item.DrawGuiBlock(g, end, out nEnd, insertPoint);
						Classes.DrawingHelpers.DrawTab(g, new Point(end.X + 10, end.Y - 1), lastBlock.Color, (insertPoint == lastBlock && lastBlock.Tag.ToString() == "after"));
						//area.children.Add(item.BlockAreas);
						lastBlock = item;
						end = nEnd;
					}

					#endregion

					#region end

					textRect = g.MeasureString("End: " + _name + "()", f);
					r = normalizeRect(new Rectangle(end, new Size((int)textRect.Width + 10, (int)textRect.Height + 10)));
					Classes.DrawingHelpers.DrawBlockBG(g, r, Color.Red);
					b.Color = Color.FromArgb(103, Color.White);
					g.DrawString("End: " + _name + "()", f, b, new Point(r.Left + 6, r.Top + 6));

					b.Color = Color.Black;
					g.DrawString("End: " + _name + "()", f, b, new Point(r.Left + 5, r.Top + 5));
					using (Pen connectorPen = new Pen(Color.FromArgb(150,SystemColors.ControlDark), 3f))
					{
						connectorPen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
						connector[3] = new Point(r.X, r.Y + 15);
						connector[2] = new Point(r.X - 15, r.Y + 15);
						g.DrawLines(connectorPen, connector);

						int z = connector[1].Y; int x = connector[2].Y;
						x -= z;
						x /= 2;
						int midPoint = x  + z;

						connectorPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
						connectorPen.Width = 5f;
						Point[] taskline = new Point[] { new Point(connector[1].X - 1, midPoint), new Point(connector[1].X - 15, midPoint) };
						g.DrawLines(connectorPen, taskline);
						SizeF texSiz = g.MeasureString("Task \"" + this.Name + "()\":", f);
						PointF drawPoint = new PointF(taskline[1].X - 5 - texSiz.Width, 
							midPoint - texSiz.Height / 2);
						
						g.DrawString("Task \"" + this.Name + "()\":", f, connectorPen.Brush, drawPoint);
						
					}
					#endregion

					Classes.DrawingHelpers.DrawTab(g, new Point(r.Left + 10, r.Top - 1), lastBlock.Color,
						insertPoint == lastBlock && lastBlock.Tag.ToString() == "after");
				}
			}
		}

		private static Rectangle normalizeRect(Rectangle r)
		{
			if (r.Width < 100)
				r.Width = 100;
			if (r.Height < 25)
				r.Height = 25;
			return r;
		}

		public void DrawThumb(Graphics g, Size size)
		{
			float itmScale = 120; //Padding plus start/end
			foreach (ICodeBlock block in _actions)
			{
				itmScale += block.GuiSize.Height;
			}
			itmScale = size.Height / itmScale;
			if (itmScale > 1)
				itmScale = 1;

			using (SolidBrush b = new SolidBrush(Color))
			{
				using (Pen p = new Pen(Color.Black))
				{
					PointF pos = new PointF(10, 30 * itmScale);
					g.FillRectangle(b, new RectangleF(pos, new SizeF(100 * itmScale, 30 * itmScale)));
					g.DrawRectangle(p, pos.X, pos.Y, 100 * itmScale, 30 * itmScale);
					pos.Y += 30 * itmScale;
					foreach (ICodeBlock block in _actions)
					{
						drawBlockForThumb(g, itmScale, pos, b, block, p, out pos);
					}
					b.Color = Color.Red;
					g.FillRectangle(b, new RectangleF(pos, new SizeF(100 * itmScale, 30 * itmScale)));
					g.DrawRectangle(p, pos.X, pos.Y, 100 * itmScale, 30 * itmScale);
				}
			}
		}

		void drawBlockForThumb(Graphics g, float itmScale, PointF pos, SolidBrush b, ICodeBlock block, Pen p, out PointF posOff)
		{
			b.Color = block.Color;
			g.FillRectangle(b, new RectangleF(pos, new SizeF(block.GuiSize.Width * itmScale, block.GuiSize.Height * itmScale)));
			g.DrawRectangle(p, pos.X, pos.Y, block.GuiSize.Width * itmScale, block.GuiSize.Height * itmScale);
			PointF prePos = pos;
			if (block.IsLoop && block.Actions.Count > 0)
			{
				pos.X += 10 * itmScale;
				pos.Y += 30 * itmScale;
				foreach (ICodeBlock subBlock in block.Actions)
				{
					drawBlockForThumb(g, itmScale, pos, b, subBlock, p, out pos);
				}
			}
			pos = prePos;
			pos.Y += block.GuiSize.Height * itmScale;
			posOff = pos;
		}

		public void DrawGuiBlock(Graphics g, Point orgin, out Point end, ICodeBlock dropPoint)
		{
			throw new NotImplementedException();
		}
        
        #region Mouse

        public void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
		{
			
		}

		public void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			
		}

		public void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
		{
			throw new NotImplementedException();
		}

		public void OnMouseHover(System.Drawing.Point p)
		{
			throw new NotImplementedException();
		}

		#endregion

        #endregion

        #endregion

        #region Events

        public event Action<string> NameChanged;
		public event Action<string> GuiChanged;

		#endregion

		void block_GuiRefreshRequired(string reason)
		{
            if (GuiChanged != null)
                GuiChanged(reason);
		}

        public void RemoveBlock(ICodeBlock block)
        {
            removeBlockRecursive(this, block);

            if (GuiChanged != null)
                GuiChanged("Block Removed (" + block.Name + ")");
        }

        void removeBlockRecursive(ICodeBlock container, ICodeBlock removeMe)
        {
            if (!container.Actions.Remove(removeMe))
                foreach (ICodeBlock childBlock in container.Actions)
                {
                    removeBlockRecursive(childBlock, removeMe);
                }
        }
    }

	//internal class Method : IGuiPage, ICodeElement
	//{
	//    List<ICodeElement> _actions = new List<ICodeElement>();
	//    public List<ICodeElement> Actions
	//    {
	//        get { return _actions; }
	//    }

	//    string _name = "newMethod";
	//    public string Name
	//    {
	//        get
	//        {
	//            return _name;
	//        }
	//        set
	//        {
	//            string nv = value.Replace(" ", "");
	//            if (nv != _name)
	//            {
	//                _name = nv;
	//                if (NameChanged != null)
	//                    NameChanged(_name);
	//            }
	//        }
	//    }

	//    public Method(string name)
	//    {
	//        _name = name;
	//    }

	//    public string GenerateCode
	//    {
	//        get
	//        { return "pseudo method code! :D (" + _name + ")"; }
	//    }

	//    public event Action<string> NameChanged;

	//    public event Action GuiChanged;

	//    public void DrawGUI(System.Drawing.Graphics g)
	//    {
	//        throw new NotImplementedException();
	//    }

	//    public void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
	//    {
	//        throw new NotImplementedException();
	//    }

	//    public void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
	//    {
	//        throw new NotImplementedException();
	//    }

	//    public void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
	//    {
	//        throw new NotImplementedException();
	//    }

	//    public void OnMouseHover(System.Drawing.Point p)
	//    {
	//        throw new NotImplementedException();
	//    }

	//    public void DrawGuiBlock(System.Drawing.Graphics g, System.Drawing.Point orgin,
	//        out System.Drawing.Point end)
	//    {
	//        throw new NotImplementedException();
	//    }

	//    public CodeType Type
	//    {
	//        get { return CodeType.Method; }
	//    }

	//    public bool IsLoop
	//    {
	//        get { throw new NotImplementedException(); }
	//    }

	//    public System.Drawing.Point LoopPos(System.Drawing.Point location)
	//    {
	//        throw new NotImplementedException();
	//    }

	//    public System.Drawing.Color Color
	//    {
	//        get { throw new NotImplementedException(); }
	//    }


	//    public Point PanOffset
	//    {
	//        get
	//        {
	//            throw new NotImplementedException();
	//        }
	//        set
	//        {
	//            throw new NotImplementedException();
	//        }
	//    }


	//    public Size GuiSize
	//    {
	//        get { throw new NotImplementedException(); }
	//    }


	//    public List<DropBlock> GetDropPoints()
	//    {
	//        throw new NotImplementedException();
	//    }


	//    public event EventHandler GuiRefreshRequired;


	//    public void DrawGUI(Graphics g, int insertPoint)
	//    {
	//        throw new NotImplementedException();
	//    }


	//    public void InsertBlock(int index, ICodeElement block)
	//    {
	//        throw new NotImplementedException();
	//    }


	//    public void DrawGuiBlock(Graphics g, Point orgin, out Point end, int dropPoint)
	//    {
	//        throw new NotImplementedException();
	//    }
	//}

	//internal class Enumeration : ICodeElement
	//{
	//    List<EnumValue> members = new List<EnumValue>();

	//    public bool IsLoop
	//    {
	//        get { return false; }
	//    }

	//    public Point LoopPos(Point location)
	//    {
	//        return Point.Empty;
	//    }

	//    string _name = "newEnum";
	//    public string Name
	//    {
	//        get
	//        {
	//            return _name;
	//        }
	//        set
	//        {
	//            _name = value.Trim();
	//        }
	//    }

	//    public Enumeration(string name)
	//    {
	//        _name = name;
	//        members.Add(new EnumValue(name, members.Count));
	//    }

	//    public string GenerateCode
	//    {
	//        get { return "pseudo enum! :D (" + _name + ")"; }
	//    }

	//    public void DrawGuiBlock(Graphics g, Point orgin, out Point end)
	//    {
	//        throw new NotImplementedException();
	//    }

	//    public Color Color
	//    {
	//        get { throw new NotImplementedException(); }
	//    }

	//    public CodeType Type
	//    {
	//        get { return CodeType.Enum; }
	//    }


	//    public Size GuiSize
	//    {
	//        get { throw new NotImplementedException(); }
	//    }


	//    public event EventHandler GuiRefreshRequired;

	//    public List<ICodeElement> Actions
	//    {
	//        get { throw new NotImplementedException(); }
	//    }


	//    public List<Point> GetDropPoints()
	//    {
	//        throw new NotImplementedException();
	//    }


	//    public void DrawGuiBlock(Graphics g, Point orgin, out Point end, int dropPoint)
	//    {
	//        throw new NotImplementedException();
	//    }
	//}

	//internal class Structure : ICodeElement
	//{
	//    public bool IsLoop
	//    {
	//        get { throw new NotImplementedException(); }
	//    }

	//    public Point LoopPos(Point location)
	//    {
	//        throw new NotImplementedException();
	//    }

	//    string _name = "newStruct";
	//    public string Name
	//    {
	//        get
	//        {
	//            return _name;
	//        }
	//        set
	//        {
	//            _name = value.Trim();
	//        }
	//    }

	//    public Structure(string name)
	//    {
	//        _name = name;
	//    }

	//    public string GenerateCode
	//    {
	//        get { return "pseudo struct! :D (" + _name + ")"; }
	//    }

	//    public void DrawGuiBlock(Graphics g, Point orgin, out Point end)
	//    {
	//        throw new NotImplementedException();
	//    }

	//    public Color Color
	//    {
	//        get { throw new NotImplementedException(); }
	//    }

	//    public CodeType Type
	//    {
	//        get { return CodeType.Struct; }
	//    }


	//    public Size GuiSize
	//    {
	//        get { throw new NotImplementedException(); }
	//    }


	//    public event EventHandler GuiRefreshRequired;

	//    public List<ICodeElement> Actions
	//    {
	//        get { throw new NotImplementedException(); }
	//    }


	//    public List<Point> GetDropPoints()
	//    {
	//        throw new NotImplementedException();
	//    }


	//    public void DrawGuiBlock(Graphics g, Point orgin, out Point end, int dropPoint)
	//    {
	//        throw new NotImplementedException();
	//    }
	//}

	[Serializable]
	internal class GenericCodeElement : ICodeBlock, ISerializable
    {
        #region ctors

        public GenericCodeElement(string ElementName, string code, Color col, bool loop = false)
		{
			name = ElementName;
			codeGen = code;
			isLoop = loop;
			color = col;
		}

		public GenericCodeElement(SerializationInfo info, StreamingContext context)
		{
			tag = info.GetString("tag");
			isLoop = info.GetBoolean("loop");
			name = info.GetString("name");
			color = (Color)info.GetValue("color", typeof(Color));

			string[] blocks = (string[])info.GetValue("blocks", typeof(string[]));
			foreach (string str in blocks)
			{
				acts.Add((Classes.ICodeBlock)info.GetValue(str, typeof(Classes.ICodeBlock)));
			}
		}

        #endregion

        #region Items

        #region Properties

        public string tag;
		public string Tag
		{
			get
			{
				return tag;
			}
			set
			{
				tag = value;
			}
		}

		private bool isLoop = false;
		public bool IsLoop
		{
			get { return isLoop; }
		}

		public Point LoopPos(Point location)
		{
			return new Point(area.Left + 10, area.Bottom);
		}

		private string name = "Generic Code Element";
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
				if (NameChanged != null)
					NameChanged(value);
			}
		}

		Size guiSize = new Size(10, 10);
		public Size GuiSize
		{
			get { return guiSize; }
		}

		Rectangle area = new Rectangle(0, 0, 10, 10);
		public Rectangle Area
		{
			get { return area; }
		}

		private Color color = Color.Gray;
		public Color Color
		{
			get { return color; }
		}

		public CodeType Type
		{
			get { return CodeType.Custom; }
		}

		List<ICodeBlock> acts = new List<ICodeBlock>();
		public List<ICodeBlock> Actions
		{
			get { return acts; }
		}

        #endregion

		#endregion

        #region Methods

        public void InsertBlock(int index, ICodeBlock block)
        {
            Actions.Insert(index, block);
            if (GuiChanged != null)
                GuiChanged("Block Added (" + block.Name + ")");
        }

        private string codeGen = "//Generic Code not provided!";
		public string GenerateCode
		{
			get
			{
				string RetVal = codeGen;

				if (isLoop)
				{
					System.Text.StringBuilder intCode = new System.Text.StringBuilder();
					foreach (ICodeBlock item in Actions)
					{
						string[] s = item.GenerateCode.Split(new string[] { "\r\n" }, StringSplitOptions.None);
						foreach (string itemS in s)
						{
							intCode.AppendLine(SettingsManager.TabString + itemS);
						}
						
					}
					RetVal = RetVal.Replace("{CODE}", intCode.ToString());
				}

				return RetVal; 
			}
		}

		#region Drawing

		public void DrawGuiBlock(Graphics g, Point orgin, out Point end, ICodeBlock dropPoint)
		{
				if (isLoop)
					DrawLoop(g, ref orgin, out end, dropPoint);
				else
					DrawNoLoop(g, ref orgin, out end);
			if (Global.Debug && this == dropPoint)
				using (SolidBrush b = new SolidBrush(Color.FromArgb(100, Color.Blue)))
				{
					g.FillRectangle(b, area);
				}
		}

		private void DrawNoLoop(Graphics g, ref Point orgin, out Point end)
		{
			using (Font f = new Font("Segoe UI", 10f))
			{
				using (SolidBrush b = new SolidBrush(Color.FromArgb(103, Color.White)))
				{
					SizeF textRect = g.MeasureString(name, f);

					Rectangle r = new Rectangle(new Point(orgin.X, orgin.Y), new Size((int)textRect.Width + 10, (int)textRect.Height + 10));
					if (r.Width < 100)
						r.Width = 100;
					if (r.Height < 25)
						r.Height = 25;
					guiSize = r.Size;
					area = r;
					if (color != Color.Transparent)
					{
						Classes.DrawingHelpers.DrawBlockBG(g, r, this.Color);
						g.DrawString(name, f, b, new Point(r.Left + 6, r.Top + 6));
						b.Color = Color.Black;
						g.DrawString(name, f, b, new Point(r.Left + 5, r.Top + 5));
					}
					end = new Point(r.Left, r.Bottom);

				}
			}
		}

		private void DrawLoop(Graphics g, ref Point orgin, out Point end, ICodeBlock dropPoint)
		{
			using (Font f = new Font("Segoe UI", 10f))
			{
				using (SolidBrush b = new SolidBrush(Color.FromArgb(103, Color.White)))
				{
					SizeF textRect = g.MeasureString(name, f);
					Point top;
					Rectangle r = 
						new Rectangle(new Point(orgin.X, orgin.Y), new Size((int)textRect.Width + 10, (int)textRect.Height + 10));
					if (r.Width < 100)
						r.Width = 100;
					if (r.Height < 25)
						r.Height = 25;
					int topY = r.Bottom;
					area = r;
					top = r.Location;
					Point currPos = new Point(r.Left + 10, r.Bottom);

					Classes.DrawingHelpers.DrawLoopTop(g, r, this.color);

					g.DrawString(name, f, b, new Point(r.Left + 6, r.Top + 6));
					b.Color = Color.Black;
					g.DrawString(name, f, b, new Point(r.Left + 5, r.Top + 5));

					#region Blocks

					ICodeBlock lastItem = this;
					lastItem = this;
					foreach (ICodeBlock item in Actions)
					{
						if (item is GenericCodeElement)
						{
							Point nEnd;
							item.DrawGuiBlock(g, currPos, out nEnd, dropPoint);
							Classes.DrawingHelpers.DrawTab(g, new Point(currPos.X + 10, currPos.Y - 1), lastItem.Color != Color.Transparent ? lastItem.Color : color,
								((dropPoint == lastItem && lastItem.Tag.ToString() == "after" && dropPoint != this)
								|| (dropPoint == this && acts.Count == 0 && this.tag.ToString() == "before")));

							lastItem = item;
							currPos = nEnd;
						}
					}
					if (acts.Count == 0)
					{
						Classes.DrawingHelpers.DrawTab(g, new Point(currPos.X + 10, currPos.Y - 1), Color, 
							((dropPoint == lastItem && lastItem.Tag.ToString() == "after" && dropPoint != this) 
							|| (dropPoint == this && acts.Count == 0 && this.tag.ToString() == "before")));
						currPos.Y += 30;
					}
					#endregion

					currPos.X -= 10;

					r = new Rectangle(new Point(currPos.X, currPos.Y), new Size(100, 30));
					Classes.DrawingHelpers.DrawLoopBottom(g, r, this.color);

					b.Color = Color.FromArgb(103, Color.White);
					g.DrawString("End: " + name, f, b, new Point(r.Left + 6, r.Top + 6));
					b.Color = Color.Black;
					g.DrawString("End: " + name, f, b, new Point(r.Left + 5, r.Top + 5));

					Rectangle r2 = new Rectangle(new Point(currPos.X, topY), new Size(10, r.Top - topY));
					Classes.DrawingHelpers.DrawLoopLeft(g, r2, this.color);
					bool insert = false;
					insert = dropPoint == lastItem && dropPoint.Tag.ToString() == "after" && lastItem != this;
					insert = insert || (dropPoint == this && acts.Count == 0 && dropPoint.Tag.ToString() == "before");
					Classes.DrawingHelpers.DrawTab(g, new Point(currPos.X + 20, currPos.Y - 1), lastItem != this ? lastItem.Color : SystemColors.Control, insert);
					end = new Point(r.Left, r.Bottom);
					guiSize = new Size(r.Right - top.X, r.Bottom - top.Y);
				}
			}
		}

		#endregion

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("tag", tag);
			info.AddValue("loop", isLoop);
			info.AddValue("name", name);
			info.AddValue("color", color, typeof(Color));

			string[] blocks = new string[acts.Count];
			for (int i = 0; i < acts.Count; i++)
			{
				Guid g = Guid.NewGuid();
				blocks[i] = g.ToString();
				info.AddValue(g.ToString(), acts[i], typeof(Classes.ICodeBlock));
			}
			info.AddValue("blocks", blocks, typeof(string[]));
		}

        #endregion

        public event Action<string> NameChanged;  
        public event Action<string> GuiChanged; //What blocks use...
    }

	internal class Enumeration
	{
		public Enumeration(string name = "NewEnumeration")
		{ 
			_name = name;
		}

		List<EnumValue> values = new List<EnumValue>();
		public List<EnumValue> Values { get { return values; } }
		public EnumValue this[int i]
		{
			get { return values[i]; }
			set { values[i] = value; }
		}

		public string GenerateCode()
		{
			System.Text.StringBuilder b = new System.Text.StringBuilder("enum " + _name + "\r\n{\r\n");
			foreach (EnumValue val in values)
			{
				if (val.value == values.IndexOf(val))
					b.Append(SettingsManager.TabString + val.name);
				else
					b.Append(SettingsManager.TabString + val.name + " = 0x" + string.Format("{0:X2}", val.value));

				if (values.IndexOf(val) != values.Count - 1)
					b.AppendLine(",");
			}
			b.AppendLine();
			b.Append("};");
			return b.ToString();
		}

		private string _name;
		public string Name
		{
			get { return _name; }
			set { if (string.IsNullOrEmpty(value)) 
					_name = value; }
		}
	}

	internal struct EnumValue
	{
		public string name;
		public int value;
		public bool displayHex;

		public EnumValue(string Name, int Value)
		{
			name = Name;
			value = Value;
			displayHex = false;
		}

		public override string ToString()
		{
			if (displayHex)
				return name + " (0x" + string.Format("{0:X2})", value);
			else
				return name;
		}
	}

	internal struct Struct
	{
		public String Name;
		public List<StructMember> Members;

		public Struct(string name)
		{
			Name = name;
			Members = new List<StructMember>();
		}

		public override string ToString()
		{
			return Name;
		}

		internal string GenerateCode()
		{
			System.Text.StringBuilder b = new System.Text.StringBuilder("struct " + Name + "\r\n{\r\n");
			foreach (StructMember val in Members)
			{
				
				b.Append(SettingsManager.TabString + val.Type + " " + val.Name);
				if (val.Array)
					b.Append("[" + (val.ArrayElements == -1 ? "" : val.ArrayElements.ToString()) + "]");
				b.AppendLine(";");
			}
			b.AppendLine();
			b.Append("};");
			return b.ToString();
		}
	}

	internal class StructMember
	{
		public string FriendlyType = "Integer";
		public string Type = "int";
		public string Name = "Unnamed Member";
		public bool Array = false;
		public int ArrayElements = -1;

		public StructMember(string type, string friendlyType, string name = "unnamed", bool array = false, int arrayEl = -1)
		{
			Type = type;
			FriendlyType = friendlyType;
			Name = name;
			Array = array;
			ArrayElements = arrayEl;
		}

		public override string ToString()
		{
			return FriendlyType + " \"" + Name + "\"";
		}
	}

	internal enum CodeType
	{
		Task,
		Method,
		Enumerations,
		Structs,
		Custom,
		Code
	}
}