using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class UnidadeFederativa
    {
        public UnidadeFederativa()
        {
            Cidades = new HashSet<Cidades>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Cidades> Cidades { get; set; }
    }
}
