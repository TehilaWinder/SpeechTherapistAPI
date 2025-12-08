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
    public class AppointmentsService:IAppointmentService
    {
        private readonly IAppointmentsRepository _appointmentsRepository;
        public AppointmentsService(IAppointmentsRepository appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }
        public List<Appointments> GetAll()
        {
            return _appointmentsRepository.GetAll();
        }
        public Appointments GetById(int id)
        {
            return _appointmentsRepository.GetById(id);
        }
        public void Add(Appointments appointments)
        {
            _appointmentsRepository.Add(appointments);
            _appointmentsRepository.Save();
        }

        public void Update(int id, Appointments appointments)
        {
            _appointmentsRepository.Update(id, appointments);
            _appointmentsRepository.Save();
        }

        public void Delete(int id)
        {
            _appointmentsRepository.Delete(id);
            _appointmentsRepository.Save();
        }

        public Appointments GetByDateAndHour(DateTime DateAndHour)
        {
            return _appointmentsRepository.GetByDateAndHour(DateAndHour);
        }
    }
}
