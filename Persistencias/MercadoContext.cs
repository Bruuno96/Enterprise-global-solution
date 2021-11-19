using Fiap.Aula03.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Aula03.Web.Persistencias
{
    public class MercadoContext : DbContext
    {
        //Conjunto de clientes que estão no banco de dados
        public DbSet<Business> Business { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }

        //Construtor que recebe as options e envia para o construtor do pai
        public MercadoContext(DbContextOptions op) : base(op) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurar a chave composta da tabela associativa
            modelBuilder.Entity<ItemPedido>().HasKey(i => new { i.PedidoId, i.ProdutoId });

            //Configurar o relacionamento da tabela associativa com o pedido
            modelBuilder.Entity<ItemPedido>()
                .HasOne(i => i.Pedido)
                .WithMany(i => i.ItensPedidos)
                .HasForeignKey(i => i.PedidoId);

            //Configurar o relacionamento da tabela associativa com o produto
            modelBuilder.Entity<ItemPedido>()
                .HasOne(i => i.Produto)
                .WithMany(i => i.ItensPedidos)
                .HasForeignKey(i => i.ProdutoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
