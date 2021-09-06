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
    public class UserService : DataService, IUserService
    {
        public UserService(QuizalDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<QuizalUser>> GetUsersByTotalPoints()
        {
            var users = await this.context.Users
                .OrderByDescending(u => u.TotalQuizPoints)
                .ThenByDescending(u => u.TotalAchievementPoints)
                .ToListAsync();

            return users;
        }

    }
}
