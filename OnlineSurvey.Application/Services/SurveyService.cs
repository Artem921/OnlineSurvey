
using Mapster;
using OnlineSurvey.Application.DTOs;
using OnlineSurvey.Application.Services.Abstraction;
using OnlineSurvey.Domian.Abstraction;

namespace OnlineSurvey.Application.Services
{
    internal class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository surveyRepository;

        public SurveyService(ISurveyRepository surveyRepository)
        {
            this.surveyRepository = surveyRepository;
        }

        public async Task<SurveyDto> GetByIdAsync(int id)
        {
            var survey = await surveyRepository.GetByIdAsync(id);

            return survey is null ? throw new NullReferenceException($"Опроса с таким Id не существует {nameof(SurveyService)}") : survey.Adapt<SurveyDto>();
        }


    }
}