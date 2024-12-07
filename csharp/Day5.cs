namespace AdventOfCode2024;

public class Day5
{
    public static void Run()
    {
        var file = File.ReadAllText("../../../../csharp/day5.txt").Split("\n\n");
        var rules = file[0].Split("\n").Select(row => row.Split("|").Select(int.Parse).ToArray()).ToArray();
        var updates = file[1].Split("\n").Select(row => row.Split(",").Select(int.Parse).ToArray()).ToArray();

        var sumPart1 = 0;
        var sumPart2 = 0;

        foreach (var update in updates)
        {
            var correct = true;
            for (var number = 0; number < update.Length; number++)
            {
                var preceding = (from rule in rules where rule[0] == update[number] select rule[1]).ToList();
                var previousNumbers = update.Take(number);
                if (!preceding.Any(num => previousNumbers.Contains(num))) continue;
                correct = false;
                break;
            }

            if (correct) sumPart1 += update[update.Length / 2];
            else sumPart2 += SortIncorrect(update, rules);
        }

        Console.WriteLine(sumPart1);
        Console.WriteLine(sumPart2);
    }

    private static int SortIncorrect(int[] update, int[][] rules)
    {
        var sorted = false;
        while (!sorted)
        {
            var fine = 0;
            for (var number = 0; number < update.Length; number++)
            {
                var preceding = (from rule in rules where rule[0] == update[number] select rule[1]).ToList();
                var previousNumbers = update.Take(number).ToList();
                foreach (var t in preceding)
                {
                    for (var j = 0; j < previousNumbers.Count; j++)
                    {
                        if (t != previousNumbers[j]) continue;
                        (update[number], update[j]) = (update[j], update[number]);
                        goto Restart;
                    }
                }

                if (preceding.All(num => !previousNumbers.Contains(num))) fine++;
            }

            if (fine == update.Length) sorted = true;
            Restart:
            {
            }
        }

        return update[update.Length / 2];
    }
}