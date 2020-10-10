using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelemedUnividas.Controllers
{
    public class EspecialidadeController : Controller
    {
        // GET: EspecialidadeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EspecialidadeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EspecialidadeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EspecialidadeController/Create
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

        // GET: EspecialidadeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EspecialidadeController/Edit/5
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

        // GET: EspecialidadeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EspecialidadeController/Delete/5
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
