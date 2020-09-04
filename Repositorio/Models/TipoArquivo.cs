using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class TipoArquivo
    {
        public TipoArquivo()
        {
            Arquivo = new HashSet<Arquivo>();
        }

        public int Codigo { get; set; }
        public byte[] Descricao { get; set; }

        public virtual ICollection<Arquivo> Arquivo { get; set; }
    }
}
