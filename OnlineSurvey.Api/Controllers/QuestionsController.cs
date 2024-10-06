using Microsoft.AspNetCore.Mvc;
using OnlineSurvey.Application.Services.Abstraction;

namespace OnlineSurvey.Api.Controllers
{
    [Route("Survey")]
    [ApiController]
    internal class QuestionsController : ControllerBase
    {
       private readonly  IQuestionService questionService;

        public QuestionsController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }
        /// <summary>
        /// Возвращает конкретный вопрос (Question) с вариантами ответов, конкретного опроса (Survey)
        /// </summary>
        /// <param name="questionId"> Id Вопроса. Принимает целочисленное значение.(Question)</param> 
        /// <param name="surveyId"> Id Опроса. Принимает целочисленное значение. (Survey)</param> 
        /// Пример запроса:
        /// 
        /// questionId = 1
        /// 
        [Route("GetQuestion/Search")]
        [HttpGet]
        public async Task<IActionResult> GetQuestionAsync(int surveyId,int questionId)
        {
            var question = await questionService.GetByIdAsync(surveyId,questionId);

            return Ok(question);
        }
    }
}
