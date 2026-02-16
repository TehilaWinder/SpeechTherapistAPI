using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core.Entities
{
    public class WorkingHours
    {
        public int WorkingHoursCode { get; set; }
        public int SpeechTherapistCode { get; set; }
        public int DayOfWekk { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
