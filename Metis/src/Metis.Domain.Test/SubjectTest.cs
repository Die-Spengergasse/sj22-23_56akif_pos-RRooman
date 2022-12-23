using Metis.Domain.Model;
using Metis.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Metis.Domain.Test
{
    public class SubjectTest
    {
        private MetisContext GenerateDb()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite("Data Source=Metis_Subject_Test.db");

            MetisContext db = new MetisContext(optionsBuilder.Options);

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            return db;
        }

        [Fact]
        public void Subject_Constructor_Name_Decription_Test()
        {
            MetisContext db = GenerateDb();
            Subject subject = new Subject("SubjectName", "SubjectDescription");

            db.Subjects.Add(subject);
            db.SaveChanges();

            Assert.Equal(1, db.Subjects.Count());
        }

        [Fact]
        public void Subject_AddQuestion_Test()
        {
            Subject subject = new Subject("subjectname", "subjectdescription");
            Question question = new Question("questiontype", QuestionType.Understanding, AnswerType.MultipleChoice);
            subject.AddQuestion(question);

            Assert.Equal(question, subject.Questions.First());
        }

        [Fact]
        public void Subject_AddTopic_Test()
        {
            MetisContext db = GenerateDb();
            db.Seed();

            Subject subject = new Subject("subjectname", "subjectdescription");
            Topic topic = db.Topics.First();

            subject.AddTopic(topic);

            Assert.Equal(topic, subject.Topics[0]);
        }

        [Fact]
        public void Subject_AddTopic_ArgumentNullException_Test()
        {
            Subject subject = new Subject("", "");

            try
            {
                subject.AddTopic(null);
            } 
            catch (Exception e)
            {
                Assert.Equal("question is NULL!", e.Message);
            }
        }


    }
}
