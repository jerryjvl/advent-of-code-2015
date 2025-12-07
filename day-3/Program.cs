var lines = File.ReadAllLines("input.txt");

var map = new Dictionary<(long, long), int>();
long x = 0;
long y = 0;
map[(x, y)] = 1;
foreach (var dir in lines[0])
{
    switch (dir)
    {
        case '^':
            y--;
            break;
        case 'v':
            y++;
            break;
        case '<':
            x--;
            break;
        case '>':
            x++;
            break;
    }

    int count = 0;
    map.TryGetValue((x, y), out count);
    map[(x, y)] = count + 1;
}
Console.WriteLine(map.Count);

map = new Dictionary<(long, long), int>();
long sx = 0, sy = 0, rx = 0, ry = 0;
map[(0, 0)] = 2;
foreach (var dir in lines[0])
{
    switch (dir)
    {
        case '^':
            sy--;
            break;
        case 'v':
            sy++;
            break;
        case '<':
            sx--;
            break;
        case '>':
            sx++;
            break;
    }

    int count = 0;
    map.TryGetValue((sx, sy), out count);
    map[(sx, sy)] = count + 1;

    (sx, sy, rx, ry) = (rx, ry, sx, sy);
}
Console.WriteLine(map.Count);
