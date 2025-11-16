using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Appointments.Core.Entities
{
    /// <summary>
    /// Represents an appointment in the database.
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// The unique identifier for the appointment.
        /// Mapped to MongoDB "_id" field.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        /// <summary>
        /// The unique identifier of the patient.
        /// </summary>
        [BsonElement("patientId")]
        public string PatientId { get; set; } = null!;

        /// <summary>
        /// The full name of the patient.
        /// </summary>
        [BsonElement("patientName")]
        public string PatientName { get; set; } = null!;

        /// <summary>
        /// The email address of the patient.
        /// </summary>
        [BsonElement("patientEmail")]
        public string PatientEmail { get; set; } = null!;

        /// <summary>
        /// The date and time of the appointment.
        /// </summary>
        [BsonElement("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Additional notes for the appointment.
        /// </summary>
        [BsonElement("notes")]
        public string Notes { get; set; } = string.Empty;
    }
}
