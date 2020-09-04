using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Arquivo
    {
        public int Codigo { get; set; }
        public int TipoArquivoCodigo { get; set; }
        public int ProntuarioCodigo { get; set; }
        public string Src { get; set; }
        public DateTime? DataCriacao { get; set; }

        public virtual Prontuario ProntuarioCodigoNavigation { get; set; }
        public virtual TipoArquivo TipoArquivoCodigoNavigation { get; set; }
    }
}
