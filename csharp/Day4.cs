namespace AdventOfCode2024;

public class Day4
{
    public static void Run()
    {
        var countPart1 = 0;
        var countPart2 = 0;
        var field = File.ReadLines("../../../../csharp/day4.txt").ToArray();
        for (var y = 0; y < field.Length; y++)
        {
            for (var x = 0; x < field[y].Length; x++)
            {
                switch (field[y][x])
                {
                    case 'X':
                        countPart1 += CheckX(field, y, x);
                        break;
                    case 'A':
                        countPart2 += CheckA(field, y, x);
                        break;
                }
            }
        }

        Console.WriteLine(countPart1);
        Console.WriteLine(countPart2);
    }

    private static int CheckX(string[] field, int y, int x)
    {
        var count = 0;
        if (x - 3 >= 0 && field[y][x - 1] == 'M' && field[y][x - 2] == 'A' && field[y][x - 3] == 'S') count++;
        if (x + 3 < field.Length && field[y][x + 1] == 'M' && field[y][x + 2] == 'A' && field[y][x + 3] == 'S') count++;
        if (y - 3 >= 0 && field[y - 1][x] == 'M' && field[y - 2][x] == 'A' && field[y - 3][x] == 'S') count++;
        if (y + 3 < field.Length && field[y + 1][x] == 'M' && field[y + 2][x] == 'A' && field[y + 3][x] == 'S') count++;

        if (y - 3 >= 0 && x - 3 >= 0 && field[y - 1][x - 1] == 'M' && field[y - 2][x - 2] == 'A' &&
            field[y - 3][x - 3] == 'S') count++;
        if (y + 3 < field.Length && x + 3 < field.Length && field[y + 1][x + 1] == 'M' && field[y + 2][x + 2] == 'A' &&
            field[y + 3][x + 3] == 'S') count++;
        if (y - 3 >= 0 && x + 3 < field.Length && field[y - 1][x + 1] == 'M' && field[y - 2][x + 2] == 'A' &&
            field[y - 3][x + 3] == 'S') count++;
        if (y + 3 < field.Length && x - 3 >= 0 && field[y + 1][x - 1] == 'M' && field[y + 2][x - 2] == 'A' &&
            field[y + 3][x - 3] == 'S') count++;

        return count;
    }

    private static int CheckA(string[] field, int y, int x)
    {
        if (y - 1 < 0 || x - 1 < 0 || y + 1 >= field.Length || x + 1 >= field.Length ||
            Math.Abs(field[y - 1][x - 1] - field[y + 1][x + 1]) != 'S' - 'M') return 0;
        if (y - 1 >= 0 && x - 1 >= 0 && y + 1 < field.Length && x + 1 < field.Length && Math.Abs(field[y + 1][x - 1] - field[y - 1][x + 1]) == 'S' - 'M') return 1;
        return 0;
    }
}