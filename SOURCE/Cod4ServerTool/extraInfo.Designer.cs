namespace Cod4ServerTool
{
	partial class extraInfo
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(extraInfo));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.hostnametext = new System.Windows.Forms.TextBox();
			this.serveriptext = new System.Windows.Forms.TextBox();
			this.refreshbutton = new System.Windows.Forms.Button();
			this.connectbutton = new System.Windows.Forms.Button();
			this.closebutton = new System.Windows.Forms.Button();
			this.mapnametext = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.clientstext = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.maxclientstext = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.gametypetext = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.maxpingtext = new System.Windows.Forms.TextBox();
			this.punkbustercheck = new System.Windows.Forms.CheckBox();
			this.playerlistview = new System.Windows.Forms.ListView();
			this.namecol = new System.Windows.Forms.ColumnHeader();
			this.scorecol = new System.Windows.Forms.ColumnHeader();
			this.playerlatencycol = new System.Windows.Forms.ColumnHeader();
			this.panel1 = new System.Windows.Forms.Panel();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.latencytext = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.extra = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.panel2 = new System.Windows.Forms.Panel();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Server Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(21, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Server IP:";
			// 
			// hostnametext
			// 
			this.hostnametext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.hostnametext.Location = new System.Drawing.Point(81, 6);
			this.hostnametext.Name = "hostnametext";
			this.hostnametext.ReadOnly = true;
			this.hostnametext.Size = new System.Drawing.Size(198, 20);
			this.hostnametext.TabIndex = 2;
			// 
			// serveriptext
			// 
			this.serveriptext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.serveriptext.Location = new System.Drawing.Point(81, 35);
			this.serveriptext.Name = "serveriptext";
			this.serveriptext.ReadOnly = true;
			this.serveriptext.Size = new System.Drawing.Size(198, 20);
			this.serveriptext.TabIndex = 3;
			// 
			// refreshbutton
			// 
			this.refreshbutton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.refreshbutton.Location = new System.Drawing.Point(148, 0);
			this.refreshbutton.Name = "refreshbutton";
			this.refreshbutton.Size = new System.Drawing.Size(364, 29);
			this.refreshbutton.TabIndex = 4;
			this.refreshbutton.Text = "Refresh Info";
			this.refreshbutton.UseVisualStyleBackColor = true;
			this.refreshbutton.Click += new System.EventHandler(this.refreshbutton_Click);
			// 
			// connectbutton
			// 
			this.connectbutton.Dock = System.Windows.Forms.DockStyle.Left;
			this.connectbutton.Location = new System.Drawing.Point(0, 0);
			this.connectbutton.Name = "connectbutton";
			this.connectbutton.Size = new System.Drawing.Size(148, 29);
			this.connectbutton.TabIndex = 5;
			this.connectbutton.Text = "Connect To Server";
			this.connectbutton.UseVisualStyleBackColor = true;
			this.connectbutton.Click += new System.EventHandler(this.connectbutton_Click);
			// 
			// closebutton
			// 
			this.closebutton.Dock = System.Windows.Forms.DockStyle.Right;
			this.closebutton.Location = new System.Drawing.Point(512, 0);
			this.closebutton.Name = "closebutton";
			this.closebutton.Size = new System.Drawing.Size(75, 29);
			this.closebutton.TabIndex = 6;
			this.closebutton.Text = "Close";
			this.closebutton.UseVisualStyleBackColor = true;
			this.closebutton.Click += new System.EventHandler(this.closebutton_Click);
			// 
			// mapnametext
			// 
			this.mapnametext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mapnametext.Location = new System.Drawing.Point(81, 66);
			this.mapnametext.Name = "mapnametext";
			this.mapnametext.ReadOnly = true;
			this.mapnametext.Size = new System.Drawing.Size(198, 20);
			this.mapnametext.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Map Name:";
			// 
			// clientstext
			// 
			this.clientstext.Location = new System.Drawing.Point(81, 92);
			this.clientstext.Name = "clientstext";
			this.clientstext.ReadOnly = true;
			this.clientstext.Size = new System.Drawing.Size(57, 20);
			this.clientstext.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(34, 95);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Clients:";
			// 
			// maxclientstext
			// 
			this.maxclientstext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.maxclientstext.Location = new System.Drawing.Point(184, 92);
			this.maxclientstext.Name = "maxclientstext";
			this.maxclientstext.ReadOnly = true;
			this.maxclientstext.Size = new System.Drawing.Size(95, 20);
			this.maxclientstext.TabIndex = 12;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(154, 95);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(12, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "/";
			// 
			// gametypetext
			// 
			this.gametypetext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gametypetext.Location = new System.Drawing.Point(81, 118);
			this.gametypetext.Name = "gametypetext";
			this.gametypetext.ReadOnly = true;
			this.gametypetext.Size = new System.Drawing.Size(198, 20);
			this.gametypetext.TabIndex = 14;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 121);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "GameType:";
			// 
			// maxpingtext
			// 
			this.maxpingtext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.maxpingtext.Location = new System.Drawing.Point(184, 142);
			this.maxpingtext.Name = "maxpingtext";
			this.maxpingtext.ReadOnly = true;
			this.maxpingtext.Size = new System.Drawing.Size(95, 20);
			this.maxpingtext.TabIndex = 16;
			// 
			// punkbustercheck
			// 
			this.punkbustercheck.AutoCheck = false;
			this.punkbustercheck.AutoSize = true;
			this.punkbustercheck.Enabled = false;
			this.punkbustercheck.Location = new System.Drawing.Point(81, 168);
			this.punkbustercheck.Name = "punkbustercheck";
			this.punkbustercheck.Size = new System.Drawing.Size(88, 17);
			this.punkbustercheck.TabIndex = 17;
			this.punkbustercheck.Text = "Punkbuster?";
			this.punkbustercheck.UseVisualStyleBackColor = true;
			// 
			// playerlistview
			// 
			this.playerlistview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.namecol,
            this.scorecol,
            this.playerlatencycol});
			this.playerlistview.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.playerlistview.FullRowSelect = true;
			this.playerlistview.Location = new System.Drawing.Point(0, 197);
			this.playerlistview.Name = "playerlistview";
			this.playerlistview.Size = new System.Drawing.Size(282, 248);
			this.playerlistview.TabIndex = 18;
			this.playerlistview.UseCompatibleStateImageBehavior = false;
			this.playerlistview.View = System.Windows.Forms.View.Details;
			// 
			// namecol
			// 
			this.namecol.Text = "Player Name";
			this.namecol.Width = 91;
			// 
			// scorecol
			// 
			this.scorecol.Text = "Score";
			// 
			// playerlatencycol
			// 
			this.playerlatencycol.Text = "Player Latency";
			this.playerlatencycol.Width = 117;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.refreshbutton);
			this.panel1.Controls.Add(this.connectbutton);
			this.panel1.Controls.Add(this.closebutton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 445);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(587, 29);
			this.panel1.TabIndex = 19;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 474);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(587, 22);
			this.statusStrip1.TabIndex = 21;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// latencytext
			// 
			this.latencytext.Location = new System.Drawing.Point(81, 142);
			this.latencytext.Name = "latencytext";
			this.latencytext.ReadOnly = true;
			this.latencytext.Size = new System.Drawing.Size(57, 20);
			this.latencytext.TabIndex = 23;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(26, 149);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 13);
			this.label8.TabIndex = 22;
			this.label8.Text = "Latency:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(154, 145);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(12, 13);
			this.label9.TabIndex = 24;
			this.label9.Text = "/";
			// 
			// extra
			// 
			this.extra.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.extra.Dock = System.Windows.Forms.DockStyle.Fill;
			this.extra.Location = new System.Drawing.Point(0, 0);
			this.extra.Name = "extra";
			this.extra.Size = new System.Drawing.Size(302, 445);
			this.extra.TabIndex = 25;
			this.extra.UseCompatibleStateImageBehavior = false;
			this.extra.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 139;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Value";
			this.columnHeader2.Width = 131;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.splitter2);
			this.panel2.Controls.Add(this.playerlistview);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.label9);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.latencytext);
			this.panel2.Controls.Add(this.hostnametext);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.serveriptext);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.mapnametext);
			this.panel2.Controls.Add(this.punkbustercheck);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.maxpingtext);
			this.panel2.Controls.Add(this.clientstext);
			this.panel2.Controls.Add(this.gametypetext);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Controls.Add(this.maxclientstext);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(282, 445);
			this.panel2.TabIndex = 26;
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter2.Location = new System.Drawing.Point(0, 194);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(282, 3);
			this.splitter2.TabIndex = 25;
			this.splitter2.TabStop = false;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(282, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 445);
			this.splitter1.TabIndex = 27;
			this.splitter1.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.extra);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(285, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(302, 445);
			this.panel3.TabIndex = 28;
			// 
			// extraInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(587, 496);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "extraInfo";
			this.Text = "Server Information";
			this.Load += new System.EventHandler(this.extraInfo_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hostnametext;
		private System.Windows.Forms.TextBox serveriptext;
		private System.Windows.Forms.Button refreshbutton;
		private System.Windows.Forms.Button connectbutton;
		private System.Windows.Forms.Button closebutton;
		private System.Windows.Forms.TextBox mapnametext;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox clientstext;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox maxclientstext;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox gametypetext;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox maxpingtext;
		private System.Windows.Forms.CheckBox punkbustercheck;
		private System.Windows.Forms.ListView playerlistview;
		private System.Windows.Forms.ColumnHeader namecol;
		private System.Windows.Forms.ColumnHeader scorecol;
		private System.Windows.Forms.ColumnHeader playerlatencycol;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TextBox latencytext;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ListView extra;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Splitter splitter2;
	}
}