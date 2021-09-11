﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CondominioAppMarketplace.Infra.Data;

namespace CondominioAppMarketplace.Infra.Migrations
{
    [DbContext(typeof(MarketplaceContext))]
    [Migration("20200130221256_ModeloAjustesDeTablelas1.0")]
    partial class ModeloAjustesDeTablelas10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
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
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnName("DataDeAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnName("DataDeCadastro")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataDeFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ItemDeVendaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<int>("NumeroDeCliques")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TodosOsCondominios")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ItemDeVendaId");

                    b.ToTable("Campanha");
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

                    b.Property<Guid>("CondominioId")
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

            modelBuilder.Entity("CondominioApp.Loja.Domain.ItemDeVenda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnName("DataDeAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnName("DataDeCadastro")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataDeFim")
                        .HasColumnName("DataDeFim")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataDeInicio")
                        .HasColumnName("DataDeInicio")
                        .HasColumnType("datetime");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<int>("NumeroDeCliques")
                        .HasColumnType("int");

                    b.Property<Guid>("ParceiroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PorcentagemDeDesconto")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VendedorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("VendedorId");

                    b.ToTable("ItemDeVenda");
                });

            modelBuilder.Entity("CondominioApp.Loja.Domain.Lead", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bloco")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnName("DataDeAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnName("DataDeCadastro")
                        .HasColumnType("datetime");

                    b.Property<Guid>("ItemDeVendaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("NomeDoCliente")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NomeDoCondominio")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Unidade")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ItemDeVendaId");

                    b.ToTable("Lead");
                });

            modelBuilder.Entity("CondominioApp.Loja.Domain.Parceiro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cor")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

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

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LogoMarca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

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
                        .HasColumnType("nvarchar(85)")
                        .HasMaxLength(85);

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnName("DataDeAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnName("DataDeCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("EspecificacaoTecnica")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("CondominioApp.Loja.Domain.Campanha", b =>
                {
                    b.HasOne("CondominioApp.Loja.Domain.ItemDeVenda", "ItemDeVenda")
                        .WithMany("Campanhas")
                        .HasForeignKey("ItemDeVendaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
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

            modelBuilder.Entity("CondominioApp.Loja.Domain.ItemDeVenda", b =>
                {
                    b.HasOne("CondominioApp.Loja.Domain.Produto", "Produto")
                        .WithMany("ItensDeVenda")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CondominioApp.Loja.Domain.Vendedor", "Vendedor")
                        .WithMany("ItensDeVenda")
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CondominioApp.Loja.Domain.Lead", b =>
                {
                    b.HasOne("CondominioApp.Loja.Domain.ItemDeVenda", "ItemDeVenda")
                        .WithMany("Leads")
                        .HasForeignKey("ItemDeVendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("CondominioApp.Loja.Core.ValueObjects.Email", "EmailDoCliente", b1 =>
                        {
                            b1.Property<Guid>("LeadId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .HasColumnName("EmailDoCliente")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.HasKey("LeadId");

                            b1.ToTable("Lead");

                            b1.WithOwner()
                                .HasForeignKey("LeadId");
                        });

                    b.OwnsOne("CondominioApp.Loja.Core.ValueObjects.Telefone", "Telefone", b1 =>
                        {
                            b1.Property<Guid>("LeadId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .HasColumnName("Telefone")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.HasKey("LeadId");

                            b1.ToTable("Lead");

                            b1.WithOwner()
                                .HasForeignKey("LeadId");
                        });
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
                        .WithMany("Produtos")
                        .HasForeignKey("ParceiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("CondominioApp.Loja.Core.ValueObjects.Url", "Url", b1 =>
                        {
                            b1.Property<Guid>("ProdutoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .HasColumnName("Link")
                                .HasColumnType("nvarchar(250)")
                                .HasMaxLength(250);

                            b1.HasKey("ProdutoId");

                            b1.ToTable("Produto");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoId");
                        });
                });

            modelBuilder.Entity("CondominioApp.Loja.Domain.Vendedor", b =>
                {
                    b.HasOne("CondominioApp.Loja.Domain.Parceiro", "Parceiro")
                        .WithMany("Vendedores")
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
                                .HasColumnType("nvarchar(254)")
                                .HasMaxLength(254);

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
