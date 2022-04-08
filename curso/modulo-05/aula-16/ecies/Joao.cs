using System.Security.Cryptography;
using System.Text;
using Ecc;

public class Joao
{
    public byte[] ChavePublica { get; set; }
    private byte[] ChavePrivada { get; set; }
    public Joao()
    {
        using var ecdh = new ECDiffieHellmanCng(ECCurve.NamedCurves.nistP256);
        ecdh.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
        ecdh.HashAlgorithm = CngAlgorithm.Sha256;

        ChavePublica = ecdh.PublicKey.ToByteArray();
        ChavePrivada = ecdh.Key.Export(CngKeyBlobFormat.EccPrivateBlob);
    }
    public string Descriptografar(TrocaMensagem mensagem, byte[] chavePublica)
    {
        var chaveCompartilhada = ChaveCompartilhada(chavePublica);
        Console.WriteLine($"Chave compartilhada gerada por Joao:  {Convert.ToHexString(chaveCompartilhada)}");

        var cipherBytes = Convert.FromBase64String(mensagem.Cipher);
        var decryptedBytes = new byte[cipherBytes.Length];
        // perform decryption
        using (AesGcm aesgcm = new AesGcm(chaveCompartilhada))
            aesgcm.Decrypt(
                Convert.FromBase64String(mensagem.InitializationVector), 
                cipherBytes, 
                Convert.FromBase64String(mensagem.AuthenticationTag), 
                decryptedBytes);

        // convert the byte array to the plain text string
        var clearText = Encoding.UTF8.GetString(decryptedBytes);

        return clearText;
    }

    private byte[] ChaveCompartilhada(byte[] chavePublica)
    {
        using ECDiffieHellmanCng ecdh = new ECDiffieHellmanCng(CngKey.Import(ChavePrivada, CngKeyBlobFormat.EccPrivateBlob));
        ecdh.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
        ecdh.HashAlgorithm = CngAlgorithm.Sha256;

        return ecdh.DeriveKeyMaterial(CngKey.Import(chavePublica, CngKeyBlobFormat.EccPublicBlob));
    }
}