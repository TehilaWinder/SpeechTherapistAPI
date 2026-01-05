using AutoMapper;
using SpeechTherapist.Core.DTOs;
using SpeechTherapist.Core.Entities;
using SpeechTherapistAPI.Models;

namespace SpeechTherapistAPI
{
    public class MappingPostProfile: Profile
    {
        public MappingPostProfile()
        {
            CreateMap<Patients, PatientPostModel>().ReverseMap();
            CreateMap<Treatments, TreatmentsPostModel>().ReverseMap();
            CreateMap<Appointments, AppointmentsPostModel>().ReverseMap();
        }
    }
}

