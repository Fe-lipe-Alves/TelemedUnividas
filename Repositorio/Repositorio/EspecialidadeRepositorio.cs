using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repositorio
{
    public class EspecialidadeRepositorio : BaseRepositorio<Especialidade>
    {

        public List<Especialidade> Localizar(string pesquisa)
        {
            List<Especialidade> especialidades = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                especialidades = (from e in db.Especialidade where e.Descricao.Contains(pesquisa) select e).ToList();
            }

            return especialidades;
        }
    }
}
