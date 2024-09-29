
using Mapster;
using OnlineSurvey.Application.DTOs;
using OnlineSurvey.Application.Services.Abstraction;
using OnlineSurvey.Domian.Abstraction;
using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Application.Services
{
    internal class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository surveyRepository;

        public SurveyService(ISurveyRepository surveyRepository)
        {
            this.surveyRepository = surveyRepository;
        }
    
        public async Task<QuestionDto> GetQuestionByIdAsync(int surveyId, int questionId)
        {
            if (surveyId != null && questionId != null)
            {
                var question = await surveyRepository.GetQuestionByIdAsync(surveyId, questionId);
                return question is null ? throw new NullReferenceException($"Вопроса с таким Id не существует {nameof(SurveyService)}") : question.Adapt<QuestionDto>();
            }

            else
            {
                throw new ArgumentNullException($" Параметы {nameof(surveyId)} и {nameof(questionId)} метода  GetQuestionByIdAsync  не могут быть пустыми");
            }
        }

        public async Task<Survey> GetSurveyByIdAsync(int id) => await surveyRepository.GetSurveyByIdAsync(id);
      
        
    }
}