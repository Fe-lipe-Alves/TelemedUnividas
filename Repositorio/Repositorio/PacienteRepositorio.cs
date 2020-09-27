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
        public override IQueryable<object> DbModel { get; set; }

        public PacienteRepositorio()
        {
            this.DbModel = (new TelemedUnividasContext()).Paciente;
        }

        /*
        public override void Inserir(Paciente paciente)
        {
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                var metodo = 
                db.Paciente.Add(paciente);
                db.SaveChanges();
            }
        }

        public override Paciente Localizar(int codigo)
        {
            Paciente paciente = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                paciente = (from p in db.Paciente where p.Codigo == codigo select p).FirstOrDefault();
            }
            return paciente;
        }

        public override List<Paciente> Localizar(string pesquisa)
        {
            List<Paciente> pacientes = null;
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                pacientes = (from p in db.Paciente where p.Nome.Contains(pesquisa) || p.Sobrenome.Contains(pesquisa) select p).ToList();
            }
            return pacientes;
        }

        public override void Atualizar(Paciente paciente)
        {
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                db.Entry(paciente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public override void Excluir(Paciente paciente)
        {
            using (TelemedUnividasContext db = new TelemedUnividasContext())
            {
                db.Entry(paciente).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        */
    }
}
