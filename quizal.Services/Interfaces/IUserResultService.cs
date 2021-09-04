using System;
using System.Collections.Generic;
using quizal.models;
using System.Text;
using System.Threading.Tasks;

namespace quizal.Services.Interfaces
{
    public interface IUserResultService
    {
        Task<UserResult> GetUserResultById(int id, string username);

        Task<IEnumerable<UserResult>> GetAllUserResultsByUser(string username);
    }
}
