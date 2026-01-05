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
    public class TreatmentRepository : ITreatmentsRepository
    {
        private readonly DataContext _context;
        public TreatmentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Treatments>> GetAllAsync()
        {
            return await _context.treatments.ToListAsync();
        }
        public async Task<Treatments> GetByIdAsync(int id)
        {
            var t = await _context.treatments.FirstOrDefaultAsync(x => x.TreatmentCode == id);
            return t;
        }
        public void Add(Treatments treatment)
        {
            _context.treatments.Add(treatment);
        }
        
        public async Task UpdateAsync(int id,Treatments treatments)
        {
            var t= await GetByIdAsync(id);
            t.TreatmentName = treatments.TreatmentName;
            t.DurationMinutes = treatments.DurationMinutes;
        }

        public async Task DeleteAsync(int id)
        {
            var treatment = await GetByIdAsync(id);
            _context.treatments.Remove(treatment);    
        }
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

        public async Task<Treatments> GetByNameAsync(string name)
        {
            var t = await _context.treatments.FirstOrDefaultAsync(x => x.TreatmentName == name);
            return t;
        }
    }
}
