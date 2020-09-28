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
        #region Propriedades
        public virtual int Codigo { get; set; }
        /// <summary>
        /// Armazena uma instância do repositório pertinente a entidade <typeparamref name="Entity"/>
        /// </summary>
        public virtual BaseRepositorio<Entity> repositorio { get; set; }
        #endregion

        #region Métodos
        /// <summary>
        /// Converter o objeto <typeparamref name="Model"/> em <typeparamref name="Entity"/> e o insere ou atualiza no banco de dados
        /// </summary>
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

        /// <summary>
        /// Converter o objeto <typeparamref name="Model"/> em <typeparamref name="Entity"/> e o exclui do banco de dados
        /// </summary>
        public void Excluir()
        {
            Entity entity = BaseModel<Entity, Model>.ConverterModel(this);
            this.repositorio.Excluir(entity);
        }

        /// <summary>
        /// Obtem um objeto <typeparamref name="Entity"/> do banco de dados que contenha a chave primária igual a <paramref name="codigo"/> e o converte para <typeparamref name="Model"/>
        /// </summary>
        public Model Obter(int codigo)
        {
            Entity entidade = this.repositorio.Localizar(codigo);
            Model modelo = BaseModel<Entity, Model>.ReverterModel(entidade);
            return modelo;
        }

        /// <summary>
        /// Converte um objeto <typeparamref name="Entity"/> em um objeto <typeparamref name="Model"/>
        /// </summary>
        public static Entity ConverterModel(object modelo)
        {
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            Entity entidade = mapper.Map<Entity>(modelo);
            return entidade;
        }

        /// <summary>
        /// Converte um objeto <typeparamref name="Model"/> em um objeto <typeparamref name="Entity"/>
        /// </summary>
        public static Model ReverterModel(Entity entidade)
        {
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            Model modelo = mapper.Map<Model>(entidade);
            return modelo;
        }

        /// <summary>
        /// Converte uma lista de objetos <typeparamref name="Entity"/> em uma lsita de objetos <typeparamref name="Model"/>
        /// </summary>
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

        /// <summary>
        /// Converte uma lista de objetos <typeparamref name="Model"/> em uma lista de objetos <typeparamref name="Entity"/>
        /// </summary>
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
