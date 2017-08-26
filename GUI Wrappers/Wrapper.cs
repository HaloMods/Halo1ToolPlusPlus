using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace Tool__
{
	public class Wrapper : System.Windows.Forms.UserControl
	{
		protected System.Windows.Forms.RichTextBox ConsoleOutput;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Cancel;
		protected System.Windows.Forms.ToolTip ToolTips;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ConsoleInput;

		protected ProcessCaller processCaller;

		[DllImport("Winmm.dll")] public static extern 
			bool PlaySound( string szSound, IntPtr hMod, int flags );

		public Wrapper()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
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

		/// <summary>
		/// Handles the events of StdErrReceived and StdOutReceived.
		/// </summary>
		/// <remarks>
		/// If stderr were handled in a separate function, it could possibly
		/// be displayed in red in the richText box, but that is beyond 
		/// the scope of this demo.
		/// </remarks>
		protected virtual void Write(object sender, DataReceivedEventArgs e)
		{
			this.ConsoleOutput.AppendText(e.Text + Environment.NewLine);
			new Thread(new ThreadStart(ConsoleOutput.Refresh)).Start();
			//this.ConsoleOutput.Refresh();
		}

		/// <summary>
		/// Handles the events of processCompleted & processCanceled
		/// </summary>
		protected virtual void ProcessCompletedOrCanceled(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Default;
			PlaySound("\\WINNT\\Media\\tada.wav", IntPtr.Zero, 0x00020000 | 0x0000);
			MessageBox.Show(this.Parent, "Tool Command Completed!", "Kornman00 says:");
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.ConsoleOutput = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Cancel = new System.Windows.Forms.Button();
			this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.ConsoleInput = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// ConsoleOutput
			// 
			this.ConsoleOutput.DetectUrls = false;
			this.ConsoleOutput.Location = new System.Drawing.Point(0, 168);
			this.ConsoleOutput.Name = "ConsoleOutput";
			this.ConsoleOutput.Size = new System.Drawing.Size(496, 352);
			this.ConsoleOutput.TabIndex = 0;
			this.ConsoleOutput.TabStop = false;
			this.ConsoleOutput.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 144);
			this.label1.Name = "label1";
			this.label1.TabIndex = 1;
			this.label1.Text = "Tool Output:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Cancel
			// 
			this.Cancel.Location = new System.Drawing.Point(176, 144);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(128, 23);
			this.Cancel.TabIndex = 2;
			this.Cancel.Text = "Cancel Tool Command";
			this.Cancel.Click += new System.EventHandler(this.OnCancel);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Tool Input:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConsoleInput
			// 
			this.ConsoleInput.Location = new System.Drawing.Point(88, 120);
			this.ConsoleInput.Name = "ConsoleInput";
			this.ConsoleInput.Size = new System.Drawing.Size(336, 20);
			this.ConsoleInput.TabIndex = 4;
			this.ConsoleInput.Text = "";
			this.ConsoleInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnConsoleInputEnter);
			// 
			// Wrapper
			// 
			this.Controls.Add(this.ConsoleInput);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ConsoleOutput);
			this.Name = "Wrapper";
			this.Size = new System.Drawing.Size(496, 544);
			this.ResumeLayout(false);

		}
		#endregion

		private void OnCancel(object sender, System.EventArgs e)
		{
			if (processCaller != null)
			{
				processCaller.Cancel();
				this.Cursor = Cursors.Default;
			}
		}

		private void OnConsoleInputEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(ConsoleInput.ReadOnly == true || e.KeyChar != (char)0xD)
				return;

			processCaller.WriteStdIn(ConsoleInput.Text);
		}
	}
}
