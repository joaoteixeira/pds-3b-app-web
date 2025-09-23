namespace AppWeb.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public int Quantidade { get; set; }

        public decimal Valor {  get; set; }
    }
}
