using Dynamite.Console.Utilities;
using NLog;
using System;
using System.IO;
using System.Net.Http;

namespace Dynamite.Console.Providers.DnsMadeEasy
{
    public class DnsMadeEasyDynamicDnsProvider : IDynamicDnsProvider
    {
        static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        static readonly string DnsMadeEasyConfigurationFilePath = Path.Combine(Environment.CurrentDirectory, "Configuration", "DnsMadeEasy.json");
        static readonly HttpClient Client = new HttpClient();

        readonly DnsMadeEasyConfiguration _dnsMadeEasyConfiguration;

        public string DisplayName => "DNS Made Easy";

        public DnsMadeEasyDynamicDnsProvider() : this(ConfigurationLoader.Load<DnsMadeEasyConfiguration>(DnsMadeEasyConfigurationFilePath))
        {
        }

        public DnsMadeEasyDynamicDnsProvider(DnsMadeEasyConfiguration dnsMadeEasyConfiguration)
        {
            _dnsMadeEasyConfiguration = dnsMadeEasyConfiguration;
        }

        public void UpdateIp4Address(string ip4Address)
        {
            foreach (var dynamicDnsRecord in _dnsMadeEasyConfiguration.DynamicDnsRecords)
            {
                var requestUri = DnsMadeEasyApi.BuildUpdateIpUri(_dnsMadeEasyConfiguration.Username, dynamicDnsRecord.Id, dynamicDnsRecord.Password, ip4Address);
                var response = Client.GetAsync(requestUri).Result;

                if (response.IsSuccessStatusCode)
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
