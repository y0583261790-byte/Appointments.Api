using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
