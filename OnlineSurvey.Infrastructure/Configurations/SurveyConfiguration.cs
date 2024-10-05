using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Infrastructure.Configurations
{
    internal class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {         
            builder.HasData(
                Survey.Create(1, "Фильмы", "Анонимный опрос для статистики "),
                Survey.Create(2, "Оценка качества работы сотрудника", "Анонимный опрос для улучшение качества "));
        }
    }
}
