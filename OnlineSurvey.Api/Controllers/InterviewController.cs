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

        [Route("AddResult")]
        [HttpPost]
        public async Task<IActionResult> AddResultAsync(int questionId, string quaere, List<string> results)
        {
            var sessionId = HttpContext.Session.GetString("sessionId");

            if (sessionId == null)
            {
                sessionId = HttpContext.Session.Id;
                HttpContext.Session.SetString("sessionId", sessionId);
            }

            await interviewService.UpdateAsync(sessionId, questionId, quaere, results);
          
            return Ok();
                
         }

        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var t =await interviewService.GetAllAsync();

            return Ok(t);
        }
    }
}
