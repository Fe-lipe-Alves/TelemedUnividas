using Repositorio.Models;
using Repositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TelemedUnividas.Models
{
    public class PacienteModel : BaseModel<Paciente, PacienteModel>
    {
        #region Propriedades
        [Display(Name = "Código")]
        public override int Codigo { get; set; }

        [Display(Name = "Endereço")]
        public int? EnderecoCodigo { get; set; }

        [Display(Name = "Nome")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Nome não pode ter mais de 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        [DataType(DataType.Text)]
        [StringLength(150, ErrorMessage = "Sobrenome não pode ter mais de 150 caracteres")]
        public string Sobrenome { get; set; }

        [Display(Name = "CPF")]
        [DataType(DataType.Text)]
        public string Cpf { get; set; }

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "E-mail não pode ter mais de 100 caracteres")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [StringLength(16, ErrorMessage = "Senha não pode ter mais de 16 caracteres")]
        public string Senha { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }
        #endregion

        #region Propriedades Auxiliares
        public new PacienteRepositorio repositorio { get; set; }
        #endregion

        #region Construtores
        public PacienteModel()
        {
            this.repositorio = new PacienteRepositorio();
            base.repositorio = this.repositorio;
        }

        public PacienteModel(int codigo, int? enderecoCodigo, string nome, string sobrenome, string cpf, string telefone, string email, string senha, DateTime? dataNascimento, PacienteRepositorio repositorio)
        {
            this.Codigo = codigo;
            this.EnderecoCodigo = enderecoCodigo;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Cpf = cpf;
            this.Telefone = telefone;
            this.Email = email;
            this.Senha = senha;
            this.DataNascimento = dataNascimento;
            this.repositorio = new PacienteRepositorio();
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Retorna uma lista de <see cref="PacienteModel"/> que contenham o valor de <paramref name="pesquisa"/> no nome, email ou CRM
        /// </summary>
        /// <param name="pesquisa"></param>
        /// <returns></returns>
        public List<PacienteModel> Localizar(string pesquisa = "")
        {
            List<Paciente> especialistaEntity = this.repositorio.Localizar(pesquisa);
            List<PacienteModel> especialistas = PacienteModel.ReverterModelList(especialistaEntity);
            return especialistas;
        }

        public PacienteModel LocalizarCPF(string cpf)
        {
            Paciente paciente = this.repositorio.LocalizarCPF(cpf);
            return PacienteModel.ReverterModel(paciente);
        }
        
        public PacienteModel LocalizarEmail(string email)
        {
            Paciente paciente = this.repositorio.LocalizarEmail(email);
            return PacienteModel.ReverterModel(paciente);
        }

        /// <summary>
        /// Retorna o <see cref="PacienteModel"/> que corresponde ao <paramref name="email"/> e <paramref name="senha"/> fornecidos
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public PacienteModel Login(string email, string senha)
        {
            Paciente paciente = this.repositorio.Login(email, senha);
            return PacienteModel.ReverterModel(paciente);
        }

        public String NomeCompleto()
        {
            return this.Nome + " " + this.Sobrenome;
        }        
        #endregion
    }
}
