using Dynamite.Console.Domain.Model;

namespace Dynamite.Console.Domain
{
    public interface IIp4AddressRepository
    {
        LatestIp4Address GetLatest();
        void Update(string ip4Address);
    }
}
