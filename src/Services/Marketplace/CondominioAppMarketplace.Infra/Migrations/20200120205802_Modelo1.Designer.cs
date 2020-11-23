﻿// <auto-generated />

using System;
using CondominioAppMarketplace.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppMarketplace.Infra.Migrations
{
    [DbContext(typeof(MarketplaceContext))]
    [Migration("20200120205802_Modelo1")]
    partial class Modelo1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CondominioApp.Loja.Domain.Condominio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnName("DataDeAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnName("DataDeCadastro")
                        .HasColumnType("datetime");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid>("ParceiroId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParceiroId");

                    b.ToTable("Condominio");
                });

            modelBuilder.Entity("CondominioApp.Loja.Domain.Parceiro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnName("DataDeAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnName("DataDeCadastro")
                        .HasColumnType("datetime");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LogoMarca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Token")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Parceiro");
                });

            modelBuilder.Entity("CondominioApp.Loja.Domain.Condominio", b =>
                {
                    b.HasOne("CondominioApp.Loja.Domain.Parceiro", "Parceiro")
                        .WithMany("Condominios")
                        .HasForeignKey("ParceiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CondominioApp.Loja.Domain.Parceiro", b =>
                {
                    b.OwnsOne("CondominioAppParceiros.Core.ValueObjects.Cnpj", "Cnpj", b1 =>
                        {
                            b1.Property<Guid>("ParceiroId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("numero")
                                .HasColumnName("Cnpj")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.HasKey("ParceiroId");

                            b1.ToTable("Parceiro");

                            b1.WithOwner()
                                .HasForeignKey("ParceiroId");
                        });

                    b.OwnsOne("CondominioAppParceiros.Core.ValueObjects.Contrato", "Contrato", b1 =>
                        {
                            b1.Property<Guid>("ParceiroId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("DataDeInicio")
                                .HasColumnName("ContratoDataDeInicio")
                                .HasColumnType("DateTime");

                            b1.Property<DateTime>("DataDeRenovacao")
                                .HasColumnName("ContratoDataDeRenovacao")
                                .HasColumnType("DateTime");

                            b1.Property<string>("Descricao")
                                .HasColumnName("ContratoDescricao")
                                .HasColumnType("nvarchar(250)")
                                .HasMaxLength(250);

                            b1.HasKey("ParceiroId");

                            b1.ToTable("Parceiro");

                            b1.WithOwner()
                                .HasForeignKey("ParceiroId");
                        });

                    b.OwnsOne("CondominioAppParceiros.Core.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("ParceiroId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("bairro")
                                .HasColumnName("Bairro")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("cep")
                                .HasColumnName("Cep")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("cidade")
                                .HasColumnName("Cidade")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("complemento")
                                .HasColumnName("Complemento")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("estado")
                                .HasColumnName("Estado")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("logradouro")
                                .HasColumnName("Logradouro")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("municipio")
                                .HasColumnName("Municipio")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("numero")
                                .HasColumnName("Numero")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.HasKey("ParceiroId");

                            b1.ToTable("Parceiro");

                            b1.WithOwner()
                                .HasForeignKey("ParceiroId");
                        });

                    b.OwnsOne("CondominioAppParceiros.Core.ValueObjects.Senha", "Senha", b1 =>
                        {
                            b1.Property<Guid>("ParceiroId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .HasColumnName("Senha")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.HasKey("ParceiroId");

                            b1.ToTable("Parceiro");

                            b1.WithOwner()
                                .HasForeignKey("ParceiroId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
