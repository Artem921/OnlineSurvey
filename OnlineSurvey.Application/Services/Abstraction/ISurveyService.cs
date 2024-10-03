using OnlineSurvey.Application.DTOs;

namespace OnlineSurvey.Application.Services.Abstraction
{
    internal interface ISurveyService
    {
        public Task<SurveyDto> GetByIdAsync(int id);
    }
}
