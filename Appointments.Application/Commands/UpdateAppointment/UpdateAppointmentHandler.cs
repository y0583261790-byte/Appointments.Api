using Appointments.Application.DTOs;
using Appointments.Core.Entities;
using Appointments.Core.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.Commands.UpdateAppointment
{
    /// <summary>
    /// Handler for updating an existing appointment.
    /// </summary>
    public class UpdateAppointmentHandler:IUpdateAppointmentHandler
    {
        private readonly IAppointmentRepository _repo;
        private readonly IMapper _mapper;


        public UpdateAppointmentHandler(IAppointmentRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles updating an appointment.
        /// </summary>
        /// <param name="command">The update command.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>The updated appointment as AppointmentDto.</returns>
        public async Task<AppointmentDto> HandleAsync(string id,UpdateAppointmentCommand command, CancellationToken ct = default)
        {
            var appointment = await _repo.GetByIdAsync(id);

            if (appointment == null)
                throw new KeyNotFoundException($"Appointment with Id {id} not found");

            _mapper.Map(command, appointment);

            await _repo.UpdateAsync(appointment, ct);

            return _mapper.Map<AppointmentDto>(appointment);
        }
    }
}
