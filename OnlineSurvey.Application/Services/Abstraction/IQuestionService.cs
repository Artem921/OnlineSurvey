using OnlineSurvey.Application.DTOs;

namespace OnlineSurvey.Application.Services.Abstraction
{
    internal interface IQuestionService
    {
        public Task<QuestionDto> GetByIdAsync(int surveyId,int questionId);
    }
}
