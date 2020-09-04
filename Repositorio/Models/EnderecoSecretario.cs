using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class EnderecoSecretario
    {
        public int EnderecoCodigo { get; set; }
        public int SecretarioCodigo { get; set; }

        public virtual Endereco EnderecoCodigoNavigation { get; set; }
        public virtual Secretario SecretarioCodigoNavigation { get; set; }
    }
}
