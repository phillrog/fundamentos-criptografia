from sage.all import *
from tabulate import tabulate
from random import randrange

def alphabetToPoint(alphabet, g):
    alphabet_dict = {}

    for i, character in enumerate(alphabet):
        alphabet_dict[character] = (i+1)*g

    return alphabet_dict

# Só funciona para primos pequenos: 3697
def gerarGrafico(points, e):
    graph = e.plot(gridlines='true')
    for i in range(1,len(points)):
        # to generate 2d graph
        point1 = [points[i][1][0], points[i][1][1]]
        point2 = [points[i-1][1][0], points[i-1][1][1]]

        l = line([point1, point2], color='red', thickness=1)
        graph += l.plot()
        
    # Primeiro ponto com o ultimo
    point1 = [points[0][1][0], points[0][1][1]]
    point2 = [points[len(points)-1][1][0], points[len(points)-1][1][1]]
    
    l = line([point1, point2], color='red', thickness=1)
    graph += l.plot()

    graph.save('./cypher-map.png')

# G = generator point
# Pk = public key
# n = private key

a = 1
b = 7
moduloP = 97
n = 46
mensagem = 'desenvolvedor.io'
ecc = EllipticCurve(Zmod(moduloP), [a, b])
print(ecc)
G = ecc(9,39)
Pk = n*G;Pk

variaveis = [['modulo p', moduloP], ['a', a], ['b', b], ['n', n], ['G', G], ['PK', Pk], ['mensagem', mensagem]]
print(tabulate(variaveis, headers=['Variaveis', 'Valores'], tablefmt='fancy_grid'))

# generate array with every letter from alphabet. Uppercase, lowercase and numbers
alfabeto = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '.', ' ']

mapa_pontos = alphabetToPoint(alfabeto, G)
print('Mapa de caracteres')
print(tabulate(mapa_pontos.items(), tablefmt='fancy_grid'))

print('\n\n==================CRIPTOGRAFANDO=================')
print('Criptografando uma mensagem a partir da chave publica')
print('k = Numero aleatorio')
print('Pm = Ponto do mapa de caracteres')
print('c = [kG, pm+k*Pk]')
print('c1 = kG')
print('c2 = pm+k*Pk')

cypher = []
for i in range(len(mensagem)):
    k = randrange(1, moduloP-2)
    pm = mapa_pontos[mensagem[i]]
    c1 = k*G
    c2 = (pm + k*Pk)
    cypher.append([c1, c2])

print(f'Mensagem cifrada:')
print(tabulate(cypher, headers=['c1', 'c2'], tablefmt='fancy_grid'))
gerarGrafico(cypher, ecc)

    