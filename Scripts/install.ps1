$name = 'Aggravator'
$appData = "$env:APPDATA\\$name"
$exePath = "$appData\\$name.exe"
$desc = 'All the better to annoy you with.'
$displayName = 'Aggravator, The Adventure'
$startupType = 'Automatic'
# $acl = Get-Acl $exePath
# $aclRuleArgs = "{DOMAIN OR COMPUTER NAME\USER}", "Read,Write,ReadAndExecute", "ContainerInherit,ObjectInherit", "None", "Allow"
# $accessRule = New-Object System.Security.AccessControl.FileSystemAccessRule($aclRuleArgs)
# $acl.SetAccessRule($accessRule)
# $acl | Set-Acl "{EXE PATH}"

#New-Service -Name {SERVICE NAME} -BinaryPathName "{EXE FILE PATH}" -Credential "{DOMAIN OR COMPUTER NAME\USER}" -Description "{DESCRIPTION}" -DisplayName "{DISPLAY NAME}" -StartupType Automatic
New-Service -Name $name -BinaryPathName $exePath -Description $desc -DisplayName $displayName -StartupType $startupType