using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core.Entities
{
    public class SpeechTerapist
    {
        [Key]
        public int SpeechTherapistCode { get; set; }
        public int UserCode { get; set; }

        [ForeignKey("UserCode")]
        public Users User { get; set; }
        public List<Patients> Patients { get; set; }
        public List<WorkingHours> WorkingHours { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public eEducation Education { get; set; }
    }
    public enum eEducation { B_A, M_A, Doctoral }

}
