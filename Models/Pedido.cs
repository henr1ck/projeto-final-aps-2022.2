namespace ProjetoFinal.Models
{
    public class Pedido
    {
        public int id { get; set; }
        public int consumidorId { get; set; }
        public virtual Consumidor consumidor { get; set; }
        public virtual ICollection<Produto> produtos { get; set; }

        void incluirProduto(Produto produto){
            produtos.Add(produto);
        }

        void excluirProduto(int id){
            foreach(var produto in produtos){
                if(produto.id.Equals(id)){
                    produtos.Remove(produto);
                    break;
                }
            };
        }
    }
}