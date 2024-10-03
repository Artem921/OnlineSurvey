using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Application.DTOs
{
    internal class InterviewDto
    {
        public string Id { get; set; } = string.Empty;
        public ICollection<ResultDto> Results { get; set; } = null!;
        public ICollection<SurveyDto> Surveys { get; set; } = null!;

        public InterviewDto() { }
        public InterviewDto(string id)
        {
            Id = id;
            Results = new List<ResultDto>();
            Surveys = new List<SurveyDto>();
        }

    }
}
