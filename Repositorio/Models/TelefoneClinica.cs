using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class TelefoneClinica
    {
        public int ClinicaCodigo { get; set; }
        public int TelefoneCodigo { get; set; }

        public virtual Clinica ClinicaCodigoNavigation { get; set; }
        public virtual Telefone TelefoneCodigoNavigation { get; set; }
    }
}
