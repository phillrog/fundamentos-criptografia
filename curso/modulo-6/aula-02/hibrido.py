from os import urandom
from Crypto.PublicKey import RSA
from Crypto import Cipher
from Crypto.Cipher import AES
from Crypto.Cipher import PKCS1_OAEP
from Crypto.Util.Padding import pad, unpad
from tabulate import tabulate
from base64 import urlsafe_b64decode, urlsafe_b64encode
import binascii
import json

print('============== CRIPTOGRAFANDO ==============\n')

secretKey = urandom(16)
iv = urandom(12)

mensagem = b'desenvolvedor.io'

aes = AES.new(secretKey, AES.MODE_GCM, iv)
data = aes.encrypt_and_digest(pad(mensagem, AES.block_size))
tag = data[1]
cipher = data[0]

dados = {
    'mensagem': mensagem.decode(),
    'senha': urlsafe_b64encode(secretKey).decode(),
    'initialization vector': urlsafe_b64encode(iv).decode(),
    'tag': urlsafe_b64encode(tag).decode(),
    'cipher': urlsafe_b64encode(cipher).decode(),
}

print(tabulate(dados.items(), tablefmt='fancy_grid'))


pem = open('rsa-public-key.pem','r')
parDeChaves = RSA.import_key(pem.read())
chavePublica = parDeChaves.publickey()

encryptor = PKCS1_OAEP.new(chavePublica)
senhaCriptografada = encryptor.encrypt(secretKey)

conteudoCriptografado = {
    'iv': urlsafe_b64encode(iv).decode(), 
    'tag': urlsafe_b64encode(tag).decode(), 
    'cipher': urlsafe_b64encode(cipher).decode(), 
    'pwd': urlsafe_b64encode(senhaCriptografada).decode()
}

print('\nEnviar ao destinatario: \n')
print(json.dumps(conteudoCriptografado, indent=4))

print('\n\n============== DESCRIPTOGRAFANDO ==============\n')


pem = open('rsa-private-key.pem','r')
parDeChaves = RSA.import_key(pem.read())

encryptor = PKCS1_OAEP.new(parDeChaves)
senhaOriginal = encryptor.decrypt(urlsafe_b64decode(conteudoCriptografado["pwd"]))

aes = AES.new(senhaOriginal, AES.MODE_GCM, urlsafe_b64decode(conteudoCriptografado['iv']))
decrypted = aes.decrypt_and_verify(urlsafe_b64decode(conteudoCriptografado['cipher']), urlsafe_b64decode(conteudoCriptografado['tag']))

plainText = unpad(decrypted, AES.block_size)
print('Plain text:', plainText.decode())
