using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelemedUnividas.Models;
using System.Web;
using Repositorio.Models;
using System.Collections;
using Repositorio.Helpers;
using Newtonsoft.Json;
using System.Text.Json;
using Repositorio.JsonModels;

namespace TelemedUnividas.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Especialistas()
        {
            ViewData["especialistas"] = (new EspecialistaModel()).Localizar();

            return View();
        }
        public IActionResult Pacientes()
        {
            ViewData["pacientes"] = (new PacienteModel()).Localizar();

            return View();
        }

        public IActionResult Secretarios()
        {
            ViewData["secretarios"] = (new SecretarioModel()).Localizar();

            return View();
        }


        /// <summary>
        /// Exibe a tela de cadastro
        /// </summary>
        /// <returns></returns>
        public IActionResult Cadastrar()
        {
            try
            {
                ViewData["estados"] = (new UnidadeFederativaModel()).Localizar();
                ViewData["clinicas"] = (new ClinicaModel()).Localizar();
                ViewData["especialidades"] = (new EspecialidadeModel()).Localizar();
            }
            catch (Exception)
            {

            }

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
                    PacienteModel pacienteTeste = null;
                    pacienteTeste = (new PacienteModel()).LocalizarCPF(cpf);
                    if (pacienteTeste != null)
                    {
                        throw new Exception("CPF já cadastrado em outro usuário");
                    }

                    pacienteTeste = (new PacienteModel()).LocalizarEmail(cpf);
                    if (pacienteTeste != null)
                    {
                        throw new Exception("CPF já cadastrado em outro usuário");
                    }


                    //String senha = Senha.Gerar();
                    String senha = "abcd@123";

                    EnderecoModel endereco = new EnderecoModel();
                    endereco.CidadeCodigo = cidade;
                    endereco.Logradouro = rua;
                    endereco.Numero = numero;
                    endereco.Complemento = complemento;
                    endereco.Bairro = bairro;
                    endereco.Salvar();

                    if (tipoUsuario == "paciente")
                    {
                        double coparticipacao = double.Parse(form["coparticipacao"]);

                        if(coparticipacao != 0.0)
                        {
                            // Carrega os dados do objeto
                            PacienteModel paciente = new PacienteModel()
                            {
                                Nome = nome,
                                Sobrenome = sobrenome,
                                Cpf = cpf,
                                DataNascimento = dataNascimento,
                                Telefone = telefone,
                                Email = email,
                                Senha = Hash.GetHashString(senha),
                                EnderecoCodigo = endereco.Codigo
                            };
                            paciente.Salvar();
                        }
                    } else if(tipoUsuario == "especialista")
                    {
                        EspecialistaModel especialistaTeste = null;
                        especialistaTeste = (new EspecialistaModel()).LocalizarCPF(cpf);
                        if (especialistaTeste != null)
                        {
                            throw new Exception("CPF já cadastrado em outro usuário");
                        }

                        especialistaTeste = (new EspecialistaModel()).LocalizarEmail(cpf);
                        if (especialistaTeste != null)
                        {
                            throw new Exception("CPF já cadastrado em outro usuário");
                        }


                        string crm = form["crm"];
                        List<EspecialidadeClinicaJsonModel> especialidadesClinicas = System.Text.Json.JsonSerializer.Deserialize<List<EspecialidadeClinicaJsonModel>>(form["especialidadesClinicas"]);
                        
                        if (crm != "" && especialidadesClinicas != null)
                        {
                            // Carrega objeto
                            EspecialistaModel especialista = new EspecialistaModel()
                            {
                                Nome = nome,
                                Sobrenome = sobrenome,
                                Cpf = cpf,
                                DataNascimento = dataNascimento,
                                Telefone = telefone,
                                Email = email,
                                Senha = Hash.GetHashString(senha),
                                EnderecoCodigo = endereco.Codigo
                            };
                            especialista.Salvar();

                            // Percorre todas as uniões de clinicas e especialidades
                            foreach (EspecialidadeClinicaJsonModel especialidadeClinica in especialidadesClinicas)
                            {
                                ClinicaModel clinica = (new ClinicaModel()).Obter(especialidadeClinica.clinica);
                                EspecialidadeModel especialidade = (new EspecialidadeModel()).Obter(especialidadeClinica.especialidade);

                                // Caso um dos modelos estiver vazio retorna um erro
                                if (clinica == null)
                                {
                                    throw new Exception("Clinica Inválida");
                                }
                                if (especialidade == null)
                                {
                                    throw new Exception("Clinica Inválida");
                                }

                                // Salva o vinculo Especialista, Especialidade e Clinica
                                especialista.SalvarEspecialidadesClinicas(especialidade, clinica);
                            }

                        }
                    } else if (tipoUsuario == "secretario")
                    {
                        SecretarioModel secretarioTeste = null;
                        secretarioTeste = (new SecretarioModel()).LocalizarCPF(cpf);
                        if (secretarioTeste != null)
                        {
                            throw new Exception("CPF já cadastrado em outro usuário");
                        }

                        secretarioTeste = (new SecretarioModel()).LocalizarEmail(cpf);
                        if (secretarioTeste != null)
                        {
                            throw new Exception("CPF já cadastrado em outro usuário");
                        }

                        SecretarioModel secretario = new SecretarioModel()
                        {
                            Nome = nome,
                            Sobrenome = sobrenome,
                            Cpf = cpf,
                            DataNascimento = dataNascimento,
                            Telefone = telefone,
                            Email = email,
                            Senha = Hash.GetHashString(senha),
                            EnderecoCodigo = endereco.Codigo
                        };

                        secretario.Salvar();
                    } else if (tipoUsuario == "administrador")
                    {
                        AdministradorModel administradorTeste = null;
                        administradorTeste = (new AdministradorModel()).LocalizarEmail(cpf);
                        if (administradorTeste != null)
                        {
                            throw new Exception("CPF já cadastrado em outro usuário");
                        }

                        AdministradorModel administrador = new AdministradorModel()
                        {
                            Nome = nome,
                            Sobrenome = sobrenome,
                            Email = email,
                            Senha = Hash.GetHashString(senha),
                        };

                        administrador.Salvar();
                    }
                    else
                    {
                        throw new Exception("Tipo de usuário não encontrado");
                    }

                    // Aqui segue o Fluxo normal e envia uma mensagem de e-mail
                    // com as informações de login
                } else
                {
                    throw new Exception("Preencha todos os campos corretamente.");
                }
            }
            catch (Exception ex)
            {
                ViewData["erro"] = "Falha ao salvar os dados"+ex.Message;
                return View("Cadastrar");
            }

            ViewData["sucesso"] = "Sucesso ao cadastrar usuário";
            return View("../Administrador/Index");
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
            AdministradorModel administrador = null;

            try
            {
                string email = form["email"];
                //string senha = Hash.GetHashString(form["senha"]);
                string senha = Hash.GetHashString(form["senha"]);

                if (email != "" && senha != "")
                {
                    paciente = (new PacienteModel()).Login(email, senha);
                    if (paciente != null)
                    {
                        HttpContext.Session.SetInt32("codigo_usuario", paciente.Codigo);
                        HttpContext.Session.SetString("tipo_usuario", "Paciente");
                    }

                    especialista = (new EspecialistaModel()).Login(email, senha);
                    if (especialista != null)
                    {
                        HttpContext.Session.SetInt32("codigo_usuario", especialista.Codigo);
                        HttpContext.Session.SetString("tipo_usuario", "Especialista");
                    }

                    secretario = (new SecretarioModel()).Login(email, senha);
                    if (secretario != null)
                    {
                        HttpContext.Session.SetInt32("codigo_usuario", secretario.Codigo);
                        HttpContext.Session.SetString("tipo_usuario", "Secretario");
                    }

                    administrador = (new AdministradorModel()).Login(email, senha);
                    if (administrador != null)
                    {
                        HttpContext.Session.SetInt32("codigo_usuario", administrador.Codigo);
                        HttpContext.Session.SetString("tipo_usuario", "Administrador");
                        return View("../Administrador/Index");
                    }

                    return View("../Home/Index");
                } else
                {
                    throw new Exception("E-mail ou senha invalidos");
                }
            }
            catch (Exception ex)
            {
                ViewData["erro"] = new { Mensagem = ex.Message };
            }

            return View("Login");
        }

        /// <summary>
        /// Logout do usuário
        /// </summary>
        /// <returns></returns>
        public IActionResult Sair()
        {
            HttpContext.Session.Remove("codigo_usuario");
            HttpContext.Session.Remove("tipo_usuario");

            return View("../Home/Index");
        }

        public JsonResult Buscar(string pesquisa)
        {
            List<PacienteModel> pacientes = (new PacienteModel()).Localizar(pesquisa);

            List<object> pacientesObject = new List<object>();

            foreach (PacienteModel paciente in pacientes)
            {
                pacientesObject.Add(new { codigo = paciente.Codigo, nome = paciente.NomeCompleto() });
            }

            return new JsonResult(pacientesObject);
        }
    }
}
