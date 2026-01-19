using System.ComponentModel.DataAnnotations;

namespace SpeechTherapist.Core.Entities
{
    public class Patients
    {
        [Key]
        public int PatientCode { get; set; }
        public int UserCode { get; set; }
        public Users User { get; set; }
        public string Report { get; set; }
        public bool IsActive { get; set; }
        public List<Appointments> Appointments { get; set; }
        public SpeechTerapist SpeechTerapist { get; set; }

    }
}
