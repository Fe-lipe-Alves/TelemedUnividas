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
        public abstract IQueryable<object> DbModel { get; set; }

        public void Teste()
        {
            Type x = typeof(Entity);
            var c = x.Name;
            var db = new TelemedUnividasContext();
            object[] vet = new object[] { 4, 5 };

            var bg = db.Find(x, 4);

            object newHuman = Activator.CreateInstance(x);

            var z = db.Attach(newHuman);

            Type myType = typeof(TelemedUnividasContext);
            // Get the PropertyInfo object by passing the property name.
            PropertyInfo myPropInfo = myType.GetProperty(c);

            var t = myPropInfo.DeclaringType;
        }

        // ----------------------------------------

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

            Type x = typeof(Entity);
            model = (Entity)db.Find(x, codigo);

            return model;
        }

        public virtual List<Entity> Localizar(string pesquisa)
        {
            List<Entity> model = default(List<Entity>);
            TelemedUnividasContext db = new TelemedUnividasContext();

            Type x = typeof(Entity);
            object[] vet = new object[5];
            vet[0] = "Felipe";
            vet[1] = 1006;

            //object df = db.Set<Entity>();


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
