using System.Security.Cryptography;
using System.Text;
using System.IO;

RandomNumberGenerator random = RandomNumberGenerator.Create();
byte[] data = new byte[256];
random.GetBytes(data);

var sb = new StringBuilder("new byte[] { ");
foreach (var b in data)
    sb.Append(b + ", ");
sb.Append("}");

Console.WriteLine("Array: {0}", sb.ToString());

using (MemoryStream Stream = new MemoryStream(data))
{
    using (StreamReader streamReader = new StreamReader(Stream))
    {
        Console.WriteLine("String: {0}", streamReader.ReadToEnd());
    }
}
