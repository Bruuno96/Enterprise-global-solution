using Fiap.Aula03.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Repositories
{
    public interface IPedidoRepository
    {
        void Cadastrar(Pedido pedido);

        IList<Pedido> Listar();

        Pedido BuscarPorId(int id);

        void Salvar();
    }
}