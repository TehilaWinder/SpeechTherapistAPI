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
        public List<Appointments> GetAll();
        public Appointments GetById(int id);
        public Appointments GetByDateAndHour(DateTime DateAndHour);
        public void Add(Appointments appointments);
        public void Update(int id,Appointments appointments);
        public void Delete(int id);
        public void Save();
    }
}
