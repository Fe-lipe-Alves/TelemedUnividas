using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelemedUnividas.Models;

namespace TelemedUnividas.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Cadastrar()
        {
            PacienteModel paciente = new PacienteModel();
            EspecialidadeModel especialidadeModel = new EspecialidadeModel();
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(IFormCollection form)
        {
            try
            {
                var x = form;
            }
            catch (Exception ex)
            {
                ViewData["mensagem"] = "Ops... Os dados não foram salvos";
            }
            return View();
        }
    }
}
