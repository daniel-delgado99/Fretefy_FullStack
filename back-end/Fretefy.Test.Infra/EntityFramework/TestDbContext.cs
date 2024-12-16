using Fretefy.Test.Domain.Entities;
using System;
using Fretefy.Test.Infra.EntityFramework.Mappings;
using Microsoft.EntityFrameworkCore;
using Fretefy.Test.Domain.Services;
using Fretefy.Test.Infra.EntityFramework.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Fretefy.Test.Infra.EntityFramework
{
    public class TestDbContext : DbContext
    {
        public TestDbContext()
        {

        }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CidadeMap());
            modelBuilder.ApplyConfiguration(new RegiaoMap());
            modelBuilder.ApplyConfiguration(new RegiaoCidadeMap());
        }
    }
}
