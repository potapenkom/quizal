using System;
using System.Collections.Generic;
using System.Text;

namespace quizal.models
{
    public class UserResult
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public QuizalUser User { get; set; }

        public int QuizId { get; set; }

        public Quiz Quiz { get; set; }

        public int UsersCorrectAnswers { get; set; }

        public int UsersWrongAnswers { get; set; }

        public int PointsEarned { get; set; }
    }
}
