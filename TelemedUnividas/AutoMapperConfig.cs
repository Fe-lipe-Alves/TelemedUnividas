﻿using AutoMapper;
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
                //cfg.CreateMap<Pacientes, PacienteModel>();
                //cfg.CreateMap<PacienteModel, Pacientes>();
            });
            return config;
        }
    }
}
