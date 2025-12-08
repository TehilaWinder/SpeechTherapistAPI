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
        public Patients GetByIdNumber(string id);
        public void Add(Patients patient);
        public void Update(int id,Patients patient);
        public void Delete(int id);
        public void Save();
    }
}
