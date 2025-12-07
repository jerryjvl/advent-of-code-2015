using System.Security.Cryptography;
using System.Text;

var lines = File.ReadAllLines("input.txt");
var prefix = lines[0];

for (long num = 1; num < long.MaxValue; num++)
{
    var value = prefix + num.ToString();
    var bytes = MD5.HashData(Encoding.UTF8.GetBytes(value));
    if (bytes[0] == 0 && bytes[1] == 0 && (bytes[2] & 0xF0) == 0)
    {
        Console.WriteLine(num);
        break;
    }
}

for (long num = 1; num < long.MaxValue; num++)
{
    var value = prefix + num.ToString();
    var bytes = MD5.HashData(Encoding.UTF8.GetBytes(value));
    if (bytes[0] == 0 && bytes[1] == 0 && bytes[2]  == 0)
    {
        Console.WriteLine(num);
        break;
    }
}
