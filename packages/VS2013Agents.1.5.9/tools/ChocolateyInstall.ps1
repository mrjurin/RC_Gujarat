try {
    Write-Host "About to download http://download.microsoft.com/download/9/8/B/98B5E7D1-231B-4439-824F-0EE0B8D3011E/VS2013_RTM_AGTS_ENU.iso into ${env:temp}\vs2013agents.iso "
    Get-ChocolateyWebFile 'VS2013Agents' "$env:temp\vs2013agents.iso" 'http://download.microsoft.com/download/9/8/B/98B5E7D1-231B-4439-824F-0EE0B8D3011E/VS2013_RTM_AGTS_ENU.iso'
    Write-Host "downloaded, now mounting..."

    $driveLetter = 'w:'
    $path = "$env:temp\vs2013agents.iso"

    if ( (Get-Command "Mount-DiskImage" -ErrorAction SilentlyContinue) ) {
      Mount-DiskImage -ImagePath $path
      $driveLetter = (Get-DiskImage $path | Get-Volume).DriveLetter + ":"
      Install-ChocolateyInstallPackage 'VS2013Agents' 'exe' '/q' "${driveLetter}\TestAgent\vstf_testagent.exe"
      Dismount-DiskImage $path
    } elseif ( Get-Command "imdisk" ) {
      imdisk -a -f "$path" -m "$driveLetter"
      Install-ChocolateyInstallPackage 'VS2013Agents' 'exe' '/q' 'w:\TestAgent\vstf_testagent.exe'
      imdisk -d -m "$driveLetter"      
    } else {
      Write-ChocolateyFailure 'Could not mount ISO. Was not able to find "imdisk", "Mount-DiskImage" or another suitable command.'
    }

    Write-ChocolateySuccess 'VS2013Agents'
}
catch {
    Write-ChocolateyFailure 'VS2013Agents'
}