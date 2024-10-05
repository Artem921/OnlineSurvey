using Microsoft.EntityFrameworkCore;
using OnlineSurvey.Domian.Abstraction;
using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Infrastructure.Repositories
{
    internal class InterviewRepository : IInterviewRepository
    {
        private readonly AppDbContext context;

        public InterviewRepository(AppDbContext context)
        {
            this.context = context;
        }  

        public async  Task AddAsync(Interview interview)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    await context.Interviews.AddAsync(interview);
                    await context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch { transaction.Rollback(); }
            }
               
        }

        public async Task UpdateAsync(Interview interview)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var result = interview.Results.FirstOrDefault();
                    await context.Results.AddAsync(result);
                    await context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch { transaction.Rollback(); }

               
            }
        }
    }
}
