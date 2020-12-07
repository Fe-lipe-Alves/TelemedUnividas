using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositorio.Repositorio;
using Repositorio.Models;

namespace TelemedUnividas.Models
{
    public class ChamadaModel : BaseModel<Chamada, ChamadaModel>
    {
        #region Propriedades
        public int Codigo { get; set; }
        public int ConsultaCodigo { get; set; }
        public string Link { get; set; }
        public DateTime? Inicio { get; set; }
        public TimeSpan? Duracao { get; set; }
        public bool? PresencaPaciente { get; set; }
        public bool? PresencaEspecialista { get; set; }
        public string Observacoes { get; set; }
        #endregion

        #region Propriedades Auxiliares
        public new ChamadaRepositorio repositorio{ get; set; }
        #endregion

        #region Construtores
        public ChamadaModel()
        {
            this.repositorio = new ChamadaRepositorio();
            base.repositorio = this.repositorio;
        }

        public ChamadaModel(int codigo, int consultaCodigo, String link, DateTime? inicio, TimeSpan? duracao, bool? presencaPaciente, bool? presencaEspecialista, string observacoes)
        {
            Codigo = codigo;
            ConsultaCodigo = consultaCodigo;
            Link = link;
            Inicio = inicio;
            Duracao = duracao;
            PresencaPaciente = presencaPaciente;
            PresencaEspecialista = presencaEspecialista;
            Observacoes = observacoes;
            this.repositorio = new ChamadaRepositorio();
            base.repositorio = this.repositorio;
        }
        #endregion

        #region Métodos
        public ChamadaModel ObterPorConsulta(int consulta_codigo)
        {
            Chamada chamada = this.repositorio.ObterPorConsulta(consulta_codigo);
            return ChamadaModel.ReverterModel(chamada);
        }
        #endregion
    }
}
