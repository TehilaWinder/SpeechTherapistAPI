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
        private readonly DataContext _context;
        public UsersRepository(DataContext context)
        {
            _context = context;
        }
        public void AddUserAsync(Users user)
        {
            _context.users.Add(user);
        }

        public async Task DeleteAsync(int id)
        {
            var users = await GetByIdAsync(id);
            _context.users.Remove(users);
        }

        public async Task<Users> GetByIdAsync(int id)
        {
            var u = await _context.users.FirstOrDefaultAsync(x => x.UserCode == id);
            return u;
        }

        public async Task<Users> GetByUserNameAsync(string UserName, string Password)
        {
            var u = await _context.users.FirstOrDefaultAsync(x => x.IdNumber == Password && x.FullName==UserName);
            return u;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Users users)
        {
            var u = await GetByIdAsync(id);
            u.Email = users.Email;
            u.FullName = users.FullName;
            u.PhoneNumber = users.PhoneNumber;
            u.IdNumber = users.IdNumber;
        }
    }
}
