using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Aula03.Web.Models
{
    [Table("Tbl_Pedido")]
    public class Pedido
    {
        [Column("Id"), HiddenInput]
        public int PedidoId { get; set; }

        [Column("Dt_Pedido"), Display(Name = "Data Pedido")]
        public DateTime DataPedido { get; set; }

        public Business Business { get; set; }
        public int BusinessId { get; set; }
        public IList<ItemPedido> ItensPedidos { get; set; }
    }
}
