using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using UrielGuy.SyntaxHighlightingTextBox;

namespace Visual_NXC.Forms
{
	/// <summary>
	/// MDI host for nxcOutputForm
	/// </summary>
	internal partial class nxcOutput : Form
	{
		public string SelectedPath;
		public nxcOutput()
		{
			InitializeComponent();
			(toolStrip1.Renderer as ToolStripProfessionalRenderer).RoundedEdges = false;
		}

		public void AddTab(string code, string name, Classes.CodeType type)
		{
			Visual_NXC.Controls.highlighterBox h = new Visual_NXC.Controls.highlighterBox();
			h.BorderStyle = BorderStyle.None;
			h.Dock = DockStyle.Fill;
			h.Text = code;
			h.AcceptsTab = true;
			h.CaseSensitive = true;
			InitSyntaxHighlighter(h);
			h.RefreshHighlighting();
			TabItem i = new TabItem(name, type, h);
			tabBar1.AddTab(i);
			panel1.Controls.Clear();
			panel1.Controls.Add(h);
		}

		private void tabBar1_SelectedTabChanged(TabItem obj)
		{
			panel1.Controls.Clear();
			if (obj != null)
				panel1.Controls.Add(obj.assocItem as Visual_NXC.Controls.highlighterBox);
		}

		private void InitSyntaxHighlighter(Visual_NXC.Controls.highlighterBox h)
		{
			h.Seperators.Add(' ');
			h.Seperators.Add('.');
			h.Seperators.Add(',');
			h.Seperators.Add('\r');
			h.Seperators.Add('\n');
			h.Seperators.Add('+');
			h.Seperators.Add('-');
			h.Seperators.Add('\t');
			h.Seperators.Add('(');
			h.Seperators.Add(')');
			h.Seperators.Add('{');
			h.Seperators.Add('}');

			h.WordWrap = false;
			h.ScrollBars = RichTextBoxScrollBars.Both;
			h.HighlightDescriptors.Add(new HighlightDescriptor("/*", "*/", Color.Green, null, DescriptorType.ToCloseToken, DescriptorRecognition.StartsWith, false));
			//h.HighlightDescriptors.Add(new HighlightDescriptor("\"", "\"", Color.Maroon, null, DescriptorType.ToCloseToken, DescriptorRecognition.StartsWith, false));
			h.HighlightDescriptors.Add(new HighlightDescriptor("//", Color.Green, null, DescriptorType.ToEOL, DescriptorRecognition.StartsWith, false));
			h.HighlightDescriptors.Add(new HighlightDescriptor("#", Color.Navy, null, DescriptorType.ToEOL, DescriptorRecognition.StartsWith, false));

			LoadCommands(h);
			LoadConstants(h);
			LoadKeywords(h);
		}

		private static void LoadKeywords(Visual_NXC.Controls.highlighterBox h)
		{
			using (StreamReader r = File.OpenText(
				new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + "\\Codeview\\keywords.shf"))
			{
				string color = r.ReadLine();
				color = color.Replace("#COLOR=", "");
				Color c = Tools.stringToColor(color);
				while (!r.EndOfStream)
				{
					string line = r.ReadLine();
					h.HighlightDescriptors.Add(
						new HighlightDescriptor(line.Trim(), c, null,
							DescriptorType.Word, DescriptorRecognition.WholeWord, false));
				}
			}
		}

		private static void LoadConstants(Visual_NXC.Controls.highlighterBox h)
		{
			using (StreamReader r = File.OpenText(new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + "\\Codeview\\constants.shf"))
			{
				string color = r.ReadLine();
				color = color.Replace("#COLOR=", "");
				Color c = Tools.stringToColor(color);
				while (!r.EndOfStream)
				{
					string line = r.ReadLine();
					h.HighlightDescriptors.Add(
						new HighlightDescriptor(line.Trim(), c, null,
							DescriptorType.Word, DescriptorRecognition.WholeWord, false));
				}
			}
		}

		private static void LoadCommands(Visual_NXC.Controls.highlighterBox h)
		{
			using (StreamReader r = File.OpenText(new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + "\\Codeview\\commands.shf"))
			{
				string color = r.ReadLine();
				color = color.Replace("#COLOR=", "");
				Color c = Tools.stringToColor(color);
				while (!r.EndOfStream)
				{
					string line = r.ReadLine();
					h.HighlightDescriptors.Add(
						new HighlightDescriptor(line.Trim(), c, null,
							DescriptorType.Word, DescriptorRecognition.WholeWord, false));
				}
			}
		}

		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			if (folderBrwsDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				SelectedPath = folderBrwsDlg.SelectedPath;
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
		}
	}
}
