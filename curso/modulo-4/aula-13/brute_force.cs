#r "nuget: Blake3, 0.5.0"
#r "nuget: Sodium.Core, 1.2.3"

using System.Security.Cryptography;
using System.Text;
using Sodium;

var MD5 = (string password, out double totaltime, out int count) =>
{
    var seconds = Stopwatch.StartNew();
    var hashCount = 0;
    var bytes = Encoding.ASCII.GetBytes(password);
    var md5 = System.Security.Cryptography.MD5.Create();
    do
    {
        md5.ComputeHash(bytes);
        hashCount++;
    } while (seconds.ElapsedMilliseconds < _time);

    seconds.Stop();
    totaltime = seconds.Elapsed.TotalSeconds;
    count = hashCount;
};

var Blake = (string password, out double totaltime, out int count) =>
{
    var seconds = Stopwatch.StartNew();
    var hashCount = 0;
    var bytes = Encoding.ASCII.GetBytes(password);
    
    do
    {
        Blake3.Hasher.Hash(bytes);
        hashCount++;
    } while (seconds.ElapsedMilliseconds < _time);

    seconds.Stop();
    totaltime = seconds.Elapsed.TotalSeconds;
    count = hashCount;
};

var Sha256 = (string password, out double totaltime, out int count) =>
{
    var shA256Managed = SHA256.Create();
    var bytes = Encoding.ASCII.GetBytes(password);
    
    var seconds = Stopwatch.StartNew();
    var hashCount = 0;
    do
    {
        shA256Managed.ComputeHash(bytes);
        hashCount++;
    } while (seconds.ElapsedMilliseconds < _time);

    seconds.Stop();
    totaltime = seconds.Elapsed.TotalSeconds;
    count = hashCount;
};

var Argon2 = (string password, out double totaltime, out int count) =>
{
    var seconds = Stopwatch.StartNew();
    var hashCount = 0;
    do
    {
        PasswordHash.ArgonHashString(password, PasswordHash.StrengthArgon.Moderate);
        hashCount++;
    } while (seconds.ElapsedMilliseconds < _time);

    seconds.Stop();
    totaltime = seconds.Elapsed.TotalSeconds;
    count = hashCount;
};

long _time = 20_000;
double seconds = 0;
var hashCount = 0;

var password = "Sup3rSecr3t";
Console.WriteLine($"Quantas senhas podem ser hasheadas em 20 segundos?");
Console.WriteLine();
Console.WriteLine("========================================");
Console.WriteLine("            MD5 hashes");
MD5(password, out seconds, out hashCount);
Console.WriteLine($"MD5: {hashCount:N}");

Console.WriteLine();
Console.WriteLine("========================================");
Console.WriteLine("            SHA256 hashes");

Sha256(password, out seconds, out hashCount);
Console.WriteLine($"SHA256: {hashCount:N}");

Console.WriteLine();
Console.WriteLine("========================================");
Console.WriteLine("            BLAKE hashes");

Blake(password, out seconds, out hashCount);
Console.WriteLine($"Blake3: {hashCount:N}");

Console.WriteLine();
Console.WriteLine("========================================");
Console.WriteLine("            Argon2 hashes");

Argon2(password, out seconds, out hashCount);
Console.WriteLine($"Argon2: {hashCount:N}");