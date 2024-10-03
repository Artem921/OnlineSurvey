using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Infrastructure.Configurations
{
    internal class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions").HasKey(q => q.Id);
            builder.Property(q => q.Quaere).HasColumnName("Quaere");
            builder.HasIndex(q => q.Id).IsUnique();
            builder.HasOne(s => s.Survey)
                .WithMany(q => q.Questions)
                .HasForeignKey(q => q.SurveyId);

            builder.HasOne(a => a.Answer)
                .WithOne(q => q.Question)
                .HasForeignKey<Answer>(a=> a.QuestionId);

            builder.HasData(
                Question.Create(1, "Ваш любимый жанр"),
                Question.Create(2, "Выбирите двух актёров, которые вам симпатизируют из этого списка"),
                Question.Create(3, "В какое время суток вы смотрите фильм"),

                Question.Create(4, "Качество обслуживания"),
                Question.Create(5, "Решил ли он вашь вопрос"),
                Question.Create(6, "Оценка работы сотрудника")
                );
                

        }
    }

}
