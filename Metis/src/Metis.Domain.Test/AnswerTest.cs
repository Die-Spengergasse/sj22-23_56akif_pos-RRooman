using Metis.Domain.Model;
using Metis.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Klasse ist XunitTest
// Dependencies auf Model und Infrastructure
namespace Metis.Domain.Test
{
    public class AnswerTest
    {
        private MetisContext GenerateDb()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite("Data Source=Metis_Answer_Test.db");
            
            MetisContext db = new MetisContext(optionsBuilder.Options);

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            return db;
        }

        [Fact]
        public void SeedDb()
        {
            MetisContext db = GenerateDb();
            db.Seed();
            Assert.True(true);
        }

        [Fact]
        public void Answer_Add_OneEntity_OneProperty_SuccessTest()
        {
            // 1. Arrange
            MetisContext db = GenerateDb();
            Answer newAnswer = new Answer("Antworttext");

            // 2. Act
            db.Answers.Add(newAnswer);
            db.SaveChanges();

            // 3. Assert
            Assert.Equal(1, db.Answers.Count());
        }

        [Fact]
        public void Answer_Add_OneEntity_TwoProperty_SuccessTest()
        {
            // 1. Arrange
            MetisContext db = GenerateDb();
            Answer newAnswer = new Answer("Antworttext", "Weil halt");

            // 2. Act
            db.Answers.Add(newAnswer);
            db.SaveChanges();

            // 3. Assert
            Assert.Equal(1, db.Answers.Count());
        }
    }
}
