using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizal.models
{
    public class Achievement
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Requirement { get; set; }

        public string LogoUrl { get; set; }

        public int Points { get; set; }

        public List<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
    }
}
