using System;

namespace Dynamite.Console.Infrastructure.DnsMadeEasy
{
    public static class DnsMadeEasyApi
    {
        public static Uri BuildUpdateIpUri(string username, int id, string password, string ip4Address)
        {
            return new Uri($"http://cp.dnsmadeeasy.com/servlet/updateip?username={username}&id={id}&password={password}&ip={ip4Address}");
        }
    }
}
