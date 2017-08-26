using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Microsoft.Win32;

namespace Tool__
{
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel ToolPanel;
		private System.Windows.Forms.RadioButton ModelButton;
		private System.Windows.Forms.RadioButton AnimationsButton;
		private System.Windows.Forms.RadioButton StringsButton;
		private System.Windows.Forms.RadioButton UnicodeStringsButton;
		private System.Windows.Forms.RadioButton BitmapsButton;
		private System.Windows.Forms.RadioButton BitmapButton;
		private System.Windows.Forms.RadioButton StructureButton;
		private System.Windows.Forms.RadioButton StructureLensButton;
		private System.Windows.Forms.RadioButton SBSButton;
		private System.Windows.Forms.RadioButton CollisionGeometryButton;
		private System.Windows.Forms.RadioButton PhysicsButton;
		private System.Windows.Forms.RadioButton SoundsButton;
		private System.Windows.Forms.RadioButton SoundsByTypeButton;
		private System.Windows.Forms.RadioButton BuildCacheFileButton;
		private System.Windows.Forms.RadioButton WindowsFontButton;
		private System.Windows.Forms.RadioButton HudMessagesButton;
		private System.Windows.Forms.RadioButton LightmapsButton;
		private System.Windows.Forms.RadioButton ProcessSoundsButton;
		private System.Windows.Forms.RadioButton MergeSceneryButton;
		private System.Windows.Forms.RadioButton ZMUButton;
		private System.Windows.Forms.RadioButton IDDButton;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MainMenu MainMenu;
		private System.Windows.Forms.MenuItem FileMenu;
		private System.Windows.Forms.MenuItem FileExit;
		private System.Windows.Forms.MenuItem OptionsMenu;
		private System.Windows.Forms.MenuItem OptionsProperties;
		private System.Windows.Forms.MenuItem OptionsAbout;
		private System.Windows.Forms.StatusBar StatusBar;
		private System.Windows.Forms.MenuItem FavMenu;
		public static int DefaultSelection;
		public static string HaloDir;

		public MainForm()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
			
			if(System.IO.File.Exists("tool.exe") == false)
			{
				MessageBox.Show("#ERROR: Tool++ can't find 'tool.exe'.\nIs Tool++ in your HaloCE directory?",
					"Whoops",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				this.Close();
			}

			RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software\\Tool++");

			MainForm.HaloDir = (string)rk.GetValue("Dir", "C:\\Program Files\\Microsoft Games\\Halo Custom Edition\\");
			MainForm.DefaultSelection = (int)rk.GetValue("Default", 0);

			if(DefaultSelection == 0)
				return;
			else if(DefaultSelection == 1)
				OnModel(null, null);
			else if(DefaultSelection == 2)
				OnAnimations(null, null);
			else if(DefaultSelection == 3)
				OnStrings(null, null);
			else if(DefaultSelection == 4)
				OnUnicodeStrings(null, null);
			else if(DefaultSelection == 5)
				OnBitmaps(null, null);
			else if(DefaultSelection == 6)
				OnBitmap(null, null);
			else if(DefaultSelection == 7)
				OnStructure(null, null);
			else if(DefaultSelection == 8)
				OnStructureLens(null, null);
			else if(DefaultSelection == 9)
				OnSBS(null, null);
			else if(DefaultSelection == 10)
				OnCollisionGeometry(null, null);
			else if(DefaultSelection == 11)
				OnPhysics(null, null);
			else if(DefaultSelection == 12)
				OnSounds(null, null);
			else if(DefaultSelection == 13)
				OnSoundsByType(null, null);
			else if(DefaultSelection == 14)
				OnBuild(null, null);
			else if(DefaultSelection == 15)
				OnWindowsFont(null, null);
			else if(DefaultSelection == 16)
				OnHudMessages(null, null);
			else if(DefaultSelection == 17)
				OnLightmaps(null, null);
			else if(DefaultSelection == 18)
				OnProcessSounds(null, null);
			else if(DefaultSelection == 19)
				OnMergeScenery(null, null);
			else if(DefaultSelection == 20)
				OnZMU(null, null);
			else if(DefaultSelection == 21)
				OnIDD(null, null);
			else
			{
				MessageBox.Show("#ERROR: Default Option was out of range.\nDefaulting to 'None'",
					"Whoops",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
					components.Dispose();
			}
			base.Dispose( disposing );

			RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software\\Tool++");

			rk.SetValue("Dir", MainForm.HaloDir);
			rk.SetValue("Default", MainForm.DefaultSelection);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.IDDButton = new System.Windows.Forms.RadioButton();
			this.ZMUButton = new System.Windows.Forms.RadioButton();
			this.MergeSceneryButton = new System.Windows.Forms.RadioButton();
			this.ProcessSoundsButton = new System.Windows.Forms.RadioButton();
			this.LightmapsButton = new System.Windows.Forms.RadioButton();
			this.HudMessagesButton = new System.Windows.Forms.RadioButton();
			this.WindowsFontButton = new System.Windows.Forms.RadioButton();
			this.BuildCacheFileButton = new System.Windows.Forms.RadioButton();
			this.SoundsByTypeButton = new System.Windows.Forms.RadioButton();
			this.SoundsButton = new System.Windows.Forms.RadioButton();
			this.PhysicsButton = new System.Windows.Forms.RadioButton();
			this.CollisionGeometryButton = new System.Windows.Forms.RadioButton();
			this.SBSButton = new System.Windows.Forms.RadioButton();
			this.StructureLensButton = new System.Windows.Forms.RadioButton();
			this.StructureButton = new System.Windows.Forms.RadioButton();
			this.BitmapButton = new System.Windows.Forms.RadioButton();
			this.BitmapsButton = new System.Windows.Forms.RadioButton();
			this.UnicodeStringsButton = new System.Windows.Forms.RadioButton();
			this.StringsButton = new System.Windows.Forms.RadioButton();
			this.AnimationsButton = new System.Windows.Forms.RadioButton();
			this.ModelButton = new System.Windows.Forms.RadioButton();
			this.ToolPanel = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.StatusBar = new System.Windows.Forms.StatusBar();
			this.MainMenu = new System.Windows.Forms.MainMenu();
			this.FileMenu = new System.Windows.Forms.MenuItem();
			this.FileExit = new System.Windows.Forms.MenuItem();
			this.OptionsMenu = new System.Windows.Forms.MenuItem();
			this.OptionsProperties = new System.Windows.Forms.MenuItem();
			this.OptionsAbout = new System.Windows.Forms.MenuItem();
			this.FavMenu = new System.Windows.Forms.MenuItem();
			this.groupBox1.SuspendLayout();
			this.ToolPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.IDDButton);
			this.groupBox1.Controls.Add(this.ZMUButton);
			this.groupBox1.Controls.Add(this.MergeSceneryButton);
			this.groupBox1.Controls.Add(this.ProcessSoundsButton);
			this.groupBox1.Controls.Add(this.LightmapsButton);
			this.groupBox1.Controls.Add(this.HudMessagesButton);
			this.groupBox1.Controls.Add(this.WindowsFontButton);
			this.groupBox1.Controls.Add(this.BuildCacheFileButton);
			this.groupBox1.Controls.Add(this.SoundsByTypeButton);
			this.groupBox1.Controls.Add(this.SoundsButton);
			this.groupBox1.Controls.Add(this.PhysicsButton);
			this.groupBox1.Controls.Add(this.CollisionGeometryButton);
			this.groupBox1.Controls.Add(this.SBSButton);
			this.groupBox1.Controls.Add(this.StructureLensButton);
			this.groupBox1.Controls.Add(this.StructureButton);
			this.groupBox1.Controls.Add(this.BitmapButton);
			this.groupBox1.Controls.Add(this.BitmapsButton);
			this.groupBox1.Controls.Add(this.UnicodeStringsButton);
			this.groupBox1.Controls.Add(this.StringsButton);
			this.groupBox1.Controls.Add(this.AnimationsButton);
			this.groupBox1.Controls.Add(this.ModelButton);
			this.groupBox1.Location = new System.Drawing.Point(0, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 536);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tool Commands";
			// 
			// IDDButton
			// 
			this.IDDButton.Location = new System.Drawing.Point(8, 496);
			this.IDDButton.Name = "IDDButton";
			this.IDDButton.Size = new System.Drawing.Size(184, 24);
			this.IDDButton.TabIndex = 20;
			this.IDDButton.Text = "Import-Device-Defaults";
			this.toolTip.SetToolTip(this.IDDButton, "Make a new device defaults tag from a save game");
			this.IDDButton.CheckedChanged += new System.EventHandler(this.OnIDD);
			// 
			// ZMUButton
			// 
			this.ZMUButton.Location = new System.Drawing.Point(8, 472);
			this.ZMUButton.Name = "ZMUButton";
			this.ZMUButton.Size = new System.Drawing.Size(184, 24);
			this.ZMUButton.TabIndex = 19;
			this.ZMUButton.Text = "Zoners_Model_Upgrage";
			this.toolTip.SetToolTip(this.ZMUButton, "?");
			this.ZMUButton.CheckedChanged += new System.EventHandler(this.OnZMU);
			// 
			// MergeSceneryButton
			// 
			this.MergeSceneryButton.Location = new System.Drawing.Point(8, 448);
			this.MergeSceneryButton.Name = "MergeSceneryButton";
			this.MergeSceneryButton.Size = new System.Drawing.Size(184, 24);
			this.MergeSceneryButton.TabIndex = 18;
			this.MergeSceneryButton.Text = "Merge-Scenery";
			this.toolTip.SetToolTip(this.MergeSceneryButton, "Copy scenary data fron one scenario to another scenario tag");
			this.MergeSceneryButton.CheckedChanged += new System.EventHandler(this.OnMergeScenery);
			// 
			// ProcessSoundsButton
			// 
			this.ProcessSoundsButton.Location = new System.Drawing.Point(8, 424);
			this.ProcessSoundsButton.Name = "ProcessSoundsButton";
			this.ProcessSoundsButton.Size = new System.Drawing.Size(184, 24);
			this.ProcessSoundsButton.TabIndex = 17;
			this.ProcessSoundsButton.Text = "Process-Sounds";
			this.toolTip.SetToolTip(this.ProcessSoundsButton, "Make multiple sound tags from a specified root folder");
			this.ProcessSoundsButton.CheckedChanged += new System.EventHandler(this.OnProcessSounds);
			// 
			// LightmapsButton
			// 
			this.LightmapsButton.Location = new System.Drawing.Point(8, 400);
			this.LightmapsButton.Name = "LightmapsButton";
			this.LightmapsButton.Size = new System.Drawing.Size(184, 24);
			this.LightmapsButton.TabIndex = 16;
			this.LightmapsButton.Text = "Lightmaps";
			this.toolTip.SetToolTip(this.LightmapsButton, "Create a lightmap for a scenario tag");
			this.LightmapsButton.CheckedChanged += new System.EventHandler(this.OnLightmaps);
			// 
			// HudMessagesButton
			// 
			this.HudMessagesButton.Location = new System.Drawing.Point(8, 376);
			this.HudMessagesButton.Name = "HudMessagesButton";
			this.HudMessagesButton.Size = new System.Drawing.Size(184, 24);
			this.HudMessagesButton.TabIndex = 15;
			this.HudMessagesButton.Text = "HUD-Messages";
			this.toolTip.SetToolTip(this.HudMessagesButton, "Make a new hud message tag from a scenario tag");
			this.HudMessagesButton.CheckedChanged += new System.EventHandler(this.OnHudMessages);
			// 
			// WindowsFontButton
			// 
			this.WindowsFontButton.Location = new System.Drawing.Point(8, 352);
			this.WindowsFontButton.Name = "WindowsFontButton";
			this.WindowsFontButton.Size = new System.Drawing.Size(184, 24);
			this.WindowsFontButton.TabIndex = 14;
			this.WindowsFontButton.Text = "Windows-Font";
			this.toolTip.SetToolTip(this.WindowsFontButton, "Make a new Font tag");
			this.WindowsFontButton.CheckedChanged += new System.EventHandler(this.OnWindowsFont);
			// 
			// BuildCacheFileButton
			// 
			this.BuildCacheFileButton.Location = new System.Drawing.Point(8, 328);
			this.BuildCacheFileButton.Name = "BuildCacheFileButton";
			this.BuildCacheFileButton.Size = new System.Drawing.Size(184, 24);
			this.BuildCacheFileButton.TabIndex = 13;
			this.BuildCacheFileButton.Text = "Build-Cache-File";
			this.toolTip.SetToolTip(this.BuildCacheFileButton, "Make a new .map file from a scenario tag");
			this.BuildCacheFileButton.CheckedChanged += new System.EventHandler(this.OnBuild);
			// 
			// SoundsByTypeButton
			// 
			this.SoundsByTypeButton.Location = new System.Drawing.Point(8, 304);
			this.SoundsByTypeButton.Name = "SoundsByTypeButton";
			this.SoundsByTypeButton.Size = new System.Drawing.Size(184, 24);
			this.SoundsByTypeButton.TabIndex = 12;
			this.SoundsByTypeButton.Text = "Sounds_by_Type";
			this.toolTip.SetToolTip(this.SoundsByTypeButton, "Make new sounds tags from a directory by special types");
			this.SoundsByTypeButton.CheckedChanged += new System.EventHandler(this.OnSoundsByType);
			// 
			// SoundsButton
			// 
			this.SoundsButton.Location = new System.Drawing.Point(8, 280);
			this.SoundsButton.Name = "SoundsButton";
			this.SoundsButton.Size = new System.Drawing.Size(184, 24);
			this.SoundsButton.TabIndex = 11;
			this.SoundsButton.Text = "Sounds";
			this.toolTip.SetToolTip(this.SoundsButton, "Make new sound tags from a directory with .wav or .ogg files");
			this.SoundsButton.CheckedChanged += new System.EventHandler(this.OnSounds);
			// 
			// PhysicsButton
			// 
			this.PhysicsButton.Location = new System.Drawing.Point(8, 256);
			this.PhysicsButton.Name = "PhysicsButton";
			this.PhysicsButton.Size = new System.Drawing.Size(184, 24);
			this.PhysicsButton.TabIndex = 10;
			this.PhysicsButton.Text = "Physics";
			this.toolTip.SetToolTip(this.PhysicsButton, "Make a new physics tag from a .jms(?) file");
			this.PhysicsButton.CheckedChanged += new System.EventHandler(this.OnPhysics);
			// 
			// CollisionGeometryButton
			// 
			this.CollisionGeometryButton.Location = new System.Drawing.Point(8, 232);
			this.CollisionGeometryButton.Name = "CollisionGeometryButton";
			this.CollisionGeometryButton.Size = new System.Drawing.Size(184, 24);
			this.CollisionGeometryButton.TabIndex = 9;
			this.CollisionGeometryButton.Text = "Collision-Geometry";
			this.toolTip.SetToolTip(this.CollisionGeometryButton, "Make new collision gemoetry tags from a directory with .jms(?) files");
			this.CollisionGeometryButton.CheckedChanged += new System.EventHandler(this.OnCollisionGeometry);
			// 
			// SBSButton
			// 
			this.SBSButton.Location = new System.Drawing.Point(8, 208);
			this.SBSButton.Name = "SBSButton";
			this.SBSButton.Size = new System.Drawing.Size(184, 24);
			this.SBSButton.TabIndex = 8;
			this.SBSButton.Text = "Structure-Breakable-Surfaces";
			this.toolTip.SetToolTip(this.SBSButton, "Create breakable surfaces from a structure bsp");
			this.SBSButton.CheckedChanged += new System.EventHandler(this.OnSBS);
			// 
			// StructureLensButton
			// 
			this.StructureLensButton.Location = new System.Drawing.Point(8, 184);
			this.StructureLensButton.Name = "StructureLensButton";
			this.StructureLensButton.Size = new System.Drawing.Size(184, 24);
			this.StructureLensButton.TabIndex = 7;
			this.StructureLensButton.Text = "Structure-Lens-Flares";
			this.toolTip.SetToolTip(this.StructureLensButton, "Create lens flares for a structure bsp");
			this.StructureLensButton.CheckedChanged += new System.EventHandler(this.OnStructureLens);
			// 
			// StructureButton
			// 
			this.StructureButton.Location = new System.Drawing.Point(8, 160);
			this.StructureButton.Name = "StructureButton";
			this.StructureButton.Size = new System.Drawing.Size(184, 24);
			this.StructureButton.TabIndex = 6;
			this.StructureButton.Text = "Structure";
			this.toolTip.SetToolTip(this.StructureButton, "Make a new structure bsp tag from a .jms file");
			this.StructureButton.CheckedChanged += new System.EventHandler(this.OnStructure);
			// 
			// BitmapButton
			// 
			this.BitmapButton.Location = new System.Drawing.Point(8, 136);
			this.BitmapButton.Name = "BitmapButton";
			this.BitmapButton.Size = new System.Drawing.Size(184, 24);
			this.BitmapButton.TabIndex = 5;
			this.BitmapButton.Text = "Bitmap";
			this.toolTip.SetToolTip(this.BitmapButton, "Make a new bitmap from a .tif file");
			this.BitmapButton.CheckedChanged += new System.EventHandler(this.OnBitmap);
			// 
			// BitmapsButton
			// 
			this.BitmapsButton.Location = new System.Drawing.Point(8, 112);
			this.BitmapsButton.Name = "BitmapsButton";
			this.BitmapsButton.Size = new System.Drawing.Size(184, 24);
			this.BitmapsButton.TabIndex = 4;
			this.BitmapsButton.Text = "Bitmaps";
			this.toolTip.SetToolTip(this.BitmapsButton, "Make new bitmap tags from a directory with .tif files");
			this.BitmapsButton.CheckedChanged += new System.EventHandler(this.OnBitmaps);
			// 
			// UnicodeStringsButton
			// 
			this.UnicodeStringsButton.Location = new System.Drawing.Point(8, 88);
			this.UnicodeStringsButton.Name = "UnicodeStringsButton";
			this.UnicodeStringsButton.Size = new System.Drawing.Size(184, 24);
			this.UnicodeStringsButton.TabIndex = 3;
			this.UnicodeStringsButton.Text = "Unicode-Strings";
			this.toolTip.SetToolTip(this.UnicodeStringsButton, "Make new unicode string tags from a directory with .txt files");
			this.UnicodeStringsButton.CheckedChanged += new System.EventHandler(this.OnUnicodeStrings);
			// 
			// StringsButton
			// 
			this.StringsButton.Location = new System.Drawing.Point(8, 64);
			this.StringsButton.Name = "StringsButton";
			this.StringsButton.Size = new System.Drawing.Size(184, 24);
			this.StringsButton.TabIndex = 2;
			this.StringsButton.Text = "Strings";
			this.toolTip.SetToolTip(this.StringsButton, "Make new string tags from a directory .txt files");
			this.StringsButton.CheckedChanged += new System.EventHandler(this.OnStrings);
			// 
			// AnimationsButton
			// 
			this.AnimationsButton.Location = new System.Drawing.Point(8, 40);
			this.AnimationsButton.Name = "AnimationsButton";
			this.AnimationsButton.Size = new System.Drawing.Size(184, 24);
			this.AnimationsButton.TabIndex = 1;
			this.AnimationsButton.Text = "Animations";
			this.toolTip.SetToolTip(this.AnimationsButton, "Make new animation tags from a directory with .jma files");
			this.AnimationsButton.CheckedChanged += new System.EventHandler(this.OnAnimations);
			// 
			// ModelButton
			// 
			this.ModelButton.Location = new System.Drawing.Point(8, 16);
			this.ModelButton.Name = "ModelButton";
			this.ModelButton.Size = new System.Drawing.Size(184, 24);
			this.ModelButton.TabIndex = 0;
			this.ModelButton.Text = "Model";
			this.toolTip.SetToolTip(this.ModelButton, "Make new model tags from a directory with .jms file");
			this.ModelButton.CheckedChanged += new System.EventHandler(this.OnModel);
			// 
			// ToolPanel
			// 
			this.ToolPanel.AutoScroll = true;
			this.ToolPanel.Controls.Add(this.label1);
			this.ToolPanel.Location = new System.Drawing.Point(208, 16);
			this.ToolPanel.Name = "ToolPanel";
			this.ToolPanel.Size = new System.Drawing.Size(504, 528);
			this.ToolPanel.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(64, 224);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(384, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select a Option from the \'Tool Commands\' menu.";
			// 
			// StatusBar
			// 
			this.StatusBar.Location = new System.Drawing.Point(0, 549);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.Size = new System.Drawing.Size(714, 22);
			this.StatusBar.TabIndex = 2;
			this.StatusBar.Text = "Ready";
			this.toolTip.SetToolTip(this.StatusBar, "Ready");
			// 
			// MainMenu
			// 
			this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.FileMenu,
																					 this.OptionsMenu,
																					 this.FavMenu});
			// 
			// FileMenu
			// 
			this.FileMenu.Index = 0;
			this.FileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.FileExit});
			this.FileMenu.Text = "&File";
			// 
			// FileExit
			// 
			this.FileExit.Index = 0;
			this.FileExit.Shortcut = System.Windows.Forms.Shortcut.CtrlQ;
			this.FileExit.Text = "Exit";
			this.FileExit.Click += new System.EventHandler(this.OnExit);
			this.FileExit.Select += new System.EventHandler(this.OnExitSelect);
			// 
			// OptionsMenu
			// 
			this.OptionsMenu.Index = 1;
			this.OptionsMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.OptionsProperties,
																						this.OptionsAbout});
			this.OptionsMenu.Text = "&Options";
			// 
			// OptionsProperties
			// 
			this.OptionsProperties.Index = 0;
			this.OptionsProperties.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.OptionsProperties.Text = "Properties";
			this.OptionsProperties.Click += new System.EventHandler(this.OnProperties);
			this.OptionsProperties.Select += new System.EventHandler(this.OnPropertiesSelect);
			// 
			// OptionsAbout
			// 
			this.OptionsAbout.Index = 1;
			this.OptionsAbout.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
			this.OptionsAbout.Text = "About Tool++...";
			this.OptionsAbout.Click += new System.EventHandler(this.OnAbout);
			this.OptionsAbout.Select += new System.EventHandler(this.OnAboutSelect);
			// 
			// FavMenu
			// 
			this.FavMenu.Enabled = false;
			this.FavMenu.Index = 2;
			this.FavMenu.Text = "F&avorites";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(714, 571);
			this.Controls.Add(this.StatusBar);
			this.Controls.Add(this.ToolPanel);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.MainMenu;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tool.exe++ [No Option Selected]";
			this.Closed += new System.EventHandler(this.OnExit);
			this.groupBox1.ResumeLayout(false);
			this.ToolPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void StatusText(string text)
		{
			this.StatusBar.Text = text;
			toolTip.SetToolTip(StatusBar, text);
		}

		protected override void OnMenuComplete(EventArgs e)
		{
			this.StatusText("Ready");
			base.OnMenuComplete (e);
		}

		private void OnModel(object sender, System.EventArgs e)
		{
			//ModelButton.Checked = true;
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new Model());
		}

		private void OnAnimations(object sender, System.EventArgs e)
		{
			//AnimationsButton.Checked = true;
			this.Text = "Tool.exe++ [Animations]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new Animations());
		}

		private void OnStrings(object sender, System.EventArgs e)
		{
			//StringsButton.Checked = true;
			this.Text = "Tool.exe++ [Strings]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new Strings());
		}

		private void OnUnicodeStrings(object sender, System.EventArgs e)
		{
			//UnicodeStringsButton.Checked = true;
			this.Text = "Tool.exe++ [Unicode-Strings]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new UnicodeStrings());
		}

		private void OnBitmaps(object sender, System.EventArgs e)
		{
			//BitmapsButton.Checked = true;
			this.Text = "Tool.exe++ [Bitmaps]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new Bitmaps());
		}

		private void OnBitmap(object sender, System.EventArgs e)
		{
			//BitmapButton.Checked = true;
			this.Text = "Tool.exe++ [Bitmap]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new Bitmap());
		}

		private void OnStructure(object sender, System.EventArgs e)
		{
			//StructureButton.Checked = true;
			this.Text = "Tool.exe++ [Structure]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new Structure());
		}

		private void OnStructureLens(object sender, System.EventArgs e)
		{
			//StructureLensButton.Checked = true;
			this.Text = "Tool.exe++ [Structure-Lens-Flare]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new StructureLensFlares());
		}

		private void OnSBS(object sender, System.EventArgs e)
		{
			//SBSButton.Checked = true;
			this.Text = "Tool.exe++ [Structure-Breakable-Surfaces]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new SBS());
		}

		private void OnCollisionGeometry(object sender, System.EventArgs e)
		{
			//CollisionGeometryButton.Checked = true;
			this.Text = "Tool.exe++ [Collision Geometry]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new CollisionGeometry());
		}

		private void OnPhysics(object sender, System.EventArgs e)
		{
			//PhysicsButton.Checked = true;
			this.Text = "Tool.exe++ [Physics]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new Physics());
		}

		private void OnSounds(object sender, System.EventArgs e)
		{
			//SoundsButton.Checked = true;
			this.Text = "Tool.exe++ [Sounds]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new Sounds());
		}

		private void OnSoundsByType(object sender, System.EventArgs e)
		{
			//SoundsByTypeButton.Checked = true;
			this.Text = "Tool.exe++ [Sounds_By_Type]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new SoundsByType());
		}

		private void OnBuild(object sender, System.EventArgs e)
		{
			//BuildCacheFileButton.Checked = true;
			this.Text = "Tool.exe++ [Build-Cache-File]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new BuildCacheFile());
		}

		private void OnWindowsFont(object sender, System.EventArgs e)
		{
			//WindowsFontButton.Checked = true;
			this.Text = "Tool.exe++ [Windows-Font]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new WindowsFont());
		}

		private void OnHudMessages(object sender, System.EventArgs e)
		{
			//HudMessagesButton.Checked = true;
			this.Text = "Tool.exe++ [HUD-Messages]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new HudMessages());
		}

		private void OnLightmaps(object sender, System.EventArgs e)
		{
			//LightmapsButton.Checked = true;
			this.Text = "Tool.exe++ [Lightmaps]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new Lightmaps());
		}

		private void OnProcessSounds(object sender, System.EventArgs e)
		{
			//ProcessSoundsButton.Checked = true;
			this.Text = "Tool.exe++ [Process-Sounds]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new ProcessSounds());
		}

		private void OnMergeScenery(object sender, System.EventArgs e)
		{
			//MergeSceneryButton.Checked = true;
			this.Text = "Tool.exe++ [Merge-Scenery]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new MergeScenery());
		}

		private void OnZMU(object sender, System.EventArgs e)
		{
			//ZMUButton.Checked = true;
			this.Text = "Tool.exe++ [Zoners_Model_Upgrage]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new ZMU());
		}

		private void OnIDD(object sender, System.EventArgs e)
		{
			//IDDButton.Checked = true;
			this.Text = "Tool.exe++ [Import-Device-Defaults]";
			ToolPanel.Controls.Clear();
			ToolPanel.Controls.Add(new IDD());
		}

		private void OnExit(object sender, System.EventArgs e)
		{
			this.Dispose(true);
			this.Close();
		}

		private void OnExitSelect(object sender, System.EventArgs e)
		{
			this.StatusText("Exit Tool++");
		}

		private void OnProperties(object sender, System.EventArgs e)
		{
			Properties prop = new Properties();
			prop.Show();
		}

		private void OnPropertiesSelect(object sender, System.EventArgs e)
		{
			this.StatusText("Edit Tool++ Properties");
		}

		private void OnAbout(object sender, System.EventArgs e)
		{
			About about = new About();
			about.Show();
		}

		private void OnAboutSelect(object sender, System.EventArgs e)
		{
			this.StatusText("About Tool++");
		}
	}
}