using OnlineSurvey.Application.DTOs;
using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Application.Services.Abstraction
{
    internal interface ISurveyService
    {
        public Task<QuestionDto> GetQuestionByIdAsync(int surveyId, int questionId);
        public Task<Survey> GetSurveyByIdAsync(int id);
    }
}
