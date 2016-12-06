# EzDSC
## What is this?
EzDSC is a simple GUI for designing and running your DSC configurations.

## How it works?
EzDSC have 3 main concepts:
* Resources are basic buiding blocks of configurations. It's just a table of properties.
Each resource have a type (for example: archive, package), and each type have a DSC Module that provides it.
Default module shipped with Windows is PSDesiredStateConfiguration.
Example: "Package Git", "Registry DisableUAC", "Group AddToAdmin" etc.
* Roles are more high level blocks of configuration - it just combines bunch of resouces.
For example "Generic Server" role would have set of some basic resouces that shoud be applied to all servers, "Web Server" would have more specific resouces that installs IIS, configures it, etc.
* Servers (and group of servers) is a tree structure. Each node of that tree can have multiple roles and variables attached to it.

## What can it do?
* Use PowerShell variables in resources;
* Support dependencies between resources;
* Export resulting DSC configuration to file;
* Directly run DSC configuration from app;
* Use community modules (unpack them and place into Modules folder of your repository);
* Install necessary community modules to target servers;

## How to use it?
1. Select folder to store your DSC repository
2. Create some resources
3. Create roles that uses your resouces
4. Add servers/groups
5. Assign roles to servers/groups
6. If you use variables in your resourses - add them to servers/groups

## How to use variables in resouces?
If you using only value of your variable: write it with $ at beginning
Example:
Credential = $ADCredential

If you using variable in string: write it inside of double quotes
Example:
Path = "$Share\distr.exe"

## How to use variables in servers and groups?
Add variable without "$" sign at beginning.

If variable uses powershell script: write code without double quotes

Example:

Credential = Get-Credential -UserName CONTOSO\user -Message "Active Directory Credential"


If variable is a array of string: write them inside of @(), in double quotes, comma separated

Example:

AdminMembers = @("CONTOSO\user", "CONTOSO\group")


If variable is a string: write it in double quotes:
Example:
Share = "\\server\share"
