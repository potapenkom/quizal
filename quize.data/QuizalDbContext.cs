using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using quizal.models;


namespace quizal.data
{
    public class QuizalDbContext : IdentityDbContext<QuizalUser>
    {
        public QuizalDbContext(DbContextOptions<QuizalDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserAchievement>()
                .HasKey(ua => new { ua.UserId, ua.AchievementId });
            base.OnModelCreating(builder);
        }


        public DbSet<Quiz> Quizzes { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<UserResult> UserResults { get; set; }

        public DbSet<QuestionSuggestion> QuestionSuggestions { get; set; }

        public DbSet<Achievement> Achievements { get; set; }

        public DbSet<UserAchievement> UserAchievements { get; set; }

    }
}
