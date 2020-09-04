using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class EspecialidadeEspecialistaClinica
    {
        public int EspecialisataCodigo { get; set; }
        public int EspecialidadeCodigo { get; set; }
        public int ClinicaCodigo { get; set; }

        public virtual Clinica ClinicaCodigoNavigation { get; set; }
        public virtual Especialidade EspecialidadeCodigoNavigation { get; set; }
        public virtual Especialista EspecialisataCodigoNavigation { get; set; }
    }
}
