using Microsoft.EntityFrameworkCore;

namespace ProjetoFinal.Models
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options){

        }

        public DbSet<Produto> produto {get; set;}
        public DbSet<Pedido> pedido {get; set;}
        public DbSet<Pagamento> pagamento {get; set;}
        public DbSet<Credito> credito {get; set;}
        public DbSet<Consumidor> consumidor {get; set;}
        public DbSet<Boleto> boleto {get; set;}

    }
}