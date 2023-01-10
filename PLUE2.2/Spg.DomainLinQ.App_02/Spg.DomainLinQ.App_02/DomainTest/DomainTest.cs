using Microsoft.EntityFrameworkCore;
using Spg.DomainLinQ.App.Infrastructure;
using Spg.DomainLinQ.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTest
{
    public class DomainTest
    {
        private Shop2000Context GenerateDb()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite("Data Source=Shop2000.db");

            Shop2000Context db = new Shop2000Context(optionsBuilder.Options);

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            return db;
        }

        [Fact]
        public void SeedDb()
        {
            Shop2000Context db = GenerateDb();

            db.Seed();
            Assert.True(true);
        }

        [Fact]
        public void User_Add_OneEntityTest()
        {
            Shop2000Context db = GenerateDb();
            User user = new User(12345, Guid.NewGuid(), "first", "last", "first.last@email.com", Gender.NA, new Shop(), new Address(), new Address());

            db.Users.Add(user);
            db.SaveChanges();

            Assert.Equal(1, db.Users.Count());
        }

        [Fact]
        public void shop_add_oneentitytest()
        {
            Shop2000Context db = GenerateDb();
            Shop shop = new Shop();

            db.Shops.Add(shop);
            db.SaveChanges();

            Assert.Equal(1, db.Shops.Count());
        }
    }
}
