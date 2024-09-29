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

        public InterviewService(IInterviewRepository interviewRepository)
        {
            this.interviewRepository = interviewRepository;
        }

        public async Task AddAsync(InterviewDto interview)
        {
            await interviewRepository.AddAsync(interview.Adapt<Interview>());
        }

        public async Task DeleteAsync(string id)
        {
            var interview = await GetByIdAsync(id);

            await interviewRepository.DeleteAsync(interview.Adapt<Interview>());                 
        }

        public async Task<List<Interview>?> GetAllAsync()
        {
            return await interviewRepository.GetAllAsync();
        }

        public async Task<InterviewDto?> GetByIdAsync(string id)
        {
            var interview = await interviewRepository.GetByIdAsync(id);

            return  interview.Adapt<InterviewDto>();
        }

        public async Task UpdateAsync(string interviewId, int questionId, string quaere, List<string> results)
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
        }
    }
}
