using AutoMapper;
using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelemedUnividas.Models;

namespace TelemedUnividas
{
    public class AutoMapperConfig : Profile
    {
        public static MapperConfiguration RegisterMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Paciente, PacienteModel>();
                cfg.CreateMap<PacienteModel, Paciente>();

                cfg.CreateMap<Especialista, EspecialistaModel>();
                cfg.CreateMap<EspecialistaModel, Especialista>();

                cfg.CreateMap<Especialidade, EspecialidadeModel>();
                cfg.CreateMap<EspecialidadeModel, Especialidade>();

                cfg.CreateMap<Endereco, EnderecoModel>();
                cfg.CreateMap<EnderecoModel, Endereco>();
            });
            return config;
        }
    }
}
