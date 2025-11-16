using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.Commands.DeleteAppointment
{
    public interface IDeleteAppointmentHandler
    {
        Task<bool> HandleAsync(DeleteAppointmentCommand command, CancellationToken ct = default);
    }
}
