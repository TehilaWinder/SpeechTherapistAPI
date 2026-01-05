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
    public class PatientService:IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<IEnumerable<Patients>> GetAllAsync() 
        { 
            return await _patientRepository.GetAllAsync(); 
        }
        public async Task<Patients> GetByIdAsync(int id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }
        public async Task AddAsync(Patients patient)
        {
            _patientRepository.Add(patient);
           await _patientRepository.SaveAsync();
        }

        public async Task UpdateAsync(int id, Patients patient)
        {
            await _patientRepository.UpdateAsync(id, patient);
            await _patientRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
           await _patientRepository.DeleteAsync(id);
           await _patientRepository.SaveAsync();
        }

        public async Task<Patients> GetByIdNumberAsync(string id)
        {
            return await _patientRepository.GetByIdNumberAsync(id);
        }
    }
}
