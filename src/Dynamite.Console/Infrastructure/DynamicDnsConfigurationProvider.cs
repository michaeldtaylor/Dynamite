using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Dynamite.Console.Domain;
using Dynamite.Console.Utilities;

namespace Dynamite.Console.Infrastructure
{
    public class DynamicDnsConfigurationProvider : IDynamicDnsConfigurationProvider
    {
        public IDynamicDnsConfiguration GetConfiguration(Type type)
        {
            var baseName = $"{type.Name.Replace("DynamicDnsProvider", string.Empty)}";
            var filePath = GetConfigurationFilePath(baseName);
            var configurationTypeName = $"{baseName}Configuration";
            var configurationType = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == configurationTypeName);

            if (configurationType == null)
            {
                throw new ConfigurationErrorsException($"Could not find an configuration class named '{configurationTypeName}'.");
            }

            return ConfigurationLoader.Load(filePath, configurationType);
        }

        static string GetConfigurationFilePath(string simpleName)
        {
            return Path.Combine(Environment.CurrentDirectory, "Configuration", $"{simpleName}.json");
        }
    }
}