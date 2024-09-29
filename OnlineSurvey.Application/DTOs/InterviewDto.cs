using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Application.DTOs
{
    internal class InterviewDto
    {
        public string Id { get; set; }
        public ICollection<ResultDto> Results { get; set; } = null!;

    }
}
