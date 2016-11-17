using System.Collections.Generic;
using Dynamite.Console.Domain;
using Dynamite.Console.Domain.Model;

namespace Dynamite.Console.Infrastructure.DnsMadeEasy
{
    public class DnsMadeEasyConfiguration : IDynamicDnsConfiguration
    {
        public DnsMadeEasyConfiguration()
        {
            DynamicDnsRecords = new List<DynamicDnsRecord>();
        }

        public string Username { get; set; }
        public List<DynamicDnsRecord> DynamicDnsRecords { get; set; }
    }
}
