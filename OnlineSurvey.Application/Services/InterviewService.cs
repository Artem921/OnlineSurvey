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

        public InterviewService(IInterviewRepository interviewRepository, 
                                ISurveyService surveyService)
        {
            this.interviewRepository = interviewRepository;
            this.surveyService = surveyService;
        }

        /// <summary>
        /// Сохраняет новый Interview в бд 
        /// </summary>
        /// <returns> возвращает Id следующего вопроса  </returns>
        public async Task<int> AddAsync(string interviewId,
                                        int surveyId, 
                                        int questionId,
                                        List<string> results)
        {
            var (interview, lastQuestionId) = await CreatInterview(interviewId, surveyId, questionId, results);

            await interviewRepository.AddAsync(interview.Adapt<Interview>());

            var nextQuestionId = questionId;

            if (nextQuestionId < lastQuestionId)
            {
                return nextQuestionId += 1;
            }
            else { return nextQuestionId; }
        }

        /// <summary>
        /// Вставляет новые данные Interview в бд
        /// </summary>
        /// <returns> возвращает Id последнего следующего вопроса  </returns>
        public async Task<int> UpdateAsync(string interviewId,
                                           int surveyId, 
                                           int questionId, 
                                           List<string> results)
        {
            var (interview, lastQuestionId) = await CreatInterview(interviewId, surveyId, questionId, results);

            await interviewRepository.UpdateAsync(interview.Adapt<Interview>());

            var nextQuestionId = questionId;

            if (nextQuestionId < lastQuestionId)
            {
                return nextQuestionId += 1;
            }
            else { return nextQuestionId; }
        }

        public async Task<(InterviewDto, int)> CreatInterview(string interviewId, int surveyId, int questionId, List<string> results)
        {
            var interview = new InterviewDto(interviewId);
            var result = new ResultDto(Guid.NewGuid(), interviewId, questionId, results);
            var survey = await surveyService.GetByIdAsync(surveyId);
            var lastQuestionId = await Task.Run(()=>survey.Questions.LastOrDefault().Id);
            interview.Results.Add(result);
            return (interview, lastQuestionId);

        }
    }
}
