using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Aula03.Web.Models
{
    [Table("Tbl_Business")]
    public class Business
    {
        [Column("Id"), HiddenInput]
        public int ClienteId { get; set; }

        //Relacionamento um-para-um
        public Endereco Endereco { get; set; }

        //Propriedade que mapeia a FK
        public int? EnderecoId { get; set; }

        //Relacionamento um-para-muitos
        public IList<Pedido> Pedidos { get; set; }

        [Required, MaxLength(80)]
        public string Nome { get; set; }
        
        [Column("Dt_nascimento"), Required, Display(Name = "Data Nascimento"), DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
       
        [Display(Name ="Gênero")]
        public Genero? Genero { get; set; }
        
        public bool Especial { get; set; }
        
        [Required, MaxLength(12)]
        public string Cpf  { get; set; }
    }

    public enum Genero
    {
        Feminino, Masculino, Outros
    }
}
