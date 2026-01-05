using SpeechTherapist.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core.Repository
{
    public interface ITreatmentsRepository
    {
        public Task<IEnumerable<Treatments>> GetAllAsync();
        public Task<Treatments> GetByIdAsync(int id);
        public Task<Treatments> GetByNameAsync(string name);
        public void Add(Treatments treatments);
        public Task UpdateAsync(int id, Treatments treatments);
        public Task DeleteAsync(int id);
        public Task SaveAsync();

    }
}
