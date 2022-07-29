[CmdletBinding()]
param (
    $DoitContainerVersion)

$doitContainerVersion = $DoitContainerVersion;

mkdir docker-info;

$doitContainerVersion | Out-File -FilePath docker-info\text.txt;

write-host $doitContainerVersion