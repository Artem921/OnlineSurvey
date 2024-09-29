namespace OnlineSurvey.Api.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public string QuestionId { get; set; } = string.Empty;
        public IEnumerable<string> Replys { get; set; }
    }
}
