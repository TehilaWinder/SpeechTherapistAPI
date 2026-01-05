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
    public class TreatmentService:ITreatmentsServie
    {
        private readonly ITreatmentsRepository _treatmentsRepository;
        public TreatmentService( ITreatmentsRepository treatmentsRepository)
        {
            _treatmentsRepository = treatmentsRepository;
        }
        public async Task<IEnumerable<Treatments>> GetAllAsync()
        {
            return await _treatmentsRepository.GetAllAsync();
        }
        public async Task<Treatments> GetByIdAsync(int id) {
            return await _treatmentsRepository.GetByIdAsync(id);
        }
        public async Task AddAsync(Treatments treatment)
        {
            _treatmentsRepository.Add(treatment);
            await _treatmentsRepository.SaveAsync();
        }

        public async Task UpdateAsync(int id, Treatments treatments)
        {
            await _treatmentsRepository.UpdateAsync(id, treatments);
            await _treatmentsRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _treatmentsRepository.DeleteAsync(id);
            await _treatmentsRepository.SaveAsync();
        }

        public Task<Treatments> GetByNameAsync(string name)
        {
            return _treatmentsRepository.GetByNameAsync(name);
        }
    }
}
