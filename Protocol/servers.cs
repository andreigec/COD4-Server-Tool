using System;
using System.Collections.Generic;
using System.IO;

namespace Protocol
{
    public class Servers
    {
        //a dictionary of servername (ip:port), server
        public Dictionary<String, Server> masterServers = new Dictionary<string, Server>();

        public void deserialise(String filename)
        {
            masterServers = new Dictionary<string, Server>();

            if (File.Exists(filename) == false)
                return;

            var FS = new FileStream(filename, FileMode.Open);
            var SR = new StreamReader(FS);

            String file = SR.ReadToEnd();

            var sep = new string[1];
            sep[0] = "block";

            String[] args = file.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            foreach (String s in args)
            {
                var serv = new Server();
                serv.deserialise(s);
                string ip = serv.getVariable(Protocol.ipAddressSTR);
                string port = serv.getVariable(Protocol.portSTR);

                if (ip!= null && port != null)
                {
                    String ipaddr = ip+Server.separator+port;
                    if (masterServers.ContainsKey(ipaddr) == false)
                        masterServers.Add(ipaddr, serv);
                }
            }

            SR.Close();
            FS.Close();
        }

        public void serialise(String filename)
        {
            var FS = new FileStream(filename, FileMode.Create);
            var SW = new StreamWriter(FS);

            String ff = "";

            foreach (String s in masterServers.Keys)
            {
                ff += "\r\nblock\r\n" + masterServers[s].serialise() + "\r\nblock\r\n";
            }
            SW.Write(ff);

            SW.Close();
            FS.Close();
        }
    }
}