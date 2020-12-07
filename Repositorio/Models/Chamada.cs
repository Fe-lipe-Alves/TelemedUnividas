using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Chamada
    {
        public int Codigo { get; set; }
        public int ConsultaCodigo { get; set; }
        public string Link { get; set; }
        public DateTime? Inicio { get; set; }
        public TimeSpan? Duracao { get; set; }
        public bool? PresencaPaciente { get; set; }
        public bool? PresencaEspecialista { get; set; }
        public string Observacoes { get; set; }

        public virtual Consulta ConsultaCodigoNavigation { get; set; }
    }
}
