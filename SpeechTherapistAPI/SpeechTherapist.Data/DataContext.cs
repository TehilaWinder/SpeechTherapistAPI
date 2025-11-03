
using SpeechTherapist.Core.Entities;

namespace SpeechTherapist.Data
{
    public class DataContext 
    {
        public List<Patients> patients { get; set; }
        public List<Appointments> appointments { get; set; }
        public List<Treatments> treatments { get; set; }
        public DataContext()
        {

            patients = new List<Patients> { new Patients { PatientCode = 1, FullName = "tehila winder", IdNumber = "328472923", PhoneNumber = "0583261707", Email = "twinder1707@gmail.com",Rport="vjsvc fdysdi fiyseflqiw",IsActive = true } };
            treatments = new List<Treatments> { new Treatments { TreatmentCode = 1, TreatmentName = "gimgum" },new Treatments { TreatmentCode = 2, TreatmentName = "ptm" } };
            appointments = new List<Appointments> { new Appointments { AppointmentCode = 1, PatientCode = 1, TreatmentCode = 2, DateAndHour = new DateTime(2025, 12, 1, 13, 45, 00),Status=0 } };


        }
    }
}
