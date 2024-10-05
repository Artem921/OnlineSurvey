using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Infrastructure.Configurations
{
    internal class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasIndex(q => q.Id).IsUnique();

            builder.HasOne(s => s.Survey)
                .WithMany(s => s.Questions)
                .HasForeignKey(s => s.SurveyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Answer)
                .WithOne(q => q.Question)
                .HasForeignKey<Answer>(a => a.QuestionId);

            builder.HasData(
                Question.Create(1,1, "Ваш любимый жанр"),
                Question.Create(2,1, "Выбирите двух актёров, которые вам симпатизируют из этого списка"),
                Question.Create(3,1, "В какое время суток вы смотрите фильм"),

                Question.Create(4,2, "Качество обслуживания"),
                Question.Create(5,2, "Решил ли он вашь вопрос"),
                Question.Create(6,2, "Оценка работы сотрудника")
                );
                

        }
    }

}
