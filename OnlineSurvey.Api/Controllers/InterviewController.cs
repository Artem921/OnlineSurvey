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
        /// <param name="questionId">Id вопроса (Question)</param> 
        /// <param name="surveyId">Id опросника (Survey)</param> 
        /// <param name="quaere">Текст вопроса</param> 
        /// <param name="results">Выбранные ответы</param> 
        /// <returns name ="quenceId">Следующий Id вопроса (Question) </returns>
        [Route("AddResult")]
        [HttpPost]
        public async Task<IActionResult> AddResultAsync(int questionId,int surveyId, string quaere, List<string> results)
        {
            var sessionId = HttpContext.Session.GetString("sessionId");

            if (sessionId == null)
            {     
                sessionId = HttpContext.Session.Id;
                HttpContext.Session.SetString("sessionId", sessionId);
            }

            var quenceId =await interviewService.UpdateAsync(sessionId, surveyId, questionId, quaere, results);
          
            return Ok(quenceId);
                
         }
    }
}
