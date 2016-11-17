namespace Dynamite.Console.Domain
{
    public interface IDynamicDnsProvider
    {
        string DisplayName { get; }
        void UpdateIp4Address(string ip4Address);
    }
}
