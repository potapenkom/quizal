using Microsoft.EntityFrameworkCore;
using quizal.data;
using quizal.models;
using quizal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizal.Services.Implementations
{
    public class AchievementService : DataService, IAchievementService
    {
        public AchievementService(QuizalDbContext context) : base(context)
        {  
        }

        public async Task<IEnumerable<Achievement>> GetAllAchievements()
        {
            return await this.context.Achievements.ToListAsync();
        }

        public async Task<IEnumerable<UserAchievement>> GetAchievementsByUser(string username)
        {
            return await this.context.UserAchievements
                .Where(x => x.User.UserName.Equals(username))
                .Include(x => x.Achievement)
                .OrderByDescending(x => x.AchievedOn)
                .ToListAsync();
        }

    }
}
