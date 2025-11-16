namespace Appointments.Application.Commands.DeleteAppointment
{
    public interface IDeleteAppointmentHandler
    {
        Task<bool> HandleAsync(DeleteAppointmentCommand command, CancellationToken ct = default);
    }
}
