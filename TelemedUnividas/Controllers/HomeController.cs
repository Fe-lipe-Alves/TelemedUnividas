using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TelemedUnividas.Models;
using Repositorio;
using Repositorio.Models;
using AutoMapper;
using Repositorio.Repositorio;

namespace TelemedUnividas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() 
        {
            /*
            PacienteModel paciente = (new PacienteModel()).Obter(4);

            PacienteModel pacienteJoao = new PacienteModel();
            pacienteJoao.Nome = "João";
            pacienteJoao.Sobrenome = "Pedro";
            paciente.Salvar();
            */
        
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
