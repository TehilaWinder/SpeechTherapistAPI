using SpeechTherapist.Core.Entities;
using SpeechTherapist.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Data
{
    public class PatientsRepository : IPatientRepository
    {
        private readonly DataContext _context;
        public PatientsRepository(DataContext context)
        {
            _context = context;
        }
        public List<Patients> GetAll()
        {
            return _context.patients;
        }
        public Patients GetById(int id)
        {
            var p = _context.patients.Find(x => x.PatientCode == id);
            return p;
        }
        public void Add(Patients patient)
        {

            _context.patients.Add(patient);
        }
    }
}
