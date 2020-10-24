using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
        /// <summary>
        /// Obtem uma lista de <see cref="Especialista"/> em que na propriedade <see cref="Especialista.Nome"/>, <see cref="Especialista.Sobrenome"/> ou <see cref="Especialista.Crm"/> contenham o conteudo de <paramref name="pesquisa"/>
        /// </summary>
        /// <param name="pesquisa"></param>
        public List<Especialista> Localizar(string pesquisa)
        {
            List<Especialista> especialistas = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                especialistas = (from e in db.Especialista where e.Nome.Contains(pesquisa) || e.Sobrenome.Contains(pesquisa) || e.Crm.Contains(pesquisa) select e).ToList();
            }

            return especialistas;
        }

        /// <summary>
        /// Busca por <see cref="Especialista"/> que corresponde ao <paramref name="email"/> e <paramref name="senha"/> informados
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        public Especialista Login(string email, string senha)
        {
            Especialista especialista = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                especialista = (from p in db.Especialista where p.Email == email && p.Senha == senha select p).FirstOrDefault();
            }

            return especialista;
        }

        /// <summary>
        /// Obtem uam lista de <see cref="Especialista"/> que se relacionam com <see cref="Especialidade"/> correspondente ao código <paramref name="especialidade_codigo"/>
        /// </summary>
        /// <param name="especialidade_codigo"></param>
        /// <returns></returns>
        public List<Especialista> LocalizarPorEspecialidade(int especialidade_codigo)
        {
            List<Especialista> especialistas = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                especialistas = (from e in db.Especialista 
                                 join eec in db.EspecialidadeEspecialistaClinica on e.Codigo equals eec.EspecialistaCodigo
                                 where eec.EspecialidadeCodigo == especialidade_codigo
                                 select e).ToList();
            }

            return especialistas;
        }

        public List<Especialista> LocalizarPorClinica(int clinica_codigo)
        {
            List<Especialista> especialistas = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                var query = db.Especialista    // your starting point - table in the "from" statement
                   .Join(db.EspecialidadeEspecialistaClinica, // the source table of the inner join
                      especialist => especialist.Codigo,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
                      eec => eec.EspecialistaCodigo,   // Select the foreign key (the second part of the "on" clause)
                      (especialist, eec) => new { Especialista = especialist, EspecialidadeEspecialistaClinica = eec }) // selection
                   .Where(e => e.EspecialidadeEspecialistaClinica.ClinicaCodigo == clinica_codigo)
                   .Select(e => e.Especialista).ToList();    // where statement
            }

            return especialistas;
        }

        /// <summary>
        /// Salva o vinculo entre o <see cref="Especialista"/>, a <see cref="Especialidade"/> e a <see cref="Clinica"/>
        /// </summary>
        /// <param name="especialidade"></param>
        /// <param name="especialista"></param>
        /// <param name="clinica"></param>
        public void SalvarEspecialidadesClinicas(Especialidade especialidade, Especialista especialista, Clinica clinica)
        {
            EspecialidadeEspecialistaClinica eec = new EspecialidadeEspecialistaClinica();
            eec.EspecialistaCodigo = especialista.Codigo;
            eec.EspecialidadeCodigo = especialidade.Codigo;
            eec.ClinicaCodigo = clinica.Codigo;

            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                db.Entry(eec);
                db.EspecialidadeEspecialistaClinica.Add(eec);
                db.SaveChanges();
            }
        }
        #endregion
    }
}
