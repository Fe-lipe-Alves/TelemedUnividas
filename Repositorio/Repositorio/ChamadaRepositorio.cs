using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Repositorio.Models;

namespace Repositorio.Repositorio
{
    public class ChamadaRepositorio : BaseRepositorio<Chamada>
    {
        public Chamada ObterPorConsulta(int consulta_codigo)
        {
            Chamada chamada = null;

            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                chamada = (from c in db.Chamada where c.ConsultaCodigo == consulta_codigo select c).FirstOrDefault();
            }

            return chamada;
        }
    }
}
