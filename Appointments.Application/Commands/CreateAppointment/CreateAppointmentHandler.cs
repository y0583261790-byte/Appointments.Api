using Appointments.Application.DTOs;
using Appointments.Core.Entities;
using Appointments.Core.Interfaces;
using AutoMapper;


namespace Appointments.Application.Commands.CreateAppointment
{
    /// <summary>
    /// Handler for creating a new appointment.
    /// </summary>
    public class CreateAppointmentHandler : ICreateAppointmentHandler
    {
        private readonly IAppointmentRepository _repo;
        private readonly IMapper _mapper;

        public CreateAppointmentHandler(IAppointmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the creation of a new appointment.
        /// </summary>
        /// <param name="cmd">The command containing appointment data.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>The created appointment entity.</returns>
        public async Task<AppointmentDto> HandleAsync(CreateAppointmentCommand cmd, CancellationToken ct = default)
        {
            var appointment = _mapper.Map<Appointment>(cmd);
            await _repo.InsertAsync(appointment, ct);
            return _mapper.Map<AppointmentDto>(appointment);
        }
    }
}
