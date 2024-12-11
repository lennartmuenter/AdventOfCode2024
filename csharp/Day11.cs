namespace AdventOfCode2024;

public class Day11
{
    public static void Run()
    {
        var stones = File.ReadAllText("../../../../csharp/day11.txt").Trim().Split(" ").Select(long.Parse).ToList();
        for (var count = 0; count < 25; count++)
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
                    var num = stones[i];
                    var split = (long)Math.Pow(10, length / 2);
                    stones[i] = num / split;
                    stones.Insert(i+1, num % split);
                    i++;
                }
                else
                {
                    stones[i] *= 2024;
                }
            }
        }
        Console.WriteLine(stones.Count);
    }
}