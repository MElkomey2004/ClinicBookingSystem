using AutoMapper;
using ClinicBookingSystem.DTOs.Appointment;
using ClinicBookingSystem.DTOs.Clinic;
using ClinicBookingSystem.DTOs.Doctor;
using ClinicBookingSystem.DTOs.Specialty;
using ClinicBookingSystem.Models;

namespace ClinicBookingSystem.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Clinic, ClinicDto>()
			.ForMember(dest => dest.SpecialtyName, opt => opt.MapFrom(src => src.Specialty.Name));

			CreateMap<CreateClinicDto, Clinic>().ReverseMap();
			CreateMap<UpdateClinicDto, Clinic>().ReverseMap();

			CreateMap<Specialty, SpecialtyDto>().ReverseMap();
			CreateMap<CreateSpecialtyDto, Specialty>().ReverseMap();
			CreateMap<UpdateSpecialtyDto, Specialty>().ReverseMap();


			CreateMap<Doctor, DoctorDto>()
			.ForMember(dest => dest.SpecialtyName, opt => opt.MapFrom(src => src.Specialty.Name))
			.ForMember(dest => dest.ClinicName, opt => opt.MapFrom(src => src.Clinic != null ? src.Clinic.Name : null));

			CreateMap<CreateDoctorDto, Doctor>();
			CreateMap<UpdateDoctorDto, Doctor>();

			CreateMap<Appointment, AppointmentDto>()
			.ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName))
			.ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.User.FullName))
			.ForMember(dest => dest.ClinicName, opt => opt.MapFrom(src => src.Clinic.Name));
		}
	}
}
