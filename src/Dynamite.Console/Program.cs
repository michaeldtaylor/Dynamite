using Dynamite.Console.Providers;
using Dynamite.Console.Providers.Ip4AddressProvider;
using Dynamite.Console.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLog;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Topshelf;

namespace Dynamite.Console
{
    class Program
    {
        static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        static readonly string DyamiteConfigurationFilePath = Path.Combine(Environment.CurrentDirectory, "Configuration", "Dynamite.json");

        static void Main()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                Converters =
                {
                    new StringEnumConverter()
                }
            };

            var dynamiteConfiguration = ConfigurationLoader.Load<DynamiteConfiguration>(Program.DyamiteConfigurationFilePath);
            var dynamicDnsProviders = dynamiteConfiguration.ProviderTypeNames.Select(p =>
            {
                var type = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == p);

                if (type == null)
                {
                    return null;
                }

                return (IDynamicDnsProvider)Activator.CreateInstance(type);
            });

            var latestIp4AddressProvider = new FileIp4AddressProvider();

            var host = HostFactory.New(x =>
            {
                x.SetServiceName("DynamiteConsole");
                x.SetDescription("Updates domain records for various Dynamic DNS providers.");
                x.SetDisplayName("DynamiteConsole");

                x.Service(() => new DynamiteUpdater(dynamiteConfiguration, dynamicDnsProviders, latestIp4AddressProvider));
                x.RunAsNetworkService();
                x.StartAutomatically();
                x.EnablePauseAndContinue();
                x.UseNLog();
                x.OnException(ex => Logger.Error(ex));
            });

            host.Run();
        }
    }
}
