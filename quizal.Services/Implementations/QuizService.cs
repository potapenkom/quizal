using AutoMapper;
using quizal.Common.ServiceModels;
using quizal.data;
using quizal.models;
using quizal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizal.Services.Implementations
{
    public class QuizService : DataService, IQuizService
    {
        private readonly IMapper mapper;

        public QuizService(QuizalDbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }

        public async Task CreateQuiz(Quiz quiz)
        {
            await this.context.Quizzes.AddAsync(quiz);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteQuiz(int id)
        {
            var quiz = await this.context.Quizzes.Include(q => q.QuizQuestions).FirstOrDefaultAsync(q => q.Id == id);

            if (quiz == null)
            {
                return;
            }
            this.context.Quizzes.Remove(quiz);
            this.context.Questions.RemoveRange(quiz.QuizQuestions);
            await this.context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Quiz>> AllQuizzes()
        {
            var quizzes = await this.context.Quizzes.Include(q => q.QuizQuestions).ToListAsync();

            return quizzes;
        }

        public async Task<Quiz> GetQuizById(int id)
        {
            var quiz = await this.context.Quizzes
                .Include(q => q.QuizQuestions.OrderBy(q => Guid.NewGuid()).Take(10))
                .FirstOrDefaultAsync(q => q.Id == id);

            return quiz;
        }


        public async Task StartQuiz(QuizServiceModel model, string username)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            var quiz = await this.context.Quizzes.Include(q => q.QuizQuestions).FirstOrDefaultAsync(q => q.Id == model.Id);
            var questions = new List<Question>();
            foreach (var answer in model.Answers)
            {
                var question = await this.context.Questions.Where(q => q.Id == answer.QuestionId).FirstOrDefaultAsync();
                questions.Add(question);

            }

            if (user == null || quiz == null)
            {
                return;
            }

            var results = new UserResult();
            results.UserId = user.Id;
            results.User = user;
            results.QuizId = quiz.Id;
            results.Quiz = quiz;

            model.Result = results;

            for (int i = 0; i < questions.Count; i++)
            {
                var questionId = questions[i].Id;
                var correctAnswer = questions[i].CorrectAnswer;
                var currentAnswer = model.Answers.FirstOrDefault(x => x.QuestionId == questionId).Answer;

                var result = currentAnswer == correctAnswer ? model.Result.UsersCorrectAnswers++ : model.Result.UsersWrongAnswers++;
            }

            model.Result.PointsEarned = model.Result.UsersCorrectAnswers;
            user.TotalQuizPoints += model.Result.PointsEarned;

            await this.context.UserResults.AddAsync(model.Result);

            await this.context.SaveChangesAsync();
        }


        public Task<IEnumerable<QuizalUser>> GetUsersByTotalPoints()
        {
            throw new NotImplementedException();
        }
    }
}
