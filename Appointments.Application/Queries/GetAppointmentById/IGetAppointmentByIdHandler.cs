using Appointments.Application.DTOs;
using Appointments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.Queries.GetAppointmentById
{
    public interface IGetAppointmentByIdHandler
    {
        Task<AppointmentDto?> Handle(GetAppointmentByIdQuery query);
    }
}
