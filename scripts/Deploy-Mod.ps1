<#
.SYNOPSIS
    Deploys the built mod to the Wildfrost Mods directory.

.DESCRIPTION
    Copies the compiled DLL, plus the files bundled with it in release/ (the
    Spanish font), to the game's StreamingAssets/Mods directory so the game
    can discover and load it.

    The game folder is found through Steam: the Steam install path comes from
    the registry, every library listed in steamapps/libraryfolders.vdf is
    checked for Wildfrost's app manifest (App ID 1811990), and its installdir
    gives the folder. Pass -GamePath to skip the lookup.

.PARAMETER Configuration
    Build configuration to deploy from: Debug or Release. Default: Release.

.PARAMETER GamePath
    Path to the Wildfrost game directory. Default: found through Steam.

.PARAMETER BuildFirst
    If specified, runs Build-Mod.ps1 before deploying.

.EXAMPLE
    .\Deploy-Mod.ps1
    .\Deploy-Mod.ps1 -BuildFirst
    .\Deploy-Mod.ps1 -GamePath "D:\Games\Wildfrost"
#>

param(
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release",

    [string]$GamePath,

    [switch]$BuildFirst
)

$ErrorActionPreference = "Stop"
$ModName = "WildfrostAccessibility"
$SteamAppId = "1811990"
$ProjectDir = Join-Path $PSScriptRoot "..\src"
$ReleaseModDir = [System.IO.Path]::Combine($PSScriptRoot, "..", "release", "put in game folder",
    "Modded", "Wildfrost_Data", "StreamingAssets", "Mods", $ModName)

function Get-SteamRoot {
    $keys = @(
        @{ Path = "HKCU:\Software\Valve\Steam"; Name = "SteamPath" },
        @{ Path = "HKLM:\SOFTWARE\WOW6432Node\Valve\Steam"; Name = "InstallPath" },
        @{ Path = "HKLM:\SOFTWARE\Valve\Steam"; Name = "InstallPath" }
    )
    foreach ($key in $keys) {
        try {
            $value = (Get-ItemProperty -Path $key.Path -Name $key.Name -ErrorAction Stop).($key.Name)
            if ($value -and (Test-Path $value)) {
                return [System.IO.Path]::GetFullPath($value)
            }
        } catch {}
    }
    return $null
}

function Get-SteamLibraries([string]$steamRoot) {
    $libraries = @($steamRoot)
    $vdf = Join-Path $steamRoot "steamapps\libraryfolders.vdf"
    if (Test-Path $vdf) {
        foreach ($match in [regex]::Matches((Get-Content $vdf -Raw), '"path"\s+"([^"]+)"')) {
            $libraries += $match.Groups[1].Value -replace '\\\\', '\'
        }
    }
    # Windows paths ignore case; Steam may list the same library as "s:\" and "S:\"
    return $libraries | Sort-Object -Unique
}

function Find-GamePath {
    $steamRoot = Get-SteamRoot
    if (-not $steamRoot) {
        Write-Warning "Steam install not found in the registry."
        return $null
    }

    foreach ($library in Get-SteamLibraries $steamRoot) {
        $steamapps = Join-Path $library "steamapps"
        $manifest = Join-Path $steamapps "appmanifest_$SteamAppId.acf"
        if (-not (Test-Path $manifest)) { continue }

        $installDir = "Wildfrost"
        $m = [regex]::Match((Get-Content $manifest -Raw), '"installdir"\s+"([^"]+)"')
        if ($m.Success) { $installDir = $m.Groups[1].Value }

        $candidate = Join-Path $steamapps "common\$installDir"
        if (Test-Path $candidate) { return $candidate }
    }
    return $null
}

if (-not $GamePath) {
    $GamePath = Find-GamePath
    if (-not $GamePath) {
        Write-Error "Wildfrost not found in any Steam library. Pass -GamePath `"<game folder>`"."
        exit 1
    }
    Write-Host "Found Wildfrost: $GamePath" -ForegroundColor Cyan
}

if (-not (Test-Path (Join-Path $GamePath "Modded"))) {
    Write-Error "No Modded folder in $GamePath - is this the Wildfrost game folder?"
    exit 1
}

# Build first if requested
if ($BuildFirst) {
    & (Join-Path $PSScriptRoot "Build-Mod.ps1") -Configuration $Configuration
    if ($LASTEXITCODE -ne 0) {
        Write-Error "Build failed. Deploy aborted."
        exit 1
    }
}

# Find the built DLL
$outputDir = Join-Path (Join-Path $ProjectDir "bin") $Configuration
$dll = Join-Path $outputDir "$ModName.dll"

if (-not (Test-Path $dll)) {
    # Search for it
    $found = Get-ChildItem -Path (Join-Path $ProjectDir "bin") -Recurse -Filter "$ModName.dll" | Select-Object -First 1
    if ($found) {
        $dll = $found.FullName
    } else {
        Write-Error "DLL not found. Run Build-Mod.ps1 first."
        exit 1
    }
}

# Determine mod destination
$modsDir = [System.IO.Path]::Combine($GamePath, "Modded", "Wildfrost_Data", "StreamingAssets", "Mods", $ModName)

if (-not (Test-Path $modsDir)) {
    New-Item -ItemType Directory -Path $modsDir -Force | Out-Null
    Write-Host "Created mod directory: $modsDir" -ForegroundColor Cyan
}

# Copy DLL
Copy-Item -Path $dll -Destination $modsDir -Force
Write-Host "Deployed: $dll" -ForegroundColor Green
Write-Host "      -> $modsDir" -ForegroundColor Green

# Copy the files shipped beside the DLL (the Spanish font). The DLL itself
# comes from the build output above, which is never older than release/.
if (Test-Path $ReleaseModDir) {
    Get-ChildItem -Path $ReleaseModDir -File | Where-Object { $_.Name -ne "$ModName.dll" } | ForEach-Object {
        Copy-Item -Path $_.FullName -Destination $modsDir -Force
        Write-Host "Deployed: $($_.Name)" -ForegroundColor Green
    }
}

# Verify
$deployed = Join-Path $modsDir "$ModName.dll"
if (Test-Path $deployed) {
    $info = Get-Item $deployed
    Write-Host "`nDeployment successful. Size: $($info.Length) bytes, Modified: $($info.LastWriteTime)" -ForegroundColor Green
} else {
    Write-Error "Deployment verification failed."
    exit 1
}
