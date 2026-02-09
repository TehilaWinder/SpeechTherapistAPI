using SpeechTherapist.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core.Service
{
    public interface ISpeechTherapistService
    {
        public Task<IEnumerable<SpeechTerapist>> GetAllAsync();
        public Task<SpeechTerapist> GetByIdAsync(int id);
        public Task<SpeechTerapist> GetByIdNumberAsync(string id);
        public Task AddAsync(SpeechTerapist speechTherapist);
        public Task UpdateAsync(int id, SpeechTerapist speechTherapist);
        public Task DeleteAsync(int id);
        
    }
}
