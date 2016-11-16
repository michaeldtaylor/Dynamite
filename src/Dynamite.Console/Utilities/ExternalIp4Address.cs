using System.Net.Http;

namespace Dynamite.Console.Utilities
{
    public static class ExternalIp4Address
    {
        const string ExternalIp4CheckUri = "https://api.ipify.org/";

        public static string Get()
        {
            return new HttpClient().GetStringAsync(ExternalIp4CheckUri).Result;
        }
    }
}
