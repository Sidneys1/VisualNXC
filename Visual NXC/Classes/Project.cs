using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace Visual_NXC.Classes
{
	[Serializable()]
	internal class Project : ISerializable
	{
		#region Properties

		bool _dirty = true;
		public bool Dirty
		{
			get { return _dirty; }
			set 
			{ 
				_dirty = value; 
				if (DirtyChanged != null) 
					DirtyChanged("No Reason.."); 
			}
		}
        public void SetDirtyAndUndo(string reason)
        {
            _dirty = true;
            if (DirtyChanged != null)
                DirtyChanged(reason); 
        }

		string _name = "Untitled Project";
		public string Name
		{
			get { return _name; }
			set 
			{
				string newName = value.Trim();
				if (newName != _name)
				{
					_name = newName;
					if (NameChanged != null)
						NameChanged();
					Dirty = true;
				}
			}
		}

		string _path = string.Empty;
		public string Path
		{
			get { return _path; }
			set 
			{ 
				_path = value;
				System.IO.FileInfo inf = new System.IO.FileInfo(value);
				Name = inf.Name.Replace(inf.Extension, "");
			}
		}

		public Guid U_ID = Guid.NewGuid();
        

		public int currentUndoLevel = -1;

		#endregion

		#region Elements

		#region Code Elements

		List<ICodeBlock> _codeElements = new List<ICodeBlock>();
		public List<ICodeBlock> CodeElements
		{
			get { return _codeElements; }
		}

		#region Code Element Methods

		public ICodeBlock GetElement(string file)
		{
			foreach (ICodeBlock e in _codeElements)
			{
				if (e.Name == file)
					return e;
			}
			return null;
		}
		public void AddElement(ICodeBlock e)
		{
			_codeElements.Add(e);

			e.NameChanged += new Action<string>(Item_NameChanged);
            e.GuiChanged += new Action<string>(block_GuiChanged);
			
			if (ElementAdded != null)
				ElementAdded(e);
            SetDirtyAndUndo("Block Added: " + e.Name);
		}
		public void DeleteElement(ICodeBlock e)
		{
			_codeElements.Remove(e);
			if (ElementRemoved != null)
				ElementRemoved(e);
			Dirty = true;
		}

		#endregion

		#region Dirty Binds

		void Item_NameChanged(string obj)
		{
            SetDirtyAndUndo("Item Renamed: " + obj);
		}
        void block_GuiChanged(string obj)
        {
            SetDirtyAndUndo(obj);
        }

		#endregion

		#endregion

		#region Enumerations

		List<Enumeration> _enums = new List<Enumeration>();
		public List<Enumeration> Enumerations
		{
			get { return _enums; }
		}

		#region Enum Methods

		public void AddEnum(Enumeration e)
		{
			_enums.Add(e);
			//if (ElementAdded != null)
			//	ElementAdded(e);
			Dirty = true;
		}

		#endregion

		#endregion

		#region Stuctures

		List<Struct> _structs = new List<Struct>();
		public List<Struct> Structs
		{
			get { return _structs; }
		}

		#endregion

		#endregion

		#region Events

		public event Action NameChanged;
		public event Action<ICodeBlock> ElementRemoved;
		public event Action<ICodeBlock> ElementAdded;
		public event Action<String> DirtyChanged;

		#endregion

		#region Ctors

		public Project()
		{
		}

		public Project(SerializationInfo info, StreamingContext ctxt)
		{
			U_ID = (Guid)info.GetValue("guid", typeof(Guid));
			string[] blocks = (string[])info.GetValue("blocks", typeof(string[]));
			foreach (string str in blocks)
			{
				_codeElements.Add((Classes.ICodeBlock)info.GetValue(str, typeof(Classes.ICodeBlock)));
			}
			Dirty = false;
		}

		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			info.AddValue("guid", U_ID);
			string[] blocks = new string[_codeElements.Count];
			for (int i = 0; i < _codeElements.Count; i++)
			{
				Guid g = Guid.NewGuid();
				blocks[i] = g.ToString();
				info.AddValue(g.ToString(), _codeElements[i], typeof(Classes.ICodeBlock));
			}
			info.AddValue("blocks", blocks, typeof(string[]));
		}

		public void Initialize()
		{
			Task m = new Task("main");
			AddElement(m);
		}

		#endregion

		public IGuiPage GetPage(string file)
		{
			foreach (ICodeBlock e in _codeElements)
			{
				if (e is IGuiPage && e.Name == file)
					return e as IGuiPage;
			}
			return null;
		}

		public string GetTitle()
		{
			return _name + (_dirty ? "*" : "");
		}

		#region I/O

		public bool Save(string path, bool undo = false)
		{
			try
			{
				Stream stream = File.Open(path, FileMode.Create);
				SoapFormatter bF = new SoapFormatter();
				bF.Serialize(stream, this);
				stream.Dispose();
				if (!undo)
				{
					Path = path;
					Dirty = false;
				}
				return true;
			}
			catch (Exception ex)
			{
				ex.Message.GetType();
				return false;
			}
		}

		public static Project Open(string file)
		{
			Stream stream = File.Open(file, FileMode.Open);
			SoapFormatter bF = new SoapFormatter();
			Classes.Project retVal = (Classes.Project)bF.Deserialize(stream);
			retVal.postLoad();
			retVal.Path = file;
			retVal.Dirty = false;
			stream.Dispose();
			return retVal;
		}

		private void postLoad()
		{
			foreach (ICodeBlock block in _codeElements)
			{
					block.NameChanged += new Action<string>(Item_NameChanged);
                    block.GuiChanged += new Action<string>(block_GuiChanged);
			}
			
		}


		#endregion
	}

	internal enum Tool
	{
		Cursor,
		Hand, 
		Eraser
	}
}