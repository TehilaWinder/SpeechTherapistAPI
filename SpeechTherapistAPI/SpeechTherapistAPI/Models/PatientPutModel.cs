namespace SpeechTherapistAPI.Models
{
    public class PatientPutModel
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
