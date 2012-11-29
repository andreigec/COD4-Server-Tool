using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cod4ServerTool
{
	partial class view
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(view));
            this.iprightclickcontext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewServerInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favouriteselected = new System.Windows.Forms.ToolStripMenuItem();
            this.unfavouriteselected = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSingleIPAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addServersFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addServersFromFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addServersFromCOD4MasterServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshServerOnSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.nofilters = new System.Windows.Forms.ToolStripMenuItem();
            this.noservers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dontsave = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.serverview = new System.Windows.Forms.ListView();
            this.searchbutton = new System.Windows.Forms.Button();
            this.filterbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mapcheck = new System.Windows.Forms.CheckBox();
            this.latencycheck = new System.Windows.Forms.CheckBox();
            this.latencydrop = new System.Windows.Forms.ComboBox();
            this.mapdrop = new System.Windows.Forms.ComboBox();
            this.punkbustercheck = new System.Windows.Forms.CheckBox();
            this.pingcheck = new System.Windows.Forms.CheckBox();
            this.gametypecheck = new System.Windows.Forms.CheckBox();
            this.gametypedrop = new System.Windows.Forms.ComboBox();
            this.allowfullcheck = new System.Windows.Forms.CheckBox();
            this.allowemptycheck = new System.Windows.Forms.CheckBox();
            this.inactivecheck = new System.Windows.Forms.CheckBox();
            this.favouritecheck = new System.Windows.Forms.CheckBox();
            this.filterpanel = new System.Windows.Forms.Panel();
            this.autoscan = new System.Windows.Forms.ToolStripMenuItem();
            this.scanselected = new System.Windows.Forms.Button();
            this.iprightclickcontext.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.filterpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // iprightclickcontext
            // 
            this.iprightclickcontext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewServerInformationToolStripMenuItem,
            this.favouriteselected,
            this.unfavouriteselected,
            this.refreshAllToolStripMenuItem,
            this.refreshSelectedToolStripMenuItem,
            this.addSingleIPAddressToolStripMenuItem,
            this.addServersFromFileToolStripMenuItem,
            this.addServersFromFileToolStripMenuItem1,
            this.addServersFromCOD4MasterServerToolStripMenuItem,
            this.deleteSelectedToolStripMenuItem});
            this.iprightclickcontext.Name = "iprightclickcontext";
            this.iprightclickcontext.Size = new System.Drawing.Size(276, 224);
            this.iprightclickcontext.Opening += new System.ComponentModel.CancelEventHandler(this.iprightclickcontext_Opening);
            // 
            // viewServerInformationToolStripMenuItem
            // 
            this.viewServerInformationToolStripMenuItem.Name = "viewServerInformationToolStripMenuItem";
            this.viewServerInformationToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.viewServerInformationToolStripMenuItem.Text = "View Server Information";
            this.viewServerInformationToolStripMenuItem.Click += new System.EventHandler(this.viewServerInformationToolStripMenuItem_Click);
            // 
            // favouriteselected
            // 
            this.favouriteselected.Name = "favouriteselected";
            this.favouriteselected.Size = new System.Drawing.Size(275, 22);
            this.favouriteselected.Text = "Favourite Selected";
            this.favouriteselected.Click += new System.EventHandler(this.favouriteselected_Click);
            // 
            // unfavouriteselected
            // 
            this.unfavouriteselected.Name = "unfavouriteselected";
            this.unfavouriteselected.Size = new System.Drawing.Size(275, 22);
            this.unfavouriteselected.Text = "Un-Favourite Selected";
            this.unfavouriteselected.Click += new System.EventHandler(this.unfavouriteselected_Click);
            // 
            // refreshAllToolStripMenuItem
            // 
            this.refreshAllToolStripMenuItem.Name = "refreshAllToolStripMenuItem";
            this.refreshAllToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.refreshAllToolStripMenuItem.Text = "Refresh All";
            this.refreshAllToolStripMenuItem.Click += new System.EventHandler(this.refreshAllToolStripMenuItem_Click);
            // 
            // refreshSelectedToolStripMenuItem
            // 
            this.refreshSelectedToolStripMenuItem.Name = "refreshSelectedToolStripMenuItem";
            this.refreshSelectedToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.refreshSelectedToolStripMenuItem.Text = "Refresh Selected";
            this.refreshSelectedToolStripMenuItem.Click += new System.EventHandler(this.refreshSelectedToolStripMenuItem_Click);
            // 
            // addSingleIPAddressToolStripMenuItem
            // 
            this.addSingleIPAddressToolStripMenuItem.Name = "addSingleIPAddressToolStripMenuItem";
            this.addSingleIPAddressToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.addSingleIPAddressToolStripMenuItem.Text = "Add Single IP Address";
            this.addSingleIPAddressToolStripMenuItem.Click += new System.EventHandler(this.addSingleIPAddressToolStripMenuItem_Click);
            // 
            // addServersFromFileToolStripMenuItem
            // 
            this.addServersFromFileToolStripMenuItem.Name = "addServersFromFileToolStripMenuItem";
            this.addServersFromFileToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.addServersFromFileToolStripMenuItem.Text = "Add Servers From URL";
            this.addServersFromFileToolStripMenuItem.Click += new System.EventHandler(this.addServersFromFileToolStripMenuItem_Click);
            // 
            // addServersFromFileToolStripMenuItem1
            // 
            this.addServersFromFileToolStripMenuItem1.Name = "addServersFromFileToolStripMenuItem1";
            this.addServersFromFileToolStripMenuItem1.Size = new System.Drawing.Size(275, 22);
            this.addServersFromFileToolStripMenuItem1.Text = "Add Servers From File";
            this.addServersFromFileToolStripMenuItem1.Click += new System.EventHandler(this.addServersFromFileToolStripMenuItem1_Click);
            // 
            // addServersFromCOD4MasterServerToolStripMenuItem
            // 
            this.addServersFromCOD4MasterServerToolStripMenuItem.Name = "addServersFromCOD4MasterServerToolStripMenuItem";
            this.addServersFromCOD4MasterServerToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.addServersFromCOD4MasterServerToolStripMenuItem.Text = "Add Servers From COD4 Master Server";
            this.addServersFromCOD4MasterServerToolStripMenuItem.Click += new System.EventHandler(this.addServersFromCOD4MasterServerToolStripMenuItem_Click);
            // 
            // deleteSelectedToolStripMenuItem
            // 
            this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.deleteSelectedToolStripMenuItem.Text = "Delete Selected";
            this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1385, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshServerOnSelect,
            this.autoscan,
            this.nofilters,
            this.noservers,
            this.toolStripSeparator1,
            this.dontsave});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // refreshServerOnSelect
            // 
            this.refreshServerOnSelect.CheckOnClick = true;
            this.refreshServerOnSelect.Name = "refreshServerOnSelect";
            this.refreshServerOnSelect.Size = new System.Drawing.Size(231, 22);
            this.refreshServerOnSelect.Text = "Refresh Server On Select";
            // 
            // nofilters
            // 
            this.nofilters.CheckOnClick = true;
            this.nofilters.Name = "nofilters";
            this.nofilters.Size = new System.Drawing.Size(231, 22);
            this.nofilters.Text = "Don\'t remember filter options";
            // 
            // noservers
            // 
            this.noservers.CheckOnClick = true;
            this.noservers.Name = "noservers";
            this.noservers.Size = new System.Drawing.Size(231, 22);
            this.noservers.Text = "Don\'t remember servers";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(228, 6);
            // 
            // dontsave
            // 
            this.dontsave.CheckOnClick = true;
            this.dontsave.Name = "dontsave";
            this.dontsave.Size = new System.Drawing.Size(231, 22);
            this.dontsave.Text = "Don\'t remember anything";
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.Silver;
            this.splitter2.Location = new System.Drawing.Point(200, 24);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(5, 501);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 525);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1385, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // serverview
            // 
            this.serverview.ContextMenuStrip = this.iprightclickcontext;
            this.serverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverview.FullRowSelect = true;
            this.serverview.GridLines = true;
            this.serverview.HideSelection = false;
            this.serverview.Location = new System.Drawing.Point(205, 24);
            this.serverview.Name = "serverview";
            this.serverview.Size = new System.Drawing.Size(1180, 501);
            this.serverview.TabIndex = 0;
            this.serverview.UseCompatibleStateImageBehavior = false;
            this.serverview.View = System.Windows.Forms.View.Details;
            this.serverview.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.serverview_ColumnClick);
            this.serverview.SelectedIndexChanged += new System.EventHandler(this.serverview_SelectedIndexChanged);
            this.serverview.DoubleClick += new System.EventHandler(this.serverview_DoubleClick);
            this.serverview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.serverview_KeyDown);
            this.serverview.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.serverview_KeyPress);
            // 
            // searchbutton
            // 
            this.searchbutton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchbutton.Location = new System.Drawing.Point(0, 478);
            this.searchbutton.Name = "searchbutton";
            this.searchbutton.Size = new System.Drawing.Size(200, 23);
            this.searchbutton.TabIndex = 5;
            this.searchbutton.Text = "Rescan All Servers";
            this.searchbutton.UseVisualStyleBackColor = true;
            this.searchbutton.Click += new System.EventHandler(this.searchbutton_Click);
            // 
            // filterbutton
            // 
            this.filterbutton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.filterbutton.Location = new System.Drawing.Point(0, 432);
            this.filterbutton.Name = "filterbutton";
            this.filterbutton.Size = new System.Drawing.Size(200, 23);
            this.filterbutton.TabIndex = 7;
            this.filterbutton.Text = "Apply Filter";
            this.filterbutton.UseVisualStyleBackColor = true;
            this.filterbutton.Click += new System.EventHandler(this.filterbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Display Filters";
            // 
            // mapcheck
            // 
            this.mapcheck.AutoSize = true;
            this.mapcheck.Location = new System.Drawing.Point(3, 38);
            this.mapcheck.Name = "mapcheck";
            this.mapcheck.Size = new System.Drawing.Size(47, 17);
            this.mapcheck.TabIndex = 1;
            this.mapcheck.Text = "Map";
            this.mapcheck.UseVisualStyleBackColor = true;
            this.mapcheck.CheckedChanged += new System.EventHandler(this.mapcheck_CheckedChanged);
            // 
            // latencycheck
            // 
            this.latencycheck.AutoSize = true;
            this.latencycheck.Location = new System.Drawing.Point(3, 64);
            this.latencycheck.Name = "latencycheck";
            this.latencycheck.Size = new System.Drawing.Size(64, 17);
            this.latencycheck.TabIndex = 3;
            this.latencycheck.Text = "Latency";
            this.latencycheck.UseVisualStyleBackColor = true;
            this.latencycheck.CheckedChanged += new System.EventHandler(this.latencycheck_CheckedChanged);
            // 
            // latencydrop
            // 
            this.latencydrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.latencydrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.latencydrop.Enabled = false;
            this.latencydrop.FormattingEnabled = true;
            this.latencydrop.Items.AddRange(new object[] {
            "<100",
            "<200",
            "<300",
            "<400",
            "<500"});
            this.latencydrop.Location = new System.Drawing.Point(92, 62);
            this.latencydrop.Name = "latencydrop";
            this.latencydrop.Size = new System.Drawing.Size(102, 21);
            this.latencydrop.TabIndex = 4;
            // 
            // mapdrop
            // 
            this.mapdrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapdrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapdrop.Enabled = false;
            this.mapdrop.FormattingEnabled = true;
            this.mapdrop.Items.AddRange(new object[] {
            "mp_backlot",
            "mp_bloc",
            "mp_bog",
            "mp_broadcast",
            "mp_carentan",
            "mp_cargoship",
            "mp_citystreets",
            "mp_convoy",
            "mp_countdown",
            "mp_crash",
            "mp_crash_snow",
            "mp_creek",
            "mp_crossfile",
            "mp_farm",
            "mp_killhouse",
            "mp_overgrown",
            "mp_pipeline",
            "mp_shipment",
            "mp_showdown",
            "mp_strike",
            "mp_vacant",
            "mp_wintercrash"});
            this.mapdrop.Location = new System.Drawing.Point(56, 34);
            this.mapdrop.MaxLength = 20;
            this.mapdrop.Name = "mapdrop";
            this.mapdrop.Size = new System.Drawing.Size(138, 21);
            this.mapdrop.TabIndex = 6;
            // 
            // punkbustercheck
            // 
            this.punkbustercheck.AutoSize = true;
            this.punkbustercheck.Checked = true;
            this.punkbustercheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.punkbustercheck.Location = new System.Drawing.Point(3, 147);
            this.punkbustercheck.Name = "punkbustercheck";
            this.punkbustercheck.Size = new System.Drawing.Size(108, 17);
            this.punkbustercheck.TabIndex = 8;
            this.punkbustercheck.Text = "Allow Punkbuster";
            this.punkbustercheck.UseVisualStyleBackColor = true;
            // 
            // pingcheck
            // 
            this.pingcheck.AutoSize = true;
            this.pingcheck.Checked = true;
            this.pingcheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pingcheck.Location = new System.Drawing.Point(3, 170);
            this.pingcheck.Name = "pingcheck";
            this.pingcheck.Size = new System.Drawing.Size(128, 17);
            this.pingcheck.TabIndex = 9;
            this.pingcheck.Text = "Allow Ping>=MaxPing";
            this.pingcheck.UseVisualStyleBackColor = true;
            // 
            // gametypecheck
            // 
            this.gametypecheck.AutoSize = true;
            this.gametypecheck.Location = new System.Drawing.Point(3, 91);
            this.gametypecheck.Name = "gametypecheck";
            this.gametypecheck.Size = new System.Drawing.Size(81, 17);
            this.gametypecheck.TabIndex = 10;
            this.gametypecheck.Text = "Game Type";
            this.gametypecheck.UseVisualStyleBackColor = true;
            this.gametypecheck.CheckedChanged += new System.EventHandler(this.gametypecheck_CheckedChanged);
            // 
            // gametypedrop
            // 
            this.gametypedrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gametypedrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gametypedrop.Enabled = false;
            this.gametypedrop.FormattingEnabled = true;
            this.gametypedrop.Items.AddRange(new object[] {
            "sd",
            "war",
            "sab",
            "dom",
            "tdm",
            "dm",
            "koth",
            "ctf"});
            this.gametypedrop.Location = new System.Drawing.Point(92, 89);
            this.gametypedrop.Name = "gametypedrop";
            this.gametypedrop.Size = new System.Drawing.Size(102, 21);
            this.gametypedrop.TabIndex = 11;
            // 
            // allowfullcheck
            // 
            this.allowfullcheck.AutoSize = true;
            this.allowfullcheck.Checked = true;
            this.allowfullcheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowfullcheck.Location = new System.Drawing.Point(3, 193);
            this.allowfullcheck.Name = "allowfullcheck";
            this.allowfullcheck.Size = new System.Drawing.Size(109, 17);
            this.allowfullcheck.TabIndex = 12;
            this.allowfullcheck.Text = "Allow Full Servers";
            this.allowfullcheck.UseVisualStyleBackColor = true;
            // 
            // allowemptycheck
            // 
            this.allowemptycheck.AutoSize = true;
            this.allowemptycheck.Checked = true;
            this.allowemptycheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowemptycheck.Location = new System.Drawing.Point(3, 216);
            this.allowemptycheck.Name = "allowemptycheck";
            this.allowemptycheck.Size = new System.Drawing.Size(122, 17);
            this.allowemptycheck.TabIndex = 13;
            this.allowemptycheck.Text = "Allow Empty Servers";
            this.allowemptycheck.UseVisualStyleBackColor = true;
            // 
            // inactivecheck
            // 
            this.inactivecheck.AutoSize = true;
            this.inactivecheck.Location = new System.Drawing.Point(3, 239);
            this.inactivecheck.Name = "inactivecheck";
            this.inactivecheck.Size = new System.Drawing.Size(92, 17);
            this.inactivecheck.TabIndex = 14;
            this.inactivecheck.Text = "Allow Inactive";
            this.inactivecheck.UseVisualStyleBackColor = true;
            // 
            // favouritecheck
            // 
            this.favouritecheck.AutoSize = true;
            this.favouritecheck.Checked = true;
            this.favouritecheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.favouritecheck.Location = new System.Drawing.Point(3, 262);
            this.favouritecheck.Name = "favouritecheck";
            this.favouritecheck.Size = new System.Drawing.Size(127, 17);
            this.favouritecheck.TabIndex = 15;
            this.favouritecheck.Text = "Allow Non-Favourited";
            this.favouritecheck.UseVisualStyleBackColor = true;
            // 
            // filterpanel
            // 
            this.filterpanel.Controls.Add(this.favouritecheck);
            this.filterpanel.Controls.Add(this.inactivecheck);
            this.filterpanel.Controls.Add(this.allowemptycheck);
            this.filterpanel.Controls.Add(this.allowfullcheck);
            this.filterpanel.Controls.Add(this.gametypedrop);
            this.filterpanel.Controls.Add(this.gametypecheck);
            this.filterpanel.Controls.Add(this.pingcheck);
            this.filterpanel.Controls.Add(this.punkbustercheck);
            this.filterpanel.Controls.Add(this.mapdrop);
            this.filterpanel.Controls.Add(this.latencydrop);
            this.filterpanel.Controls.Add(this.latencycheck);
            this.filterpanel.Controls.Add(this.mapcheck);
            this.filterpanel.Controls.Add(this.label1);
            this.filterpanel.Controls.Add(this.filterbutton);
            this.filterpanel.Controls.Add(this.scanselected);
            this.filterpanel.Controls.Add(this.searchbutton);
            this.filterpanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.filterpanel.Location = new System.Drawing.Point(0, 24);
            this.filterpanel.Name = "filterpanel";
            this.filterpanel.Size = new System.Drawing.Size(200, 501);
            this.filterpanel.TabIndex = 8;
            // 
            // autoscan
            // 
            this.autoscan.Checked = true;
            this.autoscan.CheckOnClick = true;
            this.autoscan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoscan.Name = "autoscan";
            this.autoscan.Size = new System.Drawing.Size(231, 22);
            this.autoscan.Text = "Auto scan servers on add";
            // 
            // scanselected
            // 
            this.scanselected.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.scanselected.Location = new System.Drawing.Point(0, 455);
            this.scanselected.Name = "scanselected";
            this.scanselected.Size = new System.Drawing.Size(200, 23);
            this.scanselected.TabIndex = 16;
            this.scanselected.Text = "Rescan Selected Servers";
            this.scanselected.UseVisualStyleBackColor = true;
            this.scanselected.Click += new System.EventHandler(this.scanselected_Click);
            // 
            // view
            // 
            this.ClientSize = new System.Drawing.Size(1385, 547);
            this.Controls.Add(this.serverview);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.filterpanel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "view";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COD4 Server Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.view_Load);
            this.iprightclickcontext.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.filterpanel.ResumeLayout(false);
            this.filterpanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem exitToolStripMenuItem;
		private Splitter splitter2;
		private ContextMenuStrip iprightclickcontext;
		private ToolStripMenuItem favouriteselected;
		private ToolStripMenuItem unfavouriteselected;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel toolStripStatusLabel1;
		private ToolStripMenuItem refreshAllToolStripMenuItem;
		private ToolStripMenuItem refreshSelectedToolStripMenuItem;
		private ToolStripMenuItem addSingleIPAddressToolStripMenuItem;
		private ToolStripMenuItem addServersFromFileToolStripMenuItem;
		private ToolStripMenuItem viewServerInformationToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
		private ToolStripMenuItem refreshServerOnSelect;
		private ListView serverview;
		private ToolStripMenuItem deleteSelectedToolStripMenuItem;
		private ToolStripMenuItem addServersFromCOD4MasterServerToolStripMenuItem;
		private ToolStripMenuItem addServersFromFileToolStripMenuItem1;
		private Button searchbutton;
		private Button filterbutton;
		private Label label1;
		private CheckBox mapcheck;
		private CheckBox latencycheck;
		private ComboBox latencydrop;
		private ComboBox mapdrop;
		private CheckBox punkbustercheck;
		private CheckBox pingcheck;
		private CheckBox gametypecheck;
		private ComboBox gametypedrop;
		private CheckBox allowfullcheck;
		private CheckBox allowemptycheck;
		private CheckBox inactivecheck;
		private CheckBox favouritecheck;
        private Panel filterpanel;
        private ToolStripMenuItem noservers;
        private ToolStripMenuItem nofilters;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem dontsave;
        private ToolStripMenuItem autoscan;
        private Button scanselected;
    }
}

