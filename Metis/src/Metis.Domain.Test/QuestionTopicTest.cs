using Metis.Domain.Model;
using Metis.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Metis.Domain.Test
{
    public class QuestionTopicTest
    {
        public MetisContext GenerateDb()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite("Data Source=Metis_QuestionTopic_Test");

            MetisContext db = new MetisContext(optionsBuilder.Options);

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            return db;
        }

        [Fact]
        public void QuestionTopic_Create_Test()
        {
            MetisContext db = GenerateDb();

            QuestionTopic questionTopic = new QuestionTopic(
                new Question("questiontext", QuestionType.Understanding, AnswerType.MultipleChoice),
                new Topic("topicname", "topicinfo", new Subject("subjectname", "subjectdescription"))
                );

            db.QuestionTopics.Add(questionTopic);
            db.SaveChanges();

            Assert.True(db.QuestionTopics.Any());
        }

        //[Fact]
        //public void QuestionTopic_Relation_Test() 
        //{
        //    MetisContext db = GenerateDb();
        //    db.Seed();

        //    Question question = db.Questions.First();
        //    Topic topic = db.Topics.First();

        //    QuestionTopic questionTopic = new QuestionTopic(question, topic);

        //    db.QuestionTopics.Add(questionTopic);
        //    db.SaveChanges();

        //}
    }
}
