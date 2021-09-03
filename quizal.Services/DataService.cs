using quizal.data;
using System;

namespace quizal.Services
{
    public class DataService
    {
        protected readonly QuizalDbContext context;

        public DataService(QuizalDbContext context)
        {
            this.context = context;
        }
    }
}
