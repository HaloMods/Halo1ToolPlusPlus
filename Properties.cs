using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Tool__
{
	public class Properties : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox HaloDirEdit;
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton IDDButton;
		private System.Windows.Forms.RadioButton ZMUButton;
		private System.Windows.Forms.RadioButton MergeSceneryButton;
		private System.Windows.Forms.RadioButton ProcessSoundsButton;
		private System.Windows.Forms.RadioButton LightmapsButton;
		private System.Windows.Forms.RadioButton HudMessagesButton;
		private System.Windows.Forms.RadioButton WindowsFontButton;
		private System.Windows.Forms.RadioButton BuildCacheFileButton;
		private System.Windows.Forms.RadioButton SoundsByTypeButton;
		private System.Windows.Forms.RadioButton SoundsButton;
		private System.Windows.Forms.RadioButton PhysicsButton;
		private System.Windows.Forms.RadioButton CollisionGeometryButton;
		private System.Windows.Forms.RadioButton SBSButton;
		private System.Windows.Forms.RadioButton StructureLensButton;
		private System.Windows.Forms.RadioButton StructureButton;
		private System.Windows.Forms.RadioButton BitmapButton;
		private System.Windows.Forms.RadioButton BitmapsButton;
		private System.Windows.Forms.RadioButton UnicodeStringsButton;
		private System.Windows.Forms.RadioButton StringsButton;
		private System.Windows.Forms.RadioButton AnimationsButton;
		private System.Windows.Forms.RadioButton ModelButton;
		private System.Windows.Forms.RadioButton None;
		private object DefaultOption;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Properties()
		{
			// Required for Windows Form Designer support
			InitializeComponent();

			this.HaloDirEdit.Text = MainForm.HaloDir;
			this.SetDefault(MainForm.DefaultSelection);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.HaloDirEdit = new System.Windows.Forms.TextBox();
			this.OK = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.None = new System.Windows.Forms.RadioButton();
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
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Halo Directory:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// HaloDirEdit
			// 
			this.HaloDirEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.HaloDirEdit.Location = new System.Drawing.Point(104, 0);
			this.HaloDirEdit.Name = "HaloDirEdit";
			this.HaloDirEdit.Size = new System.Drawing.Size(280, 20);
			this.HaloDirEdit.TabIndex = 1;
			this.HaloDirEdit.Text = "";
			// 
			// OK
			// 
			this.OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OK.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.OK.Location = new System.Drawing.Point(0, 350);
			this.OK.Name = "OK";
			this.OK.Size = new System.Drawing.Size(392, 23);
			this.OK.TabIndex = 2;
			this.OK.Text = "OK";
			this.OK.Click += new System.EventHandler(this.OK_Click);
			// 
			// Cancel
			// 
			this.Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Cancel.Location = new System.Drawing.Point(0, 327);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(392, 23);
			this.Cancel.TabIndex = 3;
			this.Cancel.Text = "Cancel";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.None);
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
			this.groupBox1.Location = new System.Drawing.Point(0, 32);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(384, 288);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Default Tool Option:";
			// 
			// None
			// 
			this.None.Location = new System.Drawing.Point(192, 256);
			this.None.Name = "None";
			this.None.Size = new System.Drawing.Size(184, 24);
			this.None.TabIndex = 42;
			this.None.Tag = "0";
			this.None.Text = "No Default Option";
			this.None.CheckedChanged += new System.EventHandler(this.None_CheckedChanged);
			// 
			// IDDButton
			// 
			this.IDDButton.Location = new System.Drawing.Point(8, 256);
			this.IDDButton.Name = "IDDButton";
			this.IDDButton.Size = new System.Drawing.Size(184, 24);
			this.IDDButton.TabIndex = 41;
			this.IDDButton.Tag = "21";
			this.IDDButton.Text = "Import-Device-Defaults";
			this.IDDButton.CheckedChanged += new System.EventHandler(this.IDDButton_CheckedChanged);
			// 
			// ZMUButton
			// 
			this.ZMUButton.Location = new System.Drawing.Point(192, 232);
			this.ZMUButton.Name = "ZMUButton";
			this.ZMUButton.Size = new System.Drawing.Size(184, 24);
			this.ZMUButton.TabIndex = 40;
			this.ZMUButton.Tag = "20";
			this.ZMUButton.Text = "Zoners_Model_Upgrage";
			this.ZMUButton.CheckedChanged += new System.EventHandler(this.ZMUButton_CheckedChanged);
			// 
			// MergeSceneryButton
			// 
			this.MergeSceneryButton.Location = new System.Drawing.Point(8, 232);
			this.MergeSceneryButton.Name = "MergeSceneryButton";
			this.MergeSceneryButton.Size = new System.Drawing.Size(184, 24);
			this.MergeSceneryButton.TabIndex = 39;
			this.MergeSceneryButton.Tag = "19";
			this.MergeSceneryButton.Text = "Merge-Scenery";
			this.MergeSceneryButton.CheckedChanged += new System.EventHandler(this.MergeSceneryButton_CheckedChanged);
			// 
			// ProcessSoundsButton
			// 
			this.ProcessSoundsButton.Location = new System.Drawing.Point(192, 208);
			this.ProcessSoundsButton.Name = "ProcessSoundsButton";
			this.ProcessSoundsButton.Size = new System.Drawing.Size(184, 24);
			this.ProcessSoundsButton.TabIndex = 38;
			this.ProcessSoundsButton.Tag = "18";
			this.ProcessSoundsButton.Text = "Process-Sounds";
			this.ProcessSoundsButton.CheckedChanged += new System.EventHandler(this.ProcessSoundsButton_CheckedChanged);
			// 
			// LightmapsButton
			// 
			this.LightmapsButton.Location = new System.Drawing.Point(8, 208);
			this.LightmapsButton.Name = "LightmapsButton";
			this.LightmapsButton.Size = new System.Drawing.Size(184, 24);
			this.LightmapsButton.TabIndex = 37;
			this.LightmapsButton.Tag = "17";
			this.LightmapsButton.Text = "Lightmaps";
			this.LightmapsButton.CheckedChanged += new System.EventHandler(this.LightmapsButton_CheckedChanged);
			// 
			// HudMessagesButton
			// 
			this.HudMessagesButton.Location = new System.Drawing.Point(192, 184);
			this.HudMessagesButton.Name = "HudMessagesButton";
			this.HudMessagesButton.Size = new System.Drawing.Size(184, 24);
			this.HudMessagesButton.TabIndex = 36;
			this.HudMessagesButton.Tag = "16";
			this.HudMessagesButton.Text = "HUD-Messages";
			this.HudMessagesButton.CheckedChanged += new System.EventHandler(this.HudMessagesButton_CheckedChanged);
			// 
			// WindowsFontButton
			// 
			this.WindowsFontButton.Location = new System.Drawing.Point(8, 184);
			this.WindowsFontButton.Name = "WindowsFontButton";
			this.WindowsFontButton.Size = new System.Drawing.Size(184, 24);
			this.WindowsFontButton.TabIndex = 35;
			this.WindowsFontButton.Tag = "15";
			this.WindowsFontButton.Text = "Windows Font";
			this.WindowsFontButton.CheckedChanged += new System.EventHandler(this.WindowsFontButton_CheckedChanged);
			// 
			// BuildCacheFileButton
			// 
			this.BuildCacheFileButton.Location = new System.Drawing.Point(192, 160);
			this.BuildCacheFileButton.Name = "BuildCacheFileButton";
			this.BuildCacheFileButton.Size = new System.Drawing.Size(184, 24);
			this.BuildCacheFileButton.TabIndex = 34;
			this.BuildCacheFileButton.Tag = "14";
			this.BuildCacheFileButton.Text = "Build-Cache-File";
			this.BuildCacheFileButton.CheckedChanged += new System.EventHandler(this.BuildCacheFileButton_CheckedChanged);
			// 
			// SoundsByTypeButton
			// 
			this.SoundsByTypeButton.Location = new System.Drawing.Point(8, 160);
			this.SoundsByTypeButton.Name = "SoundsByTypeButton";
			this.SoundsByTypeButton.Size = new System.Drawing.Size(184, 24);
			this.SoundsByTypeButton.TabIndex = 33;
			this.SoundsByTypeButton.Tag = "13";
			this.SoundsByTypeButton.Text = "Sounds_by_Type";
			this.SoundsByTypeButton.CheckedChanged += new System.EventHandler(this.SoundsByTypeButton_CheckedChanged);
			// 
			// SoundsButton
			// 
			this.SoundsButton.Location = new System.Drawing.Point(192, 136);
			this.SoundsButton.Name = "SoundsButton";
			this.SoundsButton.Size = new System.Drawing.Size(184, 24);
			this.SoundsButton.TabIndex = 32;
			this.SoundsButton.Tag = "12";
			this.SoundsButton.Text = "Sounds";
			this.SoundsButton.CheckedChanged += new System.EventHandler(this.SoundsButton_CheckedChanged);
			// 
			// PhysicsButton
			// 
			this.PhysicsButton.Location = new System.Drawing.Point(8, 136);
			this.PhysicsButton.Name = "PhysicsButton";
			this.PhysicsButton.Size = new System.Drawing.Size(184, 24);
			this.PhysicsButton.TabIndex = 31;
			this.PhysicsButton.Tag = "11";
			this.PhysicsButton.Text = "Physics";
			this.PhysicsButton.CheckedChanged += new System.EventHandler(this.PhysicsButton_CheckedChanged);
			// 
			// CollisionGeometryButton
			// 
			this.CollisionGeometryButton.Location = new System.Drawing.Point(192, 112);
			this.CollisionGeometryButton.Name = "CollisionGeometryButton";
			this.CollisionGeometryButton.Size = new System.Drawing.Size(184, 24);
			this.CollisionGeometryButton.TabIndex = 30;
			this.CollisionGeometryButton.Tag = "10";
			this.CollisionGeometryButton.Text = "Collision-Geometry";
			this.CollisionGeometryButton.CheckedChanged += new System.EventHandler(this.CollisionGeometryButton_CheckedChanged);
			// 
			// SBSButton
			// 
			this.SBSButton.Location = new System.Drawing.Point(8, 112);
			this.SBSButton.Name = "SBSButton";
			this.SBSButton.Size = new System.Drawing.Size(184, 24);
			this.SBSButton.TabIndex = 29;
			this.SBSButton.Tag = "9";
			this.SBSButton.Text = "Structure-Breakable-Surfaces";
			this.SBSButton.CheckedChanged += new System.EventHandler(this.SBSButton_CheckedChanged);
			// 
			// StructureLensButton
			// 
			this.StructureLensButton.Location = new System.Drawing.Point(192, 88);
			this.StructureLensButton.Name = "StructureLensButton";
			this.StructureLensButton.Size = new System.Drawing.Size(184, 24);
			this.StructureLensButton.TabIndex = 28;
			this.StructureLensButton.Tag = "8";
			this.StructureLensButton.Text = "Structure-Lens-Flares";
			this.StructureLensButton.CheckedChanged += new System.EventHandler(this.StructureLensButton_CheckedChanged);
			// 
			// StructureButton
			// 
			this.StructureButton.Location = new System.Drawing.Point(8, 88);
			this.StructureButton.Name = "StructureButton";
			this.StructureButton.Size = new System.Drawing.Size(184, 24);
			this.StructureButton.TabIndex = 27;
			this.StructureButton.Tag = "7";
			this.StructureButton.Text = "Structure";
			this.StructureButton.CheckedChanged += new System.EventHandler(this.StructureButton_CheckedChanged);
			// 
			// BitmapButton
			// 
			this.BitmapButton.Location = new System.Drawing.Point(192, 64);
			this.BitmapButton.Name = "BitmapButton";
			this.BitmapButton.Size = new System.Drawing.Size(184, 24);
			this.BitmapButton.TabIndex = 26;
			this.BitmapButton.Tag = "6";
			this.BitmapButton.Text = "Bitmap";
			this.BitmapButton.CheckedChanged += new System.EventHandler(this.BitmapButton_CheckedChanged);
			// 
			// BitmapsButton
			// 
			this.BitmapsButton.Location = new System.Drawing.Point(8, 64);
			this.BitmapsButton.Name = "BitmapsButton";
			this.BitmapsButton.Size = new System.Drawing.Size(184, 24);
			this.BitmapsButton.TabIndex = 25;
			this.BitmapsButton.Tag = "5";
			this.BitmapsButton.Text = "Bitmaps";
			this.BitmapsButton.CheckedChanged += new System.EventHandler(this.BitmapsButton_CheckedChanged);
			// 
			// UnicodeStringsButton
			// 
			this.UnicodeStringsButton.Location = new System.Drawing.Point(192, 40);
			this.UnicodeStringsButton.Name = "UnicodeStringsButton";
			this.UnicodeStringsButton.Size = new System.Drawing.Size(184, 24);
			this.UnicodeStringsButton.TabIndex = 24;
			this.UnicodeStringsButton.Tag = "4";
			this.UnicodeStringsButton.Text = "Unicode-Strings";
			this.UnicodeStringsButton.CheckedChanged += new System.EventHandler(this.UnicodeStringsButton_CheckedChanged);
			// 
			// StringsButton
			// 
			this.StringsButton.Location = new System.Drawing.Point(8, 40);
			this.StringsButton.Name = "StringsButton";
			this.StringsButton.Size = new System.Drawing.Size(184, 24);
			this.StringsButton.TabIndex = 23;
			this.StringsButton.Tag = "3";
			this.StringsButton.Text = "Strings";
			this.StringsButton.CheckedChanged += new System.EventHandler(this.StringsButton_CheckedChanged);
			// 
			// AnimationsButton
			// 
			this.AnimationsButton.Location = new System.Drawing.Point(192, 16);
			this.AnimationsButton.Name = "AnimationsButton";
			this.AnimationsButton.Size = new System.Drawing.Size(184, 24);
			this.AnimationsButton.TabIndex = 22;
			this.AnimationsButton.Tag = "2";
			this.AnimationsButton.Text = "Animations";
			this.AnimationsButton.CheckedChanged += new System.EventHandler(this.AnimationsButton_CheckedChanged);
			// 
			// ModelButton
			// 
			this.ModelButton.Location = new System.Drawing.Point(8, 16);
			this.ModelButton.Name = "ModelButton";
			this.ModelButton.Size = new System.Drawing.Size(184, 24);
			this.ModelButton.TabIndex = 21;
			this.ModelButton.Tag = "1";
			this.ModelButton.Text = "Model";
			this.ModelButton.CheckedChanged += new System.EventHandler(this.ModelButton_CheckedChanged);
			// 
			// Properties
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 373);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.OK);
			this.Controls.Add(this.HaloDirEdit);
			this.Controls.Add(this.label1);
			this.Name = "Properties";
			this.Text = "Tool++ Properties";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void SetDefault(int option)
		{
			if(option == 0)
				this.None.Checked = true;
			else if(option == 1)
				this.ModelButton.Checked = true;
			else if(option == 2)
				this.AnimationsButton.Checked = true;
			else if(option == 3)
				this.StringsButton.Checked = true;
			else if(option == 4)
				this.UnicodeStringsButton.Checked = true;
			else if(option == 5)
				this.BitmapsButton.Checked = true;
			else if(option == 6)
				this.BitmapButton.Checked = true;
			else if(option == 7)
				this.StructureButton.Checked = true;
			else if(option == 8)
				this.StructureLensButton.Checked = true;
			else if(option == 9)
				this.SBSButton.Checked = true;
			else if(option == 10)
				this.CollisionGeometryButton.Checked = true;
			else if(option == 11)
				this.PhysicsButton.Checked = true;
			else if(option == 12)
				this.SoundsButton.Checked = true;
			else if(option == 13)
				this.SoundsByTypeButton.Checked = true;
			else if(option == 14)
				this.BuildCacheFileButton.Checked = true;
			else if(option == 15)
				this.WindowsFontButton.Checked = true;
			else if(option == 16)
				this.HudMessagesButton.Checked = true;
			else if(option == 17)
				this.LightmapsButton.Checked = true;
			else if(option == 18)
				this.ProcessSoundsButton.Checked = true;
			else if(option == 19)
				this.MergeSceneryButton.Checked = true;
			else if(option == 20)
				this.ZMUButton.Checked = true;
			else if(option == 21)
				this.IDDButton.Checked = true;
			else
			{
				MessageBox.Show("#ERROR: Default Option was out of range.\nDefaulting to 'None'",
					"Whoops",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				this.None.Checked = true;
			}
		}

		private void OK_Click(object sender, System.EventArgs e)
		{
			MainForm.HaloDir = this.HaloDirEdit.Text;
			MainForm.DefaultSelection = Convert.ToInt32(this.DefaultOption);
			this.Close();
		}

		private void None_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.None.Tag;
		}

		private void ModelButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.ModelButton.Tag;
		}

		private void AnimationsButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.AnimationsButton.Tag;
		}

		private void StringsButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.StringsButton.Tag;
		}

		private void UnicodeStringsButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.UnicodeStringsButton.Tag;
		}

		private void BitmapsButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.BitmapsButton.Tag;
		}

		private void BitmapButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.BitmapButton.Tag;
		}

		private void StructureButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.StructureButton.Tag;
		}

		private void StructureLensButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.StructureLensButton.Tag;
		}

		private void SBSButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.SBSButton.Tag;
		}

		private void CollisionGeometryButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.CollisionGeometryButton.Tag;
		}

		private void PhysicsButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.PhysicsButton.Tag;
		}

		private void SoundsButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.SoundsButton.Tag;
		}

		private void SoundsByTypeButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.SoundsByTypeButton.Tag;
		}

		private void BuildCacheFileButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.BuildCacheFileButton.Tag;
		}

		private void WindowsFontButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.WindowsFontButton.Tag;
		}

		private void HudMessagesButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.HudMessagesButton.Tag;
		}

		private void LightmapsButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.LightmapsButton.Tag;
		}

		private void ProcessSoundsButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.ProcessSoundsButton.Tag;
		}

		private void MergeSceneryButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.MergeSceneryButton.Tag;
		}

		private void ZMUButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.ZMUButton.Tag;
		}

		private void IDDButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.DefaultOption = this.IDDButton.Tag;
		}
	}
}