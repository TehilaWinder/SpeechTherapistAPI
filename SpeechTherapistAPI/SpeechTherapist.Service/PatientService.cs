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
        public List<Patients> GetAll() 
        { 
            return _patientRepository.GetAll(); 
        }
        public Patients GetById(int id)
        {
            return _patientRepository.GetById(id);
        }
        public void Add(Patients patient)
        {
            _patientRepository.Add(patient);
            _patientRepository.Save();
        }
    }
}
