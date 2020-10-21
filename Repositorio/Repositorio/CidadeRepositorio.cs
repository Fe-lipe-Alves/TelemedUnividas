using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.Models;

namespace Repositorio.Repositorio
{
    public class CidadeRepositorio : BaseRepositorio<Cidade>
    {
        public List<Cidade> Localizar(string pesquisa = "")
        {
            List<Cidade> cidades = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                cidades = db.Cidade.Where(c => c.Nome.Contains(pesquisa)).ToList();
            }

            return cidades;
        } 
    }
}
