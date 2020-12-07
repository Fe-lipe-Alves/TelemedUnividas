using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositorio.Repositorio;
using Repositorio.Models;

namespace TelemedUnividas.Models
{
    public class AdministradorModel : BaseModel<Administrador, AdministradorModel>
    {
        #region Propriedades
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        #endregion

        #region Propriedades Auxiliares
        public new AdministradorRepositorio repositorio;

        #endregion

        #region Construtores
        public AdministradorModel()
        {
            this.repositorio = new AdministradorRepositorio();
            base.repositorio = this.repositorio;
        }

        public AdministradorModel(string nome, string sobrenome, string email, string senha, int codigo = 0)
        {
            Codigo = codigo;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Senha = senha;

            this.repositorio = new AdministradorRepositorio();
            base.repositorio = this.repositorio;
        }
        #endregion

        #region Métodos
        public AdministradorModel Login(string email, string senha)
        {
            Administrador administrador = this.repositorio.Login(email, senha);
            return AdministradorModel.ReverterModel(administrador);
        }

        public String NomeCompleto()
        {
            return this.Nome + " " + this.Sobrenome;
        }


        public AdministradorModel LocalizarEmail(string email)
        {
            Administrador administrador = this.repositorio.LocalizarEmail(email);
            return AdministradorModel.ReverterModel(administrador);
        }
        #endregion
    }
}
