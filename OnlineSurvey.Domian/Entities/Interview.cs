using OnlineSurvey.Domian.Entities.Base;

namespace OnlineSurvey.Domian.Entities
{
    internal class Interview
    {
        public string Id { get; set; } = string.Empty;
        public string SurveyId { get; set; } = string.Empty;
        public List<Result> Results { get; set; } 

        public Interview() { }
        private Interview(string id) 
        {         
            Id = id;
            Results = new List<Result>();
        }

        public static Interview Create(string id) 
        {
            if (string.IsNullOrEmpty(id)) { throw new ArgumentNullException($" Свойство{nameof(Id)} класса {nameof(Interview)} не может быть пустым"); }

            return new Interview(id);

        }
    }
}
