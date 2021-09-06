using quizal.Common.ServiceModels;
using quizal.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace quizal.Services.Interfaces
{
    public interface IQuizService
    {
        Task CreateQuiz(Quiz quiz);

        Task DeleteQuiz(int id);

        Task<IEnumerable<Quiz>> AllQuizzes();

        Task<Quiz> GetQuizById(int id);

        Task StartQuiz(QuizServiceModel model, string username);

    }
}
