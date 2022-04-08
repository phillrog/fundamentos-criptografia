using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

string mensagem = "desenvolvedor.io";
byte[] chave = new byte[16];
byte[] initializationVector = new byte[12];
byte[] authTag = new byte[16];

// Gera a chave e o iv
RandomNumberGenerator.Fill(chave);
RandomNumberGenerator.Fill(initializationVector);

// Exibe as informacoes na tela
Console.WriteLine("============== CRIPTOGRAFANDO ==============");
Console.WriteLine("mensagem: {0}", mensagem);
Console.WriteLine();

// converte a mensagem para bytes
byte[] plainBytes = Encoding.UTF8.GetBytes(mensagem);
byte[] cipher = new byte[plainBytes.Length];

// Criptografia
using (var aesgcm = new AesGcm(chave))
    aesgcm.Encrypt(initializationVector, plainBytes, cipher, authTag);

var rsa = RSA.Create();
var pem = File.ReadAllText("rsa-public-key.pem");
rsa.ImportFromPem(pem);
var senha = rsa.Encrypt(chave, RSAEncryptionPadding.Pkcs1);

var conteudoCriptografia = new
{
    cipher,
    initializationVector,
    authTag,
    senha
};
Console.WriteLine(JsonSerializer.Serialize(conteudoCriptografia, new JsonSerializerOptions() { WriteIndented = true }));


Console.WriteLine("============== DESCRIPTOGRAFANDO ==============");

rsa = RSA.Create();
pem = File.ReadAllText("rsa-private-key.pem");
rsa.ImportFromPem(pem);

var decryptedBytes = new byte[cipher.Length];
var senhaOriginal = rsa.Decrypt(conteudoCriptografia.senha, RSAEncryptionPadding.Pkcs1);
using (var aesgcm = new AesGcm(senhaOriginal))
    aesgcm.Decrypt(conteudoCriptografia.initializationVector, conteudoCriptografia.cipher, conteudoCriptografia.authTag, decryptedBytes);

var decryptedText = Encoding.UTF8.GetString(decryptedBytes);
Console.WriteLine("mensagem: {0}", decryptedText);
