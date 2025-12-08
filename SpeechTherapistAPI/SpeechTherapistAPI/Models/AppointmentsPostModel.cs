using SpeechTherapist.Core.Entities;

namespace SpeechTherapistAPI.Models
{
    public class AppointmentsPostModel
    {
        public DateTime DateAndHour { get; set; }
        public Patients Patients { get; set; }
        public Treatments Treatments { get; set; }
    }
}
