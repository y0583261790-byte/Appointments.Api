using Appointments.Application.DTOs;

namespace Appointments.Application.Commands.UpdateAppointment
{
    public interface IUpdateAppointmentHandler
    {
        Task<AppointmentDto> HandleAsync(string id,UpdateAppointmentCommand command, CancellationToken ct = default);
    }
}
