using SpeechTherapist.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core.Repository
{
    public interface IUsersRepository
    {
        public Task<Users> GetByUserNameAsync(string UserName, string Password);
        public Task<Users> GetByIdAsync(int id);
        public void AddUserAsync(Users user);
        public Task UpdateAsync(int id, Users users);
        public Task DeleteAsync(int id);
        public Task SaveAsync();
    }

}

