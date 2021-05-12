using DogAndPeoples.Domain.Entidades;
using DogAndPeoples.Domain.Interfaces;
using DogAndPeoples.Domain.ViewModels;
using DogAndPeoples.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DogAndPeoples.Web.Controllers
{
    public class CaesDonosController : Controller
    {
        private readonly ICaesDonosService _caesDonosService;
        public CaesDonosController()
        {
            _caesDonosService = BootStrapper.Resolve<ICaesDonosService>();
        }

        // GET: CaesDonos
        public ActionResult Index(string nomeCao = null, string raca = null)
        {
            IEnumerable<CaesViewModel> caesDonos = _caesDonosService.Listar(nomeCao, raca);
            return View(caesDonos);
        }

        public ActionResult Create()
        {
            return View(new CaesViewModel());
        }

        public ActionResult Edit(long id)
        {
            CaesViewModel caesViewModel = _caesDonosService.Obter(id);
            return View(caesViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(CaesViewModel caesViewModel)
        {
            try
            {
                _caesDonosService.Atualizar(caesViewModel);
                TempData["sucesso"] = "Registro atualizado com sucesso";
            }
            catch (Exception exception)
            {
                TempData["error"] = exception.Message;
            }

            return View(caesViewModel);
        }

        public ActionResult Remove(long idCao, long idDono)
        {
            _caesDonosService.Remover(idCao, idDono);
            TempData["sucesso"] = "Registro exclido com sucesso";
            return RedirectToAction("index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(CaesViewModel caesViewModel)
        {
            try
            {
                _caesDonosService.Adicionar(caesViewModel);
                TempData["sucesso"] = "Registro salvo com sucesso";
            }
            catch (Exception exception)
            {
                TempData["error"] = exception.Message;
            }

            return View(caesViewModel);
        }
    }
}