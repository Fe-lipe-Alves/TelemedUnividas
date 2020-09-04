using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Especialista
    {
        public Especialista()
        {
            Consulta = new HashSet<Consulta>();
            Prontuario = new HashSet<Prontuario>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataNascimento { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<Prontuario> Prontuario { get; set; }
    }
}
