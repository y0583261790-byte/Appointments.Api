namespace Appointments.Application.Commands.CreateAppointment
{
    /// <summary>
    /// Command to create a new appointment.
    /// </summary>
    public class CreateAppointmentCommand 
    {
        /// <summary>
        /// The unique identifier of the patient.
        /// </summary>
        /// <example>P001</example>
        public string PatientId { get; set; } =null!;

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
