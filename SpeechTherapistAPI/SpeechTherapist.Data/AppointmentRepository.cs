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
        public async Task<IEnumerable<Appointments>> GetAllAsync()
        {
            return await _context.appointments.Include(a=>a.Patients).Include(a => a.Treatments).ToListAsync();
        }
        public async Task<Appointments> GetByIdAsync(int id)
        {
            var a = await _context.appointments.FirstOrDefaultAsync(x => x.AppointmentCode == id);
            return a;
        }
        public void Add(Appointments appointments)
        {
            _context.appointments.Add(appointments);
        }

        public async Task UpdateAsync(int id,Appointments appointments)
        {
            var a =await GetByIdAsync(id);
            a.DateAndHour=appointments.DateAndHour;
            a.Status=appointments.Status;
            a.Patients=appointments.Patients;
            a.Treatments=appointments.Treatments;
        }

        public async Task DeleteAsync(int id)
        {
            var appointment = await GetByIdAsync(id);
             _context.appointments.Remove(appointment);
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

        public async Task<Appointments> GetByDateAndHourAsync(DateTime DateAndHour)
        {
            var a = await _context.appointments.FirstOrDefaultAsync(x => x.DateAndHour == DateAndHour);
            return a;
        }
    }
}
