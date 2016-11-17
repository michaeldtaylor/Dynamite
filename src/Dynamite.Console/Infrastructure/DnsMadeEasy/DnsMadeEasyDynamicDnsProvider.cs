using System.Net.Http;
using Dynamite.Console.Domain;
using NLog;

namespace Dynamite.Console.Infrastructure.DnsMadeEasy
{
    public class DnsMadeEasyDynamicDnsProvider : DynamicDnsProvider
    {
        static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        static readonly HttpClient Client = new HttpClient();

        const string ErrorAuthCode = "error-auth";

        public DnsMadeEasyDynamicDnsProvider(IDynamicDnsConfigurationProvider dynamicDnsConfigurationProvider, IDynamicDnsRecordPasswordResolver dynamicDnsRecordPasswordResolver)
            : base(dynamicDnsConfigurationProvider, dynamicDnsRecordPasswordResolver)
        {
        }

        public override string DisplayName => "DNS Made Easy";

        public override void UpdateIp4Address(string ip4Address)
        {
            foreach (var dynamicDnsRecord in Configuration.DynamicDnsRecords)
            {
                var requestUri = DnsMadeEasyApi.BuildUpdateIpUri(Configuration.Username, dynamicDnsRecord.Id, dynamicDnsRecord.Password, ip4Address);
                var response = Client.GetAsync(requestUri).Result;
                var content = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode && content != ErrorAuthCode)
                {
                    Logger.Info($"[{DisplayName}] Successfully updated Dynamic DNS for '{dynamicDnsRecord.Label}' (ID: {dynamicDnsRecord.Id}) with IP {ip4Address}.");
                }
                else
                {
                    Logger.Warn($"[{DisplayName}] Failed to update Dynamic DNS for '{dynamicDnsRecord.Label}' (ID: {dynamicDnsRecord.Id}) with IP {ip4Address}.");
                }
            }
        }
    }
}
