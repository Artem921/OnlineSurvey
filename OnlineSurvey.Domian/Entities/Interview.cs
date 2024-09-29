namespace OnlineSurvey.Domian.Entities
{
    internal class Interview
    {
        public string Id { get; set; } = string.Empty;
        public ICollection<Result> Results { get; set; } = null!;

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
