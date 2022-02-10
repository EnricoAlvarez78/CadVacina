using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Core.Entities;

#nullable disable

namespace Data
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)  : base(options)
        {
        }

        public virtual DbSet<Agendamento> Agendamentos { get; set; }
        public virtual DbSet<Agenda> Agenda { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<Lote> Lotes { get; set; }
        public virtual DbSet<Perfil> Perfils { get; set; }
        public virtual DbSet<Posto> Postos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Agendamento>(entity =>
            {
                entity.ToTable("Agendamento");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.Mae)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Turno)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnType("char");

                entity.HasOne(d => d.Endereco)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agendamento_Endereco");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agendamento_Grupo");

                entity.HasOne(d => d.Posto)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdPosto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agendamento_Posto");
            });

            modelBuilder.Entity<Agenda>(entity =>
            {
                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.HasOne(d => d.Lote)
                    .WithMany(p => p.Agendas)
                    .HasForeignKey(d => d.IdLote)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agenda_Lote");

                entity.HasOne(d => d.Posto)
                    .WithMany(p => p.Agendas)
                    .HasForeignKey(d => d.IdPosto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agenda_Posto");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("Endereco");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("Grupo");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lote>(entity =>
            {
                entity.ToTable("Lote");

                entity.Property(e => e.DataRecebimento).HasColumnType("datetime");

                entity.Property(e => e.Fabricante)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Posto)
                    .WithMany(p => p.Lotes)
                    .HasForeignKey(d => d.IdPosto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lote_Posto");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.ToTable("Perfil");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Posto>(entity =>
            {
                entity.ToTable("Posto");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Endereco)
                    .WithMany(p => p.Postos)
                    .HasForeignKey(d => d.IdEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Posto_Endereco");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Perfil");

                entity.HasOne(d => d.Posto)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPosto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Posto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}