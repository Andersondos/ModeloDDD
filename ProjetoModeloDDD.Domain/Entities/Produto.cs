namespace ProjetoModeloDDD.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
        public int ClienteID { get; set; } // chave estangeira um cliente pode ter muitos Produtos 
        public virtual Cliente Cliente { get; set; }
    }
}
