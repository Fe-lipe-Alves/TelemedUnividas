using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelemedUnividas.Models;
using Repositorio.JsonModels;

namespace TelemedUnividas.Controllers
{
    public class EspecialistaController : Controller
    {

       [HttpGet]
       public JsonResult ObterPorClinica(int clinica_codigo)
        {
            List<EspecialistaModel> especialistas = (new EspecialistaModel()).LocalizarPorClinica(clinica_codigo);
            List<EspecialistaJsonModel> especialistaJsonModels = new List<EspecialistaJsonModel>();

            foreach (EspecialistaModel especialista in especialistas)
            {
                EspecialistaJsonModel especialistaJson = new EspecialistaJsonModel()
                {
                    Codigo = especialista.Codigo,
                    Nome = especialista.Nome + " " + especialista.Sobrenome
                };
                especialistaJsonModels.Add(especialistaJson);
            }

            return new JsonResult(especialistaJsonModels);
        }

        // GET: EspecialistaController
        public ActionResult Index()
        {

            return View();
        }

        // GET: EspecialistaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EspecialistaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EspecialistaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EspecialistaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EspecialistaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EspecialistaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EspecialistaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
