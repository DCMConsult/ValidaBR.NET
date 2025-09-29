namespace ValidadoresBrasil.Dados
{
    public class Cpf
    {
        public string Numero { get; private set; }

        public Cpf(string numero)
        {
            Numero = numero;
        }
    }
}
