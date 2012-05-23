using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

[assembly:CLSCompliant(true)]
namespace Visual_NXC
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			if (args.Length == 1 && args[0].ToLower() == "debug")
				Global.Debug = true;
			SettingsManager.Initialize();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(true);
			Application.Run(new MainForm());
		}
	}
}
