Write-Host "Checking if pull request"

if ([bool]$env:APPVEYOR_PULL_REQUEST_NUMBER)
{
   Write-Host "Build is pull request - updating version"
   Update-AppveyorBuild -Version "0.0.0-pull-request-$($env:APPVEYOR_PULL_REQUEST_NUMBER)-$($env:APPVEYOR_BUILD_NUMBER)"
}