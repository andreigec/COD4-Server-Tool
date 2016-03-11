using System;
using System.Collections.Generic;

namespace Protocol
{
    public class Server
    {
        public static char separator = ':';
        public Dictionary<String, String> serverVariables = new Dictionary<string, string>();

        public String getVariable(String key)
        {
            if (serverVariables.ContainsKey(key) == false)
                return null;

            return serverVariables[key];
        }

        public void setVariable(String key, String value)
        {
            serverVariables[key] = value;
        }
        
        //concat ip:port
        public String getServerIdentifier(String ipKey, String portKey)
        {
            return getVariable(ipKey) + separator + getVariable(portKey);
        }
        
        public static KeyValuePair<String, String> getIpPort(String ipport)
        {
            return new KeyValuePair<String, String>(ipport.Substring(0, ipport.IndexOf(separator)),
                                                    ipport.Substring(ipport.IndexOf(separator) + 1));
        }


        public void init(String ipKey, String portKey)
        {
            var toRemove = new List<string>();

            foreach (var var in serverVariables)
            {
                if (var.Key.Equals(ipKey) == false && var.Key.Equals(portKey) == false)
                    toRemove.Add(var.Key);
            }

            foreach (String s in toRemove)
            {
                serverVariables.Remove(s);
            }
        }

        //serialise server
        public String serialise()
        {
            String returnstr = "";
            foreach (var kvp in serverVariables)
            {
                returnstr += kvp.Key + separator + kvp.Value + "\r\n";
            }

            return returnstr;
        }

        //deserialise server
        public void deserialise(String instr)
        {
            var seps = new string[1];
            seps[0] = "\r\n";
            String[] argz = instr.Split(seps, StringSplitOptions.RemoveEmptyEntries);

            serverVariables.Clear();

            foreach (String s in argz)
            {
                String key;
                String val;

                try
                {
                    key = s.Substring(0, s.IndexOf(separator));
                    val = s.Substring(s.IndexOf(separator) + 1);
                }
                catch
                {
                    return;
                }

                if (serverVariables.ContainsKey(key) == false)
                    serverVariables.Add(key, val);
            }
        }


        //end server class
    }
}