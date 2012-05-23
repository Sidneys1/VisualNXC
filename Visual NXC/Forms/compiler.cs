using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Visual_NXC.Forms
{
	/// <summary>
	/// Compiles the code.
	/// </summary>
	public partial class Compiler : Form
	{
		delegate void output(string args);
		delegate void end();

		/// <summary>
		/// Creates a new Compiler form.
		/// </summary>
		public Compiler()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			button1.Enabled = false;
			UseWaitCursor = true;
			RunCommandSync("-help");
		}

		private void setOutput(string output)
		{
			textBox1.Text += "\r\n" + output;
		}

		private void End()
		{
			this.UseWaitCursor = false;
			button1.Enabled = true;
		}

		private void RunCommandSync(object command)
		{
			Process proc = new Process();
			proc.StartInfo.Arguments = command.ToString();
			proc.StartInfo.CreateNoWindow = true;
			proc.StartInfo.FileName = @"nbc.exe";
			proc.StartInfo.RedirectStandardOutput = true;
			proc.StartInfo.UseShellExecute = false;

			proc.OutputDataReceived += new DataReceivedEventHandler(proc_OutputDataReceived);
			proc.EnableRaisingEvents = true;
			proc.Exited += new EventHandler(proc_Exited);
			proc.Start();
			proc.BeginOutputReadLine();
		}

		void proc_Exited(object sender, EventArgs e)
		{
			if (this.InvokeRequired)
			{
				end en = new end(End);
				this.Invoke(en);
			}
			else
			{
				End();
			}
		}

		void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			if (this.InvokeRequired)
			{
				output end = new output(setOutput);
				this.Invoke(end, new object[] { e.Data });
			}
			else
			{
				setOutput(e.Data);
			}
		}
	}
}
