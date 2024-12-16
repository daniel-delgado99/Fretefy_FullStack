using System;
using Fretefy.Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fretefy.Test.Infra.EntityFramework.Mappings
{
    public class RegiaoCidadeMap : IEntityTypeConfiguration<RegiaoCidade>
    {
        public void Configure(EntityTypeBuilder<RegiaoCidade> builder)
        {
            builder.HasKey(rc => new { rc.RegiaoId, rc.CidadeId });

            builder.HasOne(rc => rc.Regiao)
                   .WithMany(r => r.RegiaoCidades)
                   .HasForeignKey(rc => rc.RegiaoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rc => rc.Cidade)
                   .WithMany()
                   .HasForeignKey(rc => rc.CidadeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
               new RegiaoCidade { RegiaoId = Guid.Parse("f0f7d0d5-4b6f-4b08-93b2-e49a3f214735"), CidadeId = Guid.Parse("8e9db7f0-e40a-4e68-9b9a-e7efc3ad60c4") },
               new RegiaoCidade { RegiaoId = Guid.Parse("f0f7d0d5-4b6f-4b08-93b2-e49a3f214735"), CidadeId = Guid.Parse("1c846b6d-d207-48b3-b70d-e7ac2bc9f101") },
               new RegiaoCidade { RegiaoId = Guid.Parse("f0f7d0d5-4b6f-4b08-93b2-e49a3f214735"), CidadeId = Guid.Parse("5f402477-3a90-421f-8cde-6d982f1c872d") },
               new RegiaoCidade { RegiaoId = Guid.Parse("f0f7d0d5-4b6f-4b08-93b2-e49a3f214735"), CidadeId = Guid.Parse("0c97466d-51b3-4097-93f9-41b7fbc5f8a3") },
               new RegiaoCidade { RegiaoId = Guid.Parse("4e2736f3-017f-4c6b-81b8-9ba4ed1e37cd"), CidadeId = Guid.Parse("dd99bc63-4772-4ec0-a9b2-4c345f4d7de5") },
               new RegiaoCidade { RegiaoId = Guid.Parse("4e2736f3-017f-4c6b-81b8-9ba4ed1e37cd"), CidadeId = Guid.Parse("f8f3adf6-2c5e-4f2e-9b7e-9fa745672d85") },
               new RegiaoCidade { RegiaoId = Guid.Parse("4e2736f3-017f-4c6b-81b8-9ba4ed1e37cd"), CidadeId = Guid.Parse("805855e0-86d6-4f79-bc4e-c3c71b3d827a") },
               new RegiaoCidade { RegiaoId = Guid.Parse("5d7df2c0-1f33-4bb0-8032-2a6d8f6dcbf9"), CidadeId = Guid.Parse("1ccbd6ae-0e58-4f91-bb02-dad31c8201b1") },
               new RegiaoCidade { RegiaoId = Guid.Parse("9e9c4b2f-9c74-438d-98b0-0220193925c1"), CidadeId = Guid.Parse("dd99bc63-4772-4ec0-a9b2-4c345f4d7de5") },
               new RegiaoCidade { RegiaoId = Guid.Parse("b0c7d3f3-c1ab-4a2d-9338-c88cc51080c7"), CidadeId = Guid.Parse("af1c7b8e-d3d8-4d58-b8b6-18fdaab71a92") }
           );
        }
    }
}