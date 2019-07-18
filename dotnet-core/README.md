# DotNet Core Package

## Prerequisites

-   [dotnet core][core]
-   [PowerShell][powershell] (or use the dotnet command found in `build.ps1`)

## Building

-   Copy the generated C lang library dll (`itsme_lib.dll`) to the root of this package
-   Run `./build.ps1`

## Consuming

-   Copy/Paste the created NuGet package under `./nupkgs` to a path NuGet knows (otherwise you can't restore)
-   Alternatively, add the following line to your `.csproj` file:

```xml
<PropertyGroup>
    ...
    <RestoreSources>$(RestoreSources);<path_to_created_NuGet_package_folder>;https://api.nuget.org/v3/index.json</RestoreSources>
</PropertyGroup>
```

-   Add the ITSME library to your `.csproj` file:

```xml
<ItemGroup>
  <PackageReference Include="itsme" Version="<version_number>" />
</ItemGroup>
```

-   Start using ITSME in your dotnet core project:

```csharp
using System;
using Itsme;

namespace dotnet_core_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientID = "my_clientid";
            var serviceCode = "my_servicecode";
            var redirectURI = "https://i/redirect";
            var signingCertificateID = "my_signing_key_id";
            var signingCert = @"-----BEGIN RSA PRIVATE KEY-----
my signing PEM key
-----END RSA PRIVATE KEY-----";
            var encryptionCert = @"-----BEGIN RSA PRIVATE KEY-----
my encryption PEM key
-----END RSA PRIVATE KEY-----";
            var itsmeClient = new Client();
            itsmeClient.Init(clientID, serviceCode, redirectURI, signingCertificateID, signingCert, encryptionCert);
            var scopes = "email profile";
            var requestUri = "";
            var url = itsmeClient.GetAuthenticationURL(scopes, requestUri);
            Console.WriteLine(url);
            var user = itsmeClient.GetUserDetails("authorization_code_I_received_upon_redirect");
            Console.WriteLine(user.Name);
        }
    }
}
```

A [demo project][demo-project] is included here as well which contains all this information in a working setup.

[core]: https://dotnet.microsoft.com/download
[powershell]: https://github.com/powershell/powershell
[demo-project]: ../demos/dotnet-core
