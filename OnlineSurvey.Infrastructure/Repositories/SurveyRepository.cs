using Microsoft.EntityFrameworkCore;
using OnlineSurvey.Domian.Abstraction;
using OnlineSurvey.Domian.Entities;
namespace OnlineSurvey.Infrastructure.Repositories
{
    internal class SurveyRepository : ISurveyRepository
    {
        private readonly AppDbContext context;

        public SurveyRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Question> GetQuestionByIdAsync(int surveyId, int questionId)
        {

            var survey = await context.Surveys.Include(q => q.Questions).FirstOrDefaultAsync(s => s.Id == surveyId);

            if (survey != null)
            {

                var question = await context.Questions.Include(a => a.Answer).Where(q => q.Id == survey.Id).FirstOrDefaultAsync(s => s.Id == questionId);

                if (question != null) return question;

                else return null;
            }

            else return null;
        }

        
    }
}
