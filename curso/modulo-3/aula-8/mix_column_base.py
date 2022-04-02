def mixColumns(a, b, c, d):
    result = []
    result.append(gmul(a, 2) ^ gmul(b, 3) ^ gmul(c, 1) ^ gmul(d, 1))
    result.append(gmul(a, 1) ^ gmul(b, 2) ^ gmul(c, 3) ^ gmul(d, 1))
    result.append(gmul(a, 1) ^ gmul(b, 1) ^ gmul(c, 2) ^ gmul(d, 3))
    result.append(gmul(a, 3) ^ gmul(b, 1) ^ gmul(c, 1) ^ gmul(d, 2))
    return result

def gmul(a, b):
    if b == 1:
        return a
    tmp = (a << 1) & 0xff
    if b == 2:
        return tmp if a < 128 else tmp ^ 0x1b
    if b == 3:
        return gmul(a, 2) ^ a

def printHex(val):
    return print('{:02x}'.format(val), end=' ')

def exibirMatrizMixColumn(matriz):
    for i in range(len(matriz)):
        printHex(matriz[0][i])
        printHex(matriz[1][i])
        printHex(matriz[2][i])
        printHex(matriz[3][i])
        print()
# test vectors from https://en.wikipedia.org/wiki/Rijndael_MixColumns#Test_vectors_for_MixColumn()
