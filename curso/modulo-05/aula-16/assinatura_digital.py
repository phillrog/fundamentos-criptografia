from ecdsa import SigningKey

assinante = SigningKey.generate() # NIST192p
verificador = assinante.verifying_key

mensagem = b'desenvolvedorio'

print('Assinante:')
print(assinante.to_pem().decode())

assinatura = assinante.sign(mensagem)

print("Assinatura valida:", verificador.verify(assinatura, mensagem))