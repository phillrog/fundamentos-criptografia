using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace OpenSSL.Net3
{
    internal class DemoRSA
    {
        public static void Demo()
        {
            var cipher = CarregarPemPublicaECriptografar();
            CarregarPemPrivadaEDescriptografar(cipher);
            cipher = CarregarPemPublicaNoFormatoRsaeCriptografar();
            CarregarPemPrivadaEDescriptografar(cipher);
        }

        private static byte[] CarregarPemPublicaNoFormatoRsaeCriptografar()
        {
            var pem = File.ReadAllLines("rsaformat-public-key.pem").Skip(1).Reverse().Skip(1).Reverse();
            var rsa = RSA.Create();
            rsa.ImportRSAPublicKey(Convert.FromBase64String(string.Join(string.Empty, pem)), out _);
            var cipher = rsa.Encrypt(Encoding.Default.GetBytes("desenvolvedor.io"), RSAEncryptionPadding.Pkcs1);
            Console.WriteLine(string.Join(":", cipher));
            return cipher;
        }

        private static void CarregarPemPrivadaEDescriptografar(byte[] cipher)
        {
            var pem = File.ReadAllLines("rsa-private-key.pem").Skip(1).Reverse().Skip(1).Reverse();
            var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(string.Join(string.Empty, pem)), out _);

            Console.WriteLine(Encoding.Default.GetString(rsa.Decrypt(cipher, RSAEncryptionPadding.Pkcs1)));
        }

        private static byte[] CarregarPemPublicaECriptografar()
        {
            var pem = File.ReadAllLines("rsa-public-key.pem").Skip(1).Reverse().Skip(1).Reverse();
            var rsa = RSA.Create();
            rsa.ImportSubjectPublicKeyInfo(Convert.FromBase64String(string.Join(string.Empty, pem)), out _);
            var cipher = rsa.Encrypt(Encoding.Default.GetBytes("desenvolvedor.io"), RSAEncryptionPadding.Pkcs1);
            Console.WriteLine(string.Join(":", cipher));
            return cipher;
        }
    }
}
