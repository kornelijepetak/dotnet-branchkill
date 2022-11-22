using BranchKill;
using CliWrap;
using CommandLine;
using LibGit2Sharp;

await Parser.Default
    .ParseArguments<Options>(args)
    .WithParsedAsync(removeBranches);

static async Task removeBranches(Options options)
{
    var repository = options.Repository ?? Directory.GetCurrentDirectory();

    if (!Repository.IsValid(repository))
    {
        Console.WriteLine("Specified folder is not a valid git repository.");
        return;
    }

    var allBranches = getBranchesFrom(repository);

    var branchesToRetain = await askForBranchesToRetain(allBranches);

    var branchesToDelete = allBranches
        .Except(branchesToRetain)
        .ToHashSet();

    deleteBranches(repository, branchesToDelete);
}

static async Task<List<string>> askForBranchesToRetain(List<string> allBranches)
{
    const string header = "# Remove branches you want to delete from this file.\r\n\r\n";

    var tempFile = Path.GetTempFileName();
    File.WriteAllText(tempFile, header + string.Join("\r\n", allBranches));

    var code = await Cli.Wrap("code")
        .WithArguments($"-w {tempFile}")
        .ExecuteAsync();

    return File
        .ReadAllLines(tempFile)
        .Where(line => !string.IsNullOrWhiteSpace(line))
        .Where(line => !line.StartsWith("#"))
        .ToList();
}

static List<string> getBranchesFrom(string repository)
{
    using var repo = new Repository(repository);

    return repo.Branches.Where(b => !b.IsRemote && !b.IsCurrentRepositoryHead).Select(b => b.FriendlyName).ToList();
}

static void deleteBranches(string repository, HashSet<string> branches)
{
    using var repo = new Repository(repository);

    repo.Branches
        .Where(b => branches.Contains(b.FriendlyName))
        .ToList()
        .ForEach(repo.Branches.Remove);
}