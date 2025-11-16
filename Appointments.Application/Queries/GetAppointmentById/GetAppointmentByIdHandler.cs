using Appointments.Application.DTOs;
using Appointments.Core.Entities;
using Appointments.Core.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.Queries.GetAppointmentById
{
    /// <summary>
    /// Handler for retrieving an appointment by Id.
    /// </summary>
    public class GetAppointmentByIdHandler : IGetAppointmentByIdHandler
    {
        private readonly IAppointmentRepository _repo;
        private readonly IMapper _mapper;


        public GetAppointmentByIdHandler(IAppointmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles fetching an appointment by Id.
        /// </summary>
        /// <param name="query">The query containing the appointment Id.</param>
        /// <returns>The appointment as AppointmentDto.</returns>
        public async Task<AppointmentDto?> Handle(GetAppointmentByIdQuery query)
        {
            var appointment = await _repo.GetByIdAsync(query.Id);
            if (appointment == null)
                throw new KeyNotFoundException($"Appointment with Id {query.Id} not found");

            return _mapper.Map<AppointmentDto>(appointment);
        }
    }
}
