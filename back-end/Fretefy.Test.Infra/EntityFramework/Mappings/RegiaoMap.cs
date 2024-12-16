using System;
using Fretefy.Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fretefy.Test.Infra.EntityFramework.Mappings
{
    public class RegiaoMap : IEntityTypeConfiguration<Regiao>
    {
        public void Configure(EntityTypeBuilder<Regiao> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Nome).HasMaxLength(512).IsRequired();
            builder.HasMany(r => r.RegiaoCidades).WithOne(rc => rc.Regiao).HasForeignKey(rc => rc.RegiaoId);

            builder.HasData(
              new Regiao { Id = Guid.Parse("f0f7d0d5-4b6f-4b08-93b2-e49a3f214735"), Nome = "Norte", Ativo = true },
              new Regiao { Id = Guid.Parse("5d7df2c0-1f33-4bb0-8032-2a6d8f6dcbf9"), Nome = "Nordeste", Ativo = true },
              new Regiao { Id = Guid.Parse("9e9c4b2f-9c74-438d-98b0-0220193925c1"), Nome = "Centro-Oeste", Ativo = true },
              new Regiao { Id = Guid.Parse("4e2736f3-017f-4c6b-81b8-9ba4ed1e37cd"), Nome = "Sudeste", Ativo = false },
              new Regiao { Id = Guid.Parse("b0c7d3f3-c1ab-4a2d-9338-c88cc51080c7"), Nome = "Sul", Ativo = false }
           );
        }
    }
}
