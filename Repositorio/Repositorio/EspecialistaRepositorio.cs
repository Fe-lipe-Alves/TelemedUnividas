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
                                 join eec in db.EspecialidadeEspecialistaClinica on e.Codigo equals eec.EspecialisataCodigo
                                 where eec.EspecialidadeCodigo == especialidade_codigo
                                 select e).ToList();
            }

            return especialistas;
        }
        #endregion
    }
}
