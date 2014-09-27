using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;

namespace Tethys.Notifier.Infrastructure
{
    public sealed class NativeMethods
    {
        private NativeMethods()
        {
        }

        public static string GetMacAddress(string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress))
            {
                throw new ArgumentNullException("ipAddress");
            }

            if (ipAddress == "::1" || ipAddress == "localhost")
            {
                return GlobalSettings.Current.ServerPhysicalAddress;
            }

            var ip = IPAddress.Parse(ipAddress);
            var mac = new byte[6];
            var macAddressLength = (uint)mac.Length;

            if (SendARP(BitConverter.ToInt32(ip.GetAddressBytes(), 0), 0, mac, ref macAddressLength) != 0)
            {
                throw new InvalidOperationException("ARP command failed");
            }

            var str = new string[(int)macAddressLength];

            for (int i = 0; i < macAddressLength; i++)
            {
                str[i] = mac[i].ToString("x2");
            }

            return string.Join(":", str).ToUpper();
        }

        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        private static extern int SendARP(int DestIP, int SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);
    }
}