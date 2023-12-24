using AutoMapper;
using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Services;
using CargaSinEstres.API.CargaSinEstres.Resources;
using CargaSinEstres.API.Security.Domain.Services;
using CargaSinEstres.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CargaSinEstres.API.CargaSinEstres.Controllers;

/// <summary>
/// Controller for managing booking history-related operations.
/// </summary>
/// <remarks> Grupo 1: Carga sin estres </remarks>
[ApiController]
[Route("/api/v1/booking-history")]
public class BookingHistoryController : ControllerBase
{
    private readonly IBookingHistoryService _bookingHistoryService;
    private readonly IMapper _mapper;
    private readonly ICompanyService _companyService;
    private readonly IClientService _clientService;
    private readonly IWorkerService _workerService;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookingHistoryController"/> class.
    /// </summary>
    /// <param name="bookingHistoryService">The booking history service.</param>
    /// <param name="mapper">The mapper.</param>
    /// <param name="companyService">The company service.</param>
    /// <param name="clientService">The client service.</param>
    /// <param name="workerService">The worker service.</param>
    public BookingHistoryController(IBookingHistoryService bookingHistoryService, IMapper mapper, ICompanyService companyService,
        IClientService clientService, IWorkerService workerService)
    {
        _bookingHistoryService = bookingHistoryService;
        _mapper = mapper;
        _companyService = companyService;
        _clientService = clientService;
        _workerService = workerService;
    }

    /// <summary>
    /// Retrieves all booking history entries.
    /// </summary>
    /// <returns>An enumerable of <see cref="BookingHistoryResource"/>.</returns>  
    [HttpGet]
    public async Task<IEnumerable<BookingHistoryResource>> GetAllAsync()
    {
        var bookings = await _bookingHistoryService.GetBookingHistoryAsync();
        var resources = _mapper.Map<IEnumerable<BookingHistory>, IEnumerable<BookingHistoryResource>>(bookings);
        return resources;
    }

    /// <summary>
    /// Retrieves a specific booking by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the booking.</param>
    /// <returns>
    /// A response containing the booking details if found,
    /// or a 404 Not Found response if the booking is not found.
    /// </returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BookingHistoryResource), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<BookingHistoryResource>> GetBooking(int id)
    {
        var booking = await _bookingHistoryService.GetBookingAsync(id);

        //var workers = await _workerService.ListByWorkerIdAsync(id);
        //var showWorkers = _mapper.Map<Worker, WorkerResource>(workers);

        if (booking == null)
        {
            return NotFound();
        }

        //booking.Workers = showWorkers;

        var bookingResource = _mapper.Map<BookingHistory, BookingHistoryResource>(booking);
        return Ok(bookingResource);
    }

    /// <summary>
    /// Retrieves bookings associated with a specific client.
    /// </summary>
    /// <param name="clientId">The identifier of the client.</param>
    /// <returns>
    /// A response containing the booking resources if found,
    /// or a 404 Not Found response if no bookings are found for the client.
    /// </returns>
    [HttpGet("idClient/{clientId}")]
    [ProducesResponseType(typeof(IEnumerable<BookingHistoryResource>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<BookingHistoryResource>>> GetBookingsByClientId(int clientId)
    {
        var bookings = await _bookingHistoryService.GetBookingsByClientIdAsync(clientId);

        if (bookings == null || !bookings.Any())
        {
            return NotFound();
        }

        var bookingResources = _mapper.Map<IEnumerable<BookingHistory>, IEnumerable<BookingHistoryResource>>(bookings);
        return Ok(bookingResources);
    }

    /// <summary>
    /// Retrieves bookings associated with a specific company.
    /// </summary>
    /// <param name="companyId">The identifier of the company.</param>
    /// <returns>
    /// A response containing the booking resources if found,
    /// or a 404 Not Found response if no bookings are found for the company.
    /// </returns>
    [HttpGet("idCompany/{companyId}")]
    [ProducesResponseType(typeof(IEnumerable<BookingHistoryResource>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<BookingHistoryResource>>> GetBookingsByCompanyId(int companyId)
    {
        var bookings = await _bookingHistoryService.GetBookingsByCompanyIdAsync(companyId);

        if (bookings == null || !bookings.Any())
        {
            return NotFound();
        }

        var bookingResources = _mapper.Map<IEnumerable<BookingHistory>, IEnumerable<BookingHistoryResource>>(bookings);
        return Ok(bookingResources);
    }
    /// <summary>
    /// Creates a new booking.
    /// </summary>
    /// <param name="resource">The data for creating the booking.</param>
    /// <param name="clientId">The identifier of the associated client.</param>
    /// <param name="companyId">The identifier of the associated company.</param>
    /// <returns>
    /// A response containing the created booking details if successful,
    /// or a Bad Request response if there are validation errors or the associated client or company is not found.
    /// </returns>
    [HttpPost]
    [ProducesResponseType(typeof(BookingHistoryResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<BookingHistoryResource>> CreateBooking(
       [FromBody] SaveBookingHistoryResource resource,
       [FromQuery] int clientId,
       [FromQuery] int companyId)
    {

        var existingClient = await _clientService.GetByIdClientAsync(clientId);
        if (existingClient == null)
        {
            return BadRequest(new { error = "Client not found" });
        }
        var existingCompany = await _companyService.GetByIdAsync(companyId);
        if (existingCompany == null)
        {
            return BadRequest(new { error = "Company not found" });
        }
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        
        var booking = _mapper.Map<SaveBookingHistoryResource, BookingHistory>(resource);

        booking.Status = "Iniciar Proceso";
        booking.IdClient = clientId;
        booking.IdCompany = companyId;

        var response = await _bookingHistoryService.CreateBookingAsync(booking);

        if (!response.Success)
        {
            return BadRequest(new { error = response.Message });
        }

        var bookingResource = _mapper.Map<BookingHistory, BookingHistoryResource>(response.Resource);
        return CreatedAtAction(nameof(GetBooking), new { id = bookingResource.Id }, bookingResource);
    }

    /// <summary>
    /// Creates a new message for a specific booking.
    /// </summary>
    /// <param name="id">The identifier of the booking.</param>
    /// <param name="newMessage">The data for creating the new message.</param>
    /// <returns>
    /// A response containing the created message details if successful,
    /// or a Bad Request response if there are validation errors or the associated booking is not found.
    /// </returns>
    [HttpPut("{id}/messages")]
    [ProducesResponseType(typeof(SaveChatResource), 201)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateMessage(int id, [FromBody] SaveChatResource newMessage)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var existingBooking = await _bookingHistoryService.GetBookingAsync(id);

        if (existingBooking == null)
            return NotFound();

        newMessage.DateTime = DateTime.Now;

        // Convertir IEnumerable<Chat> a List<Chat> para poder agregar el nuevo mensaje
        var chatList = existingBooking.Chats.ToList();

        var chat = _mapper.Map<SaveChatResource, Chat>(newMessage);
        chatList.Add(chat);

        // Asignar la lista actualizada de chats de nuevo a la propiedad Chats
        existingBooking.Chats = chatList;

        var updatedBooking = _mapper.Map<BookingHistory, UpdateBookingHistoryResource>(existingBooking);
        var response = await _bookingHistoryService.UpdateBookingAsync(id, updatedBooking);

        if (!response.Success)
            return BadRequest(new { error = response.Message });

        return CreatedAtAction(nameof(CreateMessage), new { id = existingBooking.Id }, newMessage);
    }

    /// <summary>
    /// Updates the details of a specific booking.
    /// </summary>
    /// <param name="id">The identifier of the booking to update.</param>
    /// <param name="resource">The data with updated details.</param>
    /// <returns>
    /// A response containing the updated booking details if successful,
    /// or a Bad Request response if there are validation errors or the booking is not found.
    /// </returns>
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateBooking(int id, [FromBody] UpdateBookingHistoryResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
    
        //var booking = _mapper.Map<UpdateBookingHistoryResource, BookingHistory>(resource);
        var response = await _bookingHistoryService.UpdateBookingAsync(id, resource);
    
        if (!response.Success)
        {
            return BadRequest(new { error = response.Message });
        }
        var bookingResource = _mapper.Map<BookingHistory, BookingHistoryResource>(response.Resource);
        return Ok(bookingResource);
    }

}
