using AutoMapper;
using quizal.Common.ViewModels;
using quizal.Common.ServiceModels;
using quizal.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace quizal.Common.Mapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            this.CreateMap<Quiz, CreateQuizBindingModel>().ReverseMap();
            this.CreateMap<Quiz, QuizViewModel>().ReverseMap();
            this.CreateMap<Quiz, AllQuizzesViewModel>().ReverseMap();
            this.CreateMap<Question, QuestionViewModel>().ReverseMap();
            this.CreateMap<Question, AddQuestionBindingModel>().ReverseMap();
            this.CreateMap<UserResult, UserResultViewModel>().ReverseMap();
            this.CreateMap<QuizServiceModel, QuizViewModel>().ReverseMap();
            this.CreateMap<AnswersServiceModel, AnswersBindingModel>().ReverseMap();
        }
    }
}
