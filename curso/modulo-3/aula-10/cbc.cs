using System.Security.Cryptography;
using System.Text;

Console.WriteLine("============== CRIPTOGRAFANDO ==============");
var mensagem = "desenvolvedor.io";
RandomNumberGenerator random = RandomNumberGenerator.Create();
byte[] chave = new byte[16];
byte[] iv = new byte[16];

random.GetBytes(chave);
random.GetBytes(iv);

Aes aes = Aes.Create();
aes.Key = chave;
aes.IV = iv;
var ciphertext = aes.EncryptCbc(Encoding.UTF8.GetBytes(mensagem), iv, PaddingMode.PKCS7);

Console.WriteLine("Mensagem: {0}", mensagem);
Console.WriteLine("Senha: {0}", Convert.ToHexString(chave));
Console.WriteLine("Cipher: {0}", Convert.ToHexString(ciphertext));
Console.WriteLine();

Console.WriteLine("============== DESCRIPTOGRAFANDO ==============");

Console.WriteLine(Encoding.UTF8.GetString(aes.DecryptCbc(ciphertext, iv, PaddingMode.PKCS7)));