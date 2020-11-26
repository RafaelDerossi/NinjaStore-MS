﻿using CondominioApp.Principal.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CondominioApp.Principal.Domain.FlatModel;

namespace CondominioApp.Principal.Infra.DataQuery.Mapping
{
    public class GrupoFlatMapping : IEntityTypeConfiguration<GrupoFlat>
    {
        public void Configure(EntityTypeBuilder<GrupoFlat> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("GruposFlat");

            builder.Property(u => u.Descricao).IsRequired().HasColumnType($"varchar({GrupoFlat.Max})");         

            builder.Property(u => u.CondominioId).IsRequired();
           
            builder.Property(u => u.CondominioCnpj).IsRequired().HasColumnType($"varchar({Cnpj.Maxlength})");
           
            builder.Property(u => u.CondominioNome).IsRequired().HasColumnType($"varchar({CondominioFlat.Max})");

            builder.Property(u => u.CondominioLogoMarca).HasColumnType($"varchar({Foto.NomeFotoMaximo})");          

        }
    }
}
