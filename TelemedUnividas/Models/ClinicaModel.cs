using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositorio.Repositorio;
using Repositorio.Models;

namespace TelemedUnividas.Models
{
    public class ClinicaModel : BaseModel<Clinica, ClinicaModel>
    {
        #region Propriedades
        public int Codigo { get; set; }
        public int? Endereco { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        #endregion

        #region Propriedades Auxiliares
        public new ClinicaRepositorio repositorio;
        #endregion

        #region Contrutores
        public ClinicaModel()
        {
            this.repositorio = new ClinicaRepositorio();
            base.repositorio = this.repositorio;
        }

        public ClinicaModel(int codigo, int? endereco, string nome, string email, string telefone)
        {
            Codigo = codigo;
            Endereco = endereco;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            this.repositorio = new ClinicaRepositorio();
            base.repositorio = this.repositorio;
        }
        #endregion

        #region Métodos
        public List<ClinicaModel> Localizar(string pesquisa = "")
        {
            List<Clinica> cidadeEntities = this.repositorio.Localizar(pesquisa);
            return ClinicaModel.ReverterModelList(cidadeEntities);
        }
        #endregion
    }
}
