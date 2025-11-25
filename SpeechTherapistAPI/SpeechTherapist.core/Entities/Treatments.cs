using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpeechTherapist.Core.Entities
{
    public class Treatments
    {
        [Key]
        public int TreatmentCode { get; set; }
        public string TreatmentName { get; set; }
        public float DurationMinutes { get; set; }
        public List<Appointments> Appointments { get; set; }
    }
}
