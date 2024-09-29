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
