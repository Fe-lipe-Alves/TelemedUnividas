using Microsoft.EntityFrameworkCore;
using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repositorio
{
    public class PacienteRepositorio : BaseRepositorio<Paciente>
    {
        #region Métodos
        /// <summary>
        /// Obtem uma lista de <see cref="Paciente"/> que contenha o conteúdo de <paramref name="pesquisa"/> nas propriedades:
        /// <list type="table">
        /// <item><see cref="Paciente.Nome"/></item>
        /// <item><see cref="Paciente.Sobrenome"/></item>
        /// <item><see cref="Paciente.Email"/></item>
        /// <item><see cref="Paciente.Cpf"/></item>
        /// </list>
        /// </summary>
        /// <param name="pesquisa"></param>
        /// <returns></returns>
        public List<Paciente> Localizar(string pesquisa)
        {
            List<Paciente> pacientes = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                pacientes = (from p in db.Paciente
                             where p.Nome.Contains(pesquisa)
                             || p.Sobrenome.Contains(pesquisa)
                             || p.Email.Contains(pesquisa)
                             || p.Cpf.Contains(pesquisa)
                             select p).ToList();
            }
            return pacientes;
        }
        #endregion
    }
}
