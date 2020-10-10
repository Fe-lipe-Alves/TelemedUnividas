using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repositorio
{
    public class SecretarioRepositorio : BaseRepositorio<Secretario>
    {
        #region Métodos
        /// <summary>
        /// Obtem uma lista de <see cref="Secretario"/> que estão relacionados ao <see cref="Especialista"/> correspondente a <paramref name="especialista_codigo"/>
        /// </summary>
        /// <param name="especialista_codigo"></param>
        /// <returns></returns>
        /*public List<Secretario> LocalizarPorEspecialista(int especialista_codigo)
        {
            List<Secretario> secretarios = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                secretarios = (from s in db.Secretario
                               join sec in db.EspecialidadeEspecialistaClinica on s.Codigo equals sec.EspecialisataCodigo
                               where sec.EspecialidadeCodigo == especialista_codigo
                               select s).ToList();
            }
            return secretarios;
        }*/

        /// <summary>
        /// Busca por <see cref="Secretario"/> que corresponde ao <paramref name="email"/> e <paramref name="senha"/> informados
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        public Secretario Login(string email, string senha)
        {
            Secretario secretario = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                // secretario = (from p in db.Secretario where p.Email == email && p.Senha == senha select p).FirstOrDefault();
            }

            return secretario;
        }
        #endregion
    }
}
