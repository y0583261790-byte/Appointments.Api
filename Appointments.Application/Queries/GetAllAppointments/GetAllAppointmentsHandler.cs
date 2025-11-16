using Appointments.Application.DTOs;
using Appointments.Core.Entities;
using Appointments.Core.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.Queries.GetAllAppointments
{
    /// <summary>
    /// Handler for retrieving all appointments.
    /// </summary>
    public class GetAllAppointmentsHandler : IGetAllAppointmentsHandler
    {
        private readonly IAppointmentRepository _repo;
        private readonly IMapper _mapper;


        public GetAllAppointmentsHandler(IAppointmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles fetching all appointments.
        /// </summary>
        /// <param name="query">The query object.</param>
        /// <returns>List of appointments as DTOs.</returns>
        public async Task<List<AppointmentDto>> Handle(GetAllAppointmentsQuery query)
        {
            return _mapper.Map<List<AppointmentDto>>(await _repo.GetAllAsync());
        }
    }
}
