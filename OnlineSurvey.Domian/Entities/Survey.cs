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
        public string Discription { get; set; } = string.Empty;
        public IEnumerable<Question> Questions { get; set; } = null!;

        public Survey() { }
        private Survey(int id,string name,string discription)
        {
           Id = id;
           Name = name;
           Discription = discription;        
        }   
        
        public static Survey Create(int id,string name,string discription) 
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($" Свойство{nameof(Id)} класса {nameof(Survey)} не может быть <= 0");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new NullReferenceException($"Свойство{nameof(Name)} класса  {nameof(Survey)} не может быть пустым");
            }

            if (string.IsNullOrEmpty(discription))
            {
                throw new NullReferenceException($"Свойство{nameof(Discription)} класса  {nameof(Survey)} не может быть пустым");
            }
            return new Survey(id,name,discription);
        }
    }
}
