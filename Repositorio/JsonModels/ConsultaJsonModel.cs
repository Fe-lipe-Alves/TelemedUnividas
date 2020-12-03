using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.JsonModels
{
    public class ConsultaJsonModel
    {
        public int Codigo { get; set; }
        public int EspecialistaCodigo { get; set; }
        public int Paciente { get; set; }
        public int ClinicaCodigo { get; set; }
        public string Data { get; set; }
        public int? Status { get; set; }
        public bool? Retorno { get; set; }
    }
}
