using static GithubDonwloader.Github;

internal class Program
{
    public static async Task Main(string[] args)
    {
        /*
        var arguments = ProgramArguments.Parse();
        if(arguments is null)
        {
            Console.WriteLine("参数解析失败");
            return;
        }
        if (
            string.IsNullOrWhiteSpace(arguments.DestinationPath)||
            string.IsNullOrWhiteSpace(arguments.Owner)||
            string.IsNullOrWhiteSpace(arguments.Repo)||
            string.IsNullOrWhiteSpace(arguments.Branch)||
            string.IsNullOrWhiteSpace(arguments.ProxyUrl)
            )
        {
            Console.WriteLine("目标文件夹不能为空");
            return;
        }
        */
        if (args.Length > 0)
        {
            string? localPath;
            try
            {
                localPath = args[0];
                if (string.IsNullOrWhiteSpace(localPath))
                    return;
            }
            catch { return; }

            string? owner;
            try
            {
                owner = args[1];
                if (string.IsNullOrWhiteSpace(owner))
                    return;
            }
            catch { return; }

            string? repo;
            try
            {
                repo = args[2];
                if (string.IsNullOrWhiteSpace(repo))
                    return;
            }
            catch { return; }

            var branch = "master";
            try
            {
                if (!string.IsNullOrWhiteSpace(args[3]))
                    branch = args[3];
            }
            catch {}

            var proxy = true;
            try
            {
                if (string.IsNullOrWhiteSpace(args[4]))
                    return;
                if (!bool.TryParse(args[4], out _))
                    return;
                else
                    proxy = bool.Parse(args[4]);
            }
            catch {}

            var proxyUrl = "https://ghproxy.com/";
            try
            {
                if (!string.IsNullOrWhiteSpace(args[5]))
                    proxyUrl = args[5];
            }
            catch {}

            var removeRootDir = true;
            try
            {
                if (string.IsNullOrWhiteSpace(args[6]))
                    return;
                if (!bool.TryParse(args[6], out _))
                    return;
                removeRootDir = bool.Parse(args[6]);
            }
            catch {}

            await Download(localPath, owner, repo, branch,proxy, proxyUrl, removeRootDir);
        }
    }
}

/*
[ApplicationFriendlyName("Stdiffhlp")]
[Description("仅需提供作者和仓库名即可下载文件")]
internal class ProgramArguments
{
    [CommandLineArgument(Position = 0, IsRequired = true)]
    [Description("[必须] | 目标文件夹")]
    public string? DestinationPath { get; set; }

    [CommandLineArgument(Position = 1, IsRequired = true)]
    [Description("[必须] | 作者")]
    public string? Owner { get; set; }

    [CommandLineArgument(Position = 2, IsRequired = true)]
    [Description("[必须] | 仓库")]
    public string? Repo { get; set; }

    [CommandLineArgument(Position = 3, IsRequired = false, DefaultValue = "master")]
    [Description("[默认master] | 分支 [main/master/......others]")]
    public string? Branch { get; set; }

    [CommandLineArgument(Position = 4, IsRequired = false, DefaultValue = true)]
    [Description("[默认开启] | 是否开启代理")]
    public bool Proxy { get; set; }

    [CommandLineArgument(Position = 5, IsRequired = false, DefaultValue = "https://ghproxy.com/")]
    [Description("[默认 https://ghproxy.com/ ] | 代理地址 ")]
    public string? ProxyUrl { get; set; }
    [CommandLineArgument(Position = 6, IsRequired = false, DefaultValue = true)]
    [Description("[默认开启] | 移除仓库默认自带的顶级文件夹 [xxxxxrepo-master]")]
    public bool RemoveRootDir { get; set; }
    public static ProgramArguments? Parse()
    {
        var options = new ParseOptions()
        {
            ShowUsageOnError = UsageHelpRequest.SyntaxOnly,

            DuplicateArguments = ErrorMode.Error,
        };

        return CommandLineParser.Parse<ProgramArguments>(options);
    }
}
*/