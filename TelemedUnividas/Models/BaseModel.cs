using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositorio.Repositorio;
using AutoMapper;

namespace TelemedUnividas.Models
{
    public abstract class BaseModel<Entity, Model>
    {
        public virtual int Codigo { get; set; }

        public virtual BaseRepositorio<Entity> repositorio { get; set; }

        #region Métodos

        public void RunTest()
        {
            this.repositorio.Teste();
        }

        public void Salvar()
        {
            Entity entidade = BaseModel<Entity, Model>.ConverterModel(this);
            if (this.Codigo != 0)
            {
                this.repositorio.Atualizar(entidade);
            }
            else
            {
                this.repositorio.Inserir(entidade);
            }
        }

        public void Excluir()
        {
            Entity entity = BaseModel<Entity, Model>.ConverterModel(this);
            this.repositorio.Excluir(entity);
        }

        public Model Obter(int codigo)
        {
            Entity entidade = this.repositorio.Localizar(codigo);
            Model modelo = BaseModel<Entity, Model>.ReverterModel(entidade);
            return modelo;
        }

        public List<Model> Listar(string pesquisa)
        {
            List<Entity> entidades = this.repositorio.Localizar(pesquisa);
            List<Model> modelos = BaseModel<Entity, Model>.ReverterModelList(entidades);
            return modelos;
        }

        public static Entity ConverterModel(object modelo)
        {
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            Entity entidade = mapper.Map<Entity>(modelo);
            return entidade;
        }
        
        public static Model ReverterModel(Entity entidade)
        {
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            Model modelo = mapper.Map<Model>(entidade);
            return modelo;
        }

        public static List<Entity> ConverterModelList(List<Model> modelos)
        {
            List<Entity> entidades = null;
            if (modelos != null)
            {
                entidades = new List<Entity>();
                foreach (Model modelo in modelos)
                {
                    entidades.Add(BaseModel<Entity, Model>.ConverterModel(modelo));
                }
            }

            return entidades;
        }

        public static List<Model> ReverterModelList(List<Entity> entidades)
        {
            List<Model> modelos = null;
            if (entidades != null)
            {
                modelos = new List<Model>();
                foreach (Entity entidade in entidades)
                {
                    modelos.Add(BaseModel<Entity, Model>.ReverterModel(entidade));
                }
            }

            return modelos;
        }
        #endregion
    }
}
