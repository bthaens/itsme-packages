# DotNet Core ITSME Sample

## Getting started

First, copy the ITSME nuget package you want to use to the `./nupkgs` folder.
If you do not have this yet, go through the setup steps found in the [dotnet-core package README][dc-readme].

The following steps have already been done for you in this demo project, they are listed as a guideline.
To use ITSME, add the package as a dependency in `dotnet-core-demo.csproj`:

```xml
<ItemGroup>
  <PackageReference Include="itsme" Version="1.0.0" />
</ItemGroup>
```

As we want NuGet to find the package, we need to tell it to look for packages on the path as well.
Extend `dotnet-core-demo.csproj` to :

```xml
<PropertyGroup>
    ...
    <RestoreSources>$(RestoreSources);./nupkgs;https://api.nuget.org/v3/index.json</RestoreSources>
</PropertyGroup>
```

Now, run `dotnet restore` from the CLI to add the configured dependencies to your project.
You can now import `Itsme` like and use it like in the [sample][program-cs].

[dc-readme]: ../../dotnet-core/README.md
[program-cs]: Program.cs
