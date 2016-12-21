﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLog;
using Autofac;
using Topshelf;

namespace Dynamite.Console
{
    class Program
    {
        static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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

            var host = HostFactory.New(x =>
            {
                x.SetServiceName("Dynamite");
                x.SetDescription("Updates domain records for various Dynamic DNS providers.");
                x.SetDisplayName("Dynamite");

                x.Service(() =>
                {
                    using (var scope = DynamiteContainer.Current.BeginLifetimeScope())
                    {
                        return scope.Resolve<DynamiteUpdater>();
                    }
                });

                x.RunAsLocalSystem();
                x.StartAutomatically();
                x.EnablePauseAndContinue();
                x.UseNLog();
                x.OnException(ex => Logger.Error(ex));
            });

            host.Run();
        }
    }
}
