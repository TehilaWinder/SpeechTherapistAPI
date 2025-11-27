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
        public List<Patients> GetAll();
        public Patients GetById(int id);
        public void Add(Patients patient);
        public void Update(int id,Patients patient);
        public void Delete(int id);
    }
}
