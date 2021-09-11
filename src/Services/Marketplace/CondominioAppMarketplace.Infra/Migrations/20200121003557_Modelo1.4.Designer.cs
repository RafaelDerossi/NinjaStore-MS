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
    [Migration("20200121003557_Modelo1.4")]
    partial class Modelo14
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CondominioApp.Loja.Domain.Campanha", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Banner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TodosOsCondominios")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Campanhas");
                });

            modelBuilder.Entity("CondominioApp.Loja.Domain.CampanhaCondominio", b =>
                {
                    b.Property<Guid>("CampanhaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CampanhaId", "CondominioId");

                    b.HasIndex("CondominioId");

                    b.ToTable("CampanhaCondominio");
                });

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

            modelBuilder.Entity("CondominioApp.Loja.Domain.FotoDoProduto", b =>
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

                    b.Property<string>("Extensao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("NomeArquivo")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NomeOriginal")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("Principal")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("FotoDoProduto");
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

            modelBuilder.Entity("CondominioApp.Loja.Domain.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Chamada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnName("DataDeAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnName("DataDeCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid>("ParceiroId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParceiroId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("CondominioApp.Loja.Domain.Vendedor", b =>
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

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("CondominioApp.Loja.Domain.CampanhaCondominio", b =>
                {
                    b.HasOne("CondominioApp.Loja.Domain.Campanha", "Campanha")
                        .WithMany("Condominios")
                        .HasForeignKey("CampanhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CondominioApp.Loja.Domain.Condominio", "Condominio")
                        .WithMany("Campanhas")
                        .HasForeignKey("CondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CondominioApp.Loja.Domain.Condominio", b =>
                {
                    b.HasOne("CondominioApp.Loja.Domain.Parceiro", "Parceiro")
                        .WithMany("Condominios")
                        .HasForeignKey("ParceiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CondominioApp.Loja.Domain.FotoDoProduto", b =>
                {
                    b.HasOne("CondominioApp.Loja.Domain.Produto", "Produto")
                        .WithMany("Fotos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CondominioApp.Loja.Domain.Parceiro", b =>
                {
                    b.OwnsOne("CondominioApp.Loja.Core.ValueObjects.Cnpj", "Cnpj", b1 =>
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

                    b.OwnsOne("CondominioApp.Loja.Core.ValueObjects.Contrato", "Contrato", b1 =>
                        {
                            b1.Property<Guid>("ParceiroId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("DataDeInicio")
                                .HasColumnName("DataDeInicioDoContrato")
                                .HasColumnType("DateTime");

                            b1.Property<DateTime>("DataDeRenovacao")
                                .HasColumnName("DataDeRenovacaoDoContrato")
                                .HasColumnType("DateTime");

                            b1.Property<string>("Descricao")
                                .HasColumnName("DescricaoDoContrato")
                                .HasColumnType("nvarchar(250)")
                                .HasMaxLength(250);

                            b1.HasKey("ParceiroId");

                            b1.ToTable("Parceiro");

                            b1.WithOwner()
                                .HasForeignKey("ParceiroId");
                        });

                    b.OwnsOne("CondominioApp.Loja.Core.ValueObjects.Endereco", "Endereco", b1 =>
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

                    b.OwnsOne("CondominioApp.Loja.Core.ValueObjects.Senha", "Senha", b1 =>
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

            modelBuilder.Entity("CondominioApp.Loja.Domain.Produto", b =>
                {
                    b.HasOne("CondominioApp.Loja.Domain.Parceiro", "Parceiro")
                        .WithMany()
                        .HasForeignKey("ParceiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("CondominioApp.Loja.Core.ValueObjects.Url", "Url", b1 =>
                        {
                            b1.Property<Guid>("ProdutoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .HasColumnName("Link")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.HasKey("ProdutoId");

                            b1.ToTable("Produto");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoId");
                        });
                });

            modelBuilder.Entity("CondominioApp.Loja.Domain.Vendedor", b =>
                {
                    b.HasOne("CondominioApp.Loja.Domain.Parceiro", "Parceiro")
                        .WithMany()
                        .HasForeignKey("ParceiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("CondominioApp.Loja.Core.ValueObjects.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("VendedorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .HasColumnName("Cpf")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.HasKey("VendedorId");

                            b1.ToTable("Vendedor");

                            b1.WithOwner()
                                .HasForeignKey("VendedorId");
                        });

                    b.OwnsOne("CondominioApp.Loja.Core.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("VendedorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .HasColumnName("Email")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.HasKey("VendedorId");

                            b1.ToTable("Vendedor");

                            b1.WithOwner()
                                .HasForeignKey("VendedorId");
                        });

                    b.OwnsOne("CondominioApp.Loja.Core.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("VendedorId")
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

                            b1.HasKey("VendedorId");

                            b1.ToTable("Vendedor");

                            b1.WithOwner()
                                .HasForeignKey("VendedorId");
                        });

                    b.OwnsOne("CondominioApp.Loja.Core.ValueObjects.Telefone", "Telefone", b1 =>
                        {
                            b1.Property<Guid>("VendedorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .HasColumnName("Telefone")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.HasKey("VendedorId");

                            b1.ToTable("Vendedor");

                            b1.WithOwner()
                                .HasForeignKey("VendedorId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
