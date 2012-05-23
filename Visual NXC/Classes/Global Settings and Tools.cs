using System;
using Microsoft.Win32;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;

namespace Visual_NXC
{ 
	internal static class Global
	{
		internal static readonly string DragDropIdent = "V_NXC_TREE_DRAG_DROP ";

		internal static readonly string Branding = "Visual NXC";

		internal static readonly string AppData = System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Branding).FullName;

		internal static readonly string UndoPath = AppData + "\\Undo Data";

		internal static bool Debug = false;

		internal static System.Drawing.Point HandHotspot = new System.Drawing.Point(10, 10);
	}

	internal static class SettingsManager
	{
		static RegistryKey baseKey = Registry.CurrentUser;
		static string subKey = "SOFTWARE\\Borne Programming\\Visual NXC";

		#region Settings

		private static bool _tabStringSet = false;
		private static string _tabStringCache;
		public static string TabString
		{
			get
			{
				if (!_tabStringSet)
				{
					_tabStringCache = (string)Read("TabString", "\t");
					_tabStringSet = true;
				}
				return _tabStringCache;
			}
			set
			{
				Write("TabString", value);
				_tabStringCache = value;
			}
		}

		private static bool _cExtentionSet = false;
		private static bool _cExtentionCache;
		public static bool UseCExtention
		{
			get 
			{
				if (!_cExtentionSet)
				{
					_cExtentionCache = ReadBool("UseCExtention", false);
					_cExtentionSet = true;
				}
				return _cExtentionCache;
			}
			set 
			{
				Write("UseCExtention", value);
				_cExtentionCache = value;
			}
		}

		private static bool _commentsSet = false;
		private static bool _commentsCache;
		public static bool UseComments
		{
			get
			{
				if (!_commentsSet)
				{
					_commentsCache = ReadBool("UseComments", true);
					_commentsSet = true;
				}
				return _commentsCache;
			}
			set
			{
				Write("UseComments", value);
				_commentsCache = value;
			}
		}

		private static bool _tabSpacesSet = false;
		private static int _tabSpacesCache;
		public static int TabSpaces
		{
			get
			{
				if (!_tabSpacesSet)
				{
					_tabSpacesCache = (int)Read("TabSpaces", 4);
					_tabSpacesSet = true;
				}
				return _tabSpacesCache;
			}
			set
			{
				Write("TabSpaces", value);
				_tabSpacesCache = value;
			}
		}

		private static bool _compilerSet = false;
		private static bool _compilerCache;
		public static bool UseDefaultCompiler
		{
			get
			{
				if (!_compilerSet)
				{
					_compilerCache = ReadBool("UseDefaultCompiler", true);
					_compilerSet = true;
				}
				return _compilerCache;
			}
			set
			{
				Write("UseDefaultCompiler", value);
				_compilerCache = value;
			}
		}

		private static bool _compilerLocationSet = false;
		private static string _compilerLocationCache;
		public static string CompilerLocation
		{
			get 
			{
				if (!_compilerLocationSet)
				{
					_compilerLocationCache = 
						(string)Read(
							"CompilerLocation", 
							new System.IO.FileInfo(
								System.Reflection.Assembly.GetExecutingAssembly().Location
							).DirectoryName
						);
					_compilerLocationSet = true;
				}
				return _compilerLocationCache;
			}
			set
			{
				Write("CompilerLocation", value);
				_compilerLocationCache = value;
			}
		}

		private static bool _compilerOptimizationSet = false;
		private static int _compilerOptimizationCache;
		public static int CompilerOptimization
		{
			get
			{
				if (!_compilerOptimizationSet)
				{
					_compilerOptimizationCache = (int)Read("CompilerOptimization", 2);
					_compilerOptimizationSet = true;
				}
				return _compilerOptimizationCache;
			}
			set
			{
				Write("CompilerOptimization", value);
				_compilerOptimizationCache = value;
			}
		}

		private static bool _compilerEnhFwSet = false;
		private static bool _compilerEnhFwCache;
		public static bool CompilerEnhFw
		{
			get
			{
				if (!_compilerEnhFwSet)
				{
					_compilerEnhFwCache = ReadBool("CompilerEnhFw", false);
					_compilerEnhFwSet = true;
				}
				return _compilerEnhFwCache;
			}
			set
			{
				Write("CompilerEnhFw", value);
				_compilerEnhFwCache = value;
			}
		}

		#endregion

		#region Members

		public static void Initialize()
		{
			//Check that settings exist and then initialize the local caches.
			using (RegistryKey sub = baseKey.OpenSubKey(subKey))
			{
				if (sub == null)
					Fix();
			}
			string s = TabString;
		}

		static object Read(string KeyName, object Default)
		{
			using (RegistryKey sub = baseKey.OpenSubKey(subKey))
			{
				if (sub == null)
				{
					Console.WriteLine("Error Reading Value (subkey null)");
					return Default;
				}
				else
				{
					object o = sub.GetValue(KeyName.ToUpper(), Default);
					return o;
				}
			}
		}

		static bool ReadBool(string KeyName, bool Default)
		{
			using (RegistryKey sub = baseKey.OpenSubKey(subKey))
			{
				if (sub == null)
					return Default;
				else
				{
					byte[] flag = sub.GetValue(KeyName.ToUpper(), 
							Default ? new byte[] { 1 } : new byte[] { 0 }
					) as byte[];
					return (flag[0] != 0);
				}
			}
		}

		private static void Write(string KeyName, bool Value)
		{
			using (RegistryKey sub = baseKey.OpenSubKey(subKey, true))
			{
				if (sub != null)
				{
					byte[] flag = new byte[] { Value ? (byte)1 : (byte)0 };
					sub.SetValue(KeyName, flag, RegistryValueKind.Binary);
				}
			}
		}

		private static void Write(string KeyName, string Value)
		{
			using (RegistryKey sub = baseKey.OpenSubKey(subKey, true))
			{
				if (sub != null)
				{
					sub.SetValue(KeyName, Value, RegistryValueKind.String);
				}
			}
		}

		private static void Write(string KeyName, int Value)
		{
			using (RegistryKey sub = baseKey.OpenSubKey(subKey, true))
			{
				if (sub != null)
				{
					sub.SetValue(KeyName, Value, RegistryValueKind.DWord);
				}
			}
		}

		private static void Fix()
		{
			baseKey.CreateSubKey(subKey);
		}

		#endregion
	}

	internal static class NativeMethods
	{

		#region Aero

		/// <summary>
		/// This lets us hook in and make the treeviews look like windows explorer
		/// </summary>
		/// <param name="hwnd">The handle of the window to change. (exampleTrVw.Handle)</param>
		/// <param name="pszSubAppName">The name of the app to style it like. ("EXPLORER")</param>
		/// <param name="pszSubIdList">Don't worry about this.. we just pass NULL in this case</param>
		/// <returns></returns>
		[DllImport("uxtheme.dll")]
		public static extern int SetWindowTheme(
			[In] IntPtr hwnd,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszSubAppName,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszSubIdList);

		#endregion

		#region Cursors

		[DllImport("user32.dll")]
		public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

		public static System.Windows.Forms.Cursor CreateCursor(System.Drawing.Bitmap bmp, int xHotSpot, int yHotSpot)
		{
			IconInfo tmp = new IconInfo();
			GetIconInfo(bmp.GetHicon(), ref tmp);
			tmp.xHotspot = xHotSpot;
			tmp.yHotspot = yHotSpot;
			tmp.fIcon = false;
			return new System.Windows.Forms.Cursor(CreateIconIndirect(ref tmp));
		}

		public struct IconInfo
		{
			public bool fIcon;
			public int xHotspot;
			public int yHotspot;
			public IntPtr hbmMask;
			public IntPtr hbmColor;
		}

		#endregion

		internal static void MoveForm(IntPtr Handle)
		{
			ReleaseCapture();
			SendMessage(Handle, 0xa1, new IntPtr(2), new IntPtr(0));
		}
		[DllImport("user32.dll")]
		internal static extern bool ReleaseCapture();
		[DllImport("user32.dll")]
		internal static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
	}

	internal static class Tools
	{
		internal static void SetDoubleBuffered(System.Windows.Forms.Control control)
		{
			typeof(System.Windows.Forms.Control).InvokeMember("DoubleBuffered",
				BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
				null, control, new object[] { true });
		}

		internal static System.Drawing.Color stringToColor(System.String paramValue)
		{
			int red;
			int green;
			int blue;
			red = (System.Int32.Parse(paramValue.Substring(0, (2) - (0)), System.Globalization.NumberStyles.AllowHexSpecifier));
			green = (System.Int32.Parse(paramValue.Substring(2, (4) - (2)), System.Globalization.NumberStyles.AllowHexSpecifier));
			blue = (System.Int32.Parse(paramValue.Substring(4, (6) - (4)), System.Globalization.NumberStyles.AllowHexSpecifier));
			return System.Drawing.Color.FromArgb(red, green, blue);
		}

        internal static string RemoveInvalidFileChars(string arg)
        {
            char[] invalid = new char[Path.GetInvalidFileNameChars().Length + Path.GetInvalidPathChars().Length];
            Path.GetInvalidFileNameChars().CopyTo(invalid, 0);
            Path.GetInvalidPathChars().CopyTo(invalid, Path.GetInvalidFileNameChars().Length);
            string retVal = arg;
            foreach (char c in invalid)
            {
                while (retVal.Contains(c.ToString()))
                    retVal = retVal.Replace(c.ToString(), "");
            }
            return retVal;
        }

		#region Undo/Redo

		internal static void saveUndoLevel(Classes.Project proj, string undoName)
		{
			string path = Directory.CreateDirectory(Global.UndoPath + "\\" + proj.U_ID.ToString()).FullName;
            if (proj.currentUndoLevel == -1) //Or, unsaved...
                proj.currentUndoLevel = 0;

            int level = proj.currentUndoLevel + 1;
            DirectoryInfo inf = Directory.
                CreateDirectory(Global.UndoPath + "\\" + proj.U_ID.ToString());
            try
            {
                
                for (FileInfo[] files = inf.GetFiles(level.ToString() + "-*.vpf"); files.Length > 0; files = inf.GetFiles(level.ToString() + "-*.vpf"))
                {
                    File.Delete(files[0].FullName);
                    level++;
                }
            }
            catch { }
            undoName = RemoveInvalidFileChars(undoName);
			proj.Save(path + "\\" + (proj.currentUndoLevel++).ToString() + "-" + undoName + ".vpf", true);
		}

		internal static undoLevel[] getUndoLevels(Classes.Project proj)
		{
			DirectoryInfo inf = Directory.
				CreateDirectory(Global.UndoPath + "\\" + proj.U_ID.ToString());
			undoLevel[] retVal = new undoLevel[inf.GetFiles().Length];
			int i = 0;
			foreach (FileInfo file in inf.GetFiles("*.vpf"))
			{
				string name = file.Name.Replace(".vpf", "");
                string[] nameLevel = name.Split('-');
				name = nameLevel[1];
				int level = int.Parse(nameLevel[0]);
				retVal[i] = new undoLevel();
				retVal[i].levelNumber = level;
				retVal[i].name = name;
				i++;
			}
			return retVal;
		}

        internal static Classes.Project setUndoLevel(Classes.Project proj, int undoLevel)
        {
            string path = Directory.CreateDirectory(Global.UndoPath + "\\" + proj.U_ID.ToString()).FullName;
            return Classes.Project.Open(new DirectoryInfo(path).GetFiles(undoLevel.ToString() + "-*.vpf")[0].FullName);
        }

		#endregion
	}

	internal struct undoLevel
	{
		public string name;
		public int levelNumber;
	}
}

