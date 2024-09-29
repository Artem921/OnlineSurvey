namespace OnlineSurvey.Api.Models
{
    public class InterviewModel
    {
        public string Id { get; set; }
        public int SurveyId { get; set; } 
        public ResultModel Result { get; set; } = null!;   
    }
}
