using Repositorio.Models;
using Repositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace TelemedUnividas.Models
{
    public class EspecialistaModel : BaseModel<Especialista, EspecialistaModel>
    {        
        #region Propriedades
        [Display(Name = "Código")]
        public override int Codigo { get; set; }

        [Display(Name = "Endereço")]
        public int? EnderecoCodigo { get; set; }

        [Display(Name = "Nome")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Nome não pode ter mais de 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        [DataType(DataType.Text)]
        [StringLength(150, ErrorMessage = "Sobrenome não pode ter mais de 150 caracteres")]
        public string Sobrenome { get; set; }

        [Display(Name = "CPF")]
        [DataType(DataType.Text)]
        public string Cpf { get; set; }

        [Display(Name = "CRM")]
        [DataType(DataType.Text)]
        public string Crm { get; set; }

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "E-mail não pode ter mais de 100 caracteres")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [StringLength(16, ErrorMessage = "Senha não pode ter mais de 16 caracteres")]
        public string Senha { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }
        #endregion

        #region Propriedades Auxiliares
        public new EspecialistaRepositorio repositorio { get; set; }
        #endregion

        #region Construtores
        public EspecialistaModel()
        {
            this.repositorio = new EspecialistaRepositorio();
            base.repositorio = this.repositorio;
        }

        public EspecialistaModel(int codigo, int? enderecoCodigo, string nome, string sobrenome, string cpf, string crm, string telefone, string email, string senha, DateTime? dataNascimento)
        {
            this.Codigo = codigo;
            this.EnderecoCodigo = enderecoCodigo;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Cpf = cpf;
            this.Crm = crm;
            this.Telefone = telefone;
            this.Email = email;
            this.Senha = senha;
            this.DataNascimento = dataNascimento;

            this.repositorio = new EspecialistaRepositorio();
            base.repositorio = this.repositorio;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Retorna uma lista de <see cref="EspecialistaModel"/> que contenham o valor de <paramref name="pesquisa"/> no nome, email ou CRM
        /// </summary>
        /// <param name="pesquisa"></param>
        /// <returns></returns>
        public List<EspecialistaModel> Localizar(string pesquisa = "")
        {
            List<Especialista> especialistaEntity = this.repositorio.Localizar(pesquisa);
            List<EspecialistaModel> especialistas = EspecialistaModel.ReverterModelList(especialistaEntity);
            return especialistas;
        }

        /// <summary>
        /// Obtem uma lista de objetos <see cref="EspecialidadeModel"/> resultantes de uma pesquisa pelo código da <see cref="Especialidade"/> no banco de dados
        /// </summary>
        /// <param name="especialidade_codigo"></param>
        public List<EspecialistaModel> LocalizarPorEspecialidade(int especialidade_codigo)
        {
            List<Especialista> especialistas = this.repositorio.LocalizarPorEspecialidade(especialidade_codigo);
            return BaseModel<Especialista, EspecialistaModel>.ReverterModelList(especialistas);
        }

        /// <summary>
        /// Obtem uma lista de <see cref="EspecialistaModel"/> que estão relacionadoa a <see cref="Clinica"/> com código correspondente a <paramref name="clinica_codigo"/>
        /// </summary>
        /// <param name="clinica_codigo"></param>
        /// <returns></returns>
        public List<EspecialistaModel> LocalizarPorClinica(int clinica_codigo)
        {
            List<Especialista> especialistas = this.repositorio.LocalizarPorClinica(clinica_codigo);
            return EspecialistaModel.ReverterModelList(especialistas);
        }

        /// <summary>
        /// Retorna o <see cref="EspecialistaModel"/> que corresponde ao <paramref name="email"/> e <paramref name="senha"/> fornecidos
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public EspecialistaModel Login(string email, string senha)
        {
            this.repositorio.Login(email, senha);

            Especialista especialista = this.repositorio.Login(email, senha);
            return EspecialistaModel.ReverterModel(especialista);
        }


        /// <summary>
        /// Cria um vinculo entre o <see cref="Especialista"/>, a <see cref="Especialidade"/> e a <see cref="Clinica"/>
        /// </summary>
        /// <param name="especialidade"></param>
        /// <param name="clinica"></param>
        public void SalvarEspecialidadesClinicas(EspecialidadeModel especialidade, ClinicaModel clinica)
        {
            Especialidade especialidadeEntity = EspecialidadeModel.ConverterModel(especialidade);
            Clinica clinicaEntity = ClinicaModel.ConverterModel(clinica);
            Especialista especialistaEntity = EspecialistaModel.ConverterModel(this);

            this.repositorio.SalvarEspecialidadesClinicas(especialidadeEntity, especialistaEntity, clinicaEntity);
        }

        public String NomeCompleto()
        {
            return this.Nome + " " + this.Sobrenome;
        }
        #endregion
    }
}
