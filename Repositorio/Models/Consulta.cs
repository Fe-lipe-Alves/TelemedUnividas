using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Consulta
    {
        public Consulta()
        {
            Chamada = new HashSet<Chamada>();
        }

        public int Codigo { get; set; }
        public int EspecialistaCodigo { get; set; }
        public int Paciente { get; set; }
        public int ClinicaCodigo { get; set; }
        public DateTime? Data { get; set; }
        public int? Status { get; set; }
        public bool? Retorno { get; set; }

        public virtual Clinica ClinicaCodigoNavigation { get; set; }
        public virtual Especialista EspecialistaCodigoNavigation { get; set; }
        public virtual Paciente PacienteNavigation { get; set; }
        public virtual ICollection<Chamada> Chamada { get; set; }
    }
}
