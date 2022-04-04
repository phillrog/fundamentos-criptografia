#r "nuget: Blake3, 0.5.0"

using System.Text;

var mensagens = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

foreach (var mensagem in mensagens)
{
    var hash = Blake3.Hasher.Hash(Encoding.UTF8.GetBytes(mensagem));
    Console.WriteLine("Blake3: {0} - {1}", mensagem, hash);
}