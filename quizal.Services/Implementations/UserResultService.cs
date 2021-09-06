using AutoMapper;
using Microsoft.EntityFrameworkCore;
using quizal.data;
using quizal.models;
using quizal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizal.Services.Implementations
{
    public class UserResultService : DataService, IUserResultService
    {
        private readonly IMapper mapper;

        public UserResultService(QuizalDbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }

        public async Task<UserResult> GetUserResultById(int id, string username)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            var userResult = await this.context.UserResults.Include(q => q.Quiz).FirstOrDefaultAsync(ur => ur.Id == id);

            return userResult;
        }

        public async Task<IEnumerable<UserResult>> GetAllUserResultsByUser(string username)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            var userResults = await this.context.UserResults
                .Where(x => x.UserId == user.Id)
                .Include(x => x.Quiz)
                .OrderByDescending(x => x)
                .ToListAsync();

            return userResults;
        }
    }
}
