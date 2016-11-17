using System;
using Dynamite.Console.Domain;
using NLog;

namespace Dynamite.Console.Infrastructure
{
    public class EnvironmentDynamicDnsRecordPasswordResolver : IDynamicDnsRecordPasswordResolver
    {
        static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        public string Resolve(string label)
        {
            var password = Environment.GetEnvironmentVariable(label);

            if (password == null)
            {
                Logger.Warn($"An environment variable containing password for label '{label}' was not found.");
            }

            return password;
        }
    }
}