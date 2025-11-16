using Appointments.Application.Commands.CreateAppointment;
using Appointments.Application.Commands.DeleteAppointment;
using Appointments.Application.Commands.UpdateAppointment;
using Appointments.Application.DTOs;
using Appointments.Application.Queries.GetAllAppointments;
using Appointments.Application.Queries.GetAppointmentById;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for managing appointments.
/// Allows creation, updating, deletion, and retrieval of appointments.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly ICreateAppointmentHandler _createHandler;
    private readonly IGetAppointmentByIdHandler _getHandler;
    private readonly IGetAllAppointmentsHandler _getAllHandler;
    private readonly IUpdateAppointmentHandler _updateHandler;
    private readonly IDeleteAppointmentHandler _deleteHandler;

    public AppointmentsController(
        ICreateAppointmentHandler createHandler,
        IGetAppointmentByIdHandler getHandler,
        IGetAllAppointmentsHandler getAllHandler,
        IUpdateAppointmentHandler updateHandler,
        IDeleteAppointmentHandler deleteHandler)
    {
        _createHandler = createHandler;
        _getHandler = getHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getAllHandler = getAllHandler;
    }

    /// <summary>
    /// Creates a new appointment.
    /// </summary>
    /// <param name="cmd">The appointment data.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The created appointment.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateAppointmentCommand cmd, CancellationToken ct)
    {
        var created = await _createHandler.HandleAsync(cmd, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>
    /// Gets all appointments.
    /// </summary>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>List of appointments.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<AppointmentDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var list = await _getAllHandler.Handle(new GetAllAppointmentsQuery());
        return Ok(list);
    }

    /// <summary>
    /// Gets a specific appointment by its id.
    /// </summary>
    /// <param name="id">The appointment id.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The appointment details.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(string id, CancellationToken ct)
    {
        var ap = await _getHandler.Handle(new GetAppointmentByIdQuery(id));
        if (ap == null) return NotFound();
        return Ok(ap);
    }


    /// <summary>
    /// Updates an existing appointment.
    /// </summary>
    /// <param name="id">The appointment id.</param>
    /// <param name="cmd">Updated appointment data.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The updated appointment.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateAppointmentCommand cmd, CancellationToken ct)
    {
        var updated = await _updateHandler.HandleAsync(id,cmd, ct);
        if (updated == null) return NotFound();
        return Ok(updated);
    }


    /// <summary>
    /// Deletes an appointment by id.
    /// </summary>
    /// <param name="id">The appointment id.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>No content if successful, 404 if not found.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var ok = await _deleteHandler.HandleAsync(new DeleteAppointmentCommand(id), ct);
        if (!ok) return NotFound();
        return NoContent();
    }
}