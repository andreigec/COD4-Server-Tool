using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ANDREICSLIB;
using ANDREICSLIB.ClassExtras;
using ANDREICSLIB.Helpers;
using ANDREICSLIB.Licensing;
using Cod4ServerTool.ServiceReference1;
using Protocol;

namespace Cod4ServerTool
{
    public partial class view : Form
    {
        #region licensing
        private const String HelpString = "";

        private readonly String OtherText =
            @"©" + DateTime.Now.Year +
            @" Andrei Gec (http://www.andreigec.net)

Licensed under GNU LGPL (http://www.gnu.org/)

Zip Assets © SharpZipLib (http://www.sharpdevelop.net/OpenSource/SharpZipLib/)
";

        #endregion

        private readonly ListViewSorter lvs = new ListViewSorter();
        public String configlocation = "COD4STcfg.txt";
        public String gamelocation = "COD4STgameLocation.txt";

        public Protocol.Protocol protocolInstance = new Protocol.Protocol();
        public String serverlistfile = "COD4STserverList.txt";
        public Servers serversInstance = new Servers();
        private threads threadsInstance;

        public view()
        {
            InitializeComponent();
        }

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new view());
        }

        public static void resetDirectory()
        {
            String exedir = Environment.CommandLine;
            exedir = exedir.Remove(exedir.Length - 2, 2);

            exedir = exedir.Substring(0, exedir.LastIndexOf("\\"));
            exedir = exedir.Remove(0, 1);

            Environment.CurrentDirectory = exedir;
        }

        public void SaveConfig()
        {
            var savethese1 = new List<Control>();
            var savethese2 = new List<ToolStripItem>();
            var savethese3 = new List<Tuple<string, string>>();

            if (dontsave.Checked)
            {
                savethese2.Add(dontsave);
            }
            else
            {
                savethese2.Add(refreshServerOnSelect);
                savethese2.Add(nofilters);
                savethese2.Add(noservers);
                savethese2.Add(autoscan);

                if (nofilters.Checked == false)
                {
                    savethese1.AddRange(filterpanel.Controls.OfType<CheckBox>().Cast<Control>().ToList());
                }

                if (noservers.Checked == false)
                {
                    serversInstance.serialise(serverlistfile);
                }
            }

            if (dontsave.Checked || noservers.Checked)
            {
                if (File.Exists(serverlistfile))
                    File.Delete(serverlistfile);
            }

            FormConfigRestore.SaveConfig(this, configlocation, savethese1, savethese2, savethese3);
        }

        private void view_Load(object sender, EventArgs e)
        {
            serverview.ListViewItemSorter = lvs;
            //turn off thread safety
            CheckForIllegalCrossThreadCalls = false;

            threadsInstance = new threads(this);
            Application.DoEvents();

            //select the first item in the latency filter drop box
            latencydrop.SelectedIndex = 0;

            //make sure the current directory is the working directory
            resetDirectory();

            //get config
            FormConfigRestore.LoadConfig(this, configlocation);

            //get previous info
            serversInstance.deserialise(serverlistfile);

            //get all the columns
            serverview.Columns.Clear();
            foreach (var kvp in protocolInstance.getColumns())
            {
                serverview.Columns.Add(kvp.Key, kvp.Value).Name = kvp.Key;
            }

            //apply the loaded filters to all the servers
            allServersToServerView();

            Controller.ToolStripText(toolStripStatusLabel1, ref statusStrip1, "Ready");

            Licensing.LicensingForm(this, menuStrip1, HelpString, OtherText);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();

            if (threadsInstance != null)
                threadsInstance.killThreads = true;
        }


        private void serverview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serverview.SelectedItems.Count == 0)
            {
            }
            else
            {
                if (refreshServerOnSelect.Checked)
                {
                    foreach (ListViewItem LVI in serverview.SelectedItems)
                    {
                        Server s = serversInstance.masterServers[LVI.Name];
                        protocolInstance.updateServerInfo(s, Protocol.Protocol.basic);
                        Controller.UpdateServerInServerView(s, serverview);
                    }
                }
            }
        }

        private void rescanAllServers()
        {
            threadsInstance.updateAllServersThread(this, serverview, toolStripStatusLabel1, statusStrip1,
                                                   serversInstance, protocolInstance, false, false);

            allServersToServerView();
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            rescanAllServers();
        }

        private void mapcheck_CheckedChanged(object sender, EventArgs e)
        {
            if (mapcheck.Checked)
                mapdrop.Enabled = true;
            else
                mapdrop.Enabled = false;
        }

        private void latencycheck_CheckedChanged(object sender, EventArgs e)
        {
            if (latencycheck.Checked)
                latencydrop.Enabled = true;
            else
                latencydrop.Enabled = false;
        }

        private void filterbutton_Click(object sender, EventArgs e)
        {
            allServersToServerView();
        }

        private void gametypecheck_CheckedChanged(object sender, EventArgs e)
        {
            if (gametypecheck.Checked)
                gametypedrop.Enabled = true;
            else
                gametypedrop.Enabled = false;
        }


        private void iprightclickcontext_Opening(object sender, CancelEventArgs e)
        {
            refreshAllToolStripMenuItem.Enabled = true;
            if (serverview.SelectedItems.Count == 0)
            {
                refreshSelectedToolStripMenuItem.Enabled = false;
                favouriteselected.Enabled = false;
                unfavouriteselected.Enabled = false;
                deleteSelectedToolStripMenuItem.Enabled = false;
                viewServerInformationToolStripMenuItem.Enabled = false;
                return;
            }
            else
            {
                refreshSelectedToolStripMenuItem.Enabled = true;
                favouriteselected.Enabled = true;
                unfavouriteselected.Enabled = true;
                deleteSelectedToolStripMenuItem.Enabled = true;
                viewServerInformationToolStripMenuItem.Enabled = true;
            }

            if (serverview.SelectedItems.Count == 1)
                viewServerInformationToolStripMenuItem.Enabled = true;
            else
                viewServerInformationToolStripMenuItem.Enabled = false;

            int col = Controller.GetColumnIndex(serverview.Columns, Protocol.Protocol.favouriteSTR);
            bool allowUnFav = false;
            bool allowFav = false;

            foreach (ListViewItem LVI in serverview.SelectedItems)
            {
                if (LVI.SubItems[col].Text.Equals(true.ToString()))
                {
                    allowUnFav = true;
                }
                else
                    allowFav = true;
            }

            if (allowUnFav == false)
                unfavouriteselected.Enabled = false;
            else
                unfavouriteselected.Enabled = true;

            if (allowFav)
                favouriteselected.Enabled = true;
            else
                favouriteselected.Enabled = false;
        }


        private void favouriteselected_Click(object sender, EventArgs e)
        {
            Controller.UpdateFavourite(serverview, serversInstance, true);
        }

        private void unfavouriteselected_Click(object sender, EventArgs e)
        {
            Controller.UpdateFavourite(serverview, serversInstance, false);
        }

        private void refreshAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var T =
                new Thread(
                    () =>
                    threadsInstance.updateAllServersThread(this, serverview, toolStripStatusLabel1, statusStrip1,
                                                           serversInstance, protocolInstance, false, true));
            T.Start();
            T.Join();
        }

        private void refreshSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serverview.SelectedItems.Count == 1)
            {
                Controller.Refreshselected(serverview, protocolInstance, serversInstance);
            }
            else if (serverview.SelectedItems.Count > 1)
            {
                var T =
                    new Thread(
                        () =>
                        threadsInstance.updateAllServersThread(this, serverview, toolStripStatusLabel1, statusStrip1,
                                                               serversInstance, protocolInstance, true, true));
                T.Start();
            }
        }

        private void serverview_DoubleClick(object sender, EventArgs e)
        {
            if (serverview.SelectedItems.Count != 1)
                return;

            Controller.Connecttoserver(serverview.SelectedItems[0].Name, gamelocation);
            resetDirectory();
        }

        private void addSingleIPAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var SB = new getStringBox();
            SB.label1.Text = "Enter IP Address:Port";
            SB.ShowDialog();
            String ret = SB.returnvalue;
            if (ret == "")
                return;

            try
            {
                String ip = ret.Substring(0, ret.IndexOf(':'));
                String port = ret.Substring(ret.IndexOf(':') + 1);

                Server s = threadsInstance.addServerThread(ip, Int32.Parse(port), serversInstance);
                if (s == null)
                    return;

                String kkey = s.getServerIdentifier(Protocol.Protocol.ipAddressSTR, Protocol.Protocol.portSTR);

                try
                {
                    Controller.AddServerToServerView(s, serverview);
                    Controller.UpdateServerInServerView(s, serverview);
                    serverview.SelectedItems.Clear();
                    serverview.Items[kkey].Selected = true;
                    serverview.EnsureVisible(serverview.Items[kkey].Index);
                }
                catch
                {
                    serverview.SelectedItems.Clear();
                    serverview.Items[kkey].Selected = true;
                    serverview.EnsureVisible(serverview.Items[kkey].Index);
                }

                Controller.Refreshselected(serverview, protocolInstance, serversInstance);
            }
            catch
            {
                MessageBox.Show("Error, must be in the format ip:port");
            }
        }

        private void addServersFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            threadsInstance.killThreads = false;

            AsyncHelpers.RunSync(
                () =>
                    Controller.ServersFromUrl(toolStripStatusLabel1, statusStrip1, serversInstance, threadsInstance,
                        serverview,
                        this));

            resetDirectory();
        }

        private void addServersFromFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            threadsInstance.killThreads = false;

            Controller.ServersFromFile(toolStripStatusLabel1, statusStrip1, serversInstance, threadsInstance, serverview,
                                       this);

            resetDirectory();
        }


        private void viewServerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serverview.SelectedItems.Count != 1)
                return;

            var EI = new ExtraInfo(this);
            EI.ThisServer = serversInstance.masterServers[serverview.SelectedItems[0].Name];
            EI.Show();

            Controller.UpdateServerInServerView(EI.ThisServer, serverview);
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.DeleteSelected(serverview, serversInstance);
        }

        private void serverview_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ctrl+a
            if (e.KeyChar == 1)
            {
                serverview.SelectedItems.Clear();
                foreach (ListViewItem LVI in serverview.Items)
                {
                    LVI.Selected = true;
                }
            }
        }

        private void serverview_KeyDown(object sender, KeyEventArgs e)
        {
            //delete
            if (e.KeyValue == 46)
            {
                Controller.DeleteSelected(serverview, serversInstance);
            }
        }

        private void addServersFromCOD4MasterServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.MasterServerAdd(toolStripStatusLabel1, statusStrip1, serversInstance, threadsInstance);
            allServersToServerView();

            if (autoscan.Checked)
                rescanAllServers();
        }

        private void ResetColours(List<Control> controls, Color force = default(Color))
        {
            foreach (Control c in controls)
            {
                c.BackColor = force;
            }
        }

        private List<Control> GetAllCheckBoxes(Panel p)
        {
            return p.Controls.OfType<CheckBox>().Cast<Control>().ToList();
        }

        private void ContinueHit(Dictionary<Control, int> d, Control c)
        {
            if (d.ContainsKey(c) == false)
                d.Add(c, 0);

            d[c]++;
        }

        private void SetColours(Dictionary<Control, int> d, int count)
        {
            foreach (var kvp in d)
            {
                if (kvp.Value == count)
                    kvp.Key.BackColor = Color.IndianRed;
                else
                    kvp.Key.BackColor = Color.LightCoral;
            }
        }

        public void allServersToServerView()
        {
            ResetColours(GetAllCheckBoxes(filterpanel));

            serverview.Items.Clear();
            lvs.Enabled = false;

            var continueHit = new Dictionary<Control, int>();

            int count = 0;
            int max = serversInstance.masterServers.Values.Count;
            foreach (Server s in serversInstance.masterServers.Values)
            {
                Controller.ToolStripText(toolStripStatusLabel1, ref statusStrip1,
                                         "Adding server " + count + "/" + max.ToString());
                count++;
                if (inactivecheck.Checked == false && s.getVariable(Protocol.Protocol.pingSTR) == null)
                {
                    ContinueHit(continueHit, inactivecheck);
                    continue;
                }

                if (mapcheck.Checked &&
                    (s.getVariable(Protocol.Protocol.mapNameSTR) == null ||
                     s.getVariable(Protocol.Protocol.mapNameSTR) == mapdrop.Text == false))
                {
                    ContinueHit(continueHit, mapcheck);
                    continue;
                }

                if (latencycheck.Checked &&
                    (s.getVariable(Protocol.Protocol.pingSTR) == null ||
                     (Controller.GetLatencyDrop(latencydrop) < Int32.Parse(s.getVariable(Protocol.Protocol.pingSTR)))))
                {
                    ContinueHit(continueHit, latencycheck);
                    continue;
                }

                if (punkbustercheck.Checked == false &&
                    (s.getVariable(Protocol.Protocol.punkBusterSTR) == null ||
                     s.getVariable(Protocol.Protocol.punkBusterSTR) == "1"))
                {
                    ContinueHit(continueHit, punkbustercheck);
                    continue;
                }

                if (pingcheck.Checked == false &&
                    (s.getVariable(Protocol.Protocol.maxPingSTR) == null ||
                     s.getVariable(Protocol.Protocol.pingSTR) == null ||
                     (Int32.Parse(s.getVariable(Protocol.Protocol.pingSTR)) >
                      Int32.Parse(s.getVariable(Protocol.Protocol.maxPingSTR)))))
                {
                    ContinueHit(continueHit, pingcheck);
                    continue;
                }

                if (gametypecheck.Checked &&
                    (s.getVariable(Protocol.Protocol.gameTypeSTR) == null ||
                     gametypedrop.Text.Equals(s.getVariable(Protocol.Protocol.gameTypeSTR)) == false))
                {
                    ContinueHit(continueHit, gametypecheck);
                    continue;
                }

                if (s.getVariable(Protocol.Protocol.clientsSTR) != null &&
                    s.getVariable(Protocol.Protocol.maxClientsSTR) != null)
                {
                    if (allowfullcheck.Checked == false &&
                        Int32.Parse(s.getVariable(Protocol.Protocol.clientsSTR)) >=
                        Int32.Parse(s.getVariable(Protocol.Protocol.maxClientsSTR)))
                    {
                        ContinueHit(continueHit, allowfullcheck);
                        continue;
                    }

                    if (allowemptycheck.Checked == false &&
                        Int32.Parse(s.getVariable(Protocol.Protocol.clientsSTR)) <= 0)
                    {
                        ContinueHit(continueHit, allowemptycheck);
                        continue;
                    }
                }
                else if (allowemptycheck.Checked == false && s.getVariable(Protocol.Protocol.clientsSTR) == null)
                {
                    ContinueHit(continueHit, allowemptycheck);
                    continue;
                }

                if (favouritecheck.Checked == false &&
                    (s.getVariable(Protocol.Protocol.favouriteSTR) == null ||
                     Boolean.Parse(s.getVariable(Protocol.Protocol.favouriteSTR)) == false))
                {
                    ContinueHit(continueHit, favouritecheck);
                    continue;
                }


                Controller.AddServerToServerView(s, serverview);
            }
            ListViewExtras.AutoResize(serverview);
            Controller.ToolStripText(toolStripStatusLabel1, ref statusStrip1, "Ready");
            lvs.Enabled = true;
            SetColours(continueHit, serversInstance.masterServers.Values.Count);
            if (mapdrop.Items.Count > 0 && mapdrop.Text == "")
            {
                mapdrop.Text = mapdrop.Items[0].ToString();
            }

            if (gametypedrop.Items.Count > 0 && gametypedrop.Text == "")
            {
                gametypedrop.Text = gametypedrop.Items[0].ToString();
            }
        }

        private void serverview_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter.ColumnSort(lvs, serverview, e.Column);
        }

        private void scanselected_Click(object sender, EventArgs e)
        {
            threadsInstance.updateAllServersThread(this, serverview, toolStripStatusLabel1, statusStrip1,
                                                   serversInstance, protocolInstance, false, true);

            allServersToServerView();
        }
    }
}