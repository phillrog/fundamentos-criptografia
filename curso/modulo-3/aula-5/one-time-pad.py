import secrets
import binascii

def gerar_chave(n):
    bytearray = []
    aleatorio = secrets.SystemRandom()
    for i in range(n):
        bytearray.append(aleatorio.randint(0, 255))
    return bytes(bytearray)

def xor(chave, message):
    length = len(message)
    return bytes([chave[i] ^ message[i] for i in range(length)])

message = "desenvolvedor.io"
message = message.encode()
chave = gerar_chave(len(message))
cipher = xor(chave, message)
print('chave:', binascii.hexlify(chave).decode())
print('cipher:', binascii.hexlify(cipher).decode())
print(xor(chave, cipher).decode())