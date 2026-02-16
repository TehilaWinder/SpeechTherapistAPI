using SpeechTherapist.Core.Entities;
using SpeechTherapist.Core.Repository;
using SpeechTherapist.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Service
{
    public class UsersService:IUsersService
    {
        private readonly IUsersRepository _userRepository;
        public UsersService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Users> GetByUserNameAsync(string userName, string Password)
        {
            return await _userRepository.GetByUserNameAsync(userName, Password);
        }
        public async Task<Users> AddUserAsync(Users user)
        {
            return await _userRepository.AddUserAsync(user);
        }

    }
}
