using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelemedUnividas.Models;
using Repositorio.Models;
using Repositorio.JsonModels;

namespace TelemedUnividas.Controllers
{
    public class AgendaController : Controller
    {
        // GET: AgendaController
        public ActionResult Index()
        {
            ViewData["clinica_codigo"] = 2;
            ViewData["especialista_codigo"] = 1029;

            return View();
        }

        [HttpGet]
        public JsonResult Get(int especialista_codigo)
        {
            try
            {
                List<ConsultaModel> consultas = (new ConsultaModel()).ObterAgenda(especialista_codigo);
                List<ConsultaJsonModel> consultasJson = new List<ConsultaJsonModel>();
                foreach (ConsultaModel consulta in consultas)
                {
                    ConsultaJsonModel consultaJson = new ConsultaJsonModel()
                    {
                        Codigo = consulta.Codigo,
                        ClinicaCodigo = consulta.ClinicaCodigo,
                        EspecialistaCodigo = consulta.EspecialistaCodigo,
                        Data = consulta.Data,
                        Paciente = consulta.Paciente,
                        Retorno = consulta.Retorno,
                        Status = consulta.Status
                    };

                    consultasJson.Add(consultaJson);
                }

                return new JsonResult(consultasJson);
            }
            catch (Exception ex)
            {
                return new JsonResult(null);
            }
        }

        [HttpPost]
        public JsonResult Excluir(int consulta_codigo)
        {
            try
            {
                ConsultaModel consulta = (new ConsultaModel()).Obter(consulta_codigo);
                if (consulta != null)
                {
                    consulta.Excluir();
                }
                return new JsonResult(new { success = true, message = "Excluido com sucesso!" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = true, message = "Falha ao excluir" });
            }
        }

        [HttpPost]
        public JsonResult Salvar([FromBody] ConsultaJsonModel consulta)
        {
            try
            {
                ConsultaModel consultaModel = new ConsultaModel() {
                    Codigo = consulta.Codigo,
                    ClinicaCodigo = consulta.ClinicaCodigo,
                    EspecialistaCodigo = consulta.EspecialistaCodigo,
                    Data = consulta.Data,
                    Paciente = consulta.Paciente,
                    Retorno = consulta.Retorno,
                    Status = 1
                };

                consultaModel.Salvar();

                return new JsonResult(new { success = true, message = "Salvo com sucesso!"});
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Erro ao salvar" });
            }
        }

        [HttpPost]
        public ActionResult Agendar(IFormCollection form)
        {
            try
            {
                string cpf = form["cpf"];
                DateTime data = DateTime.Parse(form["dataHorario"]);
                int clinica_codigo = int.Parse(form["clinica_codigo"]);
                int especialista_codigo = int.Parse(form["especialista_codigo"]);
                PacienteModel paciente = (new PacienteModel()).LocalizarCPF(cpf);

                if(cpf != "" && 
                   data != null && 
                   clinica_codigo != 0 &&
                   especialista_codigo != 0 &&
                   paciente != null)
                {
                    ConsultaModel consulta = new ConsultaModel()
                    {
                        ClinicaCodigo = clinica_codigo,
                        //Data = data,
                        EspecialistaCodigo = especialista_codigo,
                        Paciente = paciente.Codigo
                    };
                    return new JsonResult(new
                    {
                        success = true,
                        message = "Agendado com sucesso"
                    });
                } else
                {
                    return new JsonResult(new
                    {
                        success = false,
                        message = "Flaha ao agendar"
                    });
                }
            }
            catch
            {
                return new JsonResult(new
                {
                    success = false,
                    message = "Flaha ao agendar"
                });
            }
        }

        // GET: AgendaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AgendaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgendaController/Create
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

        // GET: AgendaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AgendaController/Edit/5
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

        // GET: AgendaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AgendaController/Delete/5
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
