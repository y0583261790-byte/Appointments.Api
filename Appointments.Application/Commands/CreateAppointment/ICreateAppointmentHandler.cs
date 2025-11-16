using Appointments.Application.DTOs;

namespace Appointments.Application.Commands.CreateAppointment
{
    public interface ICreateAppointmentHandler
    {
        Task<AppointmentDto> HandleAsync(CreateAppointmentCommand cmd, CancellationToken ct = default);
    }
}
