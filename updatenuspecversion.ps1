$root = $env:APPVEYOR_BUILD_FOLDER
$versionStr = $env:APPVEYOR_BUILD_VERSION

Write-Host $root
Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\source\IdentityServer3.ElasticSearchEventService\IdentityServer3.ElasticSearchEventService.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\source\IdentityServer3.ElasticSearchEventService\IdentityServer3.ElasticSearchEventService.nuspec
