from os import urandom
from Crypto import Cipher
from Crypto.Cipher import AES
from Crypto.Util.Padding import pad, unpad
from tabulate import tabulate
from base64 import urlsafe_b64encode
import json

print('============== CRIPTOGRAFANDO ==============\n')

secretKey = urandom(16)
iv = urandom(12)

mensagem = b'desenvolvedor.io aeouaoeu 2'

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

print('\nEnviar ao destinatario: \n')
print(json.dumps({'iv': urlsafe_b64encode(iv).decode(), 'tag': urlsafe_b64encode(tag).decode(), 'cipher': urlsafe_b64encode(cipher).decode()}))

print('\n\n============== DESCRIPTOGRAFANDO ==============\n')

aes = AES.new(secretKey, AES.MODE_GCM, iv)
decrypted = aes.decrypt_and_verify(cipher, tag)

plainText = unpad(decrypted, AES.block_size)
print('Plain text:', decrypted)
