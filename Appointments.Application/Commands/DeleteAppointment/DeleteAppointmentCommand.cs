namespace Appointments.Application.Commands.DeleteAppointment
{
    /// <summary>
    /// Command to delete an appointment by Id.
    /// </summary>
    public class DeleteAppointmentCommand
    {
        public string Id { get; set; }

        public DeleteAppointmentCommand(string id)
        {
            Id = id;
        }
    }
}
