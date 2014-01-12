using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ANDREICSLIB;
using Protocol;

namespace Cod4ServerTool
{
    public static class Controller
    {
        private static void ExtractServers(Servers serversInstance, threads threadsInstance, byte[] data)
        {
            if (data == null)
                return;
            String datastr = Encoding.ASCII.GetString(data);

            var seps = new string[1];
            seps[0] = "\\";
            string[] ips = datastr.Split(seps, StringSplitOptions.RemoveEmptyEntries);

            foreach (var s in ips)
            {
                if (s.Length != 6)
                    continue;

                String ip = "";
                ip += ((int)s[0]).ToString(CultureInfo.InvariantCulture) + ".";
                ip += ((int)s[1]).ToString(CultureInfo.InvariantCulture) + ".";
                ip += ((int)s[2]).ToString(CultureInfo.InvariantCulture) + ".";
                ip += ((int)s[3]).ToString(CultureInfo.InvariantCulture);

                int port = (s[4]) * 256 + (s[5]);

                threadsInstance.addServerThread(ip, port, serversInstance);
            }
        }

        public static void MasterServerAdd(ToolStripLabel toolStripLabel, StatusStrip SS, Servers serversInstance,
                                           threads threadsInstance)
        {
            //we need to increase the 15th byte to change the region
            byte[] gs = Protocol.Protocol.cod4getservers;
            for (int region = 0; region < 6; region++)
            {
                ToolStripText(toolStripLabel, ref SS, "Adding region:" + region + "/6");
                byte[] rec =
                    Networking.SendUDPPacketGetBlockingResponse(
                        NetExtras.HostnameToIP(Protocol.Protocol.MasterServer), 20810, gs);
                gs[15]++;

                ExtractServers(serversInstance, threadsInstance, rec);
            }

            ToolStripText(toolStripLabel, ref SS, "Ready");
        }

        public static void ToolStripText(ToolStripLabel toolStripLabel, ref StatusStrip SS, String text)
        {
            toolStripLabel.Text = text;
            SS.Invalidate();
            SS.Update();
        }


        public static Image GetEmbeddedImage(String name)
        {
            return Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("Cod4ServerTool." + name));
        }

        public static int GetLatencyDrop(ComboBox cb)
        {
            String s = cb.Text;
            return int.Parse(s.Remove(0, 1));
        }

        public static void AddServerToServerView(Server s, ListView serverView)
        {
            string port = s.getVariable(Protocol.Protocol.portSTR);
            string ip = s.getVariable(Protocol.Protocol.ipAddressSTR);

            var lvi = new ListViewItem();
            String ipport = ip + Server.separator + port;
            lvi.Name = ipport;
            lvi.Text = s.getVariable(Protocol.Protocol.ipAddressSTR);

            for (int a = 1; a < serverView.Columns.Count; a++)
            {
                lvi.SubItems.Add(serverView.Columns[a].Name == Protocol.Protocol.portSTR ? port : "");
            }
            serverView.Items.Add(lvi);
            UpdateServerInServerView(s, serverView);
        }

        public static int GetColumnIndex(ListView.ColumnHeaderCollection chc, String name)
        {
            int a = 0;
            foreach (ColumnHeader ch in chc)
            {
                if (ch.Name == name)
                    return a;
                a++;
            }
            return -1;
        }

        public static void UpdateServerInServerView(Server s, ListView serverView)
        {
            String ipport = s.getServerIdentifier(Protocol.Protocol.ipAddressSTR, Protocol.Protocol.portSTR);
            int count = 0;
            foreach (ColumnHeader ch in serverView.Columns)
            {
                String val = s.getVariable(ch.Name);
                serverView.Items[ipport].SubItems[count].Text = string.IsNullOrEmpty(val) == false ? val : "";
                count++;
            }
        }

        public static void UpdateFavourite(ListView serverView, Servers serversInstance, bool isFavourite)
        {
            foreach (ListViewItem lvi in serverView.SelectedItems)
            {
                Server s = serversInstance.masterServers[lvi.Name];
                s.setVariable(Protocol.Protocol.favouriteSTR, isFavourite.ToString());
                UpdateServerInServerView(s, serverView);
            }
        }

        //refresh selected items in listview
        public static void Refreshselected(ListView serverView, Protocol.Protocol protocolInstance,
                                           Servers serversInstance)
        {
            Server serv = serversInstance.masterServers[serverView.SelectedItems[0].Name];

            protocolInstance.updateServerInfo(serv, Protocol.Protocol.basic);

            UpdateServerInServerView(serv, serverView);
        }

        public static void ServersFromFile(ToolStripLabel toolStripLabel, StatusStrip ss, Servers serversInstance,
                                           threads threadsInstance, ListView serverView, view baseView)
        {
            var ofd = new OpenFileDialog();
            ofd.Title = "Select file to extract ip:ports from";
            ofd.ShowDialog();
            if (string.IsNullOrEmpty(ofd.FileName))
                return;

            var fs = new FileStream(ofd.FileName, FileMode.Open);
            var sr = new StreamReader(fs);

            String file = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            threadsInstance.addServerCollectionThread(toolStripLabel, ref ss, file, serversInstance, threadsInstance);

            ToolStripText(toolStripLabel, ref ss, "Ready");
            baseView.allServersToServerView();
        }

        public static void ServersFromUrl(ToolStripLabel toolStripLabel, StatusStrip ss, Servers serversInstance,
                                          threads threadsInstance, ListView serverView, view baseView)
        {
            var sb = new getStringBox();
            sb.label1.Text = "Enter URL to extract ip:ports from";
            sb.ShowDialog();
            String ret = sb.returnvalue;
            if (ret == "")
                return;

            ToolStripText(toolStripLabel, ref ss, "Extracting Web Page Text");
            var page = NetExtras.DownloadWebPage(ret);

            if (page == null)
            {
                MessageBox.Show("Not a valid webpage");
                return;
            }


            threadsInstance.addServerCollectionThread(toolStripLabel, ref ss, page, serversInstance, threadsInstance);


            ToolStripText(toolStripLabel, ref ss, "Ready");
            baseView.allServersToServerView();
        }


        public static void ChangeDirectory(String exe)
        {
            String s = exe;
            s = s.Substring(0, s.LastIndexOf("\\", StringComparison.Ordinal));

            Environment.CurrentDirectory = s;
        }

        public static void Connecttoserver(String ipaddr, String gameLocation)
        {
            String codfile = gameLocation;
            if (File.Exists(codfile) == false)
            {
                var ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.Title = "Select iw3mp.exe to run an ip address with";
                ofd.ShowDialog();
                view.resetDirectory();

                if (string.IsNullOrEmpty(ofd.FileName))
                    return;

                var fs = new FileStream(codfile, FileMode.Create);
                var sw = new StreamWriter(fs);

                sw.WriteLine(ofd.FileName);

                sw.Close();
                fs.Close();
            }

            String codlocation = "";
            try
            {
                var fs = new FileStream(codfile, FileMode.Open);
                var sr = new StreamReader(fs);

                codlocation = sr.ReadToEnd();
                codlocation = codlocation.Substring(0, codlocation.IndexOf("iw3mp.exe", StringComparison.Ordinal) + 9);

                sr.Close();
                fs.Close();

                ChangeDirectory(codlocation);

                Process.Start(codlocation, "connect " + ipaddr);
            }
            catch
            {
                MessageBox.Show("An error has occurred starting:" + codlocation);
                File.Delete(codfile);
            }
        }

        public static void DeleteSelected(ListView serverView, Servers serversInstance)
        {
            ListView.SelectedListViewItemCollection slvic = serverView.SelectedItems;

            int count = 0;
            String ips = "";
            foreach (ListViewItem lvi in slvic)
            {
                if (count > 10)
                {
                    ips += "...";
                    break;
                }
                count++;
                ips += lvi.Name + "\n";
            }


            DialogResult dr = MessageBox.Show("Are you sure you want to delete these ips?\n" + ips, "question",
                                              MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
                return;


            foreach (ListViewItem lvi in slvic)
            {
                serverView.Items.Remove(lvi);
                serversInstance.masterServers.Remove(lvi.Name);
            }
        }

        public static bool IsInt(String s)
        {
            var r = new Regex("^[0-9]+$");
            return r.IsMatch(s);
        }
    }
}