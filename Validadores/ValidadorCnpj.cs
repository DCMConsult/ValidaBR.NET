using System.Text.RegularExpressions;
using ValidadoresBrasil.Dados;

namespace ValidadoresBrasil.Validadores
{
    public static class ValidadorCnpj
    {
        public static ValidationResult Validar(Cnpj cnpj)
        {
            string numeroLimpo = Regex.Replace(cnpj.Numero, @"[^\dA-Z]", "").ToUpper();

            if (numeroLimpo.Length != 14)
                return new ValidationResult(false, "O CNPJ/NIP deve conter 14 caracteres.");

            if (new string(numeroLimpo[0], 14) == numeroLimpo)
                return new ValidationResult(false, "O CNPJ/NIP não pode ter todos os caracteres iguais.");

            // Converte os 12 primeiros caracteres alfanuméricos para números
            int[] numeros = new int[14];
            for (int i = 0; i < 12; i++)
            {
                numeros[i] = ConverterCaractereParaNumero(numeroLimpo[i]);
                if (numeros[i] == -1) // Se a conversão falhar para um caractere
                    return new ValidationResult(false, "CNPJ/NIP contém caracteres inválidos.");
            }

            // Lógica de cálculo dos dígitos verificadores
            return ValidarDigitosVerificadores(numeros, numeroLimpo);
        }

        private static int ConverterCaractereParaNumero(char c)
        {
            if (char.IsDigit(c))
                return int.Parse(c.ToString());

            if (char.IsLetter(c))
                return c - 'A' + 17;

            return -1;
        }

        private static ValidationResult ValidarDigitosVerificadores(int[] numeros, string cnpjOriginal)
        {
            // Primeiro dígito verificador
            int[] multiplicadores1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += numeros[i] * multiplicadores1[i];

            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

            if (digitoVerificador1 != int.Parse(cnpjOriginal[12].ToString()))
                return new ValidationResult(false, "Dígito verificador 1 inválido.");

            // Segundo dígito verificador
            int[] multiplicadores2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += numeros[i] * multiplicadores2[i];

            soma += digitoVerificador1 * multiplicadores2[12];

            resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

            if (digitoVerificador2 != int.Parse(cnpjOriginal[13].ToString()))
                return new ValidationResult(false, "Dígito verificador 2 inválido.");

            return new ValidationResult(true);
        }
    }
}
