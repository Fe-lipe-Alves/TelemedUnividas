using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TelemedUnividas.Models;
using Repositorio.JsonModels;

namespace TelemedUnividas.Controllers
{
    public class CidadeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObterCidadesPorEstado(int estado_codigo)
        {
            List<CidadeModel> cidades = (new CidadeModel()).TodosUF(estado_codigo);
            List<CidadeJsonModel> cidadesJsonModel = new List<CidadeJsonModel>();

            foreach (CidadeModel cidade in cidades)
            {
                CidadeJsonModel cidadeJson = new CidadeJsonModel()
                {
                    Codigo = cidade.Codigo,
                    Nome = cidade.Nome
                };
                cidadesJsonModel.Add(cidadeJson);
            }

            return new JsonResult(cidadesJsonModel);
        }
    }
}
