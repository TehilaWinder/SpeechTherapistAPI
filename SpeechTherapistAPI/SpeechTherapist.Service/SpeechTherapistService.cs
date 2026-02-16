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
    public class SpeechTherapistService:ISpeechTherapistService
    {
        private readonly ISpeechTherapistRpository _speechTherapistRpository;
        public SpeechTherapistService(ISpeechTherapistRpository speechTherapistRpository)
        {
            _speechTherapistRpository = speechTherapistRpository;
        }
        public async Task<IEnumerable<SpeechTerapist>> GetAllAsync()
        {
            return await _speechTherapistRpository.GetAllAsync();
        }
        public async Task<SpeechTerapist> GetByIdAsync(int id)
        {
            return await _speechTherapistRpository.GetByIdAsync(id);
        }
        public async Task AddAsync(SpeechTerapist speechTherapist)
        {
            _speechTherapistRpository.Add(speechTherapist);
            await _speechTherapistRpository.SaveAsync();
        }

        public async Task UpdateAsync(int id, SpeechTerapist speechTherapist)
        {
            await _speechTherapistRpository.UpdateAsync(id, speechTherapist);
            await _speechTherapistRpository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _speechTherapistRpository.DeleteAsync(id);
            await _speechTherapistRpository.SaveAsync();
        }

        public async Task<SpeechTerapist> GetByIdNumberAsync(string id)
        {
            return await _speechTherapistRpository.GetByIdNumberAsync(id);
        }
    }
}

