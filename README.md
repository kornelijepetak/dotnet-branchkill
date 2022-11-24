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


## Support my work

If you find my work useful, consider buying me a drink.

<a href="https://www.buymeacoffee.com/kornelijepetak"><img src="https://img.buymeacoffee.com/button-api/?text=Buy me a drink!&emoji=&slug=kornelijepetak&button_colour=007ecc&font_colour=ffffff&font_family=Cookie&outline_colour=ffffff&coffee_colour=FFDD00" /></a>
