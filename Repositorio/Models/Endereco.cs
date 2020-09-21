using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            Clinica = new HashSet<Clinica>();
            Especialista = new HashSet<Especialista>();
            Paciente = new HashSet<Paciente>();
            Secretario = new HashSet<Secretario>();
        }

        public int Codigo { get; set; }
        public int CidadeCodigo { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }

        public virtual Cidade CidadeCodigoNavigation { get; set; }
        public virtual ICollection<Clinica> Clinica { get; set; }
        public virtual ICollection<Especialista> Especialista { get; set; }
        public virtual ICollection<Paciente> Paciente { get; set; }
        public virtual ICollection<Secretario> Secretario { get; set; }
    }
}
