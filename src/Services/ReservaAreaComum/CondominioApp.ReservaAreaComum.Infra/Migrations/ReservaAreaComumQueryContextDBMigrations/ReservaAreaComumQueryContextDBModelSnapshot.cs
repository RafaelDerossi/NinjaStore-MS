﻿// <auto-generated />
using System;
using CondominioApp.Principal.Infra.DataQuery;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CondominioApp.ReservaAreaComum.Infra.Migrations.ReservaAreaComumQueryContextDBMigrations
{
    [DbContext(typeof(ReservaAreaComumQueryContextDB))]
    partial class ReservaAreaComumQueryContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CondominioApp.ReservaAreaComum.Domain.FlatModel.AreaComumFlat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AntecedenciaMaximaEmDias")
                        .HasColumnType("int");

                    b.Property<int>("AntecedenciaMaximaEmMeses")
                        .HasColumnType("int");

                    b.Property<int>("AntecedenciaMinimaEmDias")
                        .HasColumnType("int");

                    b.Property<int>("AntecedenciaMinimaParaCancelamentoEmDias")
                        .HasColumnType("int");

                    b.Property<bool>("Ativa")
                        .HasColumnType("bit");

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataFimBloqueio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInicioBloqueio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("DiasPermitidos")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeCondominio")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("NumeroLimiteDeReservaPorUnidade")
                        .HasColumnType("int");

                    b.Property<int>("NumeroLimiteDeReservaSobreposta")
                        .HasColumnType("int");

                    b.Property<int>("NumeroLimiteDeReservaSobrepostaPorUnidade")
                        .HasColumnType("int");

                    b.Property<bool>("PermiteReservaSobreposta")
                        .HasColumnType("bit");

                    b.Property<bool>("RequerAprovacaoDeReserva")
                        .HasColumnType("bit");

                    b.Property<bool>("TemHorariosEspecificos")
                        .HasColumnType("bit");

                    b.Property<bool>("TemIntervaloFixoEntreReservas")
                        .HasColumnType("bit");

                    b.Property<string>("TempoDeDuracaoDeReserva")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TempoDeIntervaloEntreReservas")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("TempoDeIntervaloEntreReservasPorUnidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TermoDeUso")
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.ToTable("AreasComunsFlat");
                });

            modelBuilder.Entity("CondominioApp.ReservaAreaComum.Domain.FlatModel.PeriodoFlat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AreaComumFlatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("HoraFim")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("HoraInicio")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(14,2)");

                    b.HasKey("Id");

                    b.HasIndex("AreaComumFlatId");

                    b.ToTable("PeriodosFlat");
                });

            modelBuilder.Entity("CondominioApp.ReservaAreaComum.Domain.FlatModel.ReservaFlat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AndarUnidade")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("AreaComumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativa")
                        .HasColumnType("bit");

                    b.Property<bool>("Cancelada")
                        .HasColumnType("bit");

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeRealizacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoGrupoUnidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstaNaFila")
                        .HasColumnType("bit");

                    b.Property<string>("HoraFim")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("HoraInicio")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Justificativa")
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("NomeAreaComum")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeCondominio")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroUnidade")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Origem")
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(14,2)");

                    b.Property<bool>("ReservadoPelaAdministracao")
                        .HasColumnType("bit");

                    b.Property<Guid>("UnidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ReservasFlat");
                });

            modelBuilder.Entity("CondominioApp.ReservaAreaComum.Domain.FlatModel.PeriodoFlat", b =>
                {
                    b.HasOne("CondominioApp.ReservaAreaComum.Domain.FlatModel.AreaComumFlat", null)
                        .WithMany("Periodos")
                        .HasForeignKey("AreaComumFlatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
