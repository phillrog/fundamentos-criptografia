using System.Security.Cryptography;
using System.Text;

var mensagem = "desenvolvedorio";
var hash = new StringBuilder();

using (var md5Hash = MD5.Create())
{
    var crypto = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(mensagem));

    foreach (var theByte in crypto)
        hash.Append(theByte.ToString("x2"));
}

Console.WriteLine("Mensagem: {0}", mensagem);
Console.WriteLine("Hash Value: {0}", hash);