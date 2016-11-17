using System;

namespace Dynamite.Console.Domain
{
    public interface IDynamicDnsConfigurationProvider
    {
        IDynamicDnsConfiguration GetConfiguration(Type type);
    }
}