using SpeechTherapist.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core.Repository
{
    public interface IPatientRepository
    {
        public List<Patients> GetAll();
        public Patients GetById(int id);
        public bool Add(Patients patient);
    }
}
