using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using OnlineSurvey.Domian.Entities;
using System.Data;
namespace OnlineSurvey.Infrastructure
{
    internal class AppDbContext : DbContext
    {
        private readonly IConfiguration configuration;
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }  
        public DbSet<Interview> Interviews { get; set; }
        private readonly string connectionString;
        private List<string> SQLScripts = new List<string>();
        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("OnlineSurveyBd");
            CreateTables();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString)
                .UseLoggerFactory(CreateLoggerFactory())
                .EnableSensitiveDataLogging();
            
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        //}
        public  ILoggerFactory CreateLoggerFactory() =>
            LoggerFactory.Create(builder => { builder.AddConsole(); });

        public IDbConnection CreateConnection() => new NpgsqlConnection(connectionString);

        public void CreateTables()
        {

           SQLScripts.Add("CREATE TABLE IF NOT EXISTS Surveys" +
                                "Id integer  NOT NULL," +
                                "Name VARCHAR(255)   NOT NULL," +
                                "Discription TEXT  NOT NULL," +
                                "CONSTRAINT  PRIMARY KEY(Id)");

            SQLScripts.Add("CREATE TABLE IF NOT EXISTS Questions" +
                                  "Id integer  NOT NULL," +
                                  "SurveyId integer  NOT NULL," +
                                  "NumberOfAnswers integer NOT NULL," +
                                  "Quaere VARCHAR(255)  NOT NULL," +
                                  "CONSTRAINT  PRIMARY KEY(Id)," +
                                  "CONSTRAINT  FOREIGN KEY(SurveyId)" +
                                  "REFERENCES Surveys (Id) MATCH SIMPLE ON UPDATE NO ACTION ON DELETE CASCADE");

            SQLScripts.Add("CREATE TABLE IF NOT EXISTS Answers" +
                                "Id integer  NOT NULL," +
                                "QuestionId integer  NOT NULL," +
                                "Replys text[] COLLATE NOT NULL," +
                                "CONSTRAINT  PRIMARY KEY (Id)," +
                                "CONSTRAINT  FOREIGN KEY (QuestionId)" +
                                "REFERENCES  (Id) MATCH SIMPLE ON UPDATE NO ACTION ON DELETE CASCADE)");

            SQLScripts.Add("CREATE TABLE IF NOT EXISTS Interview" +
                                  "Id integer  NOT NULL," +
                                  "SurveyId integer  NOT NULL," +
                                  "CONSTRAINT  PRIMARY KEY(Id)");

            SQLScripts.Add("CREATE TABLE IF NOT EXISTS Results" +
                                "Id text  NOT NULL," +
                                "InterviewId text  NOT NULL," +
                                "Results text NOT NULL," +
                                "CONSTRAINT  PRIMARY KEY(Id)," +
                                "CONSTRAINT FOREIGN KEY(InterviewId)" +
                                "REFERENCES  (Id) MATCH SIMPLE ON UPDATE NO ACTION ON DELETE CASCADE");




            using (var connection = CreateConnection())
            {
                connection.Open();

                using (var transaction = this.Database.BeginTransaction())
                {
                    try
                    {
                        foreach(var script in SQLScripts) 
                        { 
                            connection.Execute(script);
                        
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex) { transaction.Rollback(); }
                }
            }
        }
    }


}
