using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.Models;

namespace Repositorio.Repositorio
{
    public class UnidadeFederativaRepositorio : BaseRepositorio<UnidadeFederativa>
    {
        public List<UnidadeFederativa> Localizar(string pesquisa = "")
        {
            List<UnidadeFederativa> unidadeFederativa = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                unidadeFederativa = db.UnidadeFederativa.Where(uf => uf.Nome.Contains(pesquisa)).Cast<UnidadeFederativa>().ToList();
            }

            return unidadeFederativa;
        }
    }
}
