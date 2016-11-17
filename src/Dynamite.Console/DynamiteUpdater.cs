using NLog;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dynamite.Console.Domain;
using Dynamite.Console.Utilities;
using Topshelf;

namespace Dynamite.Console
{
    public class DynamiteUpdater : ServiceControl
    {
        static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        readonly CancellationTokenSource _cancellationTokenSource;
        readonly DynamiteConfiguration _dynamiteConfiguration;
        readonly IEnumerable<IDynamicDnsProvider> _dynamicDnsProviders;
        readonly IIp4AddressRepository _ip4AddressRepository;

        public DynamiteUpdater(DynamiteConfiguration dynamiteConfiguration, IEnumerable<IDynamicDnsProvider> dynamicDnsProviders, IIp4AddressRepository ip4AddressRepository)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _dynamiteConfiguration = dynamiteConfiguration;
            _dynamicDnsProviders = dynamicDnsProviders;
            _ip4AddressRepository = ip4AddressRepository;
        }

        public bool Start(HostControl hostControl)
        {
            Logger.Info("Dynamite updater starting...");

            Task.Run(async () =>
            {
                while (true)
                {
                    var currentIp4Address = ExternalIp4Address.Get();
                    var latestIp4Address = _ip4AddressRepository.GetLatest()?.Ip4Address;

                    if (currentIp4Address != latestIp4Address)
                    {
                        _ip4AddressRepository.Update(currentIp4Address);

                        foreach (var dynamicDnsProvider in _dynamicDnsProviders)
                        {
                            Logger.Info($"[{dynamicDnsProvider.DisplayName}] Provider update starting...");

                            dynamicDnsProvider.UpdateIp4Address(currentIp4Address);

                            Logger.Info($"[{dynamicDnsProvider.DisplayName}] Provider update completed...");
                        }
                    }
                    await Task.Delay(_dynamiteConfiguration.UpdateFrequency, _cancellationTokenSource.Token);
                }
            }, _cancellationTokenSource.Token).ConfigureAwait(false);

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            Logger.Info("Dynamite updater stopping...");

            _cancellationTokenSource.Cancel();

            return true;
        }
    }
}
