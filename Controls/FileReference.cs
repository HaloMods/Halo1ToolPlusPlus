using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Tool__
{
	public class FileReference : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Button browse;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.TextBox field;
		public System.Windows.Forms.ComboBox tag;
		private System.Windows.Forms.Label name;
		public System.Windows.Forms.OpenFileDialog SelectFile;
		private System.ComponentModel.IContainer components;

		#region Control Name
		public string ControlName
		{
			get { return this.name.Text; }
			set { this.name.Text = value; }
		}
		#endregion

		#region Field
		public string Field
		{
			get { return this.field.Text; }
			set { this.field.Text = value; }
		}
		#endregion

		#region Tag Group
		public string TagType
		{
			get { return this.tag.Text; }
			set { this.tag.Text = value; }
		}
		#endregion

		#region No Tag Group
		public bool NoTagType
		{
			get { return this.tag.Enabled; }
			set { this.tag.Enabled = value; }
		}
		#endregion

		#region Filter Text
		public string FilterText
		{
			get { return this.SelectFile.Filter; }
			set { this.SelectFile.Filter = value; }
		}
		#endregion

		#region Initial Dir
		public string InitialDir
		{
			get { return this.SelectFile.InitialDirectory; }
			set { this.SelectFile.InitialDirectory = value;}
		}
		#endregion

		#region Info
		private string info;
		public string Info
		{
			get { return this.info; }
			set 
			{ 
				this.info = value;
				this.SetTips(value); 
			}
		}

		public void SetTips(string tips)
		{
			toolTip.SetToolTip(this, tips);
			toolTip.SetToolTip(this.name, tips);
			toolTip.SetToolTip(this.field, tips);
			toolTip.SetToolTip(this.tag, tips);
		}
		#endregion

		public FileReference()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

            this.Field = "";
			this.Info = "";
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.browse = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.field = new System.Windows.Forms.TextBox();
			this.tag = new System.Windows.Forms.ComboBox();
			this.name = new System.Windows.Forms.Label();
			this.SelectFile = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// browse
			// 
			this.browse.Location = new System.Drawing.Point(464, 0);
			this.browse.Name = "browse";
			this.browse.Size = new System.Drawing.Size(24, 23);
			this.browse.TabIndex = 8;
			this.browse.Text = "...";
			this.browse.Click += new System.EventHandler(this.OnBrowse);
			// 
			// field
			// 
			this.field.Location = new System.Drawing.Point(280, 0);
			this.field.Name = "field";
			this.field.Size = new System.Drawing.Size(176, 20);
			this.field.TabIndex = 7;
			this.field.Text = "";
			// 
			// tag
			// 
			this.tag.Location = new System.Drawing.Point(144, 0);
			this.tag.Name = "tag";
			this.tag.Size = new System.Drawing.Size(121, 21);
			this.tag.Sorted = true;
			this.tag.TabIndex = 6;
			// 
			// name
			// 
			this.name.Location = new System.Drawing.Point(0, 0);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(140, 24);
			this.name.TabIndex = 5;
			this.name.Text = "tag reference";
			this.name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SelectFile
			// 
			this.SelectFile.InitialDirectory = "data\\";
			this.SelectFile.Title = "Tag Reference";
			// 
			// FileReference
			// 
			this.Controls.Add(this.field);
			this.Controls.Add(this.tag);
			this.Controls.Add(this.name);
			this.Controls.Add(this.browse);
			this.Name = "FileReference";
			this.Size = new System.Drawing.Size(488, 24);
			this.ResumeLayout(false);

		}
		#endregion

		private void OnBrowse(object sender, System.EventArgs e)
		{
			if(SelectFile.ShowDialog() == DialogResult.OK)
			{
				this.Field = SelectFile.FileName;
				this.Field = this.Field.Remove(0, MainForm.HaloDir.Length + 5);
				this.Field = this.Field.Replace(this.TagType.ToLower(), "");
			}
		}
	}
}