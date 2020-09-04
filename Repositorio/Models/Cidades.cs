using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Cidades
    {
        public Cidades()
        {
            Endereco = new HashSet<Endereco>();
        }

        public int Codigo { get; set; }
        public int UnidadeFederativaCodigo { get; set; }
        public string Nome { get; set; }

        public virtual UnidadeFederativa UnidadeFederativaCodigoNavigation { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
    }
}
