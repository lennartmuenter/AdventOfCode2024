namespace AdventOfCode2024;

public class Day10
{
    public static void Run()
    {
        var map = File.ReadLines("../../../../csharp/day10.txt").Select(line => line.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray()).ToArray();
        var trailheads = new Dictionary<(int x, int y), List<(int, int)>>();
        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                if (map[y][x] == 0)
                {
                    trailheads.Add((y, x), []);
                }
            }
        }

        var sumPart1 = 0;
        var sumPart2 = 0;
        foreach (var trailhead in trailheads)
        {
            NumberOfTrails(trailhead, trailhead.Key, map, 0);
            sumPart1 += trailhead.Value.Distinct().Count();
            sumPart2 += trailhead.Value.Count;
        }
        Console.WriteLine(sumPart1);
        Console.WriteLine(sumPart2);
    }

    private static void NumberOfTrails(KeyValuePair<(int, int), List<(int, int)>> trailhead, (int, int) point, int[][] map, int value)
    {
        if (value == 9)
        {
            trailhead.Value.Add(point);
        }
        if(point.Item1-1 >= 0 && map[point.Item1-1][point.Item2] == value + 1) NumberOfTrails(trailhead, (point.Item1-1, point.Item2), map, value + 1);               //up
        if(point.Item2+1 < map[0].Length && map[point.Item1][point.Item2+1] == value + 1) NumberOfTrails(trailhead, (point.Item1, point.Item2+1), map, value + 1);    //right
        if(point.Item1+1 < map.Length && map[point.Item1+1][point.Item2] == value + 1) NumberOfTrails(trailhead, (point.Item1+1, point.Item2), map, value + 1);       //down
        if(point.Item2-1 >= 0 && map[point.Item1][point.Item2-1] == value + 1) NumberOfTrails(trailhead, (point.Item1, point.Item2-1), map, value + 1);               //left
    }
}