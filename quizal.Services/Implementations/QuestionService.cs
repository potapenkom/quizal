using quizal.data;
using quizal.models;
using quizal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace quizal.Services.Implementations
{
    public class QuestionService : DataService, IQuestionService
    {
        public QuestionService(QuizalDbContext context) : base(context)
        {

        }

        public async Task AddQuestion(Question question)
        {
            if (question.CorrectAnswer == question.FirstOption || question.CorrectAnswer == question.SecondOption ||
                question.CorrectAnswer == question.ThirdOption || question.CorrectAnswer == question.FourthOption)
            {
                await this.context.Questions.AddAsync(question);
            }
            else
            {
                return;
            }

            await this.context.SaveChangesAsync();

        }
    }
}
