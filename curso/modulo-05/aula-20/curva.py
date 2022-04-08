from sage.all import *
from tabulate import tabulate

a = 1
b = 4
p = 23

# verificar se a curva eh singular
if mod(4*a**3+27*b**2, p) == 0:
    print('A curva e singular')
    exit()

print(f'A curva y² = x³ + {a}x + {b} não e uma curva singular, pois ∆ = 4a³ + 27b² != 0')

# Todos os residuos quadraticos

# 1=1    4=2
# 2=4    5=4
# 3=2    6=1

# {
#    1: [1, 6],
#    2: [3, 4]
# }
residuosQuadraticos = {}
for x in range(1, p):
    resto = mod(x**2, p)
    if not resto in residuosQuadraticos:
        residuosQuadraticos[resto] = []
    residuosQuadraticos[resto].append(x)


resultadosDeY = [mod(x**3 + a*x + b, p) for x in range(p)]

pontosDaCurva = [['O', '(0, 1)']]
for x, y in enumerate(resultadosDeY):
    if y in residuosQuadraticos.keys():
        textoValores = f'x = {x} | y² = {y}'
        textoPontos = f'({x}, {residuosQuadraticos[y][0]}) ({x}, {residuosQuadraticos[y][1]})'
        pontosDaCurva.append([textoValores, textoPontos])

rq=[]
for item in residuosQuadraticos:
    rq.append([
        f'{residuosQuadraticos[item][0]}', 
        f'{residuosQuadraticos[item][1]}',
        item])

print("=========== RESIDUOS QUADRATICOS ===========")
print(tabulate(rq, headers=[f'x² mod {p}', f'(p-x)² mod {p}', '='], tablefmt='fancy_grid'))

print("=========== PONTOS DA CURVA ===========")
print(tabulate(pontosDaCurva, headers=[
    f'y² = x³ + {a}x + {b}', 'Pontos'], tablefmt='fancy_grid'))


# plotar graficos
# Graficos da curva:
e = EllipticCurve(Zmod(p), [a, b])
graph = e.plot(legend_label=f'EC [{a}, {b}]', gridlines='true')
graph.save('./curva-sobre-fp.png')

e = EllipticCurve([a, b])
graph = e.plot(legend_label=f'EC [{a}, {b}]')
graph.save('./curva.png')
