using System;
using Newtonsoft.Json;
using System.IO;
using Dynamite.Console.Domain;

namespace Dynamite.Console.Utilities
{
    public static class ConfigurationLoader
    {
        public static T Load<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Could not find configuration file at '{filePath}'.", filePath);
            }

            return JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
        }

        public static IDynamicDnsConfiguration Load(string filePath, Type type)
        {
            if (!typeof(IDynamicDnsConfiguration).IsAssignableFrom(type))
            {

            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Could not find configuration file at '{filePath}'.", filePath);
            }

            return (IDynamicDnsConfiguration)JsonConvert.DeserializeObject(File.ReadAllText(filePath), type);
        }
    }
}
