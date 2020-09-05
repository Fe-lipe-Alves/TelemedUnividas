using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Secretario
    {
        public int Codigo { get; set; }
        public int? EnderecoCodigo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataNascimento { get; set; }

        public virtual Endereco EnderecoCodigoNavigation { get; set; }
    }
}
