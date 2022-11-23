# Branch Kill

A quick cleanup of your git repository branches.

## Instructions

**Requirements**
⚠ You need to have VS Code installed.

**Installation**
Just run 

`dotnet tool install --global KornelijePetak.BranchKill`

from the command line.

**How to use?**
* Position yourself in a git repository
* Run `dotnet branchkill`
* A VS Code will open showing you all your branches
  * ℹ Note that the current branch won't show in the list
* Remove from the file all the branches you no longer want in your repository
* Save the file and close VS Code

**Alternative syntax**
`dotnet branchkill path-to-repo`

