using Fiap.Aula03.Web.Models;
using Fiap.Aula03.Web.Persistencias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Repositories
{
    public class BusinessRepository : IBusinessRepository
    {
        private MercadoContext _context;

        public BusinessRepository(MercadoContext context)
        {
            _context = context;
        }

        public void Atualizar(Business cliente)
        {
            _context.Business.Update(cliente);
        }

        public IList<Business> BuscarPor(Expression<Func<Business, bool>> filtro)
        {
            return _context.Business.Where(filtro).Include(c => c.Endereco).ToList();
        }

        public Business BuscarPorId(int id)
        {
            return _context.Business.Where(c => c.ClienteId == id)
                .Include(c => c.Endereco).FirstOrDefault();
        }

        public void Cadastrar(Business cliente)
        {
            _context.Business.Add(cliente);
        }

        public IList<Business> Listar()
        {
            return _context.Business.Include(c => c.Endereco).ToList();
        }

        public void Remover(int id)
        {
            var cliente = _context.Business.Find(id);
            _context.Business.Remove(cliente);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
