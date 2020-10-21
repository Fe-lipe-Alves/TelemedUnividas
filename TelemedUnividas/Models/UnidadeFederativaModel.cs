using Repositorio.Models;
using Repositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelemedUnividas.Models
{
    public class UnidadeFederativaModel : BaseModel<UnidadeFederativa, UnidadeFederativaModel>
    {
        #region Propriedades
        public override int Codigo { get; set; }
        public string Nome { get; set; }
        #endregion

        #region Propriedades Auxiliares
        public new UnidadeFederativaRepositorio repositorio { get; set; }
        #endregion

        #region Contrutores
        public UnidadeFederativaModel()
        {
            this.repositorio = new UnidadeFederativaRepositorio();
            base.repositorio = this.repositorio;
        }

        public UnidadeFederativaModel(int codigo, string nome)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.repositorio = new UnidadeFederativaRepositorio();
            base.repositorio = this.repositorio;
        }


        #endregion

        #region Métodos
        public List<UnidadeFederativaModel> Localizar(string pesquisa = "")
        {
            List<UnidadeFederativa> unidadeFederativaEntities = this.repositorio.Localizar(pesquisa);
            List<UnidadeFederativaModel> unidadeFederativa = UnidadeFederativaModel.ReverterModelList(unidadeFederativaEntities);
            return unidadeFederativa;
        }
        #endregion
    }
}
