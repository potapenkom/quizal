using quizal.models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizal.models
{
    public class Quiz
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }

        public List<Question> QuizQuestions { get; set; } = new List<Question>();

        public string QuizLogoUrl { get; set; }
    }
}
