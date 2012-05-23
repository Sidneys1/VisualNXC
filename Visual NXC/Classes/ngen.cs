using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;


namespace Visual_NXC.Classes
{
    /// <summary>
    /// Allows us to optimize the Visual NXC install.
    /// </summary>
	[RunInstaller(true)]
	public partial class ngen : System.Configuration.Install.Installer
	{
		/// <summary>
		/// Hooks in ngen to the installer!
		/// </summary>
		public ngen()
		{
			InitializeComponent();
		}   
		
		/// <summary>
		/// An override function that is called when a MSI installer is run
		/// and the executable is set as a custom action to be run at install time.
		/// The native image generator (NGEN.exe) is called, which provides a
		/// startup performance boost on Windows Forms programs. It is helpful to
		/// comment out the NGEN code and see how the performance
		/// is affected.
		/// </summary>
		/// <param name="stateSaver">No need to change this.</param>
		public override void Install(IDictionary stateSaver)
		{
			base.Install(stateSaver);
			// get the .NET runtime string, and add the ngen exe at the end.
			string runtimeStr = RuntimeEnvironment.GetRuntimeDirectory();
			string ngenStr = Path.Combine(runtimeStr, "ngen.exe");

			// create a new process...
			Process process = new Process();
			process.StartInfo.FileName = ngenStr;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

			// get the assembly (exe) path and filename.
			string assemblyPath = Context.Parameters["assemblypath"];

			// add the argument to the filename as the assembly path.
			// Use quotes--important if there are spaces in the name.
			// Use the "install" verb and ngen.exe will compile all deps.
			process.StartInfo.Arguments = "install \"" + assemblyPath + "\"";

			// start ngen. it will do its magic.
			process.Start();
			process.WaitForExit();
		}
	}
}