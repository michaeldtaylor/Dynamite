using Dynamite.Console.Model;
using System;

namespace Dynamite.Console.Providers.Ip4AddressProvider
{
    public class InMemoryIp4AddressProvider : IIp4AddressProvider
    {
        LatestIp4Address _ip4Address;

        public LatestIp4Address GetLatestIp4Address()
        {
            return _ip4Address;
        }

        public void Update(string ip4Address)
        {
            _ip4Address = new LatestIp4Address
            {
                Ip4Address = ip4Address,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
