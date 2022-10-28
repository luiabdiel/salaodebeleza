namespace salaodebeleza.Helpers
{
    
    public static class Formating
    {
        public static string Formatado(this double valor) =>
            $"R${valor.ToString(".00")}";

        public static string FormatadoCount(this int count) =>
            $"{count.ToString("00")}";
    }
    
}
