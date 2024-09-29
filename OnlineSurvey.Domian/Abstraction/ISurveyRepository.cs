using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Domian.Abstraction
{
    internal interface ISurveyRepository
    {
        public Task<Question> GetQuestionByIdAsync(int surveyId, int questionId);
        public Task<Survey> GetSurveyByIdAsync(int id);

    }
}
