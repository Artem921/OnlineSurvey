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
                }
                catch (Exception ex) { transaction.Rollback(); }
            }
               
        }

        public async Task<Interview?> GetByIdAsync(string id) => await context.Interviews.FirstOrDefaultAsync(i => i.Id == id);

        public async Task UpdateAsync(Interview interview)
        {

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var interviewOld = await context.Interviews.Include(r => r.Results).FirstOrDefaultAsync(i => i.Id == interview.Id);
                    interviewOld = interview;
                    await context.SaveChangesAsync();

                }
                catch (Exception ex) { transaction.Rollback(); }
               
            }
               
        }
        public async Task DeleteAsync(Interview interview) 
        {           
              await Task.Run(() => context.Interviews.Remove(interview));

              await context.SaveChangesAsync();           
        }

        public async Task<List<Interview>?> GetAllAsync()
        {
            return await context.Interviews.ToListAsync();
        }
    }
}
