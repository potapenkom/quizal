using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quizal.Common.ServiceModels;
using quizal.Common.ViewModels;
using quizal.models;
using quizal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quizal.Web.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {

        private readonly IQuizService quizService;
        private readonly IMapper mapper;

    
        public QuizController(IQuizService quizService, IMapper mapper)
        {
            this.quizService = quizService;
            this.mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public IActionResult CreateQuiz()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz(CreateQuizBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var quiz = mapper.Map<Quiz>(model);

            await this.quizService.CreateQuiz(quiz);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DeleteQuiz(int id)
        {
            await this.quizService.DeleteQuiz(id);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> StartQuiz(int id)
        {
            var getQuiz = await this.quizService.GetQuizById(id);

            var quiz = mapper.Map<QuizViewModel>(getQuiz);

            if (quiz == null)
            {
                return NotFound();
            }

            return this.View(quiz);
        }

        [HttpPost]
        public async Task<IActionResult> StartQuiz(QuizViewModel model)
        {
            var quiz = mapper.Map<QuizServiceModel>(model);

            await this.quizService.StartQuiz(quiz, this.User.Identity.Name);

            return RedirectToAction("Result", "UserResult", new { id = quiz.Result.Id });
        }
    }
}
