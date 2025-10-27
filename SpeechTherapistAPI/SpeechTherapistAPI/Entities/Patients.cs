namespace SpeechTherapistAPI.Entities
{
    public class Patients
    {
        public int PatientCode { get; set; }
        public string FullName { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Rport { get; set; }
        public bool IsActive { get; set; }

    }
}
