var lines = File.ReadAllLines("input.txt");

long total = 0;
foreach (var word in lines)
{
    if (word.Count(ch => "aeiou".Contains(ch)) < 3) continue;
    if (word.SkipLast(1).Zip(word.Skip(1)).All(pair => pair.First != pair.Second)) continue;
    if (((string[])["ab", "cd", "pq", "xy"]).Any(word.Contains)) continue;

    total++;
}
Console.WriteLine(total);

total = 0;
foreach (var word in lines)
{
    bool skip = true;
    for (int ix = 0; ix < word.Length - 2; ix++)
        skip &= word.IndexOf(word.Substring(ix, 2), ix + 2) == -1;
    if (skip) continue;
    if (word.SkipLast(2).Zip(word.Skip(2)).All(pair => pair.First != pair.Second)) continue;

    total++;
}
Console.WriteLine(total);
