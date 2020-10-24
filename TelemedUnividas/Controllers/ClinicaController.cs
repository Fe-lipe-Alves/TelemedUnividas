using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelemedUnividas.Models;

namespace TelemedUnividas.Controllers
{
    public class ClinicaController : Controller
    {
        // GET: ClinicaController
        public ActionResult Cadastrar()
        {
            ViewData["cidades"] = (new CidadeModel()).Localizar();
            ViewData["estados"] = (new UnidadeFederativaModel()).Localizar();
            ViewData["clinicas"] = (new ClinicaModel()).Localizar();
            ViewData["especialidades"] = (new EspecialidadeModel()).Localizar();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Salvar(IFormCollection form)
        {
            try
            {
                string nome = form["nome"];
                string telefone = form["telefone"];
                string email = form["email"];

                string logradouro = form["rua"];
                string numero = form["numero"];
                string bairro = form["bairro"];
                string complemento = form["complemento"];
                int cidade_codigo = int.Parse(form["cidade"]);
                CidadeModel cidade = null;
                if(cidade_codigo != 0)
                {
                    cidade = (new CidadeModel()).Obter(cidade_codigo);
                }

                if (nome != "" &&
                    telefone != "" &&
                    email != "" &&
                    logradouro != "" &&
                    numero != "" &&
                    bairro != "" &&
                    cidade != null)
                {
                    EnderecoModel endereco = new EnderecoModel()
                    {
                        Logradouro = logradouro,
                        Numero = numero,
                        Bairro = bairro,
                        Complemento = complemento,
                        CidadeCodigo = cidade.Codigo
                    };
                    endereco.Salvar();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClinicaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClinicaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClinicaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClinicaController/Create
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

        // GET: ClinicaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClinicaController/Edit/5
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

        // GET: ClinicaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClinicaController/Delete/5
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
