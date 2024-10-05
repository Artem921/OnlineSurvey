using OnlineSurvey.Domian.Entities.Base;

namespace OnlineSurvey.Domian.Entities
{
    internal class Survey : Entity
    {
        /// <summary>
        /// Наименование опроса
        /// </summary>
        public string? Name { get; set; } 
        /// <summary>
        /// описание опроса
        /// </summary>
        public string? Description { get; set; }
        public List<Question> Questions { get; set; } = null!;
        public Survey() { }
        private Survey(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
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
