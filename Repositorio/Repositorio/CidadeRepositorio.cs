using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.Models;

namespace Repositorio.Repositorio
{
    public class CidadeRepositorio : BaseRepositorio<Cidade>
    {
        public List<Cidade> TodosUF(int uf_codigo)
        {
            List<Cidade> cidades = new List<Cidade>();

            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                cidades = (from c in db.Cidade where c.UnidadeFederativaCodigo == uf_codigo orderby c.Nome select c).ToList();
            }

            return cidades;
        }
    }
}
