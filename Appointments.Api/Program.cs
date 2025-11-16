using Appointments.Application.Commands.CreateAppointment;
using Appointments.Application.Commands.DeleteAppointment;
using Appointments.Application.Commands.UpdateAppointment;
using Appointments.Application.Profiles;
using Appointments.Application.Queries.GetAllAppointments;
using Appointments.Application.Queries.GetAppointmentById;
using Appointments.Core.Interfaces;
using Appointments.Infrastructure.Settings;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(AppointmentProfile).Assembly);


builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddSingleton<MongoDbContext>();

builder.Services.AddScoped<ICreateAppointmentHandler, CreateAppointmentHandler>();
builder.Services.AddScoped<IGetAllAppointmentsHandler, GetAllAppointmentsHandler>();
builder.Services.AddScoped<IGetAppointmentByIdHandler, GetAppointmentByIdHandler>();
builder.Services.AddScoped<IUpdateAppointmentHandler, UpdateAppointmentHandler>();
builder.Services.AddScoped<IDeleteAppointmentHandler, DeleteAppointmentHandler>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var apiXmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var apiXmlPath = Path.Combine(AppContext.BaseDirectory, apiXmlFile);
    c.IncludeXmlComments(apiXmlPath);

    var appXmlFile = "Appointments.Application.xml";
    var appXmlPath = Path.Combine(AppContext.BaseDirectory, appXmlFile);
    c.IncludeXmlComments(appXmlPath);

    c.SchemaFilter<SwaggerExampleSchemaFilter>();
});



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();





