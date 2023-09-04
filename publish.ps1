$NewName = "$PSScriptRoot/FilesToFolders"
Rename-Item -Path $PSScriptRoot/src -NewName $NewName -Force
Publish-Module -Path $NewName -NuGetApiKey $Env:APIKEY