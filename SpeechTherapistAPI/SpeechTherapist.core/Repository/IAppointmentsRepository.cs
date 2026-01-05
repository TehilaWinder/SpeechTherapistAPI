using SpeechTherapist.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core.Repository
{
    public interface IAppointmentsRepository
    {
        public Task<IEnumerable<Appointments>> GetAllAsync();
        public Task<Appointments> GetByIdAsync(int id);
        public Task<Appointments> GetByDateAndHourAsync(DateTime DateAndHour);
        public void Add(Appointments appointments);
        public Task UpdateAsync(int id, Appointments appointments);
        public Task DeleteAsync(int id);
        public Task SaveAsync();
    }
}
