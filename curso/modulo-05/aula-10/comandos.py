msg = [ord(c) for c in "DESENVOLVEDOR.IO"]
p = random_prime(2^64); p
q = random_prime(2^65); q

n = p*q; n
phi_n = (p-1)*(q-1)

e = 65537
gcd(e, phi_n)

p = random_prime(2^64); p
n = p*q; n
phi_n = (p-1)*(q-1)
gcd(e, phi_n)

cipher = [mod(i^e, n) for i in msg]; cipher

d = inverse_mod(e, n);d

mensagem = [mod(i^d, n) for i in cipher]; mensagem

"".join(chr(i) for i in mensagem)