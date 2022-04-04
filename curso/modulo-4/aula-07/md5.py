import hashlib
mensagem = "desenvolvedorio"
result = hashlib.md5(mensagem.encode())
print("Mensagem:", mensagem)
print("Hash Value:", result.hexdigest())