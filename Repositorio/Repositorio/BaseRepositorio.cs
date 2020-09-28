using Microsoft.EntityFrameworkCore;
using Repositorio.Models;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repositorio
{
    public abstract class BaseRepositorio<Entity>
    {
        #region Métodos
        /// <summary>
        /// Insere um objeto <typeparamref name="Entity"/> no banco de dados
        /// </summary>
        /// <param name="entidade"></param>
        public virtual void Inserir(Entity entidade)
        {
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                db.Add(entidade);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Obtem o objeto <typeparamref name="Entity"/> que possui a chave primária correspondente ao parametro <paramref name="codigo"/>
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns><typeparamref name="Entity"/></returns>
        public virtual Entity Localizar(int codigo)
        {
            Entity model = default(Entity);
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                Type entidade = typeof(Entity);
                model = (Entity)db.Find(entidade, codigo);
            }
            return model;
        }

        /// <summary>
        /// Atualiza um objeto <typeparamref name="Entity"/> no banco de dados
        /// </summary>
        /// <param name="entidade"></param>
        public virtual void Atualizar(Entity entidade)
        {
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                db.Entry(entidade).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Exclui um objeto <typeparamref name="Entity"/> do banco de dados
        /// </summary>
        /// <param name="entidade"></param>
        public virtual void Excluir(Entity entidade)
        {
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                db.Entry(entidade).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        #endregion
    }
}
