namespace AdventOfCode2024;

public class Day2
{
    public static void Run()
    {
        var countPart1 = 0;
        var countPart2 = 0;
        File.ReadLines("../../../../csharp/day2.txt").ToList().ForEach(line =>
        {
            var numbers = line.Split(" ").Select(int.Parse).ToList();
            if (numbers.First() > numbers.Last()) numbers.Reverse();

            if (CheckRow(numbers) > 0)
            {
                countPart1++;
                countPart2++;
                return;
            }
            for (var index = 0; index < numbers.Count; index++)
            {
                var tmp = numbers.ToList();
                tmp.RemoveAt(index);

                if (CheckRow(tmp) <= 0) continue;
                countPart2++;
                return;
            }
        });
        Console.WriteLine($"Part 1: {countPart1}");
        Console.WriteLine($"Part 2: {countPart2}");
    }

    private static int CheckRow(List<int> numbers)
    {
        for (var index = 0; index < numbers.Count - 1; index++)
        {
            if (numbers[index] >= numbers[index + 1] || numbers[index] + 3 < numbers[index + 1])
            {
                return 0;
            }
        }

        return 1;
    }
}