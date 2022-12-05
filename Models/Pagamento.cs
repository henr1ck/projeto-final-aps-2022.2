namespace ProjetoFinal.Models
{
    public class Pagamento
    {
        public int id { get; set; }
        public double valorTotal { get; set;}
        public int pedidoId { get; set; }
        public virtual Pedido pedido { get; set;}
    }
}