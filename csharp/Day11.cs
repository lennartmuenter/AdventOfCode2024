namespace AdventOfCode2024;

public class Day11
{
    private static Dictionary<long, (long, long)> _cache = new Dictionary<long, (long, long)>();
    public static void Run()
    {
        var stones = File.ReadAllText("../../../../csharp/day11.txt").Trim().Split(" ").Select(long.Parse).ToList();
        var count = stones.Select(stone => check(stone, 75)).Sum();
        Console.WriteLine(count);
    }

    private static long check(long start, int depth)
    {
        var stones = new List<long>();
        stones.Add(start);
        for (var count = 0; count < depth; count++)
        {
            Console.WriteLine(count);
            for (var i = 0; i < stones.Count; i++)
            {
                var length = Math.Floor(Math.Log10(stones[i]) + 1);
                if (stones[i] == 0)
                {
                    stones[i] = 1;
                } else if (length % 2 == 0)
                {
                    if (_cache.ContainsKey(stones[i]))
                    {
                        var key = stones[i];
                        stones[i] = _cache[key].Item1;
                        stones.Insert(++i, _cache[key].Item2);
                        continue;
                    }
                    var num = stones[i];
                    var split = (long)Math.Pow(10, length / 2);
                    stones[i] = num / split;
                    stones.Insert(i+1, num % split);
                    _cache.Add(num, (stones[i], stones[i+1]));
                    i++;
                }
                else
                {
                    stones[i] *= 2024;
                }
            }
        }

        return stones.Count;
    }
}