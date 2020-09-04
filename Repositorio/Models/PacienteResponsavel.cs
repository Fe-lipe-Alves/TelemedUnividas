using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class PacienteResponsavel
    {
        public int PacienteCodigo { get; set; }
        public int ResponsavelCodigo { get; set; }

        public virtual Pacientes PacienteCodigoNavigation { get; set; }
        public virtual Pacientes ResponsavelCodigoNavigation { get; set; }
    }
}
