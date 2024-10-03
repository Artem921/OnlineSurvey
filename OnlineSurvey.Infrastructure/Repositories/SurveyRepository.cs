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
            var survey = await GetSurveyByIdAsync(surveyId);

            if (survey != null)
            {
                var question = await Task.Run(()=> survey.Questions.FirstOrDefault(s => s.Id == questionId));

                 return question;
            }

            else return null;
        }

        public async Task<Survey> GetByIdAsync(int id)
        {
            var survey = await context.Surveys.Include(q => q.Questions)
                                             .ThenInclude(a => a.Answer)
                                             .FirstOrDefaultAsync(s => s.Id == id);
            return survey;
        }
    }
}
