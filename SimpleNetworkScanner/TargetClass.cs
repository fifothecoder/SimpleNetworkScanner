using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNetworkScanner
{
    public class TargetClass
    {
        public IPAddress IP_ADDRESS;
        public List<ushort> PORTS;

        public TargetClass(string ip, ref List<ushort> ports)
        {
            IP_ADDRESS = IPAddress.Parse(ip);
            PORTS = ports;
        }

        public TargetClass(IPAddress ip, ref List<ushort> ports)
        {
            IP_ADDRESS = ip;
            PORTS = ports;
        }

    }
}
