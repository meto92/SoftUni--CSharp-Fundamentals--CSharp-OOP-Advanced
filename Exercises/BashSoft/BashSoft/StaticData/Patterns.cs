using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class Patterns
{
    public const string FileNamePattern = @"[^\\\/:\*\?""<>|]+";
    public static readonly string PathPattern = $@"[a-zA-Z]:([\\\/]+{FileNamePattern})*[\\\/]*";
    public static readonly Dictionary<string, Regex> PatternsByCommands = new Dictionary<string, Regex>()
    {
        ["open"] = new Regex($@"^(open)\s+({FileNamePattern})$"),
        ["mkdir"] = new Regex($@"^(mkdir)\s+({FileNamePattern})$"),
        ["ls"] = new Regex(@"^(ls)(\s+(\d{1,9}))?$"),
        ["cmp"] = new Regex($@"(cmp)\s+({PathPattern})\s+({PathPattern})"),
        ["cdRel"] =  new Regex($@"^(cdRel)\s+(((\.{{1,2}})|({FileNamePattern}))([\\\/]+|$))+"),
        ["cdAbs"] = new Regex($@"^(cdAbs)\s+({PathPattern})"),
        ["readDb"] = new Regex($@"^(readDb)\s+({FileNamePattern})"),
        ["show"] = new Regex($@"^(show)\s+(\S+)(\s+(\S+))?"),
        ["filter"] = new Regex(@"^(filter)\s+(\S+)\s+(excellent|average|poor)\s+take\s+(\d+|all)$"),
        ["order"] = new Regex(@"^(order)\s+(\S+)\s+(ascending|descending)\s+take\s+(\d+|all)$"),
        ["download"] = new Regex($@"^(download)\s+({PathPattern})$"),
        ["dropdb"] = new Regex("^(dropdb)"),
        ["help"] = new Regex("^(help)"),
        ["display"] = new Regex(@"^(display)\s+(students|courses)\s+(ascending|descending)", RegexOptions.IgnoreCase)
    };

    public static readonly Regex DbPattern = new Regex(@"(?<courseName>[A-Z][a-zA-Z#\+]*_[A-Z][a-z]{2}_(?<year>\d{4}))\s+(?<username>[A-Za-z]+\d{2}_\d{2,4})\s(?<scores>[\s\d]+)");
}