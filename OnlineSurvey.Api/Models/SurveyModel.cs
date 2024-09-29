namespace OnlineSurvey.Api.Models
{
    public class SurveyModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Discription { get; set; } = string.Empty;
        public IEnumerable<QuestionModel> Questions { get; set; } = null!;
    }
}
