using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class EnderecoEspecialista
    {
        public int EnderecoCodigo { get; set; }
        public int EspecialistaCodigo { get; set; }

        public virtual Endereco EnderecoCodigoNavigation { get; set; }
        public virtual Especialista EspecialistaCodigoNavigation { get; set; }
    }
}
