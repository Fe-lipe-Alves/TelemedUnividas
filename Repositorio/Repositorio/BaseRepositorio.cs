using Microsoft.EntityFrameworkCore;
using Repositorio.Models;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Repositorio.Repositorio
{
    public abstract class BaseRepositorio<Entity> where Entity : class
    {
        #region Métodos
        /// <summary>
        /// Insere um objeto <typeparamref name="Entity"/> no banco de dados
        /// </summary>
        /// <param name="entidade"></param>
        public virtual int Inserir(Entity entidade)
        {
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                db.Add(entidade);
                db.SaveChanges();
            }

            // Obtem o valor do id inserido
            var props = entidade.GetType().GetProperties();
            int codigo = (int)props.First().GetValue(entidade, null);

            return codigo;
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
        /// Obtem o objeto <typeparamref name="Entity"/> que possui a chave primária correspondente ao parametro <paramref name="pesquisa"/>
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns><typeparamref name="Entity"/></returns>
        public virtual List<Entity> Localizar(string pesquisa = "")
        {
            List<Entity> models = new List<Entity>();
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                Type entidade = typeof(Entity);
                //models = (Entity)db.Find(entidade, pesquisa);
                models = db.Set<Entity>().ToList();

            }
            return models;
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
