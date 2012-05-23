using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Visual_NXC.Forms
{
	internal partial class Options : Form
	{
		FlowLayoutPanel outputPanel, compilerPanel, codeAppearancePanel;
		Dictionary<Guid, bool> valueChanged = new Dictionary<Guid, bool>();
		Dictionary<Guid, string> valueMap = new Dictionary<Guid, string>();

		STP.Rgi.IRgiComponent commColor, consColor, keywColor, commandsComp, constantsComp, keywordsComp;

		public Options()
		{
			InitializeComponent();
			GenOutputUI();
			GenCompilerUI();
			GenCodeAppearanceUI();
		}

		#region Generate Interface

		private void GenOutputUI()
		{
			outputPanel = new FlowLayoutPanel() { Dock = DockStyle.Fill, AutoScroll = true };
			contentPanel.Controls.Add(outputPanel);

			#region Controls

			#region File Options

			addToPanel(outputPanel, STP.Rgi.RgiEngine.AddSeparator("File Options"), null);

			addToPanel(outputPanel,
				STP.Rgi.RgiEngine.AddBool(
					"Use .h extention for enum and struct definition files instead of .nxc",
					SettingsManager.UseCExtention,
					true
				),
				"Use .h Extention"
			);

			#endregion

			#region Formatting

			addToPanel(outputPanel, STP.Rgi.RgiEngine.AddSeparator("Code Formatting"), null);

			addToPanel(outputPanel,
				STP.Rgi.RgiEngine.AddBool(
					"Include Code Comments in Output",
					SettingsManager.UseComments,
					true
				),
				"comments"
			);
			#endregion

			#region Tabs
			addToPanel(outputPanel, STP.Rgi.RgiEngine.AddSeparator("Tabs"), null);

			#region Controls

			addToPanel(outputPanel, 
				STP.Rgi.RgiEngine.AddBool("Use Tabs", SettingsManager.TabString == "\t", true),
				"tabs"
			).ValueChanged +=new STP.Rgi.RgiValueUpdated(useTabCharCtrl_ValueChanged);

			tabSpacesCtrl =
				STP.Rgi.RgiEngine.AddInteger(
					"Use Spaces",
					SettingsManager.TabSpaces,
					4,  //Default
					0,  //Min
					10, //Max
					true
				);
			(addToPanel(outputPanel, tabSpacesCtrl, "tabSpace") as Control).Enabled =SettingsManager.TabString != "\t";
			#endregion

			#endregion

			#endregion
		}

		private void GenCompilerUI()
		{
			compilerPanel = new FlowLayoutPanel() { Dock = DockStyle.Fill, AutoScroll = true };
			contentPanel.Controls.Add(compilerPanel);

			STP.Rgi.IRgiComponent defComp = addToPanel(compilerPanel,
				STP.Rgi.RgiEngine.AddBool(
					"Use Default Compiler",
					SettingsManager.UseDefaultCompiler,
					true
				),
				"defCompiler"
			);
			defComp.ValueChanged += new STP.Rgi.RgiValueUpdated(defComp_ValueChanged);

			compilerLocCtrl =
				STP.Rgi.RgiEngine.AddFileBrowser(
					"Compiler Location",
					SettingsManager.CompilerLocation,
					"NBC Compiler (nbc.exe)|nbc.exe"
				);

			(compilerLocCtrl as Control).Enabled = !SettingsManager.UseDefaultCompiler;
			addToPanel(compilerPanel, compilerLocCtrl, "compilerLoc");

			addToPanel(compilerPanel,
				STP.Rgi.RgiEngine.AddSeparator("Compiler Arguments"), null);

			addToPanel(compilerPanel,
				STP.Rgi.RgiEngine.AddInteger(
					"Optimization Level",
					SettingsManager.CompilerOptimization,
					2, //Default
					1, //Min
					2  //Max
				),
				"optimization"
			);

			addToPanel(compilerPanel, STP.Rgi.RgiEngine.AddBool(
				"Enhanced Firmware",
				SettingsManager.CompilerEnhFw,
				false),
				"enhFW"
			);
		}

		private void GenCodeAppearanceUI()
		{
			Color commandsColor, constantsColor, keywordsColor;
			string[] commands, constants, keywords;
			StreamReader sReader;

			#region Read Commands

			sReader = File.OpenText(
				new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + "\\Codeview\\commands.shf");
			string read = sReader.ReadLine();
			read = read.Replace("#COLOR=", "");
			commandsColor = Tools.stringToColor(read);
			read = sReader.ReadToEnd();
			commands = read.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
			sReader.Close();
			#endregion

			#region Read Constants

			sReader = File.OpenText(
				new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + "\\Codeview\\constants.shf");
			read = sReader.ReadLine();
			read = read.Replace("#COLOR=", "");
			constantsColor = Tools.stringToColor(read);
			read = sReader.ReadToEnd();
			constants = read.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
			sReader.Close();
			#endregion

			#region Read Keywords

			sReader = File.OpenText(
				new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + "\\Codeview\\keywords.shf");
			read = sReader.ReadLine();
			read = read.Replace("#COLOR=", "");
			keywordsColor = Tools.stringToColor(read);
			read = sReader.ReadToEnd();
			keywords = read.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
			sReader.Close();

			#endregion

			#region Panel Controls

			codeAppearancePanel = new FlowLayoutPanel()
			{
				Dock = DockStyle.Fill,
				AutoScroll = true,
				AutoScrollMargin = new Size(0, 0)
			};

			contentPanel.Controls.Add(codeAppearancePanel);

			#region Color Controls

			addToPanel(codeAppearancePanel, 
				STP.Rgi.RgiEngine.AddSeparator("Syntax Colors"), 
				null);

			commColor = addToPanel(codeAppearancePanel,
				STP.Rgi.RgiEngine.AddCompactColor("Commands Color", commandsColor, Color.FromArgb(11579568)),
				null);

			consColor = addToPanel(codeAppearancePanel,
				STP.Rgi.RgiEngine.AddCompactColor("Constants Color", constantsColor, Color.FromArgb(8388608)), 
				null);

			keywColor = addToPanel(codeAppearancePanel,
				STP.Rgi.RgiEngine.AddCompactColor("Keywords Color", keywordsColor, Color.FromArgb(255)),
				null);

			#endregion

			#region Word Controls

			addToPanel(codeAppearancePanel,
				STP.Rgi.RgiEngine.AddSeparator("Syntax Word Groups"),
				null);

			commandsComp = addToPanel(codeAppearancePanel,
				STP.Rgi.RgiEngine.AddMultilineString(
					"Commands",
					commands,
					new string[] { Properties.Resources.commandsDefault }
				),
				null
			);

			constantsComp = addToPanel(codeAppearancePanel,
				STP.Rgi.RgiEngine.AddMultilineString(
					"Constants",
					constants,
					new string[] { Properties.Resources.contantsDefault }
				),
				null
			);

			keywordsComp = addToPanel(codeAppearancePanel,
				STP.Rgi.RgiEngine.AddMultilineString(
					"Keywords",
					keywords,
					new string[] { Properties.Resources.keywordsDefault }
				),
				null
			);

			#endregion

			#endregion
		}

		#endregion

		#region Utilities

		STP.Rgi.IRgiComponent addToPanel(FlowLayoutPanel panel,
			STP.Rgi.IRgiComponent controlToAdd, string target)
		{
			(controlToAdd as Control).Width = panel.Width - (SystemInformation.VerticalScrollBarWidth + 15);
			panel.Controls.Add(controlToAdd as Control);
			valueChanged.Add(controlToAdd.UID, false);
			valueMap.Add(controlToAdd.UID, target);
			controlToAdd.ValueChanged += new STP.Rgi.RgiValueUpdated(anyCtrl_ValueChanged);
			return controlToAdd;
		}

		#endregion

		#region Binding

		void anyCtrl_ValueChanged(STP.Rgi.IRgiComponent sender, object value)
		{
			valueChanged[sender.UID] = true;
		}

		#region Toggle Tab Spaces Enabled

		STP.Rgi.IRgiComponent tabSpacesCtrl;
		void useTabCharCtrl_ValueChanged(STP.Rgi.IRgiComponent sender, object value)
		{
			(tabSpacesCtrl as Control).Enabled = !((bool)value);
		}

		#endregion

		#region Toggle Compiler Location Enabled

		STP.Rgi.IRgiComponent compilerLocCtrl;
		void defComp_ValueChanged(STP.Rgi.IRgiComponent sender, object value)
		{
			(compilerLocCtrl as Control).Enabled = !(bool)value;
		}

		#endregion

		#endregion

		#region UI Events

		private void tabSelected(object sender, EventArgs e)
		{
			foreach (Control s in tabsPanel.Controls)
			{
				if (s != sender && s is Controls.selectCheck)
				{
					tabsPanel.SuspendLayout(); //Prevents flickering??
					(s as Controls.selectCheck).SelectedState = Visual_NXC.Controls.SelectedState.None;
					tabsPanel.ResumeLayout();
				}
			}

			outputPanel.Visible = compilerPanel.Visible = codeAppearancePanel.Visible = false;

			if (sender == outputCheck)
				outputPanel.Visible = true;
			else if (sender == compilerCheck)
				compilerPanel.Visible = true;
			else if (sender == codeAppearanceCheck)
				codeAppearancePanel.Visible = true;
		}

		private void okBtn_Click(object sender, EventArgs e)
		{
			SaveChangedSettings();
		}

		#endregion	

		private void SaveChangedSettings()
		{
			#region Output Settings

			foreach (STP.Rgi.IRgiComponent control in outputPanel.Controls)
			{
				if (valueChanged[control.UID])
				{
					switch (valueMap[control.UID])
					{
						default:
							//No option?
							break;

						case "Use .h Extention":
							SettingsManager.UseCExtention = (bool)control.Value;
							break;

						case "comments":
							SettingsManager.UseComments = (bool)control.Value;
							break;

						case "tabs":
							if ((bool)control.Value)
								SettingsManager.TabString = "\t";
							else
							{
								SettingsManager.TabSpaces = (int)tabSpacesCtrl.Value;
								string tabStr = "";
								for (int i = 0; i < (int)tabSpacesCtrl.Value; i++)
									tabStr += " ";
								SettingsManager.TabString = tabStr;
							}
							break;

						case "tabSpace":
							SettingsManager.TabSpaces = (int)tabSpacesCtrl.Value;

							if (!(tabSpacesCtrl as Control).Enabled)
							{
								SettingsManager.TabString = "\t";
							}
							else
							{
								string tabStr = "";
								for (int i = 0; i < (int)tabSpacesCtrl.Value; i++)
									tabStr += " ";
								SettingsManager.TabString = tabStr;
							}
							break;
					}
				}
			}

			#endregion

			#region Compiler Settings

			foreach (STP.Rgi.IRgiComponent control in compilerPanel.Controls)
			{
				if (valueChanged[control.UID])
				{
					switch (valueMap[control.UID])
					{
						case "defCompiler":
							SettingsManager.UseDefaultCompiler = (bool)control.Value;
							break;

						case "compilerLoc":
							SettingsManager.CompilerLocation = (string)control.Value;
							break;

						case "optimization":
							SettingsManager.CompilerOptimization = (int)control.Value;
							break;

						case "enhFW":
							SettingsManager.CompilerEnhFw = (bool)control.Value;
							break;
					}
				}
			}

			#endregion

			#region Code Appearance

			#region Commands

			if (valueChanged[commColor.UID] || valueChanged[commandsComp.UID])
			{
				StreamWriter w =
					new StreamWriter(
						File.Create(
							new System.IO.FileInfo(
								System.Reflection.Assembly.GetExecutingAssembly().Location
							).DirectoryName + "\\Codeview\\commands.shf"
						)
					);
				w.WriteLine("#COLOR=" +
					System.Drawing.ColorTranslator.ToHtml(
						(Color)commColor.Value
					).Replace("#", "")
				);
				System.Text.StringBuilder b = new System.Text.StringBuilder();
				string[] val = (string[])commandsComp.Value;
				foreach (string str in val)
				{
					b.AppendLine(str);
				}
				w.Write(b.ToString());
				w.Close();
			}

			#endregion

			#region Contants

			if (valueChanged[consColor.UID] || valueChanged[constantsComp.UID])
			{
				StreamWriter w =
					new StreamWriter(
						File.Create(
							new System.IO.FileInfo(
								System.Reflection.Assembly.GetExecutingAssembly().Location
							).DirectoryName + "\\Codeview\\constants.shf"
						)
					);
				w.WriteLine("#COLOR=" +
					System.Drawing.ColorTranslator.ToHtml(
						(Color)consColor.Value
					).Replace("#", "")
				);
				System.Text.StringBuilder b = new System.Text.StringBuilder();
				string[] val = (string[])constantsComp.Value;
				foreach (string str in val)
				{
					b.AppendLine(str);
				}
				w.Write(b.ToString());
				w.Close();
			}

			#endregion

			#region Keywords

			if (valueChanged[keywColor.UID] || valueChanged[keywordsComp.UID])
			{
				StreamWriter w =
					new StreamWriter(
						File.Create(
							new System.IO.FileInfo(
								System.Reflection.Assembly.GetExecutingAssembly().Location
							).DirectoryName + "\\Codeview\\keywords.shf"
						)
					);
				w.WriteLine("#COLOR=" +
					System.Drawing.ColorTranslator.ToHtml(
						(Color)keywColor.Value
					).Replace("#", "")
				);
				System.Text.StringBuilder b = new System.Text.StringBuilder();
				string[] val = (string[])keywordsComp.Value;
				foreach (string str in val)
				{
					b.AppendLine(str);
				}
				w.Write(b.ToString());
				w.Close();
			}

			#endregion

			#endregion
		}
	}
}