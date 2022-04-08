using System.Text.Json;
using Ecc;

var joao = new Joao();
var maria = new Maria();

var mensagem = "desenvolvedor.io";
Console.WriteLine($"Mensagem: {mensagem}");
var cipherContent = maria.EnviarMensagem(joao.ChavePublica, mensagem);

var clearText = joao.Descriptografar(cipherContent, maria.ChavePublica);

Console.WriteLine($"Cipher content:");
Console.WriteLine(JsonSerializer.Serialize(cipherContent, new JsonSerializerOptions() { WriteIndented = true }));
Console.WriteLine($"Mensagem descriptografada: {clearText}");
