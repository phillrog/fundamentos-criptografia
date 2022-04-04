import hashlib
mensagem = "desenvolvedorio"
result = hashlib.sha256(mensagem.encode())
print("Mensagem:", mensagem)
print("Hash Value :", result.hexdigest())
print("Digest Size :", result.digest_size)
print("Block Size : ", result.block_size)