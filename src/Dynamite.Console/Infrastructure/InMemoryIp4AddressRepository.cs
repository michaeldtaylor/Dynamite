using System;
using Dynamite.Console.Domain;
using Dynamite.Console.Domain.Model;

namespace Dynamite.Console.Infrastructure
{
    public class InMemoryIp4AddressRepository : IIp4AddressRepository
    {
        LatestIp4Address _ip4Address;

        public LatestIp4Address GetLatest()
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
