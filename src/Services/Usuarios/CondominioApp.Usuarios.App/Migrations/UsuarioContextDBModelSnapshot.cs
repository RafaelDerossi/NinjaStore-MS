﻿// <auto-generated />
using System;
using CondominioApp.Usuarios.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CondominioApp.Usuarios.App.Migrations
{
    [DbContext(typeof(UsuarioContextDB))]
    partial class UsuarioContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CondominioApp.Usuarios.App.Models.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Atribuicao")
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Funcao")
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<int>("Permissao")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("CondominioApp.Usuarios.App.Models.Mobile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceKey")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("MobileId")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Modelo")
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("MoradorIdFuncionadioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Plataforma")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Versao")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Mobiles");
                });

            modelBuilder.Entity("CondominioApp.Usuarios.App.Models.Morador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<bool>("Principal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("Proprietario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<Guid>("UnidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Moradores");
                });

            modelBuilder.Entity("CondominioApp.Usuarios.App.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Rg")
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("SindicoProfissional")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("UltimoLogin")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CondominioApp.Usuarios.App.Models.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cor")
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Modelo")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("varchar(7)");

                    b.HasKey("Id");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("CondominioApp.Usuarios.App.Models.VeiculoCondominio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<Guid>("UnidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VeiculoId");

                    b.ToTable("VeiculosCondominios");
                });

            modelBuilder.Entity("CondominioApp.Usuarios.App.Models.Usuario", b =>
                {
                    b.OwnsOne("CondominioApp.Usuarios.App.ValueObjects.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("Cpf")
                                .HasColumnType("varchar(14)")
                                .HasMaxLength(14);

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("CondominioApp.Usuarios.App.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("varchar(255)")
                                .HasMaxLength(255);

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("CondominioApp.Usuarios.App.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
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

                            b1.Property<string>("numero")
                                .HasColumnName("Numero")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("CondominioApp.Usuarios.App.ValueObjects.Foto", "Foto", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("NomeDoArquivo")
                                .IsRequired()
                                .HasColumnName("NomeDoArquivo")
                                .HasColumnType("varchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("NomeOriginal")
                                .IsRequired()
                                .HasColumnName("NomeOriginal")
                                .HasColumnType("varchar(200)")
                                .HasMaxLength(200);

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("CondominioApp.Usuarios.App.ValueObjects.Telefone", "Cel", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("Celular")
                                .HasColumnType("varchar(15)")
                                .HasMaxLength(15);

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("CondominioApp.Usuarios.App.ValueObjects.Telefone", "Telefone", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("Telefone")
                                .HasColumnType("varchar(15)")
                                .HasMaxLength(15);

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });
                });

            modelBuilder.Entity("CondominioApp.Usuarios.App.Models.VeiculoCondominio", b =>
                {
                    b.HasOne("CondominioApp.Usuarios.App.Models.Veiculo", null)
                        .WithMany("VeiculoCondominios")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
