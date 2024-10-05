using Microsoft.AspNetCore.Mvc;
using OnlineSurvey.Application.Services.Abstraction;

namespace OnlineSurvey.Api.Controllers
{
    [Route("Interview")]
    [ApiController]
    internal class InterviewsController : Controller
    {
        private readonly IInterviewService interviewService;

        public InterviewsController(IInterviewService interviewService)
        {
            this.interviewService = interviewService;
        }


        /// <summary>
        /// Принимает Id опроса, Id опроса.Сохранет вопрос и ответы в бд и возвращает Id следующего вопроса
        /// </summary>
        /// <param name="questionId"> Id вопроса (Question). Принимает целочисленное значение.</param> 
        /// <param name="surveyId"> Id опроса (Question). Принимает целочисленное значение.</param> 
        /// <param name="results"> Список выбраных ответов. </param> 
        /// <returns > Возвращает  Id следующего вопроса (Question) от определённого опроса (Survey) </returns>
        [Route("AddResult")]
        [HttpPost]
        public async Task<IActionResult> AddResultAsync(int surveyId,int questionId, List<string> results)
        {
            var interviewId = HttpContext.Session.GetString("sessionId");

            if (interviewId == null)
            {
                interviewId = HttpContext.Session.Id;
                HttpContext.Session.SetString("sessionId", interviewId);
                var nextQuestionId = await interviewService.AddAsync(interviewId, surveyId,questionId, results);

                return Ok(nextQuestionId);
            }

            else
            {
                var nextQuestionId = await interviewService.UpdateAsync(interviewId, surveyId, questionId, results);

                return Ok(nextQuestionId);
            }
        }
    }
}
