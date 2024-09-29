using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Infrastructure.Configurations
{
    internal class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answers").HasKey(a => a.Id);
            builder.Property(q => q.Replys).HasColumnName("Replys");

            builder.HasData(
                Answer.Create(
                    1,
                    1,
                    new List<string> { "Детектив", "Фантастика", "Ужасы", "Драма", "Комедия", "Боевик" }),

               Answer.Create(
                    2,
                    2,
                    new List<string> { "Леонардо Ди Каприо", "Бред Пит", "Том Круз", "Аль Пачино", "Скот Аткинс" }),
               Answer.Create(
                    3,
                    3,
                    new List<string> { "Утром", "Днём", "Вечером" }),
               Answer.Create(
                    4,
                    4,
                    new List<string> { "Плохое", "Хорошее", "Отличное" }),

               Answer.Create(
                    5,
                    5,
                    new List<string> { "Да", "Нет", "Частично" }),
               Answer.Create(
                    6,
                    6,
                    new List<string> { "1", "2", "3", "4", "5" })
                );

        }
    }
}
