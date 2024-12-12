using System.Collections.Concurrent;
using System.Data;

namespace AdventOfCode2024;

public class Day11
{
    private static readonly ConcurrentDictionary<long, (long, long)> _cache = new();
    private static long _count = 0;
    public static void Run()
    {
        var stones = File.ReadAllText("../../../../csharp/day11.txt").Trim().Split(" ").Select(long.Parse).ToList();
        const int depth = 40;
        const int chunk = 5;
        Thread lastThr = null;
        var watch = System.Diagnostics.Stopwatch.StartNew();
        stones.ForEach(stone =>
        {
            var t = new Thread(() => check(stone, chunk, depth - chunk));
            t.Start();
            t.Join();
            lastThr = t;
        });
        watch.Stop();
        Console.WriteLine(_count);
        Console.WriteLine(watch.ElapsedMilliseconds);
    }

    private static void check(long start, int depth, int remainingDepth)
    {
        var stones = new List<long> { start };
        for (var currentDepth = 0; currentDepth < depth; currentDepth++)
        {
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
                    _cache.TryAdd(num, (stones[i], stones[i + 1]));
                    i++;
                }
                else
                {
                    stones[i] *= 2024;
                }
            }
        }
        if (remainingDepth == 0)
        {
            _count += stones.Count;
        }
        else
        {
            stones.ForEach(stone =>
            {
                check(stone, depth, remainingDepth - depth);
            });
        }
    }
}