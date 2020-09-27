using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Repositorio.Repositorio
{
    public class EspecialistaRepositorio : BaseRepositorio<Especialista>
    {
        #region Métodos
        public List<Especialista> Localizar(string pesquisa)
        {
            List<Especialista> especialistas = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                especialistas = (from e in db.Especialista where e.Nome.Contains(pesquisa) || e.Sobrenome.Contains(pesquisa) || e.Crm.Contains(pesquisa) select e).ToList();
            }

            return especialistas;
        }

        public List<Especialista> LocalizarPorEspecialidade(int especialidade_codigo)
        {
            List<Especialista> especialistas = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                especialistas = (from e in db.Especialista 
                                 join eec in db.EspecialidadeEspecialistaClinica on e.Codigo equals eec.EspecialisataCodigo
                                 where eec.EspecialidadeCodigo == especialidade_codigo
                                 select e).ToList();
            }

            return especialistas;
        }
        #endregion
    }
}
