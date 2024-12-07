using System.Text;

namespace AdventOfCode2024;

public class Day6
{
    public static void Run()
    {
        var maze = File.ReadAllText("../../../../csharp/day6.txt").Split("\n").Select(line => line.ToCharArray()).ToArray();
        var defaultPosition = (0, 0);
        var position = (0, 0);
        for (var y = 0; y < maze.Length; y++)
        {
            var x = maze[y].ToList().IndexOf('^');
            if (x < 0) continue;
            position = (y, x);
            defaultPosition = (y, x);
        }
        
        var walkHistory = new HashSet<(int, int)>([position]);
        var direction = (-1, 0);
        var next = (position.Item1 + direction.Item1, position.Item2 + direction.Item2);
        while (next.Item1 >= 0 && next.Item1 < maze.Length && next.Item2 >= 0 && next.Item2 < maze.Length)
        {
            if (maze[next.Item1][next.Item2] == '#')
            {
                switch (direction)
                {
                    case (-1, 0): direction = (0, 1); break;
                    case (0, 1): direction = (1, 0); break;
                    case (1, 0): direction = (0, -1); break;
                    case (0, -1): direction = (-1, 0); break;
                }
            }
            else
            {
                position = next;
                walkHistory.Add(position);
            }
            next = (position.Item1 + direction.Item1, position.Item2 + direction.Item2);
        }
        
        Console.WriteLine(walkHistory.Count);
        Console.WriteLine(Part2(walkHistory, maze, defaultPosition));
    }

    private static int Part2(HashSet<(int, int)> posibilities, char[][] maze, (int, int) defaultPosition)
    {
        var sum = 0;
        foreach (var pos in posibilities)
        {
            maze[pos.Item1][pos.Item2] = '#';
            var walkHistory = new List<(int, int, (int, int))>();
            var direction = (-1, 0);
            
            var position = defaultPosition;
            
            var next = (position.Item1 + direction.Item1, position.Item2 + direction.Item2);
            while (next.Item1 >= 0 && next.Item1 < maze.Length && next.Item2 >= 0 && next.Item2 < maze.Length)
            {
                if (maze[next.Item1][next.Item2] == '#')
                {
                    switch (direction)
                    {
                        case (-1, 0): direction = (0, 1); break;
                        case (0, 1): direction = (1, 0); break;
                        case (1, 0): direction = (0, -1); break;
                        case (0, -1): direction = (-1, 0); break;
                    }
                }
                else
                {
                    position = next;
                    if (walkHistory.Contains((position.Item1, position.Item2, (direction))))
                    {
                        sum++;
                        goto checkNext;
                    }
                    walkHistory.Add((position.Item1, position.Item2, direction));
                }
                next = (position.Item1 + direction.Item1, position.Item2 + direction.Item2);
            }
            checkNext:{}
            maze[pos.Item1][pos.Item2] = '.';
        }

        return sum;
    }
}