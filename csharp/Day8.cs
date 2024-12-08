namespace AdventOfCode2024;

public class Day8
{
    public static void Run()
    {
        var map = File.ReadLines("../../../../csharp/day8.txt").Select(line => line.ToCharArray()).ToArray();
        var dict = new Dictionary<char, List<(int, int)>>();
        var antiPart1 = new HashSet<(int, int)>();
        var antiPart2 = new HashSet<(int, int)>();

        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                if (map[y][x] == '.') continue;
                dict.TryAdd(map[y][x], []);
                dict[map[y][x]].Add((y, x));
            }
        }

        foreach (var keyValuePair in dict)
        {
            foreach (var currentPoint in keyValuePair.Value)
            {
                foreach (var point in keyValuePair.Value)
                {
                    if (currentPoint == point) continue;
                    var newAnti = (point.Item1 - currentPoint.Item1 + point.Item1,
                        point.Item2 - currentPoint.Item2 + point.Item2);
                    if (newAnti.Item1 >= 0 && newAnti.Item1 < map.Length && newAnti.Item2 >= 0 &&
                        newAnti.Item2 < map.Length) antiPart1.Add(newAnti);
                    antiPart2.Add(currentPoint);
                    while (newAnti.Item1 >= 0 && newAnti.Item1 < map.Length && newAnti.Item2 >= 0 &&
                           newAnti.Item2 < map.Length)
                    {
                        antiPart2.Add(newAnti);
                        newAnti = (point.Item1 - currentPoint.Item1 + newAnti.Item1,
                            point.Item2 - currentPoint.Item2 + newAnti.Item2);
                    }
                }
            }
        }

        Console.WriteLine(antiPart1.Count);
        Console.WriteLine(antiPart2.Count);
    }
}