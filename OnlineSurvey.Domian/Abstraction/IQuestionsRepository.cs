using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Domian.Abstraction
{
    internal interface IQuestionsRepository
    {
        public Task<Question> GetByIdAsync(int id);
    }
}
