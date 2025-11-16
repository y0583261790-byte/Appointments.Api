namespace Appointments.Application.DTOs
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Data Transfer Object for Appointment.
    /// </summary>
    public class AppointmentDto
    {
        /// <summary>
        /// The unique identifier for the appointment.
        /// </summary>
        /// <example>507f1f77bcf86cd799439011</example>
        public string Id { get; set; } = null!;

        /// <summary>
        /// The unique identifier of the patient.
        /// </summary>
        /// <example>P001</example>
        public string PatientId { get; set; } = null!;

        /// <summary>
        /// The full name of the patient.
        /// </summary>
        /// <example>John Doe</example>
        public string PatientName { get; set; } = null!;

        /// <summary>
        /// The email address of the patient.
        /// </summary>
        /// <example>john.doe@example.com</example>
        public string PatientEmail { get; set; } = null!;

        /// <summary>
        /// The date and time of the appointment.
        /// </summary>
        /// <example>2024-01-15T14:30:00</example>
        public DateTime Date { get; set; }

        /// <summary>
        /// Additional notes for the appointment.
        /// </summary>
        /// <example>Follow-up visit for routine checkup</example>
        public string Notes { get; set; } = string.Empty;
    }
}
