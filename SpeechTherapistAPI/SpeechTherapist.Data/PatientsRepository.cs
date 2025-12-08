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
            return _context.patients.ToList();
        }
        public Patients GetById(int id)
        {
            var p = _context.patients.ToList().Find(x => x.PatientCode == id);
            return p;
        }
        public void Add(Patients patient)
        {

            _context.patients.Add(patient);
        }
        public void Update(int id,Patients patient)
        {
            var p= GetById(id);
            p.FullName = patient.FullName;
            p.IdNumber = patient.IdNumber;
            p.PhoneNumber = patient.PhoneNumber;
            p.Email= patient.Email;
            p.Rport = patient.Rport;
            p.IsActive = patient.IsActive;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.patients.Remove(GetById(id));
        }

        public Patients GetByIdNumber(string id)
        {
            var p = _context.patients.ToList().Find(x => x.IdNumber == id);
            return p;
        }
    }
}
