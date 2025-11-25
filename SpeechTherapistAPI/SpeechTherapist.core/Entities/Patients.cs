using System.ComponentModel.DataAnnotations;

namespace SpeechTherapist.Core.Entities
{
    public class Patients
    {
        [Key]
        public int PatientCode { get; set; }
        public string FullName { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Rport { get; set; }
        public bool IsActive { get; set; }
        public List<Appointments> Appointments { get; set; }

    }
}
