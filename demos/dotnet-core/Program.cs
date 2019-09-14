using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace dotnet_core_api
{
    public class Program
    {
        private static Dictionary<string, string> _getSettings()
        {
            var jwks = File.ReadAllText("jwks_private.json");
            return new Dictionary<string, string>
            {
                //{"ClientID", "zEsw0hVPeC"},
                //{"RedirectURI", "https://localhost:44358/production/redirect"},
                //{"PrivateJWKSet", jwks}
            };
        }

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddInMemoryCollection(_getSettings());
                })
                .UseStartup<Startup>();
    }
}
