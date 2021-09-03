using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizal.models
{
    public class UserAchievement
    {
        public string UserId { get; set; }

        public QuizalUser User { get; set; }

        public int AchievementId { get; set; }

        public Achievement Achievement { get; set; }

        public DateTime AchievedOn { get; set; }
    }
}
