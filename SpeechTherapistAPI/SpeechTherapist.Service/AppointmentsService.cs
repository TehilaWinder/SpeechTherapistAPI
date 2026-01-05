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
        public async Task<IEnumerable<Appointments>> GetAllAsync()
        {
            return await _appointmentsRepository.GetAllAsync();
        }
        public async Task<Appointments> GetByIdAsync(int id)
        {
            return await _appointmentsRepository.GetByIdAsync(id);
        }
        public async Task AddAsync(Appointments appointments)
        {
            _appointmentsRepository.Add(appointments);
            await _appointmentsRepository.SaveAsync();
        }

        public async Task UpdateAsync(int id, Appointments appointments)
        {
           await _appointmentsRepository.UpdateAsync(id, appointments);
           await _appointmentsRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
           await _appointmentsRepository.DeleteAsync(id);
           await _appointmentsRepository.SaveAsync();
        }

        public async Task<Appointments> GetByDateAndHourAsync(DateTime DateAndHour)
        {
            return await _appointmentsRepository.GetByDateAndHourAsync(DateAndHour);
        }
    }
}
