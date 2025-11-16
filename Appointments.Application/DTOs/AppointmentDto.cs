namespace Appointments.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Appointment.
    /// </summary>
    public class AppointmentDto
    {
        /// <summary>
        /// The unique identifier for the appointment.
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// The unique identifier of the patient.
        /// </summary>
        public string PatientId { get; set; } = null!;

        /// <summary>
        /// The full name of the patient.
        /// </summary>
        public string PatientName { get; set; } = null!;

        /// <summary>
        /// The email address of the patient.
        /// </summary>
        public string PatientEmail { get; set; } = null!;

        /// <summary>
        /// The date and time of the appointment.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Additional notes for the appointment.
        /// </summary>
        public string Notes { get; set; } = string.Empty;
    }
}
