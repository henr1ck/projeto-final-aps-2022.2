namespace ProjetoFinal.Models
{
    public class Pedido
    {
        public int id { get; set; }
        public int consumidorId { get; set; }
        public virtual Consumidor consumidor { get; set; }
        public virtual ICollection<Produto> produtos { get; set; }
    }
}