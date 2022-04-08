using System.Security.Cryptography;
using System.Text;
using System.Text.Json;


Console.WriteLine("========================== CARREGANDO CHAVE PRIVADA =========================");
ECDsa ec = ECDsa.Create(ECCurve.NamedCurves.nistP256);
var pem = File.ReadAllText("ecc-private-key.pem");
ec.ImportFromPem(pem);
var parametros = ec.ExportParameters(true);
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
Console.WriteLine($"Informacoes da chave:");
Console.WriteLine(JsonSerializer.Serialize(detalhesParametros, new JsonSerializerOptions() { WriteIndented = true }));

Console.WriteLine("========================== ASSINAR DIGITALMENTE =========================");
var assinatura = ec.SignData(Encoding.UTF8.GetBytes("desenvolvedor.io"), HashAlgorithmName.SHA256);
Console.WriteLine($"Assinatura: {Convert.ToHexString(assinatura)}");


Console.WriteLine("========================== CARREGAR CHAVE PUBLICA =========================");

ec = ECDsa.Create();
pem = File.ReadAllText("ecc-public-key.pem");
ec.ImportFromPem(pem);

Console.WriteLine("Utilizando objeto ECDsa apenas com chave publica");


Console.WriteLine("========================== VALIDAR ASSINATURA COM CHAVE PUBLICA =========================");
Console.WriteLine($"Assinatura esta valida: {ec.VerifyData(Encoding.UTF8.GetBytes("desenvolvedor.io"), assinatura, HashAlgorithmName.SHA256)}");
