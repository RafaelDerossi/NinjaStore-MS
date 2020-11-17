﻿// <auto-generated />
using System;
using CondominioAppPreCadastro.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CondominioAppPreCadastro.App.Migrations
{
    [DbContext(typeof(PreCadastroContextDB))]
    partial class PreCadastroContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CondominioAppPreCadastro.App.Models.Arquivo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LeadId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("NomeOriginalDoArquivo")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("CondominioId");

                    b.HasIndex("LeadId");

                    b.ToTable("Arquivo");
                });

            modelBuilder.Entity("CondominioAppPreCadastro.App.Models.Condominio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LeadId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("NomeDoCondominio")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("NomeDoSindico")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("NumeroDoDocumento")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("OutroTipoDeDocumento")
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("Plano")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeDeAndar")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeDeGrupos")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeDeUnidades")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeDeUnidadesPorAndar")
                        .HasColumnType("int");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("TipoDeDocumento")
                        .HasColumnType("int");

                    b.Property<int>("TipoDeGrupo")
                        .HasColumnType("int");

                    b.Property<int>("TipoDeUnidade")
                        .HasColumnType("int");

                    b.Property<bool>("Transferido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.HasIndex("LeadId");

                    b.ToTable("Condominio");
                });

            modelBuilder.Entity("CondominioAppPreCadastro.App.Models.Lead", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnName("Motivo")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Lead");
                });

            modelBuilder.Entity("CondominioAppPreCadastro.App.Models.Arquivo", b =>
                {
                    b.HasOne("CondominioAppPreCadastro.App.Models.Condominio", null)
                        .WithMany("Arquivos")
                        .HasForeignKey("CondominioId");

                    b.HasOne("CondominioAppPreCadastro.App.Models.Lead", "Lead")
                        .WithMany()
                        .HasForeignKey("LeadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CondominioAppPreCadastro.App.Models.Condominio", b =>
                {
                    b.HasOne("CondominioAppPreCadastro.App.Models.Lead", "Lead")
                        .WithMany("Condominios")
                        .HasForeignKey("LeadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("CondominioApp.Core.ValueObjects.Email", "EmailDoSindico", b1 =>
                        {
                            b1.Property<Guid>("CondominioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnName("EmailDoSindico")
                                .HasColumnType("varchar(255)")
                                .HasMaxLength(255);

                            b1.HasKey("CondominioId");

                            b1.ToTable("Condominio");

                            b1.WithOwner()
                                .HasForeignKey("CondominioId");
                        });

                    b.OwnsOne("CondominioApp.Core.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("CondominioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("bairro")
                                .HasColumnName("Bairro")
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("cep")
                                .HasColumnName("Cep")
                                .HasColumnType("nvarchar(10)")
                                .HasMaxLength(10);

                            b1.Property<string>("cidade")
                                .HasColumnName("Cidade")
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("complemento")
                                .HasColumnName("Complemento")
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("estado")
                                .HasColumnName("Estado")
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("logradouro")
                                .HasColumnName("Logradouro")
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("municipio")
                                .HasColumnName("Municipio")
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("numero")
                                .HasColumnName("Numero")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.HasKey("CondominioId");

                            b1.ToTable("Condominio");

                            b1.WithOwner()
                                .HasForeignKey("CondominioId");
                        });

                    b.OwnsOne("CondominioApp.Core.ValueObjects.Telefone", "TelefoneDoSindico", b1 =>
                        {
                            b1.Property<Guid>("CondominioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("TelefoneDoSindico")
                                .HasColumnType("varchar(15)")
                                .HasMaxLength(15);

                            b1.HasKey("CondominioId");

                            b1.ToTable("Condominio");

                            b1.WithOwner()
                                .HasForeignKey("CondominioId");
                        });
                });

            modelBuilder.Entity("CondominioAppPreCadastro.App.Models.Lead", b =>
                {
                    b.OwnsOne("CondominioApp.Core.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("LeadId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("varchar(255)")
                                .HasMaxLength(255);

                            b1.HasKey("LeadId");

                            b1.ToTable("Lead");

                            b1.WithOwner()
                                .HasForeignKey("LeadId");
                        });

                    b.OwnsOne("CondominioApp.Core.ValueObjects.Telefone", "Telefone", b1 =>
                        {
                            b1.Property<Guid>("LeadId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("Telefone")
                                .HasColumnType("varchar(15)")
                                .HasMaxLength(15);

                            b1.HasKey("LeadId");

                            b1.ToTable("Lead");

                            b1.WithOwner()
                                .HasForeignKey("LeadId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
