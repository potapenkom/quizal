using quizal.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace quizal.Common.ViewModels
{
    public class MyAchievementsViewModel
    {
        public string UserId { get; set; }

        public QuizalUser User { get; set; }

        public int AchievementId { get; set; }

        public Achievement Achievement { get; set; }

        public DateTime AchievedOn { get; set; }
    }
}
