using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

ECDsa ec = ECDsa.Create(ECCurve.NamedCurves.nistP256);
var parametros = ec.ExportParameters(true);
Console.WriteLine($"Informacoes da chave:");
var detalhesParametros = new
{
    Curve = "P-256",
    parametros.D,
    Q = new
    {
        parametros.Q.X,
        parametros.Q.Y

    }
};
var mensagem = "desenvolvedor.io";
Console.WriteLine(JsonSerializer.Serialize(detalhesParametros, new JsonSerializerOptions() { WriteIndented = true }));
var assinatura = ec.SignData(Encoding.UTF8.GetBytes(mensagem), HashAlgorithmName.SHA256);

Console.WriteLine($"Assinatura da mensagem {mensagem}: {Convert.ToHexString(assinatura)}");

var assinaturaValida = ec.VerifyData(Encoding.UTF8.GetBytes(mensagem), assinatura, HashAlgorithmName.SHA256);
Console.WriteLine($"Assinatura esta valida: {assinaturaValida}");
