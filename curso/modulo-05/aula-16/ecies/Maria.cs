using System.Security.Cryptography;
using System.Text;

namespace Ecc
{
    public class Maria
    {
        public byte[] ChavePublica { get; set; }
        private byte[] ChavePrivada { get; set; }

        public Maria()
        {
            using var maria = new ECDiffieHellmanCng(ECCurve.NamedCurves.nistP256);
            maria.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
            maria.HashAlgorithm = CngAlgorithm.Sha256;

            ChavePublica = maria.PublicKey.ToByteArray();
            ChavePrivada = maria.Key.Export(CngKeyBlobFormat.EccPrivateBlob);

        }

        public TrocaMensagem EnviarMensagem(byte[] chavePublicaDestinatario, string mensagem)
        {
            var chaveCompartilhada = GerarChave(chavePublicaDestinatario);
            Console.WriteLine($"Chave compartilhada gerada por Maria: {Convert.ToHexString(chaveCompartilhada)}");
            var (cipher, iv, auth) = Criptografar(chaveCompartilhada, mensagem);

            return new TrocaMensagem(Convert.ToBase64String(cipher), Convert.ToBase64String(iv), Convert.ToBase64String(auth));
        }

        private byte[] GerarChave(byte[] chavePublicaDestinatario)
        {
            var maria = new ECDiffieHellmanCng(CngKey.Import(ChavePrivada, CngKeyBlobFormat.EccPrivateBlob));

            var chaveDestinatario = CngKey.Import(chavePublicaDestinatario, CngKeyBlobFormat.EccPublicBlob);

            return maria.DeriveKeyMaterial(chaveDestinatario);
        }

        private (byte[] cipher, byte[] initializationVector, byte[] authTag) Criptografar(byte[] chave, string mensagem)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(mensagem);
            byte[] cipher = new byte[plainBytes.Length];

            byte[] authTag = new byte[16];
            byte[] initializationVector = new byte[12];

            RandomNumberGenerator.Fill(initializationVector);

            using (var aesgcm = new AesGcm(chave))
                aesgcm.Encrypt(initializationVector, plainBytes, cipher, authTag);

            return (cipher, initializationVector, authTag);
            
        }
    }
}