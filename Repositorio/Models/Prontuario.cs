using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Prontuario
    {
        public Prontuario()
        {
            Arquivo = new HashSet<Arquivo>();
        }

        public int Codigo { get; set; }
        public int PacienteCodigo { get; set; }
        public int EspecialistaCodigo { get; set; }
        public int ClinicaCodigo { get; set; }

        public virtual Clinica ClinicaCodigoNavigation { get; set; }
        public virtual Especialista EspecialistaCodigoNavigation { get; set; }
        public virtual Pacientes PacienteCodigoNavigation { get; set; }
        public virtual ICollection<Arquivo> Arquivo { get; set; }
    }
}
