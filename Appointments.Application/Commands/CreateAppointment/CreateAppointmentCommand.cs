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
        public string PatientId { get; set; } =null!;

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
