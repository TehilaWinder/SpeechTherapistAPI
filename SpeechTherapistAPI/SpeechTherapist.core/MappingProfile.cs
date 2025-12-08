using AutoMapper;
using SpeechTherapist.Core.DTOs;
using SpeechTherapist.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patients,PatientDto>().ReverseMap();
            CreateMap<Treatments, TreatmentsDto>().ReverseMap();
            CreateMap<Appointments, AppointmentsDto>().ReverseMap();
        }
    }
}
