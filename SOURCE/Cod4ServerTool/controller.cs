using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ANDREICSLIB;
using Protocol;

namespace Cod4ServerTool
{
    public static class controller
    {
        private static void extractServers(Servers serversInstance, threads threadsInstance, byte[] data)
        {
            if (data == null)
                return;
            String datastr = Encoding.ASCII.GetString(data);

            var seps = new string[1];
            seps[0] = "\\";
            string[] ips = datastr.Split(seps, StringSplitOptions.RemoveEmptyEntries);

            foreach (String s in ips)
            {
                if (s.Length != 6)
                    continue;

                String ip = "";
                ip += ((int) s[0]).ToString() + ".";
                ip += ((int) s[1]).ToString() + ".";
                ip += ((int) s[2]).ToString() + ".";
                ip += ((int) s[3]).ToString();

                int port = (s[4])*256 + (s[5]);

                threadsInstance.addServerThread(ip, port, serversInstance);
            }
        }

        public static void masterServerAdd(ToolStripLabel toolStripLabel, StatusStrip SS, Servers serversInstance,
                                           threads threadsInstance)
        {
            //we need to increase the 15th byte to change the region
            var gs = Protocol.Protocol.cod4getservers;
            for (int region = 0; region < 6; region++)
            {
                toolStripText(toolStripLabel, ref SS, "Adding region:" + region + "/6");
                byte[] rec = NetUpdates.SendUDPPacketGetBlockingResponse(NetUpdates.GetIPFromHostname(Protocol.Protocol.MasterServer), 20810, gs);
                gs[15]++;

                extractServers(serversInstance, threadsInstance, rec);
            }

            toolStripText(toolStripLabel, ref SS, "Ready");
        }

        public static void toolStripText(ToolStripLabel toolStripLabel, ref StatusStrip SS, String text)
        {
            toolStripLabel.Text = text;
            SS.Invalidate();
            SS.Update();
        }


        public static Image getEmbeddedImage(String name)
        {
            return Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("Cod4ServerTool." + name));
        }

       public static int getLatencyDrop(ComboBox CB)
        {
            String s = CB.Text;
            return int.Parse(s.Remove(0, 1));
        }

        public static void addServerToServerView(Server s, ListView serverView)
        {
            string port = s.getVariable(Protocol.Protocol.portSTR);
            string ip = s.getVariable(Protocol.Protocol.ipAddressSTR);

            var LVI = new ListViewItem();
            String ipport = ip+Server.separator+port;
            LVI.Name = ipport;
            LVI.Text = s.getVariable(Protocol.Protocol.ipAddressSTR);

            for (int a = 1; a < serverView.Columns.Count; a++)
            {
                if (serverView.Columns[a].Name == Protocol.Protocol.portSTR)
                    LVI.SubItems.Add(port);
                else
                    LVI.SubItems.Add("");
            }
            serverView.Items.Add(LVI);
            updateServerInServerView(s, serverView);
        }

        public static int getColumnIndex(ListView.ColumnHeaderCollection CHC, String name)
        {
            int a = 0;
            foreach (ColumnHeader ch in CHC)
            {
                if (ch.Name == name)
                    return a;
                a++;
            }
            return -1;
        }
        
        public static void updateServerInServerView(Server s, ListView serverView)
        {
            String ipport = s.getServerIdentifier(Protocol.Protocol.ipAddressSTR, Protocol.Protocol.portSTR);
            int count = 0;
            foreach (ColumnHeader CH in serverView.Columns)
            {
                String val = s.getVariable(CH.Name);
                if (string.IsNullOrEmpty(val) == false)
                    serverView.Items[ipport].SubItems[count].Text = val;
                else
                    serverView.Items[ipport].SubItems[count].Text = "";
                count++;
            }
        }
        
        public static void updateFavourite(ListView serverView, Servers serversInstance, bool isFavourite)
        {
            foreach (ListViewItem LVI in serverView.SelectedItems)
            {
                Server s = serversInstance.masterServers[LVI.Name];
                s.setVariable(Protocol.Protocol.favouriteSTR, isFavourite.ToString());
                updateServerInServerView(s, serverView);
            }
        }
        
        //refresh selected items in listview
        public static void refreshselected(ListView serverView, Protocol.Protocol protocolInstance, Servers serversInstance)
        {
            Server serv = serversInstance.masterServers[serverView.SelectedItems[0].Name];

            protocolInstance.updateServerInfo(serv, Protocol.Protocol.basic);

            updateServerInServerView(serv, serverView);
        }
        
        public static void serversFromFile(ToolStripLabel toolStripLabel, StatusStrip SS, Servers serversInstance,
                                           threads threadsInstance, ListView serverView, view baseView)
        {
            var OFD = new OpenFileDialog();
            OFD.Title = "Select file to extract ip:ports from";
            OFD.ShowDialog();
            if (string.IsNullOrEmpty(OFD.FileName))
                return;

            var FS = new FileStream(OFD.FileName, FileMode.Open);
            var SR = new StreamReader(FS);

            String file = SR.ReadToEnd();
            SR.Close();
            FS.Close();

            threadsInstance.addServerCollectionThread(toolStripLabel, ref SS, file, serversInstance, threadsInstance);

            toolStripText(toolStripLabel, ref SS, "Ready");
            baseView.allServersToServerView();
        }

        public static void serversFromURL(ToolStripLabel toolStripLabel, StatusStrip SS, Servers serversInstance,
                                          threads threadsInstance, ListView serverView, view baseView)
        {
            var SB = new getStringBox();
            SB.label1.Text = "Enter URL to extract ip:ports from";
            SB.ShowDialog();
            String ret = SB.returnvalue;
            if (ret == "")
                return;

            toolStripText(toolStripLabel, ref SS, "Extracting Web Page Text");
            String page = NetUpdates.DownloadWebPage(ret);

            if (page == null)
            {
                MessageBox.Show("Not a valid webpage");
                return;
            }


            threadsInstance.addServerCollectionThread(toolStripLabel, ref SS, page, serversInstance, threadsInstance);


            toolStripText(toolStripLabel, ref SS, "Ready");
            baseView.allServersToServerView();
        }
       

        public static void changeDirectory(String exe)
        {
            String s = exe;
            s = s.Substring(0, s.LastIndexOf("\\"));

            Environment.CurrentDirectory = s;
        }

        public static void connecttoserver(String ipaddr, String gameLocation)
        {
            String codfile = gameLocation;
            if (File.Exists(codfile) == false)
            {
                var OFD = new OpenFileDialog();
                OFD.Multiselect = false;
                OFD.Title = "Select iw3mp.exe to run an ip address with";
                OFD.ShowDialog();
                view.resetDirectory();

                if (OFD.FileName == null || OFD.FileName.Length == 0)
                    return;

                var FS = new FileStream(codfile, FileMode.Create);
                var SW = new StreamWriter(FS);

                SW.WriteLine(OFD.FileName);

                SW.Close();
                FS.Close();
            }

            String codlocation = "";
            try
            {
                var FS = new FileStream(codfile, FileMode.Open);
                var SR = new StreamReader(FS);

                codlocation = SR.ReadToEnd();
                codlocation = codlocation.Substring(0, codlocation.IndexOf("iw3mp.exe") + 9);

                SR.Close();
                FS.Close();

                changeDirectory(codlocation);

                Process.Start(codlocation, "connect " + ipaddr);
            }
            catch
            {
                MessageBox.Show("An error has occurred starting:" + codlocation);
                File.Delete(codfile);
            }
        }

        public static void deleteSelected(ListView serverView, Servers serversInstance)
        {
            ListView.SelectedListViewItemCollection SLVIC = serverView.SelectedItems;

            int count = 0;
            String ips = "";
            foreach (ListViewItem LVI in SLVIC)
            {
                if (count > 10)
                {
                    ips += "...";
                    break;
                }
                count++;
                ips += LVI.Name + "\n";
            }


            DialogResult DR = MessageBox.Show("Are you sure you want to delete these ips?\n" + ips, "question",
                                              MessageBoxButtons.YesNo);
            if (DR == DialogResult.No)
                return;


            foreach (ListViewItem LVI in SLVIC)
            {
                serverView.Items.Remove(LVI);
                serversInstance.masterServers.Remove(LVI.Name);
            }
        }

        public static bool isInt(String s)
        {
            var R = new Regex("^[0-9]+$");
            return R.IsMatch(s);
        }
    }
}