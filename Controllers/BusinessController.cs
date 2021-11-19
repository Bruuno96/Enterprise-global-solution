using Fiap.Aula03.Web.Models;
using Fiap.Aula03.Web.Persistencias;
using Fiap.Aula03.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Controllers
{
    public class BusinessController : Controller
    {
        private IBusinessRepository _businessRepository;

        public BusinessController(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _businessRepository.Remover(id);
            _businessRepository.Salvar();
            TempData["msg"] = "Business removido!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var business = _businessRepository.BuscarPorId(id);
            return View(business);
        }

        [HttpPost]
        public IActionResult Editar(Business business)
        {
            _businessRepository.Atualizar(business);
            _businessRepository.Salvar();
            TempData["msg"] = "Business atualizado!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Cadastrar(Business business)
        {
            _businessRepository.Cadastrar(business);
            _businessRepository.Salvar();
            TempData["msg"] = "Business cadastrado!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Index(string nomeBusca, Genero? generoBusca)
        {
            
            var lista = _businessRepository.BuscarPor(c =>
               (c.Nome.Contains(nomeBusca) || nomeBusca == null)  
               && (generoBusca == c.Genero || generoBusca == null));
            return View(lista);
        }
    }
}
