﻿// <auto-generated />
using System;
using CondominioApp.Correspondencias.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CondominioApp.Correspondencias.App.Migrations
{
    [DbContext(typeof(CorrespondenciaContextDB))]
    [Migration("20210713130132_ObsRetiradaCorrespondencia")]
    partial class ObsRetiradaCorrespondencia
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CondominioApp.Correspondencias.App.Models.Correspondencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bloco")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CodigoDeVerificacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataDaRetirada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeChegada")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EnviarNotificacao")
                        .HasColumnType("bit");

                    b.Property<Guid>("FuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Localizacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFuncionario")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeRetirante")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NumeroRastreamentoCorreio")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NumeroUnidade")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ObservacaoDaRetirada")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("QuantidadeDeAlertasFeitos")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TipoDeCorrespondencia")
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("UnidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Visto")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Correspondencias");
                });

            modelBuilder.Entity("CondominioApp.Correspondencias.App.Models.HistoricoCorrespondencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Acao")
                        .HasColumnType("int");

                    b.Property<Guid>("CorrespondenciaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("NomeFuncionario")
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Visto")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Historico");
                });

            modelBuilder.Entity("CondominioApp.Correspondencias.App.Models.Correspondencia", b =>
                {
                    b.OwnsOne("CondominioApp.Correspondencias.App.ValueObjects.Foto", "FotoCorrespondencia", b1 =>
                        {
                            b1.Property<Guid>("CorrespondenciaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("NomeDoArquivo")
                                .HasColumnName("NomeDoArquivoFoto")
                                .HasColumnType("varchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("NomeOriginal")
                                .HasColumnName("NomeOriginalFoto")
                                .HasColumnType("varchar(200)")
                                .HasMaxLength(200);

                            b1.HasKey("CorrespondenciaId");

                            b1.ToTable("Correspondencias");

                            b1.WithOwner()
                                .HasForeignKey("CorrespondenciaId");
                        });

                    b.OwnsOne("CondominioApp.Correspondencias.App.ValueObjects.Foto", "FotoRetirante", b1 =>
                        {
                            b1.Property<Guid>("CorrespondenciaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("NomeDoArquivo")
                                .HasColumnName("NomeArquivoFotoRetirante")
                                .HasColumnType("varchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("NomeOriginal")
                                .HasColumnName("NomeOriginalFotoRetirante")
                                .HasColumnType("varchar(200)")
                                .HasMaxLength(200);

                            b1.HasKey("CorrespondenciaId");

                            b1.ToTable("Correspondencias");

                            b1.WithOwner()
                                .HasForeignKey("CorrespondenciaId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
