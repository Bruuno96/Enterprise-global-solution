using Fiap.Aula03.Web.Models;
using Fiap.Aula03.Web.Persistencias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private MercadoContext _context;

        public PedidoRepository(MercadoContext context)
        {
            _context = context;
        }

        public Pedido BuscarPorId(int id)
        {
            return _context.Pedidos.Where(p => p.PedidoId == id)
                .Include(p => p.Business).FirstOrDefault();
        }

        public void Cadastrar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
        }

        public IList<Pedido> Listar()
        {
            return _context.Pedidos.Include(c => c.Business).ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
