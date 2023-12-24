using AutoMapper;
using CargaSinEstres.API.Security.Authorization.Attributes;
using CargaSinEstres.API.Security.Domain.Models;
using CargaSinEstres.API.Security.Domain.Services;
using CargaSinEstres.API.Security.Domain.Services.Communication;
using CargaSinEstres.API.Security.Resources;
using Microsoft.AspNetCore.Mvc;

namespace CargaSinEstres.API.Security.Controllers;
/// <summary>
/// Controller for managing client-related operations.
/// </summary>
/// <remarks> Grupo 1: Carga sin estres </remarks>
[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class ClientsController : ControllerBase{
    
    private readonly IClientService _clientService;
    private readonly IMapper _mapper;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ClientsController"/> class.
    /// </summary>
    /// <param name="clientService">The service for client-related operations.</param>
    /// <param name="mapper">The AutoMapper instance for mapping entities to resources.</param>
    public ClientsController(IClientService clientService, IMapper mapper)
    {
        _clientService = clientService;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Authenticates a client.
    /// </summary>
    /// <param name="request">The authentication request.</param>
    /// <returns>An action result representing the authentication response.</returns>
    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> AuthenticateClient(AuthenticateRequestClient request)
    {
        var response = await _clientService.AuthenticateClient(request);
        return Ok(response);
    }
    
    /// <summary>
    /// Registers a new client.
    /// </summary>
    /// <param name="request">The registration request.</param>
    /// <returns>An action result indicating the success of the registration.</returns>
    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterRequestClient request)
    {
        await _clientService.RegisterClientAsync(request);
        return Ok(new { message = "Registration successful" });
    }
    
    /// <summary>
    /// Retrieves a list of all clients.
    /// </summary>
    /// <returns>An action result containing a list of client resources.</returns>
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clients = await _clientService.ListClientAsync();
        var resources = _mapper.Map<IEnumerable<Client>,
            IEnumerable<ClientResource>>(clients);
        return Ok(resources);
    }
    
    /// <summary>
    /// Retrieves a client by its identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the client.</param>
    /// <returns>An action result containing the client resource.</returns>
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var client = await _clientService.GetByIdClientAsync(id);
        var resource = _mapper.Map<Client, ClientResource>(client);
        return Ok(resource);
    }
    
    /// <summary>
    /// Updates a client's information.
    /// </summary>
    /// <param name="id">The unique identifier of the client.</param>
    /// <param name="request">The update request.</param>
    /// <returns>An action result indicating the success of the update.</returns>
    [AllowAnonymous]
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateClient(int id, UpdateRequestClient request)
    {
        await _clientService.UpdateClientAsync(id, request);
        return Ok(new { message = "Client updated successfully" });
    }
    
    //get for login
    
    
}