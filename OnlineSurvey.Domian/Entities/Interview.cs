namespace OnlineSurvey.Domian.Entities
{
    internal class Interview
    {
        public string? Id { get; set; }
        public List<Result> Results { get; set; } = null!;
        public Interview() { }
        private Interview(string id)
        {
            Id = id;
        }

        public static Interview Create(string id)
        {
            if (string.IsNullOrEmpty(id)) { throw new ArgumentNullException($" Свойство{nameof(Id)} класса {nameof(Interview)} не может быть пустым"); }

            return new Interview(id);

        }
    }
}
