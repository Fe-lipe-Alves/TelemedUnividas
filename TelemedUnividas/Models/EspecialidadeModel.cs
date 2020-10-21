using Repositorio.Models;
using Repositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TelemedUnividas.Models
{
    public class EspecialidadeModel : BaseModel<Especialidade, EspecialidadeModel>
    {
        #region Propriedades Entidade
        [Display(Name = "Codigo")]
        public override int Codigo { get; set; }

        [Display(Name = "Descrição")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Nome não pode ter mais de 100 caracteres")]
        public string Descricao { get; set; }
        #endregion

        #region Propriedades Auxiliares
        public new EspecialidadeRepositorio repositorio { get; set; }
        #endregion

        #region Construtores
        public EspecialidadeModel()
        {
            this.repositorio = new EspecialidadeRepositorio();
            base.repositorio = this.repositorio;
        }

        public EspecialidadeModel(int codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;

            this.repositorio = new EspecialidadeRepositorio();
            base.repositorio = this.repositorio;
        }
        #endregion

        #region Métodos
        public List<EspecialidadeModel> Localizar(string pesquisa = "")
        {
            List<Especialidade> especialidadeEntities = this.repositorio.Localizar(pesquisa);
            return EspecialidadeModel.ReverterModelList(especialidadeEntities);
        }
        #endregion
    }
}
