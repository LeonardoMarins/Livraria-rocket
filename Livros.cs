namespace Livraria
{
    public class Livros
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public float Preco { get; set; }
        public int QuantidadeEstoque { get; set; }

        public static List<Livros> livrosLista = new List<Livros>();

    }
}
