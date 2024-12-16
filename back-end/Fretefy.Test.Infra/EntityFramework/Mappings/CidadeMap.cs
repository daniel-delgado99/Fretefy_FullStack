using System;
using Fretefy.Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fretefy.Test.Infra.EntityFramework.Mappings
{
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasMaxLength(1024).IsRequired();
            builder.Property(p => p.UF).HasMaxLength(2).IsRequired();

            builder.HasData(
                new Cidade { Id = Guid.Parse("8e9db7f0-e40a-4e68-9b9a-e7efc3ad60c4"), Nome = "Rio Branco", UF = "AC" },
                new Cidade { Id = Guid.Parse("1c846b6d-d207-48b3-b70d-e7ac2bc9f101"), Nome = "Maceió", UF = "AL" },
                new Cidade { Id = Guid.Parse("5f402477-3a90-421f-8cde-6d982f1c872d"), Nome = "Macapá", UF = "AP" },
                new Cidade { Id = Guid.Parse("83db2c9e-d62a-48ad-b07f-11f89d504951"), Nome = "Manaus", UF = "AM" },
                new Cidade { Id = Guid.Parse("0c97466d-51b3-4097-93f9-41b7fbc5f8a3"), Nome = "Salvador", UF = "BA" },
                new Cidade { Id = Guid.Parse("b51a6b2d-4123-4632-b2c5-87f57d7480db"), Nome = "Fortaleza", UF = " CE" },
                new Cidade { Id = Guid.Parse("09db72f5-ef75-4785-bf59-b5103063acdd"), Nome = "Brasília", UF = "DF" },
                new Cidade { Id = Guid.Parse("42c606b9-2958-4961-a3a6-92ccfc3b7078"), Nome = "Vitória", UF = "ES" },
                new Cidade { Id = Guid.Parse("8db0d3f9-121b-4f63-8d84-27a2a8dfdfdd"), Nome = "Goiânia", UF = "GO" },
                new Cidade { Id = Guid.Parse("b4abf477-e221-4017-9b62-caa52b24dfb4"), Nome = "São Luís", UF = "MA" },
                new Cidade { Id = Guid.Parse("72a2cb2d-fc50-48e4-a6e9-8599082d2b85"), Nome = "Cuiabá", UF = "MT" },
                new Cidade { Id = Guid.Parse("51b78b97-fb88-4661-bd68-df20c02ae283"), Nome = "Campo Grande", UF = "MS" },
                new Cidade { Id = Guid.Parse("3fbe0e9c-4cc9-4643-9ff1-bc57a9bcb762"), Nome = "Belo Horizonte", UF = "MG" },
                new Cidade { Id = Guid.Parse("17e01bc5-9f73-4531-9074-eefb7b8d458d"), Nome = "Belém", UF = "PA" },
                new Cidade { Id = Guid.Parse("6a2b041f-f924-468d-8635-63c62358d435"), Nome = "João Pessoa", UF = "PB" },
                new Cidade { Id = Guid.Parse("b07bb4e0-6a90-4f2f-86d7-80b198582dc0"), Nome = "Curitiba", UF = "PR" },
                new Cidade { Id = Guid.Parse("1ccbd6ae-0e58-4f91-bb02-dad31c8201b1"), Nome = "Recife", UF = "PE" },
                new Cidade { Id = Guid.Parse("332ce25e-47f1-44d9-99d5-1ae913b0ac88"), Nome = "Teresina", UF = "PI" },
                new Cidade { Id = Guid.Parse("dd99bc63-4772-4ec0-a9b2-4c345f4d7de5"), Nome = "Rio de Janeiro", UF = "RJ" },
                new Cidade { Id = Guid.Parse("4d545f9e-1ff4-471a-bbfe-7be8e5b522bc"), Nome = "Natal", UF = "RN" },
                new Cidade { Id = Guid.Parse("f8f3adf6-2c5e-4f2e-9b7e-9fa745672d85"), Nome = "Porto Alegre", UF = "RS" },
                new Cidade { Id = Guid.Parse("340ebc11-fc7c-49b2-9b4c-00b6f89c9990"), Nome = "Porto Velho", UF = "RO" },
                new Cidade { Id = Guid.Parse("805855e0-86d6-4f79-bc4e-c3c71b3d827a"), Nome = "Boa Vista", UF = "RR" },
                new Cidade { Id = Guid.Parse("2eecb465-7f31-4592-81f3-8a5b8fa5b254"), Nome = "Florianópolis", UF = "SC" },
                new Cidade { Id = Guid.Parse("af1c7b8e-d3d8-4d58-b8b6-18fdaab71a92"), Nome = "São Paulo", UF = "SP" },
                new Cidade { Id = Guid.Parse("d72b501a-34f5-47b2-9a5f-b21b3a3daaa5"), Nome = "Aracaju", UF = "SE" },
                new Cidade { Id = Guid.Parse("7c11f1d4-34bc-4260-a109-b1d7ac1bc129"), Nome = "Palmas", UF = "TO" });
        }
    }
}
