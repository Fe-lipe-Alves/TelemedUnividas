using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelemedUnividas.Models;

namespace TelemedUnividas.Controllers
{
    public class EspecialistaController : Controller
    {

        public JsonResult IndexClinica(IFormCollection form)
        {
            int id_clinica = int.Parse(form["id_clinica"]);
            if (id_clinica != 0)
            {
                List<EspecialistaModel> especialistasList = (new EspecialistaModel()).LocalizarPorClinica(id_clinica);

                List<object> especialistasResumo = new List<object>();
                foreach (EspecialistaModel especialista in especialistasList)
                {
                    especialistasResumo.Add(new { codigo = 0, nome = "Felipe" });
                }
                var response = new { success = true, data = especialistasResumo };
                return new JsonResult(response);
            }
            var responseError = new { success = false, message = "Clínica não informada"};
            return new JsonResult(responseError);
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
