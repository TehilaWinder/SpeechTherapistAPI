using SpeechTherapist.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core.Service
{
    public interface IAppointmentService
    {
        public List<Appointments> GetAll();
        public Appointments GetById(int id);
        public void Add(Appointments appointments);
    }
}
