using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repositorio
{
    public class ClinicaRepositorio : BaseRepositorio<Clinica>
    {
        public List<Clinica> Localizar(string pesquisa)
        {
            List<Clinica> clinicas = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                clinicas = db.Clinica.Where(c => c.Nome.Contains(pesquisa)).ToList();
            }

            return clinicas;
        }
    }
}
