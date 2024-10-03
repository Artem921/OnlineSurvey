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
        private readonly IQuestionService questionService;

        public InterviewService(IInterviewRepository interviewRepository, ISurveyService surveyService, IQuestionService questionService)
        {
            this.interviewRepository = interviewRepository;
            this.questionService = questionService;
            this.surveyService = surveyService;
        }

        /// <summary>
        /// Сохраняет новый Interview в бд и возвращает 
        /// </summary>
        /// 
        public async Task<int> AddAsync(string interviewId, int questionId, List<string> results)
        {
            var (interview, id) = await InsertInterview(interviewId, questionId, results);

            await interviewRepository.AddAsync(interview.Adapt<Interview>());


            if (questionId < id)
            {
                return questionId += 1;
            }
            else { return questionId; }
        }

        /// <summary>
        /// Вставляет новые данные Interview в бд
        /// </summary>
        /// 
        public async Task<int> UpdateAsync(string interviewId, int questionId, List<string> results)
        {
            var (interview, id) = await InsertInterview(interviewId, questionId, results);

            await interviewRepository.UpdateAsync(interview.Adapt<Interview>());
            if (questionId < id)
            {
                return questionId += 1;
            }
            else { return questionId; }
        }

        public async Task<(InterviewDto, int)> InsertInterview(string interviewId, int questionId, List<string> results)
        {
            var interview = new InterviewDto(interviewId);
            var result = new ResultDto(Guid.NewGuid(), results);
            result.QuestionId = questionId;
            var question = await questionService.GetByIdAsync(questionId);
            var survey = await surveyService.GetByIdAsync(question.Survey.Id);
            interview.Results.Add(result);
            interview.Surveys.Add(survey.Adapt<SurveyDto>());
            return (interview, survey.Questions.Last().Id);
        }
    }
}
