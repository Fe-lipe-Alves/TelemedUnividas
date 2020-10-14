using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositorio.Repositorio;

namespace TelemedUnividas.Models
{
    public class SecretarioEspecialistaClinicaModel : BaseModel<SecretarioEspecialistaClinica, SecretarioEspecialistaClinicaModel>
    {
        #region Propriedades
        public int SecretarioCodigo { get; set; }
        public int EspecialistaCodigo { get; set; }
        public int ClinicaCodigo { get; set; }
        #endregion

        #region Propriedades Auxiliares
        public SecretarioEspecialistaClinicaRepositorio repositorio { get; set; }
        #endregion

        #region Contrutor
        public SecretarioEspecialistaClinicaModel()
        {
            this.repositorio = new SecretarioEspecialistaClinicaRepositorio();
        }

        public SecretarioEspecialistaClinicaModel(int secretarioCodigo, int especialistaCodigo, int clinicaCodigo)
        {
            SecretarioCodigo = secretarioCodigo;
            EspecialistaCodigo = especialistaCodigo;
            ClinicaCodigo = clinicaCodigo;
            this.repositorio = repositorio;
            this.repositorio = new SecretarioEspecialistaClinicaRepositorio();
        }

        #endregion
    }
}
