param(
        [Parameter(Position=0,mandatory=$true)]
        [string]
        $libVersion,
        [Parameter(Position=1,mandatory=$false)]
        [string]
        $location = '.'
)

$extensions = @('so', 'dll', 'dylib')

If(!(Test-Path $location))
{
      New-Item -ItemType Directory -Path $location
}

ForEach ($extension in $extensions)
{
    $fileName = "itsme_lib.$extension"
    $url = "https://github.com/itsme-sdk/itsme-golang/releases/download/v$libVersion/$fileName"
    $outFile = "$location/$fileName"
    Invoke-WebRequest -Uri $url -OutFile $outFile
}
