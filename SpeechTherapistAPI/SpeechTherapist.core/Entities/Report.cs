using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core.Entities
{
    public class Report
    {
        [Key]
        public int ReportCode { get; set; }
        public int PatientCode { get; set; }

        [ForeignKey("PatientCode")]
        public Patients Patient { get; set; } 

        public int SpeechTherapistCode { get; set; }

        [ForeignKey("SpeechTherapistCode")]
        public SpeechTerapist SpeechTherapist { get; set; } 

        public string GoogleDocUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsApprovedByTherapist { get; set; }
    }
}
