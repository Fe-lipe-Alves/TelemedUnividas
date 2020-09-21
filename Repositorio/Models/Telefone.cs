using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Telefone
    {
        public int Codigo { get; set; }
        public int ClicnicaCodigo { get; set; }
        public string Numero { get; set; }

        public virtual Clinica ClicnicaCodigoNavigation { get; set; }
    }
}
