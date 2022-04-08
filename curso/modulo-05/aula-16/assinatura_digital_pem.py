from ecdsa import SigningKey, VerifyingKey

print("Carregando chave privada")
with open('ecc-private-key.pem', 'r') as pem:
    assinante = SigningKey.from_pem(pem.read())

mensagem = b'desenvolvedorio'

print('Assinante PEM:')
print(assinante.to_pem().decode())

assinatura = assinante.sign(mensagem)

print("Carregando chave publica")
with open('ecc-public-key.pem', 'r') as pem:
    verificador = VerifyingKey.from_pem(pem.read())

print('Verificador PEM:')
print(verificador.to_pem().decode())

print("Assinatura valida:", verificador.verify(assinatura, mensagem))
