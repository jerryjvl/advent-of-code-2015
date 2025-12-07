using System.Collections.Immutable;

var lines = File.ReadAllLines("input.txt");

var packages = lines.Select(line =>
    line.Split('x').Select(num => long.Parse(num)).Order().ToArray());

long paper = 0;
long ribbon = 0;
foreach (var package in packages)
{
    long l = package[0], w = package[1], h = package[2];
    long[] s = [l*w, w*h, h*l];
    paper += s[0] * 3 + s[1] * 2 + s[2] * 2;

    ribbon += (l + w) * 2 + (l * w * h);
}

Console.WriteLine(paper);
Console.WriteLine(ribbon);
