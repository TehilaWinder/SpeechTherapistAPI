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
    public class AppointmentsService : IAppointmentService
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
        public async Task<bool> PreventingDuplicateQueues(Appointments appointments)
        {
            var app = await _appointmentsRepository.GetAllAsync();
            var a = app.FirstOrDefault(a => a.DateAndHour == appointments.DateAndHour);
            if (a != null)
                return false;
            return true;
        }
        public bool QueueStatusCheck(Appointments appointments)
        {

            return appointments.Status == eStatus.Cancelled || appointments.Status == eStatus.Confirmed;
        }
        public bool CheckIsValid(Appointments appointments)
        {
            TimeSpan timeDifference = appointments.DateAndHour - DateTime.Now;

            return timeDifference.TotalHours >= 2;
        }
        public bool QueueWithinNormalRange(Appointments appointments)
        {
            var patient = appointments.Patients;
            var speechTherapist = patient.speechTherapist;
            var workingHours = speechTherapist.WorkingHours;
            var appointmentDay = appointments.DateAndHour.DayOfWeek;

            var relevantWorkDay = workingHours.FirstOrDefault(w => w.DayOfWekk == (int)appointmentDay);

            if (relevantWorkDay == null)
            {
                return false;
            }

            var appointmentTime = appointments.DateAndHour.TimeOfDay;

            return appointmentTime >= relevantWorkDay.StartTime && appointmentTime <= relevantWorkDay.EndTime;
        }
        public async Task<bool> RescheduleAppointment(int appointmentId, DateTime newDate)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);
            if (appointment == null) return false;

            // 2. עדכון הנתונים על האובייקט
            appointment.DateAndHour = newDate;
            appointment.Status = eStatus.Rescheduled;

            // 3. בדיקת תקינות (הפונקציה שלך מהשלב הקודם)
            if (!QueueWithinNormalRange(appointment))
            {
                return false;
            }

            // 4. שליחה לפונקציית העדכון הכללית שלך!
            return await Update(appointment);
        }
    }
  
}
