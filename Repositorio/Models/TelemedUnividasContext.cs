using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repositorio.Models
{
    public partial class TelemedUnividasContext : DbContext
    {
        public TelemedUnividasContext()
        {
        }

        public TelemedUnividasContext(DbContextOptions<TelemedUnividasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Arquivo> Arquivo { get; set; }
        public virtual DbSet<Chamada> Chamada { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Clinica> Clinica { get; set; }
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<EnderecoEspecialista> EnderecoEspecialista { get; set; }
        public virtual DbSet<EnderecoPaciente> EnderecoPaciente { get; set; }
        public virtual DbSet<EnderecoSecretario> EnderecoSecretario { get; set; }
        public virtual DbSet<Especialidade> Especialidade { get; set; }
        public virtual DbSet<EspecialidadeEspecialistaClinica> EspecialidadeEspecialistaClinica { get; set; }
        public virtual DbSet<Especialista> Especialista { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<PacienteResponsavel> PacienteResponsavel { get; set; }
        public virtual DbSet<Prontuario> Prontuario { get; set; }
        public virtual DbSet<Secretario> Secretario { get; set; }
        public virtual DbSet<SecretarioEspecialista> SecretarioEspecialista { get; set; }
        public virtual DbSet<Telefone> Telefone { get; set; }
        public virtual DbSet<TelefoneClinica> TelefoneClinica { get; set; }
        public virtual DbSet<TipoArquivo> TipoArquivo { get; set; }
        public virtual DbSet<UnidadeFederativa> UnidadeFederativa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.0.106,1401 ; Database= TelemedUnividas; User ID=sa;Password=<YourNewStrong!Passw0rd>;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(255);

                entity.Property(e => e.Sobrenome)
                    .HasColumnName("sobrenome")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Arquivo>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.DataCriacao)
                    .HasColumnName("data_criacao")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProntuarioCodigo).HasColumnName("prontuario_codigo");

                entity.Property(e => e.Src)
                    .HasColumnName("src")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoArquivoCodigo).HasColumnName("tipoArquivo_codigo");

                entity.HasOne(d => d.ProntuarioCodigoNavigation)
                    .WithMany(p => p.Arquivo)
                    .HasForeignKey(d => d.ProntuarioCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Arquivo_Prontuario");

                entity.HasOne(d => d.TipoArquivoCodigoNavigation)
                    .WithMany(p => p.Arquivo)
                    .HasForeignKey(d => d.TipoArquivoCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Arquivo_TipoArquivo");
            });

            modelBuilder.Entity<Chamada>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.ConsultaCodigo).HasColumnName("consulta_codigo");

                entity.Property(e => e.Duracao).HasColumnName("duracao");

                entity.Property(e => e.Inicio)
                    .HasColumnName("inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasMaxLength(255);

                entity.Property(e => e.Observacoes)
                    .HasColumnName("observacoes")
                    .HasColumnType("text");

                entity.Property(e => e.PresencaEspecialista).HasColumnName("presenca_especialista");

                entity.Property(e => e.PresencaPaciente).HasColumnName("presenca_paciente");

                entity.HasOne(d => d.ConsultaCodigoNavigation)
                    .WithMany(p => p.Chamada)
                    .HasForeignKey(d => d.ConsultaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chamada_Consulta");
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK_Cidades");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadeFederativaCodigo).HasColumnName("unidadeFederativa_codigo");

                entity.HasOne(d => d.UnidadeFederativaCodigoNavigation)
                    .WithMany(p => p.Cidade)
                    .HasForeignKey(d => d.UnidadeFederativaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cidades_UnidadeFederativa");
            });

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco).HasColumnName("endereco");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.EnderecoNavigation)
                    .WithMany(p => p.Clinica)
                    .HasForeignKey(d => d.Endereco)
                    .HasConstraintName("FK_Clinica_Endereco");
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.ClinicaCodigo).HasColumnName("clinica_codigo");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.EspecialistaCodigo).HasColumnName("especialista_codigo");

                entity.Property(e => e.Paciente).HasColumnName("paciente");

                entity.Property(e => e.Retorno).HasColumnName("retorno");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.ClinicaCodigoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.ClinicaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Consulta_Clinica");

                entity.HasOne(d => d.EspecialistaCodigoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.EspecialistaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Consulta_Especialista");

                entity.HasOne(d => d.PacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.Paciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Consulta_Pacientes");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Bairro)
                    .HasColumnName("bairro")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CidadeCodigo).HasColumnName("cidade_codigo");

                entity.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .HasColumnName("logradouro")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CidadeCodigoNavigation)
                    .WithMany(p => p.Endereco)
                    .HasForeignKey(d => d.CidadeCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Endereco_Cidades");
            });

            modelBuilder.Entity<EnderecoEspecialista>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Endereco_Especialista");

                entity.Property(e => e.EnderecoCodigo).HasColumnName("endereco_codigo");

                entity.Property(e => e.EspecialistaCodigo).HasColumnName("especialista_codigo");

                entity.HasOne(d => d.EnderecoCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.EnderecoCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Endereco_Especialista_Endereco");

                entity.HasOne(d => d.EspecialistaCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.EspecialistaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Endereco_Especialista_Especialista");
            });

            modelBuilder.Entity<EnderecoPaciente>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Endereco_Paciente");

                entity.Property(e => e.EnderecoCodigo).HasColumnName("endereco_codigo");

                entity.Property(e => e.PacienteCodigo).HasColumnName("paciente_codigo");

                entity.HasOne(d => d.EnderecoCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.EnderecoCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Endereco_Paciente_Endereco");

                entity.HasOne(d => d.PacienteCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PacienteCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Endereco_Paciente_Pacientes");
            });

            modelBuilder.Entity<EnderecoSecretario>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Endereco_Secretario");

                entity.Property(e => e.EnderecoCodigo).HasColumnName("endereco_codigo");

                entity.Property(e => e.SecretarioCodigo).HasColumnName("secretario_codigo");

                entity.HasOne(d => d.EnderecoCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.EnderecoCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Endereco_Secretario_Endereco");

                entity.HasOne(d => d.SecretarioCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SecretarioCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Endereco_Secretario_Secretario");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EspecialidadeEspecialistaClinica>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("Especialidade_Especialista_Clinica");

                entity.Property(e => e.Codigo)
                    .HasColumnName("codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClinicaCodigo).HasColumnName("clinica_codigo");

                entity.Property(e => e.EspecialidadeCodigo).HasColumnName("especialidade_codigo");

                entity.Property(e => e.EspecialistaCodigo).HasColumnName("especialista_codigo");

                entity.HasOne(d => d.ClinicaCodigoNavigation)
                    .WithMany(p => p.EspecialidadeEspecialistaClinica)
                    .HasForeignKey(d => d.ClinicaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Especialidade_Especialista_Clinica_Clinica");

                entity.HasOne(d => d.EspecialidadeCodigoNavigation)
                    .WithMany(p => p.EspecialidadeEspecialistaClinica)
                    .HasForeignKey(d => d.EspecialidadeCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Especialidade_Especialista_Especialidade");

                entity.HasOne(d => d.EspecialistaCodigoNavigation)
                    .WithMany(p => p.EspecialidadeEspecialistaClinica)
                    .HasForeignKey(d => d.EspecialistaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Especialidade_Especialista_Especialista");
            });

            modelBuilder.Entity<Especialista>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Cpf)
                    .HasColumnName("cpf")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Crm)
                    .HasColumnName("crm")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("dataNascimento")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EnderecoCodigo).HasColumnName("endereco_codigo");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sobrenome)
                    .HasColumnName("sobrenome")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.EnderecoCodigoNavigation)
                    .WithMany(p => p.Especialista)
                    .HasForeignKey(d => d.EnderecoCodigo)
                    .HasConstraintName("FK_Especialista_Endereco");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK_Pacientes_1");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Cpf)
                    .HasColumnName("cpf")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("dataNascimento")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EnderecoCodigo).HasColumnName("endereco_codigo");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sobrenome)
                    .HasColumnName("sobrenome")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.EnderecoCodigoNavigation)
                    .WithMany(p => p.Paciente)
                    .HasForeignKey(d => d.EnderecoCodigo)
                    .HasConstraintName("FK_Paciente_Endereco");
            });

            modelBuilder.Entity<PacienteResponsavel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Paciente_Responsavel");

                entity.Property(e => e.PacienteCodigo).HasColumnName("paciente_codigo");

                entity.Property(e => e.ResponsavelCodigo).HasColumnName("responsavel_codigo");

                entity.HasOne(d => d.PacienteCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PacienteCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paciente_Responsavel_Pacientes");

                entity.HasOne(d => d.ResponsavelCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ResponsavelCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paciente_Responsavel_Pacientes1");
            });

            modelBuilder.Entity<Prontuario>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.ClinicaCodigo).HasColumnName("clinica_codigo");

                entity.Property(e => e.EspecialistaCodigo).HasColumnName("especialista_codigo");

                entity.Property(e => e.PacienteCodigo).HasColumnName("paciente_codigo");

                entity.HasOne(d => d.ClinicaCodigoNavigation)
                    .WithMany(p => p.Prontuario)
                    .HasForeignKey(d => d.ClinicaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prontuario_Clinica");

                entity.HasOne(d => d.EspecialistaCodigoNavigation)
                    .WithMany(p => p.Prontuario)
                    .HasForeignKey(d => d.EspecialistaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prontuario_Especialista");

                entity.HasOne(d => d.PacienteCodigoNavigation)
                    .WithMany(p => p.Prontuario)
                    .HasForeignKey(d => d.PacienteCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prontuario_Pacientes");
            });

            modelBuilder.Entity<Secretario>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Cpf)
                    .HasColumnName("cpf")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("dataNascimento")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EnderecoCodigo).HasColumnName("endereco_codigo");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sobrenome)
                    .HasColumnName("sobrenome")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.EnderecoCodigoNavigation)
                    .WithMany(p => p.Secretario)
                    .HasForeignKey(d => d.EnderecoCodigo)
                    .HasConstraintName("FK_Secretario_Endereco");
            });

            modelBuilder.Entity<SecretarioEspecialista>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Secretario_Especialista");

                entity.Property(e => e.ClinicaCodigo).HasColumnName("clinica_codigo");

                entity.Property(e => e.SecretarioCodigo).HasColumnName("secretario_codigo");

                entity.HasOne(d => d.ClinicaCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ClinicaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Secretario_Especialista_Clinica");

                entity.HasOne(d => d.SecretarioCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SecretarioCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Secretario_Especialista_Secretario");
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TelefoneClinica>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Telefone_Clinica");

                entity.Property(e => e.ClinicaCodigo).HasColumnName("clinica_codigo");

                entity.Property(e => e.TelefoneCodigo).HasColumnName("telefone_codigo");

                entity.HasOne(d => d.ClinicaCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ClinicaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Telefone_Clinica_Clinica");

                entity.HasOne(d => d.TelefoneCodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.TelefoneCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Telefone_Clinica_Telefone");
            });

            modelBuilder.Entity<TipoArquivo>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UnidadeFederativa>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
