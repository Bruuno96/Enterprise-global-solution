using System;
using Fiap.Aula03.Web.Persistencias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fiap.Aula03.Web.Migrations
{
    [DbContext(typeof(MercadoContext))]
    partial class MercadoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fiap.Aula03.Web.Models.Business", b =>
                {
                    b.Property<int>("BusinessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("Dt_nascimento");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<bool>("Especial")
                        .HasColumnType("bit");

                    b.Property<int?>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("BusinessId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Tbl_Business");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Models.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EnderecoId");

                    b.ToTable("Tbl_Endereco");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Models.ItemPedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("PedidoId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Tbl_Item_Pedido");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime2")
                        .HasColumnName("Dt_Pedido");

                    b.Property<decimal?>("Desconto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("FormaPagamento")
                        .HasColumnType("int")
                        .HasColumnName("Forma_Pagamento");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PedidoId");

                    b.HasIndex("BusinessId");

                    b.ToTable("Tbl_Pedido");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Valor")
                        .HasMaxLength(255)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProdutoId");

                    b.ToTable("Tbl_Produto");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Models.Business", b =>
                {
                    b.HasOne("Fiap.Aula03.Web.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Models.ItemPedido", b =>
                {
                    b.HasOne("Fiap.Aula03.Web.Models.Pedido", "Pedido")
                        .WithMany("ItensPedidos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiap.Aula03.Web.Models.Produto", "Produto")
                        .WithMany("ItensPedidos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Models.Pedido", b =>
                {
                    b.HasOne("Fiap.Aula03.Web.Models.Business", "Business")
                        .WithMany("Pedidos")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Models.Business", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Models.Pedido", b =>
                {
                    b.Navigation("ItensPedidos");
                });

            modelBuilder.Entity("Fiap.Aula03.Web.Models.Produto", b =>
                {
                    b.Navigation("ItensPedidos");
                });
        }
    }
}
