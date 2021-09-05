using System;
using System.Collections.Generic;
using System.Text;

namespace quizal.Common.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        public string QuestionName { get; set; }

        public string FirstOption { get; set; }

        public string SecondOption { get; set; }

        public string ThirdOption { get; set; }

        public string FourthOption { get; set; }

        public string CorrectAnswer { get; set; }
    }
}
