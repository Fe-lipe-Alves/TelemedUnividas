using Repositorio.Models;
using Repositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelemedUnividas.Models
{
    public class CidadeModel : BaseModel<Cidade, CidadeModel>
    {
        #region Propriedades
        public override int Codigo { get; set; }
        public int UnidadeFederativaCodigo { get; set; }
        public string Nome { get; set; }
        #endregion

        #region Propriedades Auxiliares
        public new CidadeRepositorio repositorio { get; set; }
        #endregion

        #region Contrutores
        public CidadeModel()
        {
            this.repositorio = new CidadeRepositorio();
            base.repositorio = this.repositorio;
        }

        public CidadeModel(int codigo, int unidadeFederativaCodigo, string nome)
        {
            this.Codigo = codigo;
            this.UnidadeFederativaCodigo = unidadeFederativaCodigo;
            this.Nome = nome;
            this.repositorio = new CidadeRepositorio();
            base.repositorio = this.repositorio;
        }


        #endregion

        #region Métodos
        public List<CidadeModel> Localizar(string pesquisa = "")
        {
            List<Cidade> cidadeEntities = this.repositorio.Localizar(pesquisa);
            List<CidadeModel> cidades = CidadeModel.ReverterModelList(cidadeEntities);
            return cidades;
        }

        public List<CidadeModel> TodosUF(int uf_codigo)
        {
            List<Cidade> cidadesEntities = this.repositorio.TodosUF(uf_codigo);
            List<CidadeModel> cidadeModels = CidadeModel.ReverterModelList(cidadesEntities);
            return cidadeModels;
        }
        #endregion
    }
}
