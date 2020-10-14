using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelemedUnividas.Models;
using System.Web;

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
                // Dados Pessoal
                string tipoUsuario = form["tipoUsuario"];
                string nome = form["nome"];
                string sobrenome = form["sobrenome"];
                string cpf = form["cpf"];
                DateTime dataNascimento = DateTime.Parse(form["dataNascimento"]);
                string telefone = form["telefone"];
                string email = form["email"];

                // Dados Endereço
                string rua = form["rua"];
                string numero = form["numero"];
                string complemento = form["complemento"];
                string bairro = form["bairro"];
                int cidade = int.Parse(form["cidade"]);

                if (
                    tipoUsuario != "" &&
                    nome != "" &&
                    sobrenome != "" &&
                    cpf != "" &&
                    dataNascimento != null &&
                    telefone != "" &&
                    email != "" &&
                    rua != "" &&
                    numero != "" &&
                    bairro != "" &&
                    cidade != 0
                )
                {
                    EnderecoModel endereco = new EnderecoModel();
                    endereco.CidadeCodigo = cidade;
                    endereco.Logradouro = rua;
                    endereco.Numero = numero;
                    endereco.Complemento = complemento;
                    //endereco.bairro = bairro;
                    endereco.Salvar();

                    if (tipoUsuario == "paciente")
                    {
                        PacienteModel paciente = new PacienteModel()
                        {
                            Nome = nome,
                            Sobrenome = sobrenome,
                            Cpf = cpf,
                            DataNascimento = dataNascimento,
                            Telefone = telefone,
                            Email = email,
                            EnderecoCodigo = endereco.Codigo
                        };

                        paciente.Salvar();
                    } else if(tipoUsuario == "especialista")
                    {
                        EspecialistaModel especialista = new EspecialistaModel()
                        {
                            Nome = nome,
                            Sobrenome = sobrenome,
                            Cpf = cpf,
                            DataNascimento = dataNascimento,
                            Telefone = telefone,
                            Email = email,
                            EnderecoCodigo = endereco.Codigo
                        };

                        especialista.Salvar();
                    } else if (tipoUsuario == "secretario")
                    {
                        int clinica = int.Parse(form["clinicaSecretario"]);

                        if(clinica != 0)
                        {
                            SecretarioModel secretario = new SecretarioModel()
                            {
                                Nome = nome,
                                Sobrenome = sobrenome,
                                Cpf = cpf,
                                DataNascimento = dataNascimento,
                                Telefone = telefone,
                                Email = email,
                                EnderecoCodigo = endereco.Codigo
                            };

                            secretario.Salvar();
                        } else
                        {
                            // clinica não informada
                        }
                    } else
                    {
                        // tipo de usuário não encontrado
                    }
                } else
                {
                    //dados incorretos
                }
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
            PacienteModel paciente = null;
            EspecialistaModel especialista = null;
            SecretarioModel secretario = null;

            try
            {
                string email = form["email"];
                string senha = form["senha"];
                             
                if (email != "" && senha != "")
                {
                    paciente = (new PacienteModel()).Login(email, senha);
                    if (paciente != null)
                    {
                        

                        return View();
                    }

                    especialista = (new EspecialistaModel()).Login(email, senha);
                    if (especialista != null)
                    {
                        return View();
                    }

                    secretario = (new SecretarioModel()).Login(email, senha);
                    if (secretario != null)
                    {
                        return View();
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
