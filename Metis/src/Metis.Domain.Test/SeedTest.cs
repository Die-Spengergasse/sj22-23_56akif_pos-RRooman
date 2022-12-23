using Metis.Domain.Model;
using Metis.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metis.Domain.Test
{
    public class SeedTest
    {
        private MetisContext GenerateDb()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite("Data Source=Metis_Seed_Test.db");

            MetisContext db = new MetisContext(optionsBuilder.Options);

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            return db;
        }

        private MetisContext GenerateSeededDb()
        {
            MetisContext db = GenerateDb();
            db.Seed();

            return db;
        }

        [Fact]
        public void DbSeedTest()
        {
            MetisContext db = GenerateSeededDb();
            
            db.SaveChanges();

            Assert.True(true);
        }
    }
}
