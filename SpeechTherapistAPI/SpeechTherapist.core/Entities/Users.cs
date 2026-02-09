using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core.Entities
{
    public class Users
    {
        [Key]
        public int UserCode { get; set; }
        public string FullName { get; set; }
        public string password { get; set; }

        public eType Type { get; set; }
    }
    public enum eType { Patient, SpeechTherapist}
}
