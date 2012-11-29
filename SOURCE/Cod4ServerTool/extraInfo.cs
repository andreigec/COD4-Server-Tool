using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ANDREICSLIB;
using Protocol;

namespace Cod4ServerTool
{
    public partial class extraInfo : Form
    {
        private readonly view baseView;

        public Server thisServer;

        public extraInfo(view newBaseView)
        {
            InitializeComponent();
            baseView = newBaseView;
        }

        private void update(String[] split)
        {
            var ip = thisServer.getVariable(Protocol.Protocol.ipAddressSTR);
            var port = thisServer.getVariable(Protocol.Protocol.portSTR);
            var hostname = thisServer.getVariable(Protocol.Protocol.hostNameSTR);
            var mapname = thisServer.getVariable(Protocol.Protocol.mapNameSTR);
            var clients = thisServer.getVariable(Protocol.Protocol.clientsSTR);
            var maxclients = thisServer.getVariable(Protocol.Protocol.maxClientsSTR);
            var gametype = thisServer.getVariable(Protocol.Protocol.gameTypeSTR);
            var pb = thisServer.getVariable(Protocol.Protocol.punkBusterSTR);
            var maxping = thisServer.getVariable(Protocol.Protocol.maxPingSTR);
            var ping = thisServer.getVariable(Protocol.Protocol.pingSTR);


            extra.Items.Clear();
            serveriptext.Text =ip+Server.separator+port;
            hostnametext.Text = hostname;
            mapnametext.Text = mapname;

            clientstext.Text = string.IsNullOrEmpty(clients) ? "0" : clients;

            maxclientstext.Text = maxclients;
            gametypetext.Text = gametype;
            maxpingtext.Text = maxping;

            if (pb == "1")
                punkbustercheck.Checked = true;
            else
                punkbustercheck.Checked = false;

            latencytext.Text = ping;

            if (split == null)
                return;

            for (int a = 0; a < split.Length; a += 2)
            {
                String s = split[a];
                String s2 = split[a + 1];

                //check if players
                var r = new Regex(@"[0-9]+\n");
                Match M = r.Match(s2);
                if (M.Length != 0)
                {
                    string[] z = Regex.Split(s2, @"[0-9]+\n");
                    s2 = s2.Substring(0, s2.IndexOf('\n'));
                    var seps = new string[1];
                    seps[0] = "\n";
                    string[] players = z[1].Split(seps, StringSplitOptions.RemoveEmptyEntries);

                    if (players.Length == 0)
                        break;


                    playerlistview.Items.Clear();
                    foreach (String player in players)
                    {
                        var sepp = new string[1];
                        sepp[0] = "\"";
                        string[] sas = player.Split(sepp, StringSplitOptions.RemoveEmptyEntries);
                        MatchCollection mc = Regex.Matches(player, @"([0-9]+).+?([0-9]+)");


                        string arg1 = sas[0].Substring(0, sas[0].IndexOf(' '));
                        string arg2 = sas[0].Substring(sas[0].IndexOf(' ') + 1);

                        int arg1i = int.Parse(arg1);
                        int arg2i = int.Parse(arg2);

                        var LVI = new ListViewItem();

                        LVI.Text = Protocol.Protocol.sanatiseName(sas[1]);
                        LVI.SubItems.Add(arg1i.ToString());
                        LVI.SubItems.Add(arg2i.ToString());
                        playerlistview.Items.Add(LVI);
                    }
                }
                else
                {
                    var LVI = new ListViewItem();
                    LVI.Text = s;
                    LVI.SubItems.Add(s2);
                    extra.Items.Add(LVI);
                }
            }
        }

        private void updateServer()
        {
            string[] args = baseView.protocolInstance.updateServerInfo(thisServer, Protocol.Protocol.extended);

            update(args);
        }

        private void extraInfo_Load(object sender, EventArgs e)
        {
            updateServer();
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void connectbutton_Click(object sender, EventArgs e)
        {
            controller.connecttoserver(thisServer.getServerIdentifier(Protocol.Protocol.ipAddressSTR, Protocol.Protocol.portSTR),
                                       baseView.gamelocation);
            view.resetDirectory();
        }

        private void refreshbutton_Click(object sender, EventArgs e)
        {
            updateServer();
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (extra.SelectedItems.Count != 1)
                return;

            Clipboard.SetText(extra.SelectedItems[0].SubItems[1].Text);
        }

    }
}