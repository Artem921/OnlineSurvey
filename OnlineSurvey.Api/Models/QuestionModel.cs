namespace OnlineSurvey.Api.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public int NumberOfAnswers { get; set; }
        public string Quaere { get; set; } = null!;
        public AnswerModel Answer { get; set; } = null!;
    }
}
