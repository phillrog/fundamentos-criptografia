using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace OpenSSL.Net3
{
    internal class DemoECC
    {
        public static void Demo()
        {
            var cipher = CarregarPemPrivadaEAssinar();
            CarregarPemPublicaEValidarAssinatura(cipher);
        }
        
        private static void CarregarPemPublicaEValidarAssinatura(byte[] cipher)
        {
            var pem = File.ReadAllLines("ecc-public-key.pem").Skip(1).Reverse().Skip(1).Reverse();
            var ecc = ECDsa.Create();
            ecc.ImportSubjectPublicKeyInfo(Convert.FromBase64String(string.Join(string.Empty, pem)), out _);

            Console.WriteLine(ecc.VerifyData(Encoding.Default.GetBytes("desenvolvedor.io"), cipher, HashAlgorithmName.SHA256));
        }

        private static byte[] CarregarPemPrivadaEAssinar()
        {
            var pem = File.ReadAllLines("ecc-private-key.pem").Skip(1).Reverse().Skip(1).Reverse();
            var ecc = ECDsa.Create();
            ecc.ImportECPrivateKey(Convert.FromBase64String(string.Join(string.Empty, pem)), out _);

            var assinatura = ecc.SignData(Encoding.Default.GetBytes("desenvolvedor.io"), HashAlgorithmName.SHA256);
            Console.WriteLine(string.Join(":", assinatura));
            return assinatura;
        }
    }
}