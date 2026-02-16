using SpeechTherapist.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core.DTOs
{
    public class SpeechTherapistDto
    {
        public List<Patients> Patients { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public eEducation Education { get; set; }
    }
    public enum eEducation { B_A, M_A, Doctoral }
}

