using Repositorio.Models;
using Repositorio.Repositorio;
using System;
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

        #region Construtores
        public PacienteModel()
        {
            this.repositorio = new PacienteRepositorio();
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
    }
}
