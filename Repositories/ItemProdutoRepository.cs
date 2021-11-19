using Fiap.Aula03.Web.Models;
using Fiap.Aula03.Web.Persistencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Repositories
{
    public class ItemProdutoRepository : IITemPedidoRepository
    {
        private MercadoContext _context;

        public ItemProdutoRepository(MercadoContext context)
        {
            _context = context;
        }

        public void Cadastar(ItemPedido itemPedido)
        {
            _context.ItensPedidos.Add(itemPedido);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
