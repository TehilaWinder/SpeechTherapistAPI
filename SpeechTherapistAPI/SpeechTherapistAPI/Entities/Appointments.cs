namespace SpeechTherapistAPI.Entities
{
    public class Appointments
    {
        public int AppointmentCode { get; set; }
        public int PatientCode { get; set; }
        public int TreatmentCode { get; set; }
        public DateTime DateAndHour { get; set; }
        public int Status { get; set; }
    }
}
