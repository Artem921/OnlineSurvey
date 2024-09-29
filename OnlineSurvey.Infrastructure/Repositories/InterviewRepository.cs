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
                catch  { transaction.Rollback(); }
            }
               
        }

        public async Task<Interview?> GetByIdAsync(string id) => await context.Interviews.Include(r => r.Results).FirstOrDefaultAsync(i => i.Id == id);

        public async Task UpdateAsync(Interview interview)
        {

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var interviewOld = await GetByIdAsync(interview.Id);
                    await DeleteAsync(interviewOld);
                    await context.Interviews.AddAsync(interview);
                    await context.SaveChangesAsync();
                    transaction.Commit();

                }
                catch { transaction.Rollback(); }
               
            }
               
        }
        public async Task DeleteAsync(Interview interview) 
        {

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    await Task.Run(() => context.Interviews.Remove(interview));
                    await context.SaveChangesAsync();
                }
                catch { transaction.Rollback(); }
                
            }
                        
        }
    }
}
