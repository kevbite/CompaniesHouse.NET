Write-Host "Restoring nuget packages"
Push-Location -Path src
nuget restore
Pop-Location