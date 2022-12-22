using Microsoft.EntityFrameworkCore;
using Metis.Domain.Model;
using Metis.Infrastructure;

DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
optionsBuilder.UseSqlite("Data Source=Metis_Test.db");

MetisContext db = new MetisContext(optionsBuilder.Options);

// Questions die mit "L" beginnen
List<Question> result01 = db.Questions.Where(q => q.QuestionText.StartsWith("L")).ToList();

// Question mit der Id 12
var result02 = db.Questions.SingleOrDefault(q => q.Id == 12);


Console.Read();