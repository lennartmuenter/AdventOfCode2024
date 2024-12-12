namespace AdventOfCode2024;

public class Day11
{
    public static void Run()
    {
        var dict = File.ReadAllText("../../../../csharp/day11.txt").Trim().Split(" ").Select(long.Parse).ToList().ToDictionary(stone => stone, _ => 1L);
        for (var count = 0; count < 75; count++)
        {
            var newDict = dict.ToDictionary();
            foreach (var stone in dict)
            {
                if (stone.Value <= 0) continue;
                var length = Math.Floor(Math.Log10(stone.Key) + 1);
                if (stone.Key == 0)
                {
                    if (newDict.ContainsKey(1)) newDict[1] += stone.Value;
                    newDict.TryAdd(1, stone.Value);
                    newDict[0] -= stone.Value;
                } else if (length % 2 == 0)
                {
                    var split = (long) Math.Pow(10, length / 2);
                    if (newDict.ContainsKey(stone.Key / split)) newDict[stone.Key / split] += stone.Value;
                    newDict.TryAdd(stone.Key / split, stone.Value);

                    if (newDict.ContainsKey(stone.Key % split)) newDict[stone.Key % split] += stone.Value;
                    newDict.TryAdd(stone.Key % split, stone.Value);
                    newDict[stone.Key] -= stone.Value;
                    
                }
                else
                {
                    if (newDict.ContainsKey(stone.Key * 2024)) newDict[stone.Key * 2024] += stone.Value;
                    newDict.TryAdd(stone.Key * 2024, stone.Value);
                    newDict[stone.Key] -= stone.Value;
                }
            }
            dict = newDict;
        }

        Console.WriteLine(dict.Sum(keyValuePair => keyValuePair.Value));
    }
}