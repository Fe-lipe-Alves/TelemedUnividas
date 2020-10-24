using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            EspecialidadeEspecialistaClinica = new HashSet<EspecialidadeEspecialistaClinica>();
        }

        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<EspecialidadeEspecialistaClinica> EspecialidadeEspecialistaClinica { get; set; }
    }
}
