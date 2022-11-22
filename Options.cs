using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace BranchKill;

internal class Options
{
    [Option('r')]
    public string? Repository { get; set; }
}
