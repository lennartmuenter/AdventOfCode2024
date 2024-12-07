namespace AdventOfCode2024;

public class Day1
{
    public static void Run()
    {
        Console.WriteLine("Hello, World!");
        List<int> left = new List<int>();
        List<int> right = new List<int>();
        int count = 0;
        File.ReadLines("../../../../csharp/day1.txt").ToList().ForEach(x => x.Split("   ").ToList().ForEach(x => { if (count % 2 == 0) {left.Add(int.Parse(x));} else {right.Add(int.Parse(x));} count++; }));

        left.Sort();
        right.Sort();

        Dictionary<int, int> occurances = new Dictionary<int, int>();
        foreach (var x in right.GroupBy(x => x))
        {
            occurances[x.Key] = x.Count();
        }

        int sol1 = 0;
        int sol2 = 0;
        for (int i = 0; i < left.Count; i++)
        {
            sol1 += Math.Abs(left[i] - right[i]);
            if (occurances.ContainsKey(left[i]))
            {
                sol2 += occurances[left[i]] * left[i];
            }
        }

        Console.WriteLine(sol1);
        Console.WriteLine(sol2);
    }
}