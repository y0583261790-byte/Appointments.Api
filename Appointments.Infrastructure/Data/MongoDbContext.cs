using Appointments.Core.Entities;
using Appointments.Infrastructure.Settings;
using MongoDB.Driver;
using Microsoft.Extensions.Options;





namespace Infrastructure.Data
{
    public class MongoDbContext
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoClient client, IOptions<MongoSettings> settings)
        {
            _client = client;
            _database = _client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Appointment> Appointments => _database.GetCollection<Appointment>("Appointments");
    }
}