using System;
using System.Collections.Generic;

namespace Dynamite.Console
{
    public class DynamiteConfiguration
    {
        public DynamiteConfiguration()
        {
            UpdateFrequency = TimeSpan.FromMinutes(1.0);
            ProviderTypeNames = new List<string>();
        }

        public TimeSpan UpdateFrequency { get; set; }
        public List<string> ProviderTypeNames { get; set; }
    }
}
