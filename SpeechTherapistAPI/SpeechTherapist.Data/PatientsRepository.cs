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
    public class PatientsRepository : IPatientRepository
    {
        private readonly DataContext _context;
        public PatientsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Patients>> GetAllAsync()
        {
            return await _context.patients.ToListAsync();
        }
        public async Task<Patients> GetByIdAsync(int id)
        {
             var p = await _context.patients.FirstOrDefaultAsync(x => x.PatientCode == id);
            return p;
        }
        public void Add(Patients patient)
        {

            _context.patients.Add(patient);
        }
        public async Task UpdateAsync(int id,Patients patient)
        {
            var p=await GetByIdAsync(id);
            p.FullName = patient.FullName;
            p.IdNumber = patient.IdNumber;
            p.PhoneNumber = patient.PhoneNumber;
            p.Email= patient.Email;
            p.Rport = patient.Rport;
            p.IsActive = patient.IsActive;
        }
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var patients = await GetByIdAsync(id);
            _context.patients.Remove(patients);
        }

        public async Task<Patients> GetByIdNumberAsync(string id)
        {
            var p = await _context.patients.FirstOrDefaultAsync(x => x.IdNumber == id);
            return p;
        }
    }
}
