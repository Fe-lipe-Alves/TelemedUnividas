using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TelemedUnividas.Models;
using Microsoft.AspNetCore.Http;

namespace TelemedUnividas.Controllers
{
    public class ConsultaController : Controller
    {
        [HttpGet]
        public IActionResult Index(int consulta_codigo)
        {
            ConsultaModel consulta = (new ConsultaModel()).Obter(consulta_codigo);
            PacienteModel paciente = (new PacienteModel()).Obter(consulta.Paciente);

            ViewData["paciente"] = paciente;
            ViewData["consulta"] = consulta;
            return View();
        }


        public IActionResult Salvar(IFormCollection form)
        {
            int consulta_codigo = int.Parse(form["consulta_codigo"]);

            

            string receita = form["receita"];
            string atestado = form["atestado"];
            string observacoes = form["obervacoes"];
            DateTime inicio = DateTime.Parse(form["inicio"]);
            DateTime fim = DateTime.Parse(form["fim"]);
            TimeSpan duracao = fim - inicio;
            ChamadaModel chamada = new ChamadaModel()
            {
                ConsultaCodigo = consulta_codigo,
                Observacoes = observacoes,
                Duracao = duracao,
                Inicio = inicio,
            };
            chamada.Salvar();

            ConsultaModel consulta = (new ConsultaModel()).Obter(consulta_codigo);
            consulta.Status = 2; // Status Concluída
            consulta.Receita = receita;
            consulta.Atestado = atestado;
            consulta.Salvar();

            return View("../Agenda/Index");
        }

        [HttpGet]
        public IActionResult Visualizar(int consulta_codigo)
        {
            ConsultaModel consulta = (new ConsultaModel()).Obter(consulta_codigo);
            ViewData["consulta"] = consulta;

            PacienteModel paciente = null;
            ChamadaModel chamada = null;
            if (consulta != null)
            {
                paciente = (new PacienteModel()).Obter(consulta.Paciente);
                chamada = (new ChamadaModel()).ObterPorConsulta(consulta.Codigo);
            }

            ViewData["paciente"] = paciente;
            ViewData["chamada"] = chamada;

            return View();
        }
    }
}
