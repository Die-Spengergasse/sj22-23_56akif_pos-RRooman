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

        [Fact]
        public void Statistic_IncrementAsked_Add_ResultsList_Test()
        {
            MetisContext db = GenerateDb();
            db.Seed();

            var testStat = db.Questions.First().QStat;

            testStat.IncrementAsked(Model.Result.Incorrect);

            db.Update(testStat);
            db.SaveChanges();

            Assert.Equal(Model.Result.Incorrect, db.Questions.First().QStat.Results.First());
        }

        [Fact]
        public void Statistic_IncrementAsked_CalculatePercentCorrect()
        {
            MetisContext db = GenerateDb();
            db.Seed();

            var testStat = db.Questions.First().QStat;

            for (int i=0; i < 15; i++)
            {
                testStat.IncrementAsked(Model.Result.Correct);
                if (i < 5) testStat.IncrementAsked(Model.Result.Incorrect);
            }

            db.Update(testStat);
            db.SaveChanges();

            Assert.Equal(75, db.Questions.First().QStat.PercentCorrect);
        }

        [Fact]
        public void Statistic_IncrementAsked_CalculateKnowledge()
        {
            MetisContext db = GenerateDb();
            db.Seed();

            var testStat = db.Questions.First().QStat;

            for (int i = 0; i < 15; i++)
            {
                testStat.IncrementAsked(Model.Result.Correct);
                if (i < 5) testStat.IncrementAsked(Model.Result.Incorrect);
            }

            db.Update(testStat);
            db.SaveChanges();

            Assert.Equal(Model.Knowledge.Average, db.Questions.First().QStat.Knowledge);
        }
    }
}
