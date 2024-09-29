using OnlineSurvey.Application.DTOs;

namespace OnlineSurvey.Application.Services.Abstraction
{
    internal interface ISurveyService
    {
        public Task<QuestionDto> GetQuestionByIdAsync(int surveyId, int questionId);
    }
}
