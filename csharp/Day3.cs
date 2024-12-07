using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public class Day3
{
    public static void Run()
    {
        var countPart1 = 0;
        var countPart2 = 0;
        var input = File.ReadAllText("../../../../csharp/day3.txt").Replace("\n", "");
        var matches = Regex.Matches(input, @"(do[(][)]|don't[(][)]|mul[(]([0-9]+),([0-9]+)[)])");
        var mech = "do()";
        foreach (Match match in matches)
        {
            if (match.Groups[1].Value.StartsWith('d'))
            {
                mech = match.Groups[1].Value;
                continue;
            }
            var number = int.Parse(match.Groups[2].Value) * int.Parse(match.Groups[3].Value);
            countPart1 += number;
            if (mech == "do()") countPart2 += number;
        }
        Console.WriteLine($"Part 1: {countPart1}");
        Console.WriteLine($"Part 2: {countPart2}");
    }
}