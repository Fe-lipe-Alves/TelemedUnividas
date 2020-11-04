using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositorio.Repositorio;

namespace TelemedUnividas.Models
{
    public class ConsultaModel : BaseModel<Consulta, ConsultaModel>
    {
        #region Propriedades
        public int Codigo { get; set; }
        public int EspecialistaCodigo { get; set; }
        public int Paciente { get; set; }
        public int ClinicaCodigo { get; set; }
        public DateTime? Data { get; set; }
        public int? Status { get; set; }
        public bool? Retorno { get; set; }
        #endregion

        #region Propriedades Auxiliares
        public ConsultaRepositorio repositorio{ get; set; }
        #endregion

        #region Construtores
        public ConsultaModel()
        {
            this.repositorio = new ConsultaRepositorio();
            base.repositorio = this.repositorio;
        }

        public ConsultaModel(int especialistaCodigo, int paciente, int clinicaCodigo, DateTime? data, int? status, bool? retorno, int codigo = 0)
        {
            Codigo = codigo;
            EspecialistaCodigo = especialistaCodigo;
            Paciente = paciente;
            ClinicaCodigo = clinicaCodigo;
            Data = data;
            Status = status;
            Retorno = retorno;
            this.repositorio = new ConsultaRepositorio();
            base.repositorio = this.repositorio;
        }
        #endregion

        #region Métodos

        #endregion
    }
}
