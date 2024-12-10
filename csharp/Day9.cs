namespace AdventOfCode2024;

public class Day9
{
    public static void Run()
    {
        var input = File.ReadAllText("../../../../csharp/day9.txt");
        var result = new List<int>();
        
        var id = 0;
        for (var i = 0; i < input.Length; i++)
        {
            var val = int.Parse(input[i].ToString());
            if (i % 2 == 0)
            {
                for(var j = 0; j < val; j++)
                {
                    result.Add(id);
                }
                id++;
            }
            else
            {
                for (var j = 0; j < val; j++)
                {
                    result.Add(-1);
                }
            }
        }
        result.ForEach(e =>
        {
            if (e < 0)
            {
                Console.Write(". ");
            }
            else
            {
                Console.Write(e + " ");
            }
        });
        Console.WriteLine();

        while (result.Contains(-1))
        {
            result[result.IndexOf(-1)] = result[^1];
            result.RemoveAt(result.Count - 1);
        }
        
        var sum = 0L;
        for (var i = 0; i < result.Count; i++)
        {
            Console.WriteLine(i * result[i]);
            sum += i * result[i];
        }
        
        Console.WriteLine(sum);
    }
}