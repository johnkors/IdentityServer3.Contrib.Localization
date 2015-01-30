$root = $env:APPVEYOR_BUILD_FOLDER
$versionStr = $env:APPVEYOR_BUILD_VERSION

Write-Host $root
Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\source\IdentityServer3.Localization\IdentityServer3.Localization.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\source\IdentityServer3.Localization\IdentityServer3.Localization.nuspec
