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
        public virtual void Inserir(Entity entidade)
        {
            TelemedUnividasContext db = new TelemedUnividasContext();
            db.Add(entidade);
            db.SaveChanges();
        }

        public virtual Entity Localizar(int codigo)
        {
            Entity model = default(Entity);
            TelemedUnividasContext db = new TelemedUnividasContext();

            Type entidade = typeof(Entity);
            model = (Entity)db.Find(entidade, codigo);

            return model;
        }

        public virtual void Atualizar(Entity entidade)
        {
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                db.Entry(entidade).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public virtual void Excluir(Entity entidade)
        {
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                db.Entry(entidade).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
