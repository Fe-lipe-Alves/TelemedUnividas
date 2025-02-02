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
                cfg.CreateMap<Paciente, PacienteModel>();
                cfg.CreateMap<PacienteModel, Paciente>();

                cfg.CreateMap<Especialista, EspecialistaModel>();
                cfg.CreateMap<EspecialistaModel, Especialista>();

                cfg.CreateMap<Especialidade, EspecialidadeModel>();
                cfg.CreateMap<EspecialidadeModel, Especialidade>();

                cfg.CreateMap<Endereco, EnderecoModel>();
                cfg.CreateMap<EnderecoModel, Endereco>();

                cfg.CreateMap<Cidade, CidadeModel>();
                cfg.CreateMap<CidadeModel, Cidade>();

                cfg.CreateMap<UnidadeFederativa, UnidadeFederativaModel>();
                cfg.CreateMap<UnidadeFederativaModel, UnidadeFederativa>();

                cfg.CreateMap<Clinica, ClinicaModel>();
                cfg.CreateMap<ClinicaModel, Clinica>();

                cfg.CreateMap<Consulta, ConsultaModel>();
                cfg.CreateMap<ConsultaModel, Consulta>();

                cfg.CreateMap<Chamada, ChamadaModel>();
                cfg.CreateMap<ChamadaModel, Chamada>();

                cfg.CreateMap<Administrador, AdministradorModel>();
                cfg.CreateMap<AdministradorModel, Administrador>();

                cfg.CreateMap<Secretario, SecretarioModel>();
                cfg.CreateMap<SecretarioModel, Secretario>();
            });
            return config;
        }
    }
}
