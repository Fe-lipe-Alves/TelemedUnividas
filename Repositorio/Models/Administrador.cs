using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Administrador
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
