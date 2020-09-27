using Repositorio.Models;
using Repositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelemedUnividas.Models
{
    public class EspecialistaModel : BaseModel<Especialista, EspecialistaModel>
    {
        public new EspecialistaRepositorio repositorio { get; set; }
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
        public EspecialistaModel()
        {
            this.repositorio = new EspecialistaRepositorio();
        }

        public EspecialistaModel(int codigo, int? enderecoCodigo, string nome, string sobrenome, string cpf, string crm, string telefone, string email, string senha, DateTime? dataNascimento)
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

        #region Métodos
        public List<EspecialistaModel> LocalizarPorEspecialidade(int especialidade_codigo)
        {
            List<Especialista> especialistas = this.repositorio.LocalizarPorEspecialidade(especialidade_codigo);
            return BaseModel<Especialista, EspecialistaModel>.ReverterModelList(especialistas);
        }
        #endregion
    }
}
