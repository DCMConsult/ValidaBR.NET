using System.Text.RegularExpressions;
using ValidadoresBrasil.Dados;

namespace ValidadoresBrasil.Validadores
{
    public static class ValidadorCep
    {
        public static ValidationResult Validar(Cep cep)
        {
            string numeroLimpo = Regex.Replace(cep.Numero, @"[^\d]", "");

            if (numeroLimpo.Length != 8)
                return new ValidationResult(false, "O CEP deve conter 8 dígitos.");

            if (new string(numeroLimpo[0], 8) == numeroLimpo)
                return new ValidationResult(false, "O CEP não pode ter todos os dígitos iguais.");

            return new ValidationResult(true);
        }
    }
}