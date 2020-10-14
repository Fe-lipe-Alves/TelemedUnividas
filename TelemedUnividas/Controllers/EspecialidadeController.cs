using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelemedUnividas.Models;

namespace TelemedUnividas.Controllers
{
    public class EspecialidadeController : Controller
    {
        // GET: EspecialidadeController
        public ActionResult Index()
        {
            List<EspecialidadeModel> especialidades = (new EspecialidadeModel()).Todos();


            return View(especialidades);
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
                string descricao = collection["descricao"];

                if(descricao != "")
                {
                    EspecialidadeModel especialidade = new EspecialidadeModel();
                    especialidade.Descricao = descricao;
                    especialidade.Salvar();
                    return RedirectToAction(nameof(Index));
                } else
                {
                    return Redirect(ControllerContext.HttpContext.Request.Headers["Referer"]);
                }
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
        public JsonResult Edit(int id, IFormCollection collection)
        {
            try
            {
                int codigo = int.Parse(collection["codigo"]);
                string descricao = collection["descricao"];

                if(codigo != 0 && descricao != "")
                {
                    EspecialidadeModel especialidade = (new EspecialidadeModel()).Obter(codigo);
                    especialidade.Descricao = descricao;
                    especialidade.Salvar();

                    return new JsonResult(new {
                        success = true, 
                        message = "Atualizado com sucesso"
                    });
                } else
                {
                    return new JsonResult(new
                    {
                        success = false,
                        message = "Flaha ao atualizar"
                    });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    success = false,
                    message = "Flaha ao atualizar" + ex.Message
                });
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
        public JsonResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int codigo = int.Parse(collection["codigo"]);

                if (codigo != 0)
                {
                    EspecialidadeModel especialidade = (new EspecialidadeModel()).Obter(codigo);
                    especialidade.Excluir();

                    return new JsonResult(new
                    {
                        success = true,
                        message = "Removido com sucesso"
                    });
                }
                else
                {
                    return new JsonResult(new
                    {
                        success = false,
                        message = "Flaha ao remover"
                    });
                }
            }
            catch
            {
                return new JsonResult(new
                {
                    success = false,
                    message = "Flaha ao remover"
                });
            }
        }
    }
}
