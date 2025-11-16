using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.Queries.GetAppointmentById
{
    /// <summary>
    /// Query to retrieve a specific appointment by Id.
    /// </summary>
    public class GetAppointmentByIdQuery
    {
        public string Id { get; set; }

        public GetAppointmentByIdQuery(string id)
        {
            Id = id;
        }
    }
}
