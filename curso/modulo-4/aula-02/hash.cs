using System.Security.Cryptography;
using System.Text;

var mensagem = "desenvolvedorio";
var hash = new StringBuilder();

using (var sha256Hash = SHA256.Create())
{
    var crypto = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(mensagem));

    foreach (var theByte in crypto)
        hash.Append(theByte.ToString("x2"));
}

Console.WriteLine("Mensagem: {0}", mensagem);
Console.WriteLine("Hash: {0}", hash);