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
            return _context.appointments;
        }
        public Appointments GetById(int id)
        {
            var a = _context.appointments.Find(x => x.AppointmentCode == id);
            return a;
        }
        public void Add(Appointments appointments)
        {
            _context.appointments.Add(appointments);
        }
    }
}
