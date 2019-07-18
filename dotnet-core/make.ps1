param(
        [Parameter(Position=0,mandatory=$true)]
        [ValidateSet('clean','package','distribute')]
        [string]
        $command
)

$origin = Get-Location
Set-Location $PSScriptRoot
$version = '0.0.4'
$libVersion = '0.5.0.1563364026'

function Clear-Output {
    Remove-Item obj -Recurse -Force -ErrorAction SilentlyContinue
    Remove-Item bin -Recurse -Force -ErrorAction SilentlyContinue
    Remove-Item lib -Recurse -Force -ErrorAction SilentlyContinue
    Remove-Item nupkgs -Recurse -Force -ErrorAction SilentlyContinue
}

function New-Package {
    Clear-Output
    ../scripts/dependencies.ps1 -libVersion $libVersion -location './lib'
    dotnet pack --configuration Release --output nupkgs -p:PackageVersion=$($version)
}

function Publish-Package {
    New-Package
    # Add publish logic here
}

switch ($command) {
    'clean' {Clear-Output; break}
    'package' {New-Package; break}
    'distribute' {Clear-Output; break}
}

Set-Location $origin
