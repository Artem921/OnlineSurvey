using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Application.DTOs
{
    internal class SurveyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IEnumerable<QuestionDto> Questions { get; set; } = null!;
        public ICollection<InterviewDto> Interviews { get; set; } = null!;
    }
}
