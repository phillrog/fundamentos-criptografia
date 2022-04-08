// Standards for Efficient Cryptography
// https://www.secg.org/sec1-v2.pdf
using System.Globalization;
using System.Numerics;

var hexs = new Dictionary<string, string>()
{
    {
        "Primo"
        , @"00:ff:ff:ff:ff:00:00:00:01:00:00:00:00:00:00:
    00:00:00:00:00:00:ff:ff:ff:ff:ff:ff:ff:ff:ff:
    ff:ff:ff"

    },
    {"A", @"00:ff:ff:ff:ff:00:00:00:01:00:00:00:00:00:00:
    00:00:00:00:00:00:ff:ff:ff:ff:ff:ff:ff:ff:ff:
    ff:ff:fc"},
    {
        "B",
        @"5a:c6:35:d8:aa:3a:93:e7:b3:eb:bd:55:76:98:86:
    bc:65:1d:06:b0:cc:53:b0:f6:3b:ce:3c:3e:27:d2:
    60:4b"
    },
    {
        "G",
        @"04:6b:17:d1:f2:e1:2c:42:47:f8:bc:e6:e5:63:a4:
    40:f2:77:03:7d:81:2d:eb:33:a0:f4:a1:39:45:d8:
    98:c2:96:4f:e3:42:e2:fe:1a:7f:9b:8e:e7:eb:4a:
    7c:0f:9e:16:2b:ce:33:57:6b:31:5e:ce:cb:b6:40:
    68:37:bf:51:f5"
    }
};


foreach (var hex in hexs)
{
    string hex_value = hex.Value.Replace(Environment.NewLine, String.Empty).Replace(":", String.Empty).Replace(" ", String.Empty);
   
    if (hex.Key == "G")
    {
        var xy = hex_value.Substring(2);
        var x = xy.Substring(0, xy.Length / 2);
        var y = xy.Substring(xy.Length / 2);

        var xNumber = BigInteger.Parse(x, NumberStyles.AllowHexSpecifier);
        var YNumber = BigInteger.Parse(y, NumberStyles.AllowHexSpecifier);
        //printing the values
        Console.WriteLine("G: ({0}, {1})", xNumber, YNumber);
    }
    else
    {
        var int_value = BigInteger.Parse(hex_value, NumberStyles.AllowHexSpecifier);
        //printing the values
        Console.WriteLine("{0}: {1}", hex.Key, int_value);
    }

}

