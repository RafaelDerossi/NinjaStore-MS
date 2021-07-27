﻿// <auto-generated />
using System;
using CondominioApp.Principal.Infra.DataQuery;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CondominioApp.Principal.Infra.Migrations.PrincipalQueryContextDBMigrations
{
    [DbContext(typeof(PrincipalQueryContextDB))]
    [Migration("20210727125405_ajustesNoPrincipalFlat")]
    partial class ajustesNoPrincipalFlat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CondominioApp.Principal.Domain.FlatModel.CondominioFlat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .HasColumnName("Bairro")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("BoletoFolder")
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("CadastroDeVeiculoPeloMoradorAtivado")
                        .HasColumnType("bit");

                    b.Property<string>("Cep")
                        .HasColumnName("Cep")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<bool>("ChatAtivado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("ChatParaMoradorAtivado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Cidade")
                        .HasColumnName("Cidade")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("ClassificadoAtivado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("ClassificadoParaMoradorAtivado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Cnpj")
                        .HasColumnType("varchar(18)");

                    b.Property<string>("Complemento")
                        .HasColumnName("Complemento")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("ContratoAtivo")
                        .HasColumnType("bit");

                    b.Property<Guid>("ContratoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CorrespondenciaAtivada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("CorrespondenciaNaPortariaAtivada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime>("DataAssinaturaContrato")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("DescricaoContrato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnName("Estado")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid>("FuncionarioIdDoSindico")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LinkGeraBoleto")
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Logradouro")
                        .HasColumnName("Logradouro")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("MuralAtivado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("MuralParaMoradorAtivado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeArquivoContrato")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeArquivoLogo")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeDoSindico")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeOriginalArquivoContrato")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeOriginalArquivoLogo")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero")
                        .HasColumnName("Numero")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("OcorrenciaAtivada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("OcorrenciaParaMoradorAtivada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("PortariaAtivada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("PortariaParaMoradorAtivada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<int>("QuantidadeDeUnidadesContratadas")
                        .HasColumnType("int");

                    b.Property<int?>("RefereciaId")
                        .HasColumnType("int");

                    b.Property<bool>("ReservaAtivada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("ReservaNaPortariaAtivada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(15)");

                    b.Property<int>("TipoPlano")
                        .HasColumnType("int");

                    b.Property<string>("UrlWebServer")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("CondominiosFlat");
                });

            modelBuilder.Entity("CondominioApp.Principal.Domain.FlatModel.GrupoFlat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CondominioCnpj")
                        .IsRequired()
                        .HasColumnType("varchar(18)");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CondominioLogoMarca")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CondominioNome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("GruposFlat");
                });

            modelBuilder.Entity("CondominioApp.Principal.Domain.FlatModel.UnidadeFlat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Andar")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CondominioCnpj")
                        .HasColumnType("varchar(18)");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CondominioLogoMarca")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CondominioNome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("GrupoDescricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("GrupoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Ramal")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Vagas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.ToTable("UnidadesFlat");
                });
#pragma warning restore 612, 618
        }
    }
}
