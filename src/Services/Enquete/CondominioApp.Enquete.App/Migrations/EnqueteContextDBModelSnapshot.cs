﻿// <auto-generated />
using System;
using CondominioApp.Enquetes.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CondominioApp.Enquetes.App.Migrations
{
    [DbContext(typeof(EnqueteContextDB))]
    partial class EnqueteContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CondominioApp.Enquetes.App.Models.AlternativaEnquete", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("EnqueteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("EnqueteId");

                    b.ToTable("AlternativasEnquete");
                });

            modelBuilder.Entity("CondominioApp.Enquetes.App.Models.Enquete", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ApenasProprietarios")
                        .HasColumnType("bit");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CondominioNome")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsuarioNome")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Enquetes");
                });

            modelBuilder.Entity("CondominioApp.Enquetes.App.Models.RespostaEnquete", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlternativaEnqueteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bloco")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("TipoDeUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Unidade")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("UnidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsuarioNome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("AlternativaEnqueteId");

                    b.ToTable("RespostasEnquete");
                });

            modelBuilder.Entity("CondominioApp.Enquetes.App.Models.AlternativaEnquete", b =>
                {
                    b.HasOne("CondominioApp.Enquetes.App.Models.Enquete", null)
                        .WithMany("Alternativas")
                        .HasForeignKey("EnqueteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CondominioApp.Enquetes.App.Models.RespostaEnquete", b =>
                {
                    b.HasOne("CondominioApp.Enquetes.App.Models.AlternativaEnquete", null)
                        .WithMany("Respostas")
                        .HasForeignKey("AlternativaEnqueteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
