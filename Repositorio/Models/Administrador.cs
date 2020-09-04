using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Administrador
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public byte[] Sobrenome { get; set; }
        public byte[] Email { get; set; }
        public byte[] Senha { get; set; }
    }
}
