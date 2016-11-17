using System.Collections.Generic;
using Dynamite.Console.Domain.Model;

namespace Dynamite.Console.Domain
{
    public interface IDynamicDnsConfiguration
    {
        string Username { get; set; }
        List<DynamicDnsRecord> DynamicDnsRecords { get; set; }
    }
}