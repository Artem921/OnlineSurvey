using OnlineSurvey.Domian.Entities.Base;

namespace OnlineSurvey.Domian.Entities
{
    internal class Survey : Entity
    {
        /// <summary>
        /// Наименование опроса
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// описание опроса
        /// </summary>
        public string Description { get; set; } = string.Empty;
        public ICollection<Question> Questions { get; set; } = null!;
        public ICollection<Interview> Interviews { get; set; } = null!;

        public Survey() { }
        private Survey(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            Questions = new List<Question>();
            Interviews = new List<Interview>();
        }

        public static Survey Create(int id, string name, string description)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($" Свойство{nameof(Id)} класса {nameof(Survey)} не может быть <= 0");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new NullReferenceException($"Свойство{nameof(Name)} класса  {nameof(Survey)} не может быть пустым");
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new NullReferenceException($"Свойство{nameof(Description)} класса  {nameof(Survey)} не может быть пустым");
            }
            return new Survey(id, name, description);
        }
    }
}
