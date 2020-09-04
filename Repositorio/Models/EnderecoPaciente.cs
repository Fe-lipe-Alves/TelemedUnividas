using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class EnderecoPaciente
    {
        public int EnderecoCodigo { get; set; }
        public int PacienteCodigo { get; set; }

        public virtual Endereco EnderecoCodigoNavigation { get; set; }
        public virtual Pacientes PacienteCodigoNavigation { get; set; }
    }
}
