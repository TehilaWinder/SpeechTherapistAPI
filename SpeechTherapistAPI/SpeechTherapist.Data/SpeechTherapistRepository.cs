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
    public class SpeechTherapistRepository:ISpeechTherapistRpository
    {
        private readonly DataContext _context;
        public SpeechTherapistRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SpeechTerapist>> GetAllAsync()
        {
            return await _context.speechTerapists.ToListAsync();
        }
        public async Task<SpeechTerapist> GetByIdAsync(int id)
        {
            var p = await _context.speechTerapists.FirstOrDefaultAsync(x => x.SpeechTherapistCode == id);
            return p;
        }
        public void Add(SpeechTerapist speechTherapist)
        {

            _context.speechTerapists.Add(speechTherapist);
        }
        public async Task UpdateAsync(int id, SpeechTerapist speechTherapist)
        {
            var s = await GetByIdAsync(id);
            s.Email = speechTherapist.Email;
            s.IdNumber = speechTherapist.IdNumber;
            s.PhoneNumber = speechTherapist.PhoneNumber;
            s.Education=speechTherapist.Education;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var speechTherapist = await GetByIdAsync(id);
            _context.speechTerapists.Remove(speechTherapist);
        }

        public async Task<SpeechTerapist> GetByIdNumberAsync(string id)
        {
            var p = await _context.speechTerapists.FirstOrDefaultAsync(x => x.IdNumber == id);
            return p;
        }
    }
}
