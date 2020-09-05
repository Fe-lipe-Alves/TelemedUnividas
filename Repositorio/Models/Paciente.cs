using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
            Prontuario = new HashSet<Prontuario>();
        }

        public int Codigo { get; set; }
        public int? EnderecoCodigo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public byte[] Email { get; set; }
        public byte[] Senha { get; set; }
        public DateTime? DataNascimento { get; set; }

        public virtual Endereco EnderecoCodigoNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<Prontuario> Prontuario { get; set; }
    }
}
