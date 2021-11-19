using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Models
{
    [Table("Tbl_Produto")]
    public class Produto
    {
        [Column("Id"), HiddenInput]
        public int ProdutoId { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; }

        //Relacionamento muitos-para-muitos
        public IList<ItemPedido> ItensPedidos { get; set; }

        public decimal Valor { get; set; }
        
        [Display(Name = "Descrição"), MaxLength(255)]
        public string Descricao { get; set; }
        
        [Display(Name = "Disponível")]
        public bool Disponivel { get; set; }
    }
}
