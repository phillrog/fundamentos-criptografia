from os import urandom
from Crypto.Cipher import AES
from Crypto.Util.Padding import pad, unpad
from tabulate import tabulate
from base64 import urlsafe_b64encode
import json

print('============== CRIPTOGRAFANDO ==============\n')

secretKey = urandom(16)
iv = urandom(16)

mensagem = b'desenvolvedor.io'

aes = AES.new(secretKey, AES.MODE_CBC, iv)
cipher = aes.encrypt(pad(mensagem, AES.block_size))


dados = {
    'mensagem': mensagem.decode(),
    'senha': urlsafe_b64encode(secretKey).decode(),
    'Initialization Vector': urlsafe_b64encode(iv).decode(),
    'Cipher': urlsafe_b64encode(cipher).decode(),
}

print(tabulate(dados.items(), tablefmt='fancy_grid'))

print('\nEnviar ao destinatario: \n')
print(json.dumps({'iv': urlsafe_b64encode(iv).decode(), 'cipher': urlsafe_b64encode(cipher).decode()}))

print('\n\n============== DESCRIPTOGRAFANDO ==============\n')

aes = AES.new(secretKey, AES.MODE_CBC, iv)
plainText = unpad(aes.decrypt(cipher), AES.block_size)
print('Plain text:', plainText.decode())
