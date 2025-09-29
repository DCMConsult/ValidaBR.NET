using System.Text.RegularExpressions;
using ValidadoresBrasil.Dados;

namespace ValidadoresBrasil.Validadores
{
    public static class ValidadorCpf
    {
        public static ValidationResult Validar(Cpf cpf)
        {
            string numeroLimpo = Regex.Replace(cpf.Numero, @"[^\d]", "");

            if (numeroLimpo.Length != 11)
                return new ValidationResult(false, "O CPF deve conter 11 dígitos.");

            if (new string(numeroLimpo[0], 11) == numeroLimpo)
                return new ValidationResult(false, "O CPF não pode ter todos os dígitos iguais.");

            // Lógica para o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(numeroLimpo[i].ToString()) * (10 - i);

            int resto = (soma * 10) % 11;
            if (resto == 10) resto = 0;
            if (resto != int.Parse(numeroLimpo[9].ToString()))
                return new ValidationResult(false, "Dígito verificador 1 inválido.");

            // Lógica para o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(numeroLimpo[i].ToString()) * (11 - i);

            resto = (soma * 10) % 11;
            if (resto == 10) resto = 0;
            if (resto != int.Parse(numeroLimpo[10].ToString()))
                return new ValidationResult(false, "Dígito verificador 2 inválido.");

            return new ValidationResult(true);
        }
    }
}
