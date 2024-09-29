using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Infrastructure.Configurations
{
    internal class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.ToTable("Surveys").HasKey(s => s.Id);
            builder.Property(s => s.Discription).HasColumnName("Discription");
            builder.Property(s => s.Name).HasColumnName("Name");

            builder.HasMany(s => s.Questions)
                .WithOne(q => q.Survey)
                .HasForeignKey(q => q.SurveyId)
                .OnDelete(DeleteBehavior.Cascade);

            //builder.HasData(
            //    Survey.Create("1", "Фильмы", "Анонимный опрос для статистики "),
            //    Survey.Create("2", "Оценка качества работы сотрудника", "Анонимный опрос для улучшение качества ")
            //    );
        }
    }
}
