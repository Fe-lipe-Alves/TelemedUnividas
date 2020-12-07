using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Repositorio.Models;

namespace Repositorio.Repositorio
{
    public class AdministradorRepositorio : BaseRepositorio<Administrador>
    {
        /// <summary>
        /// Busca por <see cref="Administrador"/> que corresponde ao <paramref name="email"/> e <paramref name="senha"/> informados
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        public Administrador Login(string email, string senha)
        {
            Administrador administrador = null;

            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                administrador = (from p in db.Administrador where p.Email == email && p.Senha == senha select p).FirstOrDefault();
            }

            return administrador;
        }

        public Administrador LocalizarEmail(string email)
        {
            Administrador administrador = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                administrador = (from p in db.Administrador where p.Email == email select p).FirstOrDefault();
            }

            return administrador;
        }
    }
}
