using Microsoft.EntityFrameworkCore;
using SpeechTherapist.Core.Entities;
using SpeechTherapist.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Data
{
    public class AppointmentRepository: IAppointmentsRepository
    {
        private readonly DataContext _context;
        public AppointmentRepository(DataContext context) { 
            _context = context;
        }
        public List<Appointments> GetAll()
        {
            return _context.appointments.Include(a=>a.Patients).Include(a => a.Treatments).ToList();
        }
        public Appointments GetById(int id)
        {
            var a = _context.appointments.ToList().Find(x => x.AppointmentCode == id);
            return a;
        }
        public void Add(Appointments appointments)
        {
            _context.appointments.Add(appointments);
        }

        public void Update(int id,Appointments appointments)
        {
            var a = GetById(id);
            a.DateAndHour=appointments.DateAndHour;
            a.Status=appointments.Status;
            a.Patients=appointments.Patients;
            a.Treatments=appointments.Treatments;
        }

        public void Delete(int id)
        {
            _context.appointments.Remove(GetById(id));
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
