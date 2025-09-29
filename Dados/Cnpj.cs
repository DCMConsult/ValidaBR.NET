namespace ValidadoresBrasil.Dados
{
    public class Cnpj
    {
        public string Numero { get; private set; }

        public Cnpj(string numero)
        {
            Numero = numero;
        }
    }
}
