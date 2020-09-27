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

            //var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            //Pacientes p = mapper.Map<Pacientes>(paciente);

            // -------------------------------------
            //      INSERÇÃO DE PACIENTE - OK
            // -------------------------------------
            PacienteModel paciente = new PacienteModel();
            paciente.Nome = "Fernando";
            paciente.Sobrenome = "Jota";
            paciente.Salvar();

            // ----------------------------------------
            //      Localizar Lista Paciente
            // ----------------------------------------
            //List<PacienteModel> pacientes = (new PacienteModel()).Obter(4);


            List<EspecialistaModel> especialistas = (new EspecialistaModel()).LocalizarPorEspecialidade(1);


            var x = (new PacienteModel()).Obter(4);

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
