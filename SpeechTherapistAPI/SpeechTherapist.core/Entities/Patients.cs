using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeechTherapist.Core.Entities
{
    public class Patients
    {
        [Key]
        public int PatientCode { get; set; }
        public int UserCode { get; set; }

        [ForeignKey("UserCode")]
        public Users User { get; set; }
        public int SpeechTherapistCode { get; set; }

        [ForeignKey("SpeechTherapistCode")]
        public SpeechTerapist speechTherapist { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public List<Appointments> Appointments { get; set; }

    }
}
