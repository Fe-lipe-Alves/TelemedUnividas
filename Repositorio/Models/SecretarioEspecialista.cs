using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class SecretarioEspecialista
    {
        public int SecretarioCodigo { get; set; }
        public int ClinicaCodigo { get; set; }

        public virtual Clinica ClinicaCodigoNavigation { get; set; }
        public virtual Secretario SecretarioCodigoNavigation { get; set; }
    }
}
