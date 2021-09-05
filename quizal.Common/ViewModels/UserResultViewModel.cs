using quizal.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace quizal.Common.ViewModels
{
    public class UserResultViewModel
    {
        public QuizalUser User { get; set; }

        public Quiz Quiz { get; set; }

        public int UsersCorrectAnswers { get; set; }

        public int UsersWrongAnswers { get; set; }

        public int PointsEarned { get; set; }
    }
}
