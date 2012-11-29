using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using ANDREICSLIB;

namespace Protocol
{
    //game specific information, should be able to be swapped and work with another game
    public class Protocol
    {
        public static string MasterServer = "cod4master.activision.com";
        //a dictionary of column name/nice name, name used in Protocol
        //eg "Server IP","servip"

        //....getinfo xxx
        public static byte[] basic =
            {
                0xFF, 0xFF, 0xFF, 0XFF, 0x67, 0x65, 0x74, 0x69, 0x6E, 0x66, 0x6F, 0x20, 0x78, 0x78
                , 0x78
            };

        //....getservers 0-6 full empty
        public static byte[] cod4getservers =
                {
                    0xFF, 0xFF, 0xFF, 0xFF, 0x67, 0x65, 0x74, 0x73, 0x65, 0x72, 0x76, 0x65, 0x72, 0x73,
                    0x20, 0x30, 0x20, 0x66, 0x75, 0x6C, 0x6C, 0x20, 0x65, 0x6D, 0x70, 0x74, 0x79
                };

        //....getstatus   
        public static byte[] extended = {0xFF, 0xFF, 0xFF, 0xFF, 0x67, 0x65, 0x74, 0x73, 0x74, 0x61, 0x74, 0x75, 0x73};

        //use these when putting data specifically in parts of the application
        public static String ipAddressSTR = "IP Address";
        //public IPAddress ipAddress;

        public static String portSTR = "Port";
        //public int port;

        public static String hostNameSTR = "Host Name";
        //public String hostName;

        public static String pingSTR = "Ping";
        //public int ping;

        public static String mapNameSTR = "Map Name";
        //public String mapName;

        public static String clientsSTR = "Clients";
        //public int clients;

        public static String maxClientsSTR = "Max Clients";
        //public int maxClients;

        public static String gameTypeSTR = "Game Type";
        //public String gameType;

        public static String maxPingSTR = "Max Ping";
        //public int maxPing;

        public static String punkBusterSTR = "Punk Buster?";
        //public bool punkBuster;

        public static String favouriteSTR = "Favourite?";
        private readonly Dictionary<String, String> protocolList = new Dictionary<string, string>();
        //public bool favourite;	


        public Protocol()
        {
            //list the columns we want from games here, protocolUsage/nice name
            protocolList = new Dictionary<string, string>();

            protocolList.Add("ipaddress", ipAddressSTR);
            protocolList.Add("port", portSTR);
            protocolList.Add("hostname", hostNameSTR);
            protocolList.Add("ping", pingSTR);
            protocolList.Add("mapname", mapNameSTR);
            protocolList.Add("clients", clientsSTR);
            protocolList.Add("sv_maxclients", maxClientsSTR);
            protocolList.Add("gametype", gameTypeSTR);
            protocolList.Add("maxPing", maxPingSTR);
            protocolList.Add("pb", punkBusterSTR);
            protocolList.Add("fav", favouriteSTR);
        }

        //occasionally games use odd chars to indicate colours etc in names, sanatise these fields
        //uses the column/nice name
        //COD4-^%d-1 for red, 2 for green, 3 for yellow, 
        //4 for blue, 5 for cyan, 5 is magenta, 7 is white and 0 is black
        public static String sanatiseName(String instr)
        {
            String[] sas = Regex.Split(instr, "(\\^[1-9])|(\\^\\^0)", RegexOptions.Singleline);
            String outstr = "";

            foreach (String s in sas)
            {
                if (s.StartsWith("^") == false)
                    outstr += s;
            }

            outstr = outstr.Trim();
            return outstr;
        }

        //game dependent
        public static string[] sendGamePacket(IPAddress address, int port, byte[] data)
        {
            long start = DateTime.Now.Ticks;

            byte[] rec =   NetUpdates.SendUDPPacketGetBlockingResponse(address, port, data);

            if (rec == null)
                return null;

            long end = DateTime.Now.Ticks;
            long time = (end - start)/TimeSpan.TicksPerMillisecond;

            String recs = Encoding.ASCII.GetString(rec);
            recs = recs.Remove(recs.IndexOf('\0'));
            recs = recs.Remove(0, recs.IndexOf("\\") + 1);
            recs += "\\ping\\" + (int) time;

            var seps = new String[1];

            seps[0] = "\\";
            return recs.Split(seps, StringSplitOptions.RemoveEmptyEntries);
        }

        //send a packet, and for each received key/var update the server with that variable
        public string[] updateServerInfo(Server serv, byte[] protocolBytes)
        {
            try
            {
                string[] split = sendGamePacket(IPAddress.Parse(serv.serverVariables[ipAddressSTR]),
                                                int.Parse(serv.serverVariables[portSTR]), protocolBytes);
                if (split == null)
                {
                    serv.init(ipAddressSTR, portSTR);
                    return null;
                }

                for (int a = 0; a < split.Length; a += 2)
                {
                    String key = split[a];
                    String val = split[a + 1];

                    if (protocolList.ContainsKey(key))
                    {
                        key = protocolList[key];
                        if (key == hostNameSTR)
                            val = sanatiseName(val);
                        serv.setVariable(key, val);
                    }
                    else
                        continue;
                }
                return split;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<KeyValuePair<String, int>> getColumns()
        {
            return protocolList.Select(kvp1 => new KeyValuePair<string, int>(kvp1.Value, 100));
        }
    }
}