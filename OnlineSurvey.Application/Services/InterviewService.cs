using Mapster;
using OnlineSurvey.Application.DTOs;
using OnlineSurvey.Application.Services.Abstraction;
using OnlineSurvey.Domian.Abstraction;
using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Application.Services
{
    internal class InterviewService : IInterviewService
    {
        private readonly IInterviewRepository interviewRepository;
        private readonly ISurveyService surveyService;

        public InterviewService(IInterviewRepository interviewRepository, ISurveyService surveyService)
        {
            this.interviewRepository = interviewRepository;
            this.surveyService = surveyService;
        }

        /// <summary>
        /// Сохраняет новый Interview в бд
        /// </summary>
        public async Task AddAsync(InterviewDto interview)
        {
            await interviewRepository.AddAsync(interview.Adapt<Interview>());
        }

        public async Task<InterviewDto?> GetByIdAsync(string id)
        {
            var interview = await interviewRepository.GetByIdAsync(id);

            return  interview.Adapt<InterviewDto>();
        }

        /// <summary>
        /// Обновляет Interview
        /// </summary>
        public async Task<int> UpdateAsync( string interviewId, int surveyId, int questionId, string quaere, List<string> results)
        {          
            var interview = await GetByIdAsync(interviewId);

            if (interview == null)
            {
                interview = new InterviewDto();
                interview.Id = interviewId;
                interview.Results = new List<ResultDto>();
                var result = new ResultDto();
                result.Id = questionId;
                result.Results.Add(quaere, results);
                interview.Results.Add(result);
                await AddAsync(interview);

            }
            else
            {
                var result = new ResultDto();
                result.Id = questionId;
                result.Results.Add(quaere, results);
                interview.Results.Add(result);
                await interviewRepository.UpdateAsync(interview.Adapt<Interview>());
            }

            var survey = await surveyService.GetSurveyByIdAsync(surveyId);

            if(questionId < survey.Questions.Last().Id)
            {
                return questionId += 1;
            }
            else { return questionId; }
        }
    }
}
