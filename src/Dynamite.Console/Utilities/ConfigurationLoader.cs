using Newtonsoft.Json;
using System.IO;

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
    }
}
