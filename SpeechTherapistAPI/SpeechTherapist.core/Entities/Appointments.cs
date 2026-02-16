using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeechTherapist.Core.Entities
{
    public class Appointments
    {
        [Key]
        public int AppointmentCode { get; set; }
        public DateTime DateAndHour { get; set; }
        public eStatus Status { get; set; }
        public int PatientCode { get; set; }

        [ForeignKey("PatientCode")]
        public Patients Patients { get; set; }
        public int TreatmentCode { get; set; }

        [ForeignKey("TreatmentCode")]
        public Treatments Treatments { get; set; }

    }
    public enum eStatus
    {
        active, delyed, canceled
    }

}
