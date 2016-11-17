using System;
using System.Linq;
using Dynamite.Console.Domain;

namespace Dynamite.Console.Infrastructure
{
    public abstract class DynamicDnsProvider : IDynamicDnsProvider
    {
        readonly Lazy<IDynamicDnsConfiguration> _lazyConfiguration;

        public DynamicDnsProvider(IDynamicDnsConfigurationProvider dynamicDnsConfigurationProvider, IDynamicDnsRecordPasswordResolver dynamicDnsRecordPasswordResolver)
        {
            var baseType = GetType();

            _lazyConfiguration = new Lazy<IDynamicDnsConfiguration>(() =>
            {
                var configuration = dynamicDnsConfigurationProvider.GetConfiguration(baseType);

                foreach (var dynamicDnsRecord in configuration.DynamicDnsRecords.Where(d => d.Password == null))
                {
                    dynamicDnsRecord.Password = dynamicDnsRecordPasswordResolver.Resolve(dynamicDnsRecord.Label);
                }

                return configuration;
            });
        }

        public abstract string DisplayName { get; }
        public abstract void UpdateIp4Address(string ip4Address);
        protected IDynamicDnsConfiguration Configuration => _lazyConfiguration.Value;
    }
}