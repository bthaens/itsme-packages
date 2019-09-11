using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace dotnet_core_api.Integrations
{
    public interface IItsmeClient
    {
        string GetLoginUrl();
        Itsme.User GetUserDetails(string authorization_code);
    }
    public class ItsmeClient: IItsmeClient
    {
        private Itsme.Client _itsmeClient;
        public ItsmeClient(IConfiguration config, IUrlHelper urlHelper)
        {
            var settings = new Itsme.ItsmeSettings();
            settings.ClientId = config.GetValue<string>("ClientID", "zEsw0hVPeC");
            settings.RedirectUri = config.GetValue<string>("RedirectURI", urlHelper.Action("Redirect", "Get"));
            settings.PrivateJwkSet = config.GetValue<string>("PrivateJWKSet", File.ReadAllText("private_jwks.json"));
            settings.AppEnvironment = config.GetValue<string>("AppEnvironment", "e2e");
            _itsmeClient = new Itsme.Client(settings);
        }

        public string GetLoginUrl()
        {
            var urlSettings = new Itsme.UrlConfiguration();
            urlSettings.ServiceCode = "Serso_LOGIN";
            urlSettings.Scopes = new string[]{"profile", "email", "address", "phone", "eid"};
            return _itsmeClient.GetAuthenticationURL(urlSettings);
        }

        public Itsme.User GetUserDetails(string authorization_code)
        {
            return _itsmeClient.GetUserDetails(authorization_code);
        }
    }
}
