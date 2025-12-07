var lines = File.ReadAllLines("input.txt");

// Find the floor
Console.WriteLine(lines[0].Select(ch => ch == '(' ? 1 : -1).Sum());

// Find the index (+1) where we go into the basement
var sum = 0;
var deltas = lines[0].Select(ch => ch == '(' ? 1 : -1).ToArray();
for (int ix = 0; ix < deltas.Length; ix++)
{
    sum += deltas[ix];
    if (sum < 0)
    {
        Console.WriteLine(ix + 1);
        break;
    }
}
