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
        /// <summary>
        /// Exibe a tela de cadastro
        /// </summary>
        /// <returns></returns>
        public IActionResult Cadastrar()
        {
            return View();
        }

        /// <summary>
        /// Salva um novo usuário
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Salvar(IFormCollection form)
        {
            try
            {
                var x = form;
            }
            catch (Exception ex)
            {
                ViewData["erro"] = "Falha ao salvar os dados";
            }
            return View();
        }

        /// <summary>
        /// Exibe a tela de login
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Recebe os dados de email e senha iformados no formlulário e 
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public IActionResult Entrar(IFormCollection form)
        {
            try
            {
                string email = form["email"];
                string senha = form["senha"];

                if(email != "" && senha != "")
                {
                    PacienteModel paciente = (new PacienteModel()).Login(email, senha);
                    if(paciente != null)
                    {

                    }

                    EspecialistaModel especialista = (new EspecialistaModel()).Login(email, senha);
                    if (especialista != null)
                    {

                    }

                    SecretarioModel secretario = (new SecretarioModel()).Login(email, senha);
                    if (secretario != null)
                    {

                    }

                    if(paciente == null && especialista == null && secretario == null)
                    {

                    }
                } else
                {
                    throw new Exception("E-mail ou senha invalidos");
                }
            }
            catch (Exception ex)
            {
                ViewData["erro"] = new { Mensagem = ex.Message };
            }
            return View();
        }

        /// <summary>
        /// Logout do usuário
        /// </summary>
        /// <returns></returns>
        //public IActionResult Sair()
        //{

        //}
    }
}
