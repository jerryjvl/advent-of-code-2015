using System.Text.RegularExpressions;
using System.Xml;

var lines = File.ReadAllLines("input.txt");

bool[,] map = new bool[1000, 1000];

var instruction = new Regex(
    "^(toggle|turn on|turn off) ([0-9]+),([0-9]+) through ([0-9]+),([0-9]+)$");
foreach (var line in lines)
{
    var match = instruction.Match(line);

    var x1 = int.Parse(match.Groups[2].Value);
    var y1 = int.Parse(match.Groups[3].Value);
    var x2 = int.Parse(match.Groups[4].Value);
    var y2 = int.Parse(match.Groups[5].Value);

    for (int ix = x1; ix <= x2; ix++)
        for (int iy = y1; iy <= y2; iy++)
            switch (match.Groups[1].Value)
            {
                case "toggle":
                    map[ix, iy] = !map[ix, iy];
                    break;
                case "turn on":
                    map[ix, iy] = true;
                    break;
                case "turn off":
                    map[ix, iy] = false;
                    break;
            }
}

long total = 0;
for (int iy = 0; iy < 1000; iy++)
    for (int ix = 0; ix < 1000; ix++)
        total += map[ix, iy] ? 1 : 0;
Console.WriteLine(total);


int[,] map2 = new int[1000, 1000];

foreach (var line in lines)
{
    var match = instruction.Match(line);

    var x1 = int.Parse(match.Groups[2].Value);
    var y1 = int.Parse(match.Groups[3].Value);
    var x2 = int.Parse(match.Groups[4].Value);
    var y2 = int.Parse(match.Groups[5].Value);

    for (int ix = x1; ix <= x2; ix++)
        for (int iy = y1; iy <= y2; iy++)
            switch (match.Groups[1].Value)
            {
                case "toggle":
                    map2[ix, iy] += 2;
                    break;
                case "turn on":
                    map2[ix, iy] += 1;
                    break;
                case "turn off":
                    map2[ix, iy] = Math.Max(0, map2[ix, iy] - 1);
                    break;
            }
}

total = 0;
for (int iy = 0; iy < 1000; iy++)
    for (int ix = 0; ix < 1000; ix++)
        total += map2[ix, iy];
Console.WriteLine(total);
