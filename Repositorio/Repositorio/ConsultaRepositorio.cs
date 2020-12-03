using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repositorio.Repositorio
{
    public class ConsultaRepositorio : BaseRepositorio<Consulta>
    {
        public List<Consulta> ObterAgenda(int especialista_codigo)
        {
            List<Consulta> consultas = null;

            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                consultas = (from c in db.Consulta where c.EspecialistaCodigo == especialista_codigo select c).ToList();
            }

            return consultas;
        }
    }
}
