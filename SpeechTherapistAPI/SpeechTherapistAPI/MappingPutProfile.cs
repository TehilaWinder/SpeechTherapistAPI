using AutoMapper;
using SpeechTherapist.Core.DTOs;
using SpeechTherapist.Core.Entities;
using SpeechTherapistAPI.Models;

namespace SpeechTherapistAPI
{
    public class MappingPutProfile:Profile
    {
        public MappingPutProfile()
        {
            CreateMap<Patients, PatientPutModel>().ReverseMap();
            CreateMap<Treatments, TreatmentsPutModel>().ReverseMap();
            CreateMap<Appointments, AppointmentsPutModel>().ReverseMap();
        }
    }
}
