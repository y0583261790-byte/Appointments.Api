using Appointments.Core.Entities;
using Appointments.Core.Interfaces;
using Infrastructure.Data;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly MongoDbContext _ctx;

        public AppointmentRepository(MongoDbContext ctx) => _ctx = ctx;

        public async Task<Appointment> InsertAsync(Appointment appointment, CancellationToken ct = default)
        {
            await _ctx.Appointments.InsertOneAsync(appointment, cancellationToken: ct);
            return appointment;
        }

        public async Task<List<Appointment>> GetAllAsync(CancellationToken ct = default) =>
            await _ctx.Appointments.Find(_ => true).ToListAsync(ct);

        public async Task<Appointment?> GetByIdAsync(string id, CancellationToken ct = default) =>
    await _ctx.Appointments.Find(a => a.Id == id).FirstOrDefaultAsync(ct);

        public async Task<Appointment?> UpdateAsync(Appointment appointment, CancellationToken ct = default)
        {
            var options = new FindOneAndReplaceOptions<Appointment>
            {
                ReturnDocument = ReturnDocument.After
            };

            return await _ctx.Appointments.FindOneAndReplaceAsync(
                a => a.Id == appointment.Id,
                appointment,
                options,
                ct
            );
        }

        public async Task<bool> DeleteAsync(string id, CancellationToken ct = default)
        {
            var res = await _ctx.Appointments.DeleteOneAsync(a => a.Id == id, ct);
            return res.DeletedCount > 0;
        }
    }

}



