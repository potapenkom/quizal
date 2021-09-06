using quizal.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace quizal.Services.Interfaces
{
    public interface IQuestionService
    {
        Task AddQuestion(Question question);
    }
}
