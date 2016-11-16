using Dynamite.Console.Model;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Dynamite.Console.Providers.Ip4AddressProvider
{
    public class FileIp4AddressProvider : IIp4AddressProvider
    {
        static readonly string LatestIp4AddressFilePath = Path.Combine(Environment.CurrentDirectory, "LatestIp4Address.json");

        LatestIp4Address _latestIp4Address;

        public LatestIp4Address GetLatestIp4Address()
        {
            if (!File.Exists(LatestIp4AddressFilePath))
            {
                return _latestIp4Address;
            }

            _latestIp4Address = JsonConvert.DeserializeObject<LatestIp4Address>(File.ReadAllText(FileIp4AddressProvider.LatestIp4AddressFilePath));

            return _latestIp4Address;
        }

        public void Update(string ip4Address)
        {
            _latestIp4Address = new LatestIp4Address()
            {
                Ip4Address = ip4Address,
                UpdatedAt = DateTime.UtcNow
            };

            File.WriteAllText(LatestIp4AddressFilePath, JsonConvert.SerializeObject(_latestIp4Address));
        }
    }
}
