
using SpeechTherapist.Core.Entities;

namespace SpeechTherapistAPI
{
    public interface IDataContext
    {
        public List<Patients> patients { get; set; }
        public List<Appointments> appointments { get; set; }
        public List<Treatments> treatments { get; set; }
    }
}
