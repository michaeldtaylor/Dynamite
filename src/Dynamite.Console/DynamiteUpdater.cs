using Dynamite.Console.Model;
using Dynamite.Console.Providers;
using Dynamite.Console.Utilities;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;

namespace Dynamite.Console
{
    public class DynamiteUpdater : ServiceControl
    {
        static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        readonly CancellationTokenSource _cancellationTokenSource;
        readonly DynamiteConfiguration _dynamiteConfiguration;
        readonly IEnumerable<IDynamicDnsProvider> _dynamicDnsProviders;
        readonly IIp4AddressProvider _ip4AddressProvider;

        public DynamiteUpdater(DynamiteConfiguration dynamiteConfiguration, IEnumerable<IDynamicDnsProvider> dynamicDnsProviders, IIp4AddressProvider ip4AddressProvider)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _dynamiteConfiguration = dynamiteConfiguration;
            _dynamicDnsProviders = dynamicDnsProviders;
            _ip4AddressProvider = ip4AddressProvider;
        }

        public bool Start(HostControl hostControl)
        {
            Logger.Info("Dynamite updater starting...");

            Task.Run(async () =>
            {
                while (true)
                {
                    var currentIp4Address = ExternalIp4Address.Get();
                    var latestIp4Address = _ip4AddressProvider.GetLatestIp4Address()?.Ip4Address;

                    if (currentIp4Address != latestIp4Address)
                    {
                        _ip4AddressProvider.Update(currentIp4Address);

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
