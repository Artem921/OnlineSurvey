using OnlineSurvey.Domian.Entities.Base;

namespace OnlineSurvey.Domian.Entities
{
    internal class Question: Entity
    {
        public int SurveyId { get; set; }
        public Survey Survey { get; set; } = null!;
        public string Quaere { get; set; } = null!;
        public Answer Answer { get; set; } = null!;
        public Result Result { get; set; } = null!;

        public Question() { }
        private Question(int id, string quaere)
        {
            Id = id;
            Quaere = quaere;
        }

        public static Question Create(int id, string quaere)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($" Свойство{nameof(Id)} класса {nameof(Question)} не может быть <= 0");
            }
            if (string.IsNullOrEmpty(quaere))
            {
                throw new NullReferenceException($"Свойство {nameof(Quaere)} класса {nameof(Question)} не может быть пустым");
            }

            return new Question(id, quaere);

        }
    }
}
