using Appointments.Application.Commands.CreateAppointment;
using Appointments.Application.Commands.UpdateAppointment;
using Appointments.Application.DTOs;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

/// <summary>
/// Swagger schema filter that adds example JSON data to DTOs and Commands for API documentation.
/// </summary>
public class SwaggerExampleSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(AppointmentDto))
        {
            schema.Example = new Microsoft.OpenApi.Any.OpenApiObject
            {
                ["id"] = new Microsoft.OpenApi.Any.OpenApiString("507f1f77bcf86cd799439011"),
                ["patientId"] = new Microsoft.OpenApi.Any.OpenApiString("P001"),
                ["patientName"] = new Microsoft.OpenApi.Any.OpenApiString("John Doe"),
                ["patientEmail"] = new Microsoft.OpenApi.Any.OpenApiString("john.doe@example.com"),
                ["date"] = new Microsoft.OpenApi.Any.OpenApiString("2024-01-15T14:30:00"),
                ["notes"] = new Microsoft.OpenApi.Any.OpenApiString("Follow-up visit for routine checkup")
            };
        }
        else if (context.Type == typeof(CreateAppointmentCommand))
        {
            schema.Example = new Microsoft.OpenApi.Any.OpenApiObject
            {
                ["patientId"] = new Microsoft.OpenApi.Any.OpenApiString("P001"),
                ["patientName"] = new Microsoft.OpenApi.Any.OpenApiString("John Doe"),
                ["patientEmail"] = new Microsoft.OpenApi.Any.OpenApiString("john.doe@example.com"),
                ["date"] = new Microsoft.OpenApi.Any.OpenApiString("2024-01-15T14:30:00"),
                ["notes"] = new Microsoft.OpenApi.Any.OpenApiString("Follow-up visit for routine checkup")
            };
        }
        else if (context.Type == typeof(UpdateAppointmentCommand))
        {
            schema.Example = new Microsoft.OpenApi.Any.OpenApiObject
            {
                ["date"] = new Microsoft.OpenApi.Any.OpenApiString("2024-01-15T15:00:00"),
                ["notes"] = new Microsoft.OpenApi.Any.OpenApiString("Updated follow-up notes")
            };
        }
        else if (context.Type == typeof(List<AppointmentDto>))
        {
            var appointmentExample = new Microsoft.OpenApi.Any.OpenApiObject
            {
                ["id"] = new Microsoft.OpenApi.Any.OpenApiString("507f1f77bcf86cd799439011"),
                ["patientId"] = new Microsoft.OpenApi.Any.OpenApiString("P001"),
                ["patientName"] = new Microsoft.OpenApi.Any.OpenApiString("John Doe"),
                ["patientEmail"] = new Microsoft.OpenApi.Any.OpenApiString("john.doe@example.com"),
                ["date"] = new Microsoft.OpenApi.Any.OpenApiString("2024-01-15T14:30:00"),
                ["notes"] = new Microsoft.OpenApi.Any.OpenApiString("Follow-up visit for routine checkup")
            };

            var appointmentExample2 = new Microsoft.OpenApi.Any.OpenApiObject
            {
                ["id"] = new Microsoft.OpenApi.Any.OpenApiString("507f1f77bcf86cd799439012"),
                ["patientId"] = new Microsoft.OpenApi.Any.OpenApiString("P002"),
                ["patientName"] = new Microsoft.OpenApi.Any.OpenApiString("Jane Smith"),
                ["patientEmail"] = new Microsoft.OpenApi.Any.OpenApiString("jane.smith@example.com"),
                ["date"] = new Microsoft.OpenApi.Any.OpenApiString("2024-01-16T10:00:00"),
                ["notes"] = new Microsoft.OpenApi.Any.OpenApiString("Initial consultation")
            };

            schema.Example = new Microsoft.OpenApi.Any.OpenApiArray
            {
                appointmentExample,
                appointmentExample2
            };
        }
    }
}
