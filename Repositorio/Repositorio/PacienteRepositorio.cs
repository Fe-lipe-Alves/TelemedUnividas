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
    }
}
