from os import urandom
from Crypto.Cipher import AES
from Crypto.Util.Padding import pad, unpad
import binascii
from tabulate import tabulate


print('============== CRIPTOGRAFANDO ==============\n')

secretKey = urandom(16)
mensagem = b'desenvolvedor.io'

aes = AES.new(secretKey, AES.MODE_ECB)
cipher = aes.encrypt(pad(mensagem, AES.block_size))


dados = {
    'mensagem': mensagem,
    'senha': binascii.hexlify(secretKey),
    'Cipher': binascii.hexlify(cipher),
}

print(tabulate(dados.items(), tablefmt='fancy_grid'))

print('\n\n============== DESCRIPTOGRAFANDO ==============\n')

plainText = unpad(aes.decrypt(cipher), AES.block_size)
print('Plain text:', plainText.decode())
