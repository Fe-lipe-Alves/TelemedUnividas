using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class UnidadeFederativa
    {
        public UnidadeFederativa()
        {
            Cidade = new HashSet<Cidade>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }

        public virtual ICollection<Cidade> Cidade { get; set; }
    }
}
