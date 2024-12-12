[CmdletBinding()]
param (
    [Parameter()]
    [ValidateSet("Debug","Publish")]
    [String]
    $Configuration = "Debug"
)

$CSProjectPath = Join-Path $PSScriptRoot "../power-p4/src/PowerP4Module.csproj"

dotnet build $CSProjectPath /p:Configuration=$Configuration /p:Platform="AnyCPU"