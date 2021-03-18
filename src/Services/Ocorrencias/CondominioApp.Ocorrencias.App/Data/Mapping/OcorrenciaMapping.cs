﻿using CondominioApp.Ocorrencias.App.Models;
using CondominioApp.Ocorrencias.App.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Ocorrencias.App.Data.Mapping
{
    public class OcorrenciaMapping : IEntityTypeConfiguration<Ocorrencia>
    {
        public void Configure(EntityTypeBuilder<Ocorrencia> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Ocorrencias");           

            builder.Property(u => u.Descricao).IsRequired().HasColumnType($"varchar({Ocorrencia.Max})");

            builder.Property(u => u.Foto)
                   .HasMaxLength(Foto.NomeFotoMaximo)
                   .HasColumnName("Foto")
                   .HasColumnType($"varchar({Foto.NomeFotoMaximo})");


            builder.Property(u => u.Publica).IsRequired();

            builder.Property(u => u.Resolvida).IsRequired();

            builder.Property(u => u.EmAndamento).IsRequired();

            builder.Property(u => u.Parecer).IsRequired();

            builder.Property(u => u.UnidadeId).IsRequired();

            builder.Property(u => u.CondominioId).IsRequired();

            builder.Property(u => u.UsuarioId).IsRequired();

            builder.Property(u => u.Panico).IsRequired();
            
        }
    }
}