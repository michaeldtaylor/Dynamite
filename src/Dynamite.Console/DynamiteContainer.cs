using System;
using System.IO;
using System.Reflection;
using Autofac;
using Dynamite.Console.Domain;
using Dynamite.Console.Infrastructure;
using Dynamite.Console.Utilities;

namespace Dynamite.Console
{
    public static class DynamiteContainer
    {
        static readonly string DyamiteConfigurationFilePath = Path.Combine(Environment.CurrentDirectory, "Configuration", "Dynamite.json");

        static readonly Lazy<IContainer> LazyContainer = new Lazy<IContainer>(BuildContainer);

        public static IContainer Current => LazyContainer.Value;

        static IContainer BuildContainer()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var builder = new ContainerBuilder();

            var dynamiteConfiguration = ConfigurationLoader.Load<DynamiteConfiguration>(DyamiteConfigurationFilePath);

            builder.RegisterInstance(dynamiteConfiguration).SingleInstance();

            builder.RegisterType<DynamiteUpdater>()
                .As<DynamiteUpdater>();
            
            builder.RegisterType<DynamicDnsConfigurationProvider>()
                .As<IDynamicDnsConfigurationProvider>();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => typeof(IDynamicDnsProvider).IsAssignableFrom(t))
                .As<IDynamicDnsProvider>();

            builder.RegisterType<FileIp4AddressRepository>()
                .As<IIp4AddressRepository>();

            builder.RegisterType<EnvironmentDynamicDnsRecordPasswordResolver>()
                .As<IDynamicDnsRecordPasswordResolver>();

            return builder.Build();
        }
    }
}