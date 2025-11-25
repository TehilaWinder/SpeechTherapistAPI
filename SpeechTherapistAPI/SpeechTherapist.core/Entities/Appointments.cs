using System.ComponentModel.DataAnnotations;

namespace SpeechTherapist.Core.Entities
{
    public class Appointments
    {
        [Key]
        public int AppointmentCode { get; set; }
        public DateTime DateAndHour { get; set; }
        public int Status { get; set; }
        public Patients Patients { get; set; }
        public Treatments Treatments { get; set; }

    }
}
