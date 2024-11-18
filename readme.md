# power-p4

A Powershell interface for Perforce. Uses the C# module, so the installation of p4 cli is not needed.

Overall, make the cli more readable and recognizeable. Unless a strong argument can be made, move to the Microsoft approved verbs for actions. 

# Local Testing

```` powershell
docker compose up -d
.\build\vsts-validate.ps1
````

# P4 CLI comparison

https://learn.microsoft.com/en-us/powershell/scripting/developer/cmdlet/approved-verbs-for-windows-powershell-commands?view=powershell-7.4

| p4                   | power-p4            |
| -------------------- | ------------------- |
| info                 | Get-P4Info          |
| sync                 | Sync-P4Workspace    |
| changelist           | New-P4Changelist    |
| changelist -d 123456 | Remove-P4Changelist |
| changelist 123456    | Edit-P4Changelist   |
| changelist -o 123456 | Get-P4Changelist    |
| changelists          | Get-P4Changelists   |
| opened               | Get-P4Opened        |
| edit                 | Open-P4File         |
| edit                 | Edit-P4File         |
| revert               | Close-P4File        |
| revert               | Reset-P4File        |

# Useful Docs

https://www.perforce.com/manuals/p4api.net/Content/P4API_NET/initialize-connection.html#Initialize_a_connection

# Open Questions

Does a new Powershell Provider make sense?
- https://learn.microsoft.com/en-us/powershell/scripting/developer/provider/windows-powershell-provider-quickstart?view=powershell-7.4