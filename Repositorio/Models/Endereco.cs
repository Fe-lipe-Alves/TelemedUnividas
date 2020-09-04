using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Endereco
    {
        public int Codigo { get; set; }
        public int CidadeCodigo { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        public virtual Cidades CidadeCodigoNavigation { get; set; }
    }
}
