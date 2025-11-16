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
            CreateMap<CreateAppointmentCommand, Appointment>();
            CreateMap<UpdateAppointmentCommand, Appointment>()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Appointment, AppointmentDto>();
        }
    }
}
