$app = Get-WmiObject -Class Win32_Product | Where-Object { $_.Name -eq "Microsoft Agents for Visual Studio 2013" }
if($app -ne $null){
  $version=$app.Version
  $uninstaller = Get-Childitem "$env:ProgramData\Package Cache\" -Recurse -Filter vstf_testagent.exe | ? { $_.VersionInfo.ProductVersion.startswith($version)}
  Uninstall-ChocolateyPackage 'VS2013Agents' 'exe' "/Uninstall /force /Passive /NoRestart" $uninstaller.FullName
}