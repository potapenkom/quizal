using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizal.models
{
    public class QuizalUser : IdentityUser
    {
        public string Name { get; set; }

        public int TotalQuizPoints { get; set; }

        public int TotalAchievementPoints { get; set; }

        public List<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
    }
}
