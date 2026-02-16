using SpeechTherapist.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core.Service
{
    public interface IUsersService
    {
        public Task<Users> GetByUserNameAsync(string UserName, string Password);
        public Task<Users> AddUserAsync(Users user);
    }
}
