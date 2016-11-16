using System.Collections.Generic;
using Dynamite.Console.Model;

namespace Dynamite.Console.Providers.DnsMadeEasy
{
    public class DnsMadeEasyConfiguration
    {
        public DnsMadeEasyConfiguration()
        {
            DynamicDnsRecords = new List<DynamicDnsRecord>();
        }

        public string Username { get; set; }
        public List<DynamicDnsRecord> DynamicDnsRecords { get; set; }
    }
}
