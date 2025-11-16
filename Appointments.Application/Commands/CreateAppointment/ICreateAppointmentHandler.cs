using Appointments.Application.DTOs;
using Appointments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.Commands.CreateAppointment
{
    public interface ICreateAppointmentHandler
    {
        Task<AppointmentDto> HandleAsync(CreateAppointmentCommand cmd, CancellationToken ct = default);
    }
}
