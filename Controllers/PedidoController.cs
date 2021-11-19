using Fiap.Aula03.Web.Models;
using Fiap.Aula03.Web.Persistencias;
using Fiap.Aula03.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Controllers
{
    public class PedidoController : Controller
    {
        private IPedidoRepository _pedidoRepository;
        private IProdutoRepository _produtoRepository;
        private IBusinessRepository _businessRepository;
        private IITemPedidoRepository _itemPedidoRepository;

        public PedidoController(IITemPedidoRepository iTemPedidoRepository, IBusinessRepository businessRepository, IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _businessRepository = businessRepository;
            _itemPedidoRepository = iTemPedidoRepository;
        }

        [HttpPost]
        public IActionResult Adicionar(ItemPedido item)
        {
            _itemPedidoRepository.Cadastar(item);
            _itemPedidoRepository.Salvar();
            TempData["msg"] = "Produto adicionado!";
            return RedirectToAction("Adicionar", new { id = item.PedidoId }); 
        }

        [HttpGet]
        public IActionResult Adicionar(int id)
        {
            var pedido = _pedidoRepository.BuscarPorId(id);

            var lista = _produtoRepository.Listar();

            var produtosPedido = _produtoRepository.BuscarPorPedido(id);

            var listaFiltrada = lista.Where(p => !produtosPedido.Any(p2 => p2.ProdutoId == p.ProdutoId));

            ViewBag.produtosSelect = new SelectList(listaFiltrada, "ProdutoId", "Nome");

            ViewBag.produtos = produtosPedido;

            return View(pedido);
        }

        private void CarregarBusiness(int id)
        {
            var lista = _businessRepository.Listar();
            ViewBag.business = new SelectList(lista, "BusinessId", "Nome", id);
        }

        [HttpGet]
        public IActionResult Cadastrar(int id)
        {
            CarregarBusiness(id);
            return View();
        }
        
        [HttpPost]
        public IActionResult Cadastrar(Pedido pedido)
        {
            _pedidoRepository.Cadastrar(pedido);
            _pedidoRepository.Salvar();
            TempData["msg"] = "Pedido registrado";
            return RedirectToAction("Adicionar", new { id = pedido.PedidoId } );
        }

        public IActionResult Index()
        {
            var pedidos = _pedidoRepository.Listar();
            return View(pedidos);
        }
    }
}
