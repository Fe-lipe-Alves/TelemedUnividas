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

        /// <summary>
        /// Busca por <see cref="Paciente"/> que corresponde ao <paramref name="email"/> e <paramref name="senha"/> informados
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        public Paciente Login(string email, string senha)
        {
            Paciente paciente = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                paciente = (from p in db.Paciente where p.Email == email && p.Senha == senha select p).FirstOrDefault();
            }

            return paciente;
        }

        public Paciente LocalizarCPF(string cpf)
        {
            Paciente paciente = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                paciente = (from p in db.Paciente where p.Cpf == cpf select p).FirstOrDefault();
            }

            return paciente;
        }
        
        public Paciente LocalizarEmail(string email)
        {
            Paciente paciente = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                paciente = (from p in db.Paciente where p.Email == email select p).FirstOrDefault();
            }

            return paciente;
        }
        #endregion
    }
}
