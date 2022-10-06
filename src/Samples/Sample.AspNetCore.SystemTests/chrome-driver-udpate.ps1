[CmdletBinding()]
param (
    [Parameter(Mandatory = $false)]
    [string]
    $ChromeVersion
)

# store original preference to revert back later
$OriginalProgressPreference = $ProgressPreference;
# setting progress preference to silently continue will massively increase the performance of downloading the ChromeDriver
$ProgressPreference = 'SilentlyContinue';

Function Get-ChromeVersion {
    # $IsWindows will PowerShell Core but not on PowerShell 5 and below, but $Env:OS does
    # this way you can safely check whether the current machine is running Windows pre and post PowerShell Core
    If ($IsWindows -or $Env:OS) {
        Try {
            (Get-Item (Get-ItemProperty 'HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe' -ErrorAction Stop).'(Default)').VersionInfo.FileVersion;
        }
        Catch {
            Throw "Google Chrome not found in registry";
        }
    }
    ElseIf ($IsLinux) {
        Try {
            # this will check whether google-chrome command is available
            Get-Command google-chrome -ErrorAction Stop | Out-Null;
            google-chrome --product-version;
        }
        Catch {
            Throw "'google-chrome' command not found";
        }
    }
    ElseIf ($IsMacOS) {
        $ChromePath = '/Applications/Google Chrome.app/Contents/MacOS/Google Chrome';
        If (Test-Path $ChromePath) {
            $Version = & $ChromePath --version;
            $Version = $Version.Replace("Google Chrome ", "");
            $Version;
        }
        Else {
            Throw "Google Chrome not found on your MacOS machine";
        }
    }
    Else {
        Throw "Your operating system is not supported by this script.";
    }
}

# Instructions from https://chromedriver.chromium.org/downloads/version-selection
#   First, find out which version of Chrome you are using. Let's say you have Chrome 72.0.3626.81.
If ([string]::IsNullOrEmpty($ChromeVersion)) {
    $ChromeVersion = Get-ChromeVersion -ErrorAction Stop;
    Write-Output "Google Chrome version $ChromeVersion found on machine";
}

#   Take the Chrome version number, remove the last part, 
$ChromeVersion = $ChromeVersion.Substring(0, $ChromeVersion.LastIndexOf("."));
$ChromeVersion = $ChromeVersion.Substring(0, $ChromeVersion.IndexOf("."));

$ChromDriverVersionRaw = dotnet list ./src/Samples/Sample.AspNetCore.SystemTests/Sample.AspNetCore.SystemTests.csproj package | Out-String
$ChromDriverVersionRaw = $ChromDriverVersionRaw.Split('Selenium.WebDriver.ChromeDriver')[1].Trim().Split(' ')[0]
$ChromeDriverVersion = $ChromDriverVersionRaw.Substring(0, $ChromDriverVersionRaw.IndexOf("."))
Write-Output "Chromedriver version $ChromeDriverVersion found on machine";

If ([int]$ChromeVersion -gt [int]$ChromeDriverVersion) {
    dotnet add src/Samples/Sample.AspNetCore.SystemTests/Sample.AspNetCore.SystemTests.csproj package Selenium.WebDriver.ChromeDriver
    dotnet build src/Samples/Sample.AspNetCore.SystemTests/Sample.AspNetCore.SystemTests.csproj
}
Else {
    Write-Output "Chromedriver on machine is already latest version. Skipping.";
    Exit;
}

# reset back to original Progress Preference
$ProgressPreference = $OriginalProgressPreference;