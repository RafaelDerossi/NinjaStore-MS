﻿// <auto-generated />
using System;
using CondominioApp.Automacao.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CondominioApp.Automacao.App.Migrations
{
    [DbContext(typeof(AutomacaoContextDB))]
    partial class AutomacaoContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CondominioApp.Automacao.Models.CondominioCredencial", b =>
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

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("TipoApiAutomacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CondominiosCredenciais");
                });

            modelBuilder.Entity("CondominioApp.Automacao.Models.DispositivoWebhook", b =>
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

                    b.Property<bool>("Ligado")
                        .HasColumnType("bit");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("DispositivoWebhook");
                });

            modelBuilder.Entity("CondominioApp.Automacao.Models.CondominioCredencial", b =>
                {
                    b.OwnsOne("CondominioApp.Automacao.App.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("CondominioCredencialId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("varchar(255)")
                                .HasMaxLength(255);

                            b1.HasKey("CondominioCredencialId");

                            b1.ToTable("CondominiosCredenciais");

                            b1.WithOwner()
                                .HasForeignKey("CondominioCredencialId");
                        });
                });

            modelBuilder.Entity("CondominioApp.Automacao.Models.DispositivoWebhook", b =>
                {
                    b.OwnsOne("CondominioApp.Principal.Domain.ValueObjects.Url", "UrlDesligar", b1 =>
                        {
                            b1.Property<Guid>("DispositivoWebhookId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .HasColumnName("UrlDesligar")
                                .HasColumnType("varchar(255)")
                                .HasMaxLength(255);

                            b1.HasKey("DispositivoWebhookId");

                            b1.ToTable("DispositivoWebhook");

                            b1.WithOwner()
                                .HasForeignKey("DispositivoWebhookId");
                        });

                    b.OwnsOne("CondominioApp.Principal.Domain.ValueObjects.Url", "UrlLigar", b1 =>
                        {
                            b1.Property<Guid>("DispositivoWebhookId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .HasColumnName("UrlLigar")
                                .HasColumnType("varchar(255)")
                                .HasMaxLength(255);

                            b1.HasKey("DispositivoWebhookId");

                            b1.ToTable("DispositivoWebhook");

                            b1.WithOwner()
                                .HasForeignKey("DispositivoWebhookId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
