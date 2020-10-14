using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Clinica
    {
        public Clinica()
        {
            Consulta = new HashSet<Consulta>();
            Prontuario = new HashSet<Prontuario>();
        }

        public int Codigo { get; set; }
        public int? Endereco { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public virtual Endereco EnderecoNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<Prontuario> Prontuario { get; set; }
    }
}
