namespace AdventOfCode2024;

public class Day9
{
    public static void Run()
    {
        var input = File.ReadAllText("../../../../csharp/day9.txt");
        // length value
        var result = new List<(int,int)>();
        var id = 0;
        for (var i = 0; i < input.Length; i++)
        {
            var val = int.Parse(input[i].ToString());
            if (val > 0) result.Add((val, i % 2 == 0 ? id++ : -1));
        }
        
        var part1 = result.ToList();
        var searchIndex = part1.Count-1;
        while (searchIndex >= 0)
        {
            /*part1.ForEach(e =>
            {
                for (var j = 0; j < e.Item1; j++)
                {
                    if (e.Item2 == -1)
                    {
                        Console.Write(". ");
                    }
                    else
                    {
                        Console.Write(e.Item2 + " ");
                    }
                }
            });
            Console.WriteLine(); */
            for (var i = 0; i < searchIndex; i++)
            {
                if (part1[i].Item2 != -1) continue;
                if (part1[searchIndex].Item2 == -1) break;

                if (part1[i].Item1 == 0)
                {
                    part1.RemoveAt(i);
                    searchIndex--;
                    continue;
                }

                if (part1[i].Item1 - part1[searchIndex].Item1 < 0) continue;
                part1[i] = (part1[i].Item1 - part1[searchIndex].Item1, part1[i].Item2);
                var tmp = part1[searchIndex];
                part1[searchIndex] = (part1[searchIndex].Item1, -1);
                part1.Insert(i, tmp);
                searchIndex++;
                break;
            }
            searchIndex--;
        }
        
        var sumPart1 = 0L;
        var index = 0;
        for (var i = 0; i < part1.Count; i++)
        {
            if (part1[i].Item2 == -1)
            {
                index+= part1[i].Item1;
                continue;
            }
            for (var j = 0; j < part1[i].Item1; j++)
            {
                sumPart1 += index * part1[i].Item2;
                index++;
            }
        }
        
        Console.WriteLine(sumPart1);
    }
}