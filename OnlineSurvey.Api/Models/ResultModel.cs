namespace OnlineSurvey.Api.Models
{
    public class ResultModel
    {
        public int Id { get; set; }
        public Dictionary<string, List<string>> Results { get; set; }
        public ResultModel() 
        { 
            Results = new Dictionary<string, List<string>>();
        }
    }
}
