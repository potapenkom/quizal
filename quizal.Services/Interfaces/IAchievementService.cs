using quizal.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace quizal.Services.Interfaces
{
    public interface IAchievementService
    {
        Task<IEnumerable<Achievement>> GetAllAchievements();

        Task<IEnumerable<UserAchievement>> GetAchievementsByUser(string username);

        Task GetRookieAchievement(QuizalUser user);

        Task GetHundrederAchievement(QuizalUser user);

        Task GetExcellentAchievement(QuizalUser user);

        Task GetMasterAchievement(QuizalUser user);

    }
}
