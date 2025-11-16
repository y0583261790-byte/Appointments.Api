using Appointments.Application.Commands.CreateAppointment;
using Appointments.Application.Commands.UpdateAppointment;
using Appointments.Application.DTOs;
using Appointments.Core.Entities;
using AutoMapper;

namespace Appointments.Application.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            // Map create command -> entity
            CreateMap<CreateAppointmentCommand, Appointment>();

            // Map update command -> entity, only map non-null source members (supports partial updates)
            CreateMap<UpdateAppointmentCommand, Appointment>()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Map entity <-> DTO
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
        }
    }
}
