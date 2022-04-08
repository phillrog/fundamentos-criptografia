def f(a,b,p): return mod(4*a^3+27*b^2, p)
f(1,4,23)

[p for p in primes_first_n(100) if f(1,4,p) == 0]

[f'{x}^2={mod(x**2,23)} mod 23' for x in range(23)]

def f(x): return mod(x**3+1*x+4, 23)
[[x, f(x)] for x in range(23)]