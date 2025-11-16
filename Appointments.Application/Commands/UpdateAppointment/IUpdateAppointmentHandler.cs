using Appointments.Application.DTOs;
using Appointments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.Commands.UpdateAppointment
{
    public interface IUpdateAppointmentHandler
    {
        Task<AppointmentDto> HandleAsync(string id,UpdateAppointmentCommand command, CancellationToken ct = default);
    }
}
