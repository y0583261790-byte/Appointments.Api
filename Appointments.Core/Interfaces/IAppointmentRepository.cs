using Appointments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Core.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<Appointment> InsertAsync(Appointment appointment, CancellationToken ct = default);
        Task<List<Appointment>> GetAllAsync(CancellationToken ct = default);
        Task<Appointment?> GetByIdAsync(string id, CancellationToken ct = default);
        Task<Appointment?> UpdateAsync(Appointment appointment, CancellationToken ct = default);
        Task<bool> DeleteAsync(string id, CancellationToken ct = default);
    }
}
