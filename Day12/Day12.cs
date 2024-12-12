var map = File.ReadAllLines("../../../../Day12/Day12.txt").Select(line => line.ToCharArray()).ToArray();
var visited = new HashSet<(int y, int x)>();
var patches = new List<Patch>();

for (var y = 0; y < map.Length; y++)
{
    for (var x = 0; x < map[y].Length; x++)
    {
        if (visited.Contains((y, x))) continue;
        var set = new HashSet<(int y, int x)>();
        patches.Add(new Patch(map[y][x], set, GetPerimeter((y, x), set, map[y][x]), GetSides(set)));
    }
}

var part1 = 0;
var part2 = 0;
patches.ForEach(patch =>
{
    part1 += patch.Points.Count * patch.Perimeter;
    part2 += patch.Points.Count * patch.Sides;
});

Console.WriteLine(part1);
Console.WriteLine(part2);

return;

int GetPerimeter((int y, int x) current, HashSet<(int y, int x)> points, char kind)
{
    points.Add(current);
    visited.Add(current);
    var perimeter = 0;

    if (current.y - 1 >= 0 && map[current.y - 1][current.x] == kind && !points.Contains((current.y - 1, current.x))) perimeter = GetPerimeter((current.y - 1, current.x), points, kind);
    if (current.x + 1 < map[0].Length && map[current.y][current.x + 1] == kind && !points.Contains((current.y, current.x + 1))) perimeter = GetPerimeter((current.y, current.x + 1), points, kind);
    if (current.y + 1 < map.Length && map[current.y + 1][current.x] == kind && !points.Contains((current.y + 1, current.x))) perimeter = GetPerimeter((current.y + 1, current.x), points, kind);
    if (current.x - 1 >= 0 && map[current.y][current.x - 1] == kind && !points.Contains((current.y, current.x - 1))) perimeter = GetPerimeter((current.y, current.x - 1), points, kind);

    if (current.y - 1 < 0 || map[current.y - 1][current.x] != kind) perimeter++;
    if (current.y + 1 >= map.Length || map[current.y + 1][current.x] != kind) perimeter++;
    if (current.x - 1 < 0 || map[current.y][current.x - 1] != kind) perimeter++;
    if (current.x + 1 >= map.Length || map[current.y][current.x + 1] != kind) perimeter++;

    return perimeter;
}

int GetSides(HashSet<(int y, int x)> points)
{
    var sides = 0;
    foreach (var point in points)
    {
        if (!points.Contains((point.y - 1, point.x)) && !points.Contains((point.y, point.x + 1)) || points.Contains((point.y - 1, point.x)) && points.Contains((point.y, point.x + 1)) && !points.Contains((point.y - 1, point.x + 1))) sides++;
        if (!points.Contains((point.y - 1, point.x)) && !points.Contains((point.y, point.x - 1)) || points.Contains((point.y - 1, point.x)) && points.Contains((point.y, point.x - 1)) && !points.Contains((point.y - 1, point.x - 1))) sides++;
        if (!points.Contains((point.y + 1, point.x)) && !points.Contains((point.y, point.x + 1)) || points.Contains((point.y + 1, point.x)) && points.Contains((point.y, point.x + 1)) && !points.Contains((point.y + 1, point.x + 1))) sides++;
        if (!points.Contains((point.y + 1, point.x)) && !points.Contains((point.y, point.x - 1)) || points.Contains((point.y + 1, point.x)) && points.Contains((point.y, point.x - 1)) && !points.Contains((point.y + 1, point.x - 1))) sides++;
    }
    return sides;
}

internal record Patch(char Key, HashSet<(int y, int x)> Points, int Perimeter, int Sides);