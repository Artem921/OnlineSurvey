using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Domian.Abstraction
{
    internal interface ISurveyRepository
    {
        public Task<Survey> GetByIdAsync(int id);

    }
}
