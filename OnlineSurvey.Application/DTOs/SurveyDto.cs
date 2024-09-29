using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Application.DTOs
{
    internal class SurveyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Discription { get; set; } = string.Empty;
        public IEnumerable<QuestionDto> Questions { get; set; } = null!;
    }
}
