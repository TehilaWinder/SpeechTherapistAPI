using SpeechTherapist.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core.Service
{
    public interface IPatientService
    {
        public Task<IEnumerable<Patients>> GetAllAsync();
        public Task<Patients> GetByIdAsync(int id);
        public Task<Patients> GetByIdNumberAsync(string id);
        public Task AddAsync(Patients patient);
        public Task UpdateAsync(int id, Patients patient);
        public Task DeleteAsync(int id);
    }
}
