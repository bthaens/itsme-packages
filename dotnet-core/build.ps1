Set-Location $PSScriptRoot
$versionInfo = Get-Content "../version-info.json" | ConvertFrom-Json
dotnet clean --configuration Release --output nupkgs
dotnet pack --configuration Release --output nupkgs -p:PackageVersion=$($versionInfo.version)
