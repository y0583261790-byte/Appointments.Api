using Appointments.Application.Commands.CreateAppointment;
using Appointments.Core.Entities;
using Appointments.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.Commands.DeleteAppointment
{
    /// <summary>
    /// Handler for deleting an appointment.
    /// </summary>
    public class DeleteAppointmentHandler : IDeleteAppointmentHandler
    {
        private readonly IAppointmentRepository _repo;

        public DeleteAppointmentHandler(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Handles deleting an appointment.
        /// </summary>
        /// <param name="command">The delete command.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>True if deletion succeeded.</returns>
        public async Task<bool> HandleAsync(DeleteAppointmentCommand command, CancellationToken ct)
        {
            return await _repo.DeleteAsync(command.Id,ct);
        }
    }
}
