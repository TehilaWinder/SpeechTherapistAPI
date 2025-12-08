using SpeechTherapist.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core.DTOs
{
    public class AppointmentsDto
    {
        public DateTime DateAndHour { get; set; }
        public int Status { get; set; }
        public Patients Patients { get; set; }
        public Treatments Treatments { get; set; }
    }
}
