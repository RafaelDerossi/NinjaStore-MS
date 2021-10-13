﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NinjaStore.Pedidos.Infra.Data;

namespace NinjaStore.Pedidos.Infra.Migrations.PedidoQueryContextDBMigrations
{
    [DbContext(typeof(PedidoQueryContextDB))]
    [Migration("20211013162312_StatusDoPedidoFlat")]
    partial class StatusDoPedidoFlat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NinjaStore.Pedidos.Domain.FlatModel.PedidoFlat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AldeiaDoCliente")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("decimal(14,2)");

                    b.Property<string>("EmailDoCliente")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("NomeDoCliente")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(14,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(14,2)");

                    b.HasKey("Id");

                    b.ToTable("PedidosFlat");
                });

            modelBuilder.Entity("NinjaStore.Pedidos.Domain.FlatModel.ProdutoDoPedidoFlat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("decimal(14,2)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<Guid>("PedidoFlatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("decimal(14,2)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(14,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(14,2)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoFlatId");

                    b.ToTable("ProdutosDoPedidoFlat");
                });

            modelBuilder.Entity("NinjaStore.Pedidos.Domain.FlatModel.ProdutoDoPedidoFlat", b =>
                {
                    b.HasOne("NinjaStore.Pedidos.Domain.FlatModel.PedidoFlat", null)
                        .WithMany("Produtos")
                        .HasForeignKey("PedidoFlatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
