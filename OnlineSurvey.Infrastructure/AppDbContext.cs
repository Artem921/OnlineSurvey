using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OnlineSurvey.Domian.Entities;
namespace OnlineSurvey.Infrastructure
{
    internal class AppDbContext : DbContext
    {
        private readonly IConfiguration configuration;
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("OnlineSurveyBd"))
                .UseLoggerFactory(CreateLoggerFactory())
                .EnableSensitiveDataLogging()
                .UseLowerCaseNamingConvention();

        }
        public ILoggerFactory CreateLoggerFactory() =>
            LoggerFactory.Create(builder => { builder.AddConsole(); });

     
        }
    }


