using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Tool__
{
	public class SoundsByType : Wrapper
	{
		private Tool__.FolderReference DirectoryName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox Type;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox Round;
		private System.Windows.Forms.Button Run;

		public SoundsByType()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.DirectoryName = new Tool__.FolderReference();
			this.label1 = new System.Windows.Forms.Label();
			this.Type = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Round = new System.Windows.Forms.ComboBox();
			this.Run = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// DirectoryName
			// 
			this.DirectoryName.ControlName = "Directory-Name";
			this.DirectoryName.Field = "";
			this.DirectoryName.Info = "";
			this.DirectoryName.Location = new System.Drawing.Point(0, 0);
			this.DirectoryName.Name = "DirectoryName";
			this.DirectoryName.Size = new System.Drawing.Size(488, 24);
			this.DirectoryName.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Type";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Type
			// 
			this.Type.Items.AddRange(new object[] {
													  "projectile_impact",
													  "projectile_detonation",
													  "weapon_fire",
													  "weapon_ready",
													  "weapon_reload",
													  "weapon_empty",
													  "weapon_charge",
													  "weapon_overheat",
													  "weapon_idle",
													  "object_impacts",
													  "particle_impacts",
													  "slow_particle_impacts",
													  "unit_footsteps",
													  "unit_dialog",
													  "vehicle_collision",
													  "vehicle_engine",
													  "device_door",
													  "device_force_field",
													  "device_machinery",
													  "device_nature",
													  "device_computers",
													  "music",
													  "ambient_nature",
													  "ambient_machinery",
													  "ambient_computers",
													  "first_person_damage",
													  "scripted_dialog_player",
													  "scripted_effect",
													  "scripted_dialog_other",
													  "scripted_dialog_force_unspatialized",
													  "game_event"});
			this.Type.Location = new System.Drawing.Point(144, 24);
			this.Type.Name = "Type";
			this.Type.Size = new System.Drawing.Size(176, 21);
			this.Type.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Round to 64 samples?";
			// 
			// Round
			// 
			this.Round.Items.AddRange(new object[] {
													   "yes",
													   "no"});
			this.Round.Location = new System.Drawing.Point(144, 48);
			this.Round.Name = "Round";
			this.Round.Size = new System.Drawing.Size(176, 21);
			this.Round.TabIndex = 4;
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(208, 72);
			this.Run.Name = "Run";
			this.Run.TabIndex = 5;
			this.Run.Text = "Run Tool";
			this.Run.Click += new System.EventHandler(this.OnRun);
			// 
			// SoundsByType
			// 
			this.Controls.Add(this.Run);
			this.Controls.Add(this.Round);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Type);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DirectoryName);
			this.Name = "SoundsByType";
			this.Size = new System.Drawing.Size(496, 520);
			this.ResumeLayout(false);

		}
		#endregion

		private void OnRun(object sender, System.EventArgs e)
		{
			if( DirectoryName.Field == "")
				MessageBox.Show("#ERROR: Directory is 'NULL'",
					"Whoops",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			else
			{
				this.ConsoleOutput.Text = "";
				this.Cursor = Cursors.AppStarting;

				processCaller = new ProcessCaller(this);
				processCaller.StdErrReceived += new DataReceivedHandler(Write);
				processCaller.StdOutReceived += new DataReceivedHandler(Write);
				processCaller.Completed += new EventHandler(ProcessCompletedOrCanceled);
				processCaller.Cancelled += new EventHandler(ProcessCompletedOrCanceled);
				processCaller.FileName = MainForm.HaloDir + "tool.exe";
				processCaller.WorkingDirectory = MainForm.HaloDir;
				processCaller.Arguments = string.Format("sounds_by_type {0} {1} {2}", this.DirectoryName.Field, Convert.ToString(this.Type.SelectedItem), Convert.ToString(this.Round.SelectedItem));
				processCaller.Start();
			}
		}
	}
}