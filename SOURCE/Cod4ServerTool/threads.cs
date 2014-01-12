using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ANDREICSLIB;
using Protocol;

namespace Cod4ServerTool
{
    public class threads
    {
        //exit threads if true

        public view baseView;
        public object currthreadLock = new object();
        public int currthreads = 0;
        public bool killThreads = false;

        public threads(view newBaseView)
        {
            baseView = newBaseView;
        }

        private void changeCurrThread(int amount, bool isRelative)
        {
            lock (currthreadLock)
            {
                if (isRelative)
                    currthreads += amount;
                else
                    currthreads = amount;
            }
        }

        public void updateAllServersThread(view baseView, ListView serverView, ToolStripLabel toolStripLabel,
                                           StatusStrip SS, Servers serversInstance, Protocol.Protocol protocolInstance,
                                           bool selectedOnly, bool serverViewOnly)
        {
            killThreads = false;

            int maxthreads = 90;

            changeCurrThread(0, false);
            int count = 0;

            var updateList = new List<string>();
            int max = 0;
            //refresh selected in server view
            if (selectedOnly && serverViewOnly)
            {
                ListView.SelectedListViewItemCollection SLVIC = serverView.SelectedItems;
                max = SLVIC.Count;
                foreach (ListViewItem LVI in SLVIC)
                {
                    updateList.Add(LVI.Name);
                }
            }
            //refresh all in server view
            else if (selectedOnly == false && serverViewOnly)
            {
                max = serverView.Items.Count;
                foreach (ListViewItem LVI in serverView.Items)
                {
                    updateList.Add(LVI.Name);
                }
            }
            //otherwise refresh all in database
            else
            {
                max = serversInstance.masterServers.Keys.Count;
                foreach (String s in serversInstance.masterServers.Keys)
                {
                    updateList.Add(s);
                }
            }

            foreach (String s in updateList)
            {
                if (selectedOnly && serverViewOnly == false && serverView.Items.ContainsKey(s) == false)
                    continue;

            retry:
                if (killThreads)
                    break;

                if (currthreads > maxthreads)
                {
                    Thread.Sleep(100);
                    goto retry;
                }

                changeCurrThread(1, true);
                Thread t;

                if (serverViewOnly)
                    t =
                        new Thread(
                            () =>
                            updateListServerViewThread(baseView, serverView, toolStripLabel, SS, serversInstance,
                                                       protocolInstance, s));
                else
                    t =
                        new Thread(
                            () =>
                            updateListBackThread(baseView, serverView, toolStripLabel, SS, serversInstance,
                                                 protocolInstance, s));
                t.Start();

                Controller.ToolStripText(toolStripLabel, ref SS, "Updating " + count.ToString() + "/" + max.ToString());
                count++;
            }

            while (currthreads > 0)
            {
                Thread.Sleep(100);
            }

            Controller.ToolStripText(toolStripLabel, ref SS, "Ready");
            killThreads = false;
        }

        private void updateListServerViewThread(view baseView, ListView serverView, ToolStripLabel toolStripLabel,
                                                StatusStrip SS, Servers serversInstance,
                                                Protocol.Protocol protocolInstance,
                                                String ipport)
        {
            if (baseView.serversInstance.masterServers.ContainsKey(ipport) == false)
                baseView.serversInstance.masterServers.Add(ipport, new Server());

            Server serv = baseView.serversInstance.masterServers[ipport];
            protocolInstance.updateServerInfo(serv, Protocol.Protocol.basic);
            Controller.UpdateServerInServerView(serv, serverView);
            changeCurrThread(-1, true);
        }

        private void updateListBackThread(view baseView, ListView serverView, ToolStripLabel toolStripLabel,
                                          StatusStrip SS, Servers serversInstance, Protocol.Protocol protocolInstance,
                                          String ipport)
        {
            if (baseView.serversInstance.masterServers.ContainsKey(ipport) == false)
                baseView.serversInstance.masterServers.Add(ipport, new Server());

            Server serv = baseView.serversInstance.masterServers[ipport];
            protocolInstance.updateServerInfo(serv, Protocol.Protocol.basic);
            changeCurrThread(-1, true);
        }


        public void addServerCollectionThread(ToolStripLabel toolStripLabel, ref StatusStrip SS, String file,
                                              Servers serversInstance, threads threadsInstance)
        {
            int maxthreads = 90;

            changeCurrThread(0, false);

            var r = new Regex(@"([0-9]+\.[0-9]+\.[0-9]+\.[0-9]+:[0-9]+)|([a-zA-Z][a-zA-Z0-9\-\.]+?:[0-9]+)");
            MatchCollection mc;
            try
            {
                mc = r.Matches(file);
            }
            catch
            {
                Controller.ToolStripText(toolStripLabel, ref SS, "Ready");
                return;
            }

            int count = 0;
            foreach (Match m in mc)
            {
            retry:
                if (killThreads)
                    break;

                if (currthreads > maxthreads)
                {
                    Thread.Sleep(100);
                    goto retry;
                }

                Controller.ToolStripText(toolStripLabel, ref SS,
                                         "Verifying/Adding Server:" + count.ToString() + "/" + mc.Count);
                KeyValuePair<String, String> coll = Server.getIpPort(m.ToString());

                changeCurrThread(1, true);
                var t = new Thread(() => addServerThread(coll.Key, int.Parse(coll.Value), serversInstance));
                t.Start();
                count++;
            }

            while (currthreads > 0)
            {
                Thread.Sleep(100);
            }
        }

        public Server addServerThread(String ip, int port, Servers serversInstance)
        {
            var s = new Server();

            IPAddress address = NetExtras.HostnameToIP(ip);
            changeCurrThread(-1, true);
            if (address == null)
                return null;

            s.setVariable(Protocol.Protocol.ipAddressSTR, ip);
            s.setVariable(Protocol.Protocol.portSTR, port.ToString());
            string ipport = ip + Server.separator + port;

            if (port > 0 && serversInstance.masterServers.ContainsKey(ipport) == false)
            {
                try
                {
                    serversInstance.masterServers.Add(ipport, s);
                    return s;
                }
                catch
                {
                }
            }
            return null;
        }
    }
}