using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositorio.Repositorio;

namespace TelemedUnividas.Models
{
    public class EnderecoModel : BaseModel<Endereco, EnderecoModel>
    {
        #region Propriedades
        public override int Codigo { get; set; }
        public int CidadeCodigo { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        #endregion

        #region Propriedades Auxiliares
        public override BaseRepositorio<Endereco> repositorio { get; set; }

        
        #endregion

        #region Contrutor
        public EnderecoModel()
        {
            this.repositorio = new EnderecoRepositorio();
        }

        public EnderecoModel(int codigo, int cidadeCodigo, string logradouro, string numero, string complemento)
        {
            Codigo = codigo;
            CidadeCodigo = cidadeCodigo;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            this.repositorio = new EnderecoRepositorio();
        }
        #endregion
    }
}
