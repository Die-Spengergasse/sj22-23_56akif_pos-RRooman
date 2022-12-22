using Bogus;
using Metis.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// NugetPackagers: Bogus, Microsoft.EntityFrameworkCore.Tools, Mircosoft.EntitiyFrameworkCore.Sqlite
namespace Metis.Infrastructure
{
    // 1. Klasse muss von DbConetxt ableiten
    public class MetisContext : DbContext
    {
        // 2. Tabellen als Properties auflisten
        public DbSet<Answer> Answers => Set<Answer>();
        public DbSet<Flaged> Flagged => Set<Flaged>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Statistic> Statistics => Set<Statistic>();
        public DbSet<Subject> Subjects => Set<Subject>();
        public DbSet<ToDo> ToDos => Set<ToDo>();
        public DbSet<Topic> Topics => Set<Topic>();

        // 3. Constructor
        public MetisContext()
        { }
        public MetisContext(DbContextOptions options) : base(options)
        { }

        // 4. Konfiguration vor Db-Erstellung
        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.LogTo(Console.WriteLine);
        }

        // 5. Optionen während Db-Erstellung, die nicht automatisch erkannt werden
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Subject>().HasKey(s => s.Name);
            //modelBuilder.Entity<Subject>().Property(s => s.Name).IsRequired();    // nicht notwendig da Primary Key

            modelBuilder.Entity<Topic>().HasKey(s => s.Name);

            //modelBuilder.Entity<Answer>().HasKey(a => a.AnswerId);                // nicht notwendig, da Integer mit 'Id' in Namen

            //modelBuilder.Entity<Question>().OwnsOne(q => q.Answer);               // OwnsOne -> Access von Answer nur durch Owner möglich -> in dem Fall nicht gewünscht

            modelBuilder.Entity<Question>().OwnsOne(q => q.QStat);
        }

        public void Seed()
        {
            Randomizer.Seed = new Random(21271222);


            List<Subject> subjects = new Faker<Subject>()
                .CustomInstantiator(f => new Subject(f.Lorem.Word(), f.Lorem.Text()))
                .Generate(30)
                .DistinctBy(s => s.Name)
                .Take(20)
                .ToList();
            Subjects.AddRange(subjects);
            SaveChanges();

            List<Topic> topics = new Faker<Topic>()
                .CustomInstantiator(f => new Topic(
                    f.Lorem.Word(),
                    f.Lorem.Text(),
                    f.Random.ListItem(subjects)))
                .Generate(100)
                .DistinctBy(t => t.Name)
                .Take(70)
                .ToList();
            Topics.AddRange(topics);
            SaveChanges();


            List<Answer> answers = new Faker<Answer>()
                .CustomInstantiator(f => new Answer(
                    f.Lorem.Sentence(),
                    f.Lorem.Sentence())
                )
                .Generate(200)
                .Take(150)
                .ToList();
            Answers.AddRange(answers);
            SaveChanges();


            List<Question> questions = new Faker<Question>()
                .CustomInstantiator(f => new Question(
                    f.Lorem.Sentence(),
                    f.Random.Enum<QuestionType>(),
                    f.Random.Enum<AnswerType>(),
                    f.Random.ListItems(topics).ToList()))
                .Rules((f, q) =>
                {
                    q.Answer = answers[f.Random.Int(0, answers.Count() - 1)];   // nur möglich wenn Answer nicht von Question geownt wird, da Answer sonst nicht vorher instanzierbar ist
                    //q._topics = f.Random.ListItems(topics).ToList();             // nicht möglich
                    //q.Answer = new Answer(
                    //f.Lorem.Sentence(),
                    //f.Lorem.Sentence());
                })
                .Generate(200)
                .Take(150)
                .ToList();
            Questions.AddRange(questions);
            SaveChanges();


            List<ToDo> toDos = new Faker<ToDo>()
                .CustomInstantiator(f => new ToDo(
                    f.Date.Between(DateTime.Now.AddDays(1), DateTime.Now.AddMonths(12)),
                    f.Random.ListItem(questions)))
                .Generate(30)
                .ToList();
            ToDos.AddRange(toDos);
            SaveChanges();
        }
    }
}
