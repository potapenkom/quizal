using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using quizal.models;


namespace quizal.data
{
    public class QuizalDbContext : IdentityDbContext<QuizalUser>
    {
        public QuizalDbContext(DbContextOptions<QuizalDbContext> options)
            : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }


        public DbSet<Quiz> Quizzes { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<QuizalUser> UserResults { get; set; }

        public DbSet<QuizalUser> UserAchievement { get; set; }

    }
}
