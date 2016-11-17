using System;
using System.IO;
using Dynamite.Console.Domain;
using Dynamite.Console.Domain.Model;
using Newtonsoft.Json;

namespace Dynamite.Console.Infrastructure
{
    public class FileIp4AddressRepository : IIp4AddressRepository
    {
        static readonly string LatestIp4AddressFilePath = Path.Combine(Environment.CurrentDirectory, "LatestIp4Address.json");

        LatestIp4Address _latestIp4Address;

        public LatestIp4Address GetLatest()
        {
            if (!File.Exists(LatestIp4AddressFilePath))
            {
                return _latestIp4Address;
            }

            _latestIp4Address = JsonConvert.DeserializeObject<LatestIp4Address>(File.ReadAllText(FileIp4AddressRepository.LatestIp4AddressFilePath));

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
