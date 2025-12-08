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
        public List<Treatments> GetAll()
        {
            return _treatmentsRepository.GetAll();
        }
        public Treatments GetById(int id) {
            return _treatmentsRepository.GetById(id);
        }
        public void Add(Treatments treatment)
        {
            _treatmentsRepository.Add(treatment);
            _treatmentsRepository.Save();
        }

        public void Update(int id, Treatments treatments)
        {
            _treatmentsRepository.Update(id, treatments);
            _treatmentsRepository.Save();
        }

        public void Delete(int id)
        {
            _treatmentsRepository.Delete(id);
            _treatmentsRepository.Save();
        }

        public Treatments GetByName(string name)
        {
            return _treatmentsRepository.GetByName(name);
        }
    }
}
