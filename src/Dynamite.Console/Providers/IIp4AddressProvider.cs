using Dynamite.Console.Model;

namespace Dynamite.Console.Providers
{
    public interface IIp4AddressProvider
    {
        LatestIp4Address GetLatestIp4Address();
        void Update(string ip4Address);
    }
}
