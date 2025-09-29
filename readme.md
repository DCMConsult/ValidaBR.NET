# ValidaBR.NET

[![NuGet](https://img.shields.io/nuget/v/ValidadoresBrasil.Library.svg)](https://www.nuget.org/packages/ValidadoresBrasil.Library)

Uma biblioteca C# para validação de documentos e dados brasileiros como CPF, CNPJ e CEP.

Desenvolvida com foco em **simplicidade** e **compatibilidade**, o **ValidaBR.NET** é uma ferramenta leve, sem dependências, ideal para qualquer projeto .NET.

---

## 🌟 Principais Recursos

- **Validação de CPF:** Algoritmo completo para validar CPFs numéricos.  
- **Validação de CNPJ:** Suporte para o formato numérico padrão e para o **novo padrão alfanumérico NIP** (Número de Identificação de Pessoa Jurídica).  
- **Validação de CEP:** Checagem do formato com base nas regras de 8 dígitos.  
- **Design Robusto:** Separação clara entre os objetos de dados (classes `CPF`, `CNPJ`) e a lógica de validação.  
- **Ampla Compatibilidade:** Criada com **.NET Standard 2.0**, funciona em projetos .NET Framework, .NET Core/5/6/7/8+ e Xamarin.  

---

## 🛠️ Instalação

A instalação da biblioteca é feita facilmente através do NuGet Package Manager:

```bash
dotnet add package ValidadoresBrasil.Library
```

## 🚀 Como Usar

A biblioteca é projetada para ser intuitiva. Primeiro, crie uma instância do objeto de dados e, em seguida, passe-o para a classe de validação estática.

```csharp
using ValidadoresBrasil.Dados;
using ValidadoresBrasil.Validadores;
using System;

// Exemplo de uso para CPF
var cpfValido = new Cpf("123.456.789-00");
var resultadoCpf = ValidadorCpf.Validar(cpfValido);
Console.WriteLine($"CPF: {cpfValido.Numero} é válido? {resultadoCpf.IsValid}");

var cpfInvalido = new Cpf("111.111.111-11");
var resultadoCpfInvalido = ValidadorCpf.Validar(cpfInvalido);
Console.WriteLine($"CPF: {cpfInvalido.Numero} é válido? {resultadoCpfInvalido.IsValid} - Motivo: {resultadoCpfInvalido.Message}");

Console.WriteLine("--------------------");

// Exemplo de uso para CNPJ
var cnpjValido = new Cnpj("11.222.333/0001-44");
var resultadoCnpj = ValidadorCnpj.Validar(cnpjValido);
Console.WriteLine($"CNPJ: {cnpjValido.Numero} é válido? {resultadoCnpj.IsValid}");

// Nota: A validação de CNPJ suporta o novo formato NIP, basta passar a string alfanumérica.
var cnpjNip = new Cnpj("11A.222B.333C/0001-44");
var resultadoCnpjNip = ValidadorCnpj.Validar(cnpjNip);
Console.WriteLine($"CNPJ (NIP): {cnpjNip.Numero} é válido? {resultadoCnpjNip.IsValid}");

Console.WriteLine("--------------------");

// Exemplo de uso para CEP
var cepValido = new Cep("12345-678");
var resultadoCep = ValidadorCep.Validar(cepValido);
Console.WriteLine($"CEP: {cepValido.Numero} é válido? {resultadoCep.IsValid}");
```

## 🤝 Contribuição e Feedback

Sua colaboração é muito bem-vinda!

Sinta-se à vontade para abrir uma issue para relatar bugs ou sugerir melhorias.

## 📄 Licença

Este projeto está licenciado sob a licença **MIT**.