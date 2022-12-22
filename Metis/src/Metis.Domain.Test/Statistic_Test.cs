using Metis.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metis.Domain.Test
{
    public class Statistic_Test
    {
        private MetisContext GenerateDb()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite("Data Source=Metis_Statistic_Test");

            MetisContext db = new MetisContext(optionsBuilder.Options);

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            return db;
        }

        [Fact]
        public void Statistic_IncrementAsked_AskedCount_Test()
        {
            MetisContext db = GenerateDb();
            db.Seed();

            var testStat = db.Questions.First();

            testStat.QStat.IncrementAsked(Model.Result.Correct);

            db.Update(testStat);
            db.SaveChanges();

            Assert.Equal(1, db.Questions.First().QStat.AskedCount);
        }
    }
}
