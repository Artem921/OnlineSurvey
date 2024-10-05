using OnlineSurvey.Application.DTOs;
using OnlineSurvey.Application.Services.Abstraction;

namespace OnlineSurvey.Application.Services
{
    internal class QuestionService : IQuestionService
    {
        private readonly ISurveyService surveyService;

        public QuestionService(ISurveyService surveyService)
        {
            this.surveyService = surveyService;
        }

        public async Task<QuestionDto> GetByIdAsync(int surveyId, int questionId)
        {
            if (questionId != null)
            {
                var surey = await surveyService.GetByIdAsync(surveyId);
                var question = await Task.Run(() =>surey.Questions.FirstOrDefault(q => q.Id == questionId));

                return question is null ? throw new NullReferenceException($"Вопроса с таким Id не существует {nameof(QuestionService)}") :question;
            }

            else
            {
                throw new ArgumentNullException($" Параметр {nameof(questionId)} метода  {nameof(GetByIdAsync)}  не может быть  равен нулю");
            }
        }
    }
}
