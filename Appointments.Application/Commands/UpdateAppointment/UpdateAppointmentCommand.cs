namespace Appointments.Application.Commands.UpdateAppointment
{
    /// <summary>
    /// Command to update an existing appointment.
    /// Only contains fields that can be updated.
    /// </summary>
    public class UpdateAppointmentCommand
    {
        /// <summary>
        /// The date and time of the appointment.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Additional notes for the appointment.
        /// </summary>
        public string Notes { get; set; } = string.Empty;
    }
}
