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
        public override IQueryable<object> DbModel { get; set; }

        public EspecialistaRepositorio()
        {
            this.DbModel = (new TelemedUnividasContext()).Especialista;
        }
    }
}
