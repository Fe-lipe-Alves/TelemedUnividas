﻿using System;
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

                    ClinicaModel clinica = new ClinicaModel()
                    {
                        Nome = nome,
                        Email = email,
                        Endereco = endereco.Codigo,
                        Telefone = telefone
                    };
                    clinica.Salvar();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClinicaController/Editar/5
        public ActionResult Editar(int codigo)
        {
            try
            {
                if(codigo != 0)
                {
                    ClinicaModel clinica = (new ClinicaModel()).Obter(codigo);
                    if(clinica != null)
                    {
                        EnderecoModel endereco = (new EnderecoModel()).Obter((int)clinica.Endereco);
                        CidadeModel cidade = (new CidadeModel()).Obter(endereco.CidadeCodigo);
                        List<UnidadeFederativaModel> uf = (new UnidadeFederativaModel()).Todos();
                        List<CidadeModel> cidades = (new CidadeModel()).TodosUF(cidade.UnidadeFederativaCodigo);

                        ViewData["clinica"] = clinica;
                        ViewData["endereco"] = endereco;
                        ViewData["cidade"] = cidade;
                        ViewData["uf"] = uf;
                        ViewData["cidades"] = cidades;
                    } else
                    {
                        // Clinica não encontrada
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        // GET: ClinicaController
        public ActionResult Index()
        {
            List<ClinicaModel> clinicas = (new ClinicaModel()).Localizar();
            return View(clinicas);
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
