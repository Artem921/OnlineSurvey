using Mapster;
using Microsoft.AspNetCore.Mvc;
using OnlineSurvey.Api.Models;
using OnlineSurvey.Application.Services.Abstraction;

namespace OnlineSurvey.Api.Controllers
{
    [Route("Survey")]
    [ApiController]
    internal class SurveyController : ControllerBase
    {
       private readonly ISurveyService surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            this.surveyService = surveyService;
        }
        /// <summary>
        /// Возвращает конкретный вопрос с вариантами ответов
        /// </summary>
        /// <param name="surveyId">Id опросника (Survey)</param> 
        /// <param name="questionId">Id вопроса (Question)</param> 
        /// 
        /// Пример запроса:
        /// 
        /// questionId = 1
        /// surveyId = 1
        /// 
        /// <returns name="questionModel">Возвращает QuestionModel</returns>
        [Route("GetQuestion")]
        [HttpGet]
        public async Task<IActionResult>GetQuestionAsync(int surveyId,int questionId)
        {
            var questionDto = await surveyService.GetQuestionByIdAsync(surveyId,questionId);

            var questionModel = questionDto.Adapt<QuestionModel>();

            return Ok(questionModel);
        }
    }
}
