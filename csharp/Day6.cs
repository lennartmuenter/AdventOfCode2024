using System.Text;

namespace AdventOfCode2024;

public class Day6
{
    public static void Run()
    {
        var maze = File.ReadAllText("../../../../csharp/day6.txt").Split("\n").ToArray();
        var position = (0, 0);
        for (var y = 0; y < maze.Length; y++)
        {
            var x = maze[y].ToList().IndexOf('^');
            if(x >= 0) position = (y, x);
        }
        
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
                maze[position.Item1] = new StringBuilder(maze[position.Item1]) { [position.Item2] = '0' }.ToString();
                position = next;
            }
            next = (position.Item1 + direction.Item1, position.Item2 + direction.Item2);
        }

        var sum = maze.Sum(row => row.Count(letter => letter == '0')) + 1;
        Console.WriteLine(sum);
    }
}