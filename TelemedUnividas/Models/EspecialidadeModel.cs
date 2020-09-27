using Repositorio.Models;
using Repositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelemedUnividas.Models
{
    public class EspecialidadeModel : BaseModel<Especialista, EspecialidadeModel>
    {
        #region Propriedades
        public int Codigo { get; set; }
        public int? EnderecoCodigo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataNascimento { get; set; }
        #endregion

        #region Construtores
        public EspecialidadeModel()
        {
            this.repositorio = new EspecialistaRepositorio();
        }

        public BaseRepositorio<Especialista> repositorio = new EspecialistaRepositorio();

        public EspecialidadeModel(int codigo, int? enderecoCodigo, string nome, string sobrenome, string cpf, string crm, string telefone, string email, string senha, DateTime? dataNascimento)
        {
            this.Codigo = codigo;
            this.EnderecoCodigo = enderecoCodigo;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Cpf = cpf;
            this.Crm = crm;
            this.Telefone = telefone;
            this.Email = email;
            this.Senha = senha;
            this.DataNascimento = dataNascimento;
            this.repositorio = new EspecialistaRepositorio();
        }
        #endregion
    }
}
