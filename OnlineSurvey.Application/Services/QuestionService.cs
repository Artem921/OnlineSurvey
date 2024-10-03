using Mapster;
using OnlineSurvey.Application.DTOs;
using OnlineSurvey.Application.Services.Abstraction;
using OnlineSurvey.Domian.Abstraction;

namespace OnlineSurvey.Application.Services
{
    internal class QuestionService : IQuestionService
    {
        private readonly IQuestionsRepository questionsRepository;

        public QuestionService(IQuestionsRepository questionsRepository)
        {
            this.questionsRepository = questionsRepository;
        }

        public async Task<QuestionDto> GetByIdAsync(int questionId)
        {
            if (questionId != null)
            {
                var question = await questionsRepository.GetByIdAsync(questionId);
                return question is null ? throw new NullReferenceException($"Вопроса с таким Id не существует {nameof(SurveyService)}") : question.Adapt<QuestionDto>();
            }

            else
            {
                throw new ArgumentNullException($" Параметы {nameof(questionId)} метода  GetQuestionByIdAsync  не могут быть пустыми");
            }
        }
    }
}
