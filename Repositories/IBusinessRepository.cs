using Fiap.Aula03.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Repositories
{
    public interface IBusinessRepository
    {
        void Cadastrar(Business cliente);
        void Atualizar(Business cliente);
        void Remover(int id);
        IList<Business> Listar();
        Business BuscarPorId(int id);
        IList<Business> BuscarPor(Expression<Func<Business, bool>> filtro);
        void Salvar();
    }
}
