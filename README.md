# Curso Fundamentos de Criptografia e Hashing - desenvolvedor.io

*Obs: curso mais top do mercado sobre o assunto.

## Material do curso Criptografia e Hashing

## Configurando o ambiente

Todas as demos do curso foram executadas através do ubuntu com WSL2. O código é totalmente compátivel com o windows.

### Python

Instalar o python: https://www.python.org/downloads/

Instalar as dependencias do python:

```bash
pip install cryptography==2.8
pip install tabulate==0.8.9
pip install numpy==1.17.4
pip install pbkdf2==1.3
pip install pycryptodome==3.11.0
pip install blake3==0.2.1
pip install colorama==0.4.3
pip install argon2-cffi==21.3.0
pip install eciespy==0.3.11
pip install ecdsa==0.17.0
```

### Cryptool2

Efetuar download e instalar o cryptool2:

* [Link direto](https://www.cryptool.org/ct2download/Builds/Setup%20CrypTool%202.1%20(Stable%20Build%209202.2).exe) 
* Caso o link esteja com problemas acesso o site oficial: https://www.cryptool.org/en/ct2/downloads

### .NET

O curso utilizou a versão 6 do .NET. Que houve ligeiras mudanças nos algoritmos de criptografia. Além de simplificar a execução de alguns algoritmos houve grande melhoria de performance.

Efetuar download do .NET 6: https://dotnet.microsoft.com/en-us/download/dotnet/6.0

Após instalar o framework. Instalar a ferramenta dotnet script

```shell
dotnet tool install -g dotnet-script
```