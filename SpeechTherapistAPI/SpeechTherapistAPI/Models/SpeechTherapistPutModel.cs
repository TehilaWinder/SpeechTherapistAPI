using SpeechTherapist.Core.Entities;

namespace SpeechTherapistAPI.Models
{
    public class SpeechTherapistPutModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public eEducation Education { get; set; }
    }
}

