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
    public class ToDoTest
    {
        private MetisContext GenerateDb()
        {
            DbContextOptionsBuilder optionsBuilder= new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite("Data Source=Metis_ToDo_Test.db");

            MetisContext db = new MetisContext(optionsBuilder.Options);

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            return db;
        }

        [Fact]
        public void ToDo_Constructor_with_Question_Test()
        {
            MetisContext db = GenerateDb();
            ToDo newToDo = new ToDo(
                DateTime.Now.AddDays(30), 
                new Question("Frage", QuestionType.Understanding, AnswerType.MultipleChoice)
                );

            db.ToDos.Add(newToDo);
            db.SaveChanges();

            Assert.Equal(1, db.ToDos.Count());   
        }

        [Fact]
        public void ToDo_Constructor_with_Topic_Test()
        {
            MetisContext db = GenerateDb();
            ToDo newToDo = new ToDo(
                DateTime.Now.AddDays(60), 
                new Topic(
                    "Topic", 
                    "TopicInfo", 
                    new Subject("Subject", "Subjectdescription")
                    )
                );

            db.ToDos.Add(newToDo);
            db.SaveChanges();

            Assert.Equal(1, db.ToDos.Count());
        }

        [Fact]
        public void ToDo_Constructor_with_Subject_Test()
        {
            MetisContext db = GenerateDb();
            ToDo newToDo = new ToDo(
                DateTime.MaxValue,
                new Subject("Subjectname", "Subjectdiscription")
                );

            db.ToDos.Add(newToDo);
            db.SaveChanges();

            Assert.Equal(1, db.ToDos.Count());
        }

        [Fact]
        public void ToDo_SetDone_Test()
        {
            MetisContext db = GenerateDb();
            db.Seed();

            var newToDo = db.ToDos.SingleOrDefault(t => t.Id == 1);
            newToDo?.SetDone();

            Assert.True(newToDo?.Done);
        }

        [Fact]
        public void ToDo_ChangeUntil_Test()
        {
            MetisContext db = GenerateDb();
            db.Seed();

            var newToDo = db.ToDos.Single(t => t.Id == 2);
            newToDo.ChangeUntil(new DateTime(2023, 10, 10));

            Assert.Equal(new DateTime(2023, 10, 10), newToDo.Until);
        }
    }
}
