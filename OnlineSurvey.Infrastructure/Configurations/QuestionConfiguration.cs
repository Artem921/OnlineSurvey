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

            builder.HasOne(s => s.Survey)
                .WithMany(q => q.Questions)
                .HasForeignKey(q => q.SurveyId);

            builder.HasOne(a => a.Answer)
                .WithOne(q => q.Question)
                .HasForeignKey<Answer>(a=> a.QuestionId);

            //builder.HasData(
            //    Question.Create("1", "1", "Ваш любимый жанр",1),
            //    Question.Create("2", "1", "Выбирите двух актёров, которые вам симпатизируют из этого списка", 2),
            //    Question.Create("3", "1", "В какое время суток вы смотрите фильм",3),

            //    Question.Create("4", "2", "Качество обслуживания",1),
            //    Question.Create("5", "2", "Решил ли он вашь вопрос",1),
            //    Question.Create("6", "2", "Оценка работы сотрудника",1)
            //    );
                

        }
    }

}
