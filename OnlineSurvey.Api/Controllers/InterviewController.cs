using Microsoft.AspNetCore.Mvc;
using OnlineSurvey.Application.Services.Abstraction;

namespace OnlineSurvey.Api.Controllers
{
    [Route("Interview")]
    [ApiController]
    internal class InterviewController : Controller
    {
        private readonly IInterviewService interviewService;

        public InterviewController(IInterviewService interviewService)
        {
            this.interviewService = interviewService;
        }


        /// <summary>
        /// Сохранет вопрос и ответы в бд и возвращает Id следующего вопроса
        /// </summary>
        /// <param name="questionId"> Id вопроса (Question)</param> 
        /// <param name="results"> Выбранные ответы</param> 
        /// <returns > Возвращает Следующий Id вопроса (Question) </returns>
        [Route("AddResult")]
        [HttpPost]
        public async Task<IActionResult> AddResultAsync(int questionId, List<string> results)
        {
            var sessionId = HttpContext.Session.GetString("sessionId");
            Console.WriteLine(sessionId);
            if (sessionId == null)
            {
                sessionId = HttpContext.Session.Id;
                HttpContext.Session.SetString("sessionId", sessionId);
                var nextQuestionId = await interviewService.AddAsync(sessionId, questionId, results);

                return Ok(nextQuestionId);
            }

            else
            {
                var nextQuestionId = await interviewService.UpdateAsync(sessionId, questionId, results);

                return Ok(nextQuestionId);
            }
        }
    }
}
