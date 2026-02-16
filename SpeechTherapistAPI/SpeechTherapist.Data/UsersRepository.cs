using Microsoft.EntityFrameworkCore;
using SpeechTherapist.Core.Entities;
using SpeechTherapist.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Data
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _dataContext;
        public UsersRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Users> GetByUserNameAsync(string userName, string Password)
        {
            return await _dataContext.users.FirstOrDefaultAsync(u => u.UserName == userName && u.password == Password);
        }

        public async Task<Users> AddUserAsync(Users user)
        {
            await _dataContext.users.AddAsync(user);
            return user;
        }

    }
}
