using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Models
{
    //Classe que mapeia a tabela associativa
    [Table("Tbl_Item_Pedido")]
    public class ItemPedido
    {
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
    }
}
