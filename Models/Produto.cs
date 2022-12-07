namespace ProjetoFinal.Models
{
    public class Produto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public double valor {get; set;} 
        public int fornecedorId { get; set; }
        public virtual Fornecedor fornecedor { get; set;}
        public int categoriaId { get; set; }
        public virtual Categoria categoria { get; set;}

    }
}