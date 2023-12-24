using AutoMapper;
using CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
using CargaSinEstres.API.Security.Authorization.Handlers.Interfaces;
using CargaSinEstres.API.Security.Domain.Models;
using CargaSinEstres.API.Security.Domain.Repositories;
using CargaSinEstres.API.Security.Domain.Services;
using CargaSinEstres.API.Security.Domain.Services.Communication;
using CargaSinEstres.API.Security.Exceptions;
using IClientRepository = CargaSinEstres.API.Security.Domain.Repositories.IClientRepository;

namespace CargaSinEstres.API.Security.Services;

/// <summary>
/// Service class for managing client-related operations.
/// </summary>
/// <remarks> Grupo 1: Carga sin estres </remarks>
public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtHandler _jwtHandlerClient;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientService"/> class.
    /// </summary>
    /// <param name="clientRepository">The client repository.</param>
    /// <param name="unitOfWork">The unit of work for database operations.</param>
    /// <param name="jwtHandlerClient">The JWT handler for client authentication.</param>
    /// <param name="mapper">The AutoMapper instance for object mapping.</param>
    public ClientService(IClientRepository clientRepository, IUnitOfWork unitOfWork, IJwtHandler jwtHandlerClient, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
        _jwtHandlerClient = jwtHandlerClient;
        _mapper = mapper;
    }

/// <summary>
        /// Initializes a new instance of the <see cref="ClientService"/> class.
        /// </summary>
        /// <param name="clientRepository">The client repository.</param>
        /// <param name="unitOfWork">The unit of work for database operations.</param>
        /// <param name="mapper">The AutoMapper instance for object mapping.</param>
    public ClientService(IClientRepository clientRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <summary>
    /// Authenticates a client using the provided credentials.
    /// </summary>
    /// <param name="request">The authentication request.</param>
    /// <returns>An authentication response.</returns>
    public async Task<AuthenticateResponseClient> AuthenticateClient(AuthenticateRequestClient request)
    {
        var client = await _clientRepository.FindByEmailClientAsync(request.Email);
        Console.WriteLine($"Request: {request.Email},{request.Password}");
        Console.WriteLine($"Client: {client.Id}, {client.Email}, {client.Password}");
        Console.WriteLine("Authentication successful. About to generate token");
        // authentication successful
        var response = _mapper.Map<AuthenticateResponseClient>(client);
        Console.WriteLine($"Response: {response.Id}, {response.Email}");
        return response;
    }

    /// <summary>
    /// Retrieves a list of clients asynchronously.
    /// </summary>
    /// <returns>A collection of clients.</returns>
    public async Task<IEnumerable<Client>> ListClientAsync()
    {
        return await _clientRepository.ListClientAsync();
    }

    /// <summary>
    /// Retrieves a client by ID asynchronously.
    /// </summary>
    /// <param name="id">The client ID.</param>
    /// <returns>The client with the specified ID.</returns>
    public async Task<Client> GetByIdClientAsync(int id)
    {
        var client = await _clientRepository.FindByIdClientAsync(id);
        if (client == null) throw new KeyNotFoundException("Client not found");
        return client;
    }
    
    /// <summary>
    /// Registers a new client asynchronously.
    /// </summary>
    /// <param name="request">The registration request.</param>
    public async Task RegisterClientAsync(RegisterRequestClient request)
    { 
        // validate
        if (_clientRepository.ExistsByEmailClient(request.Email))
            throw new AppException("Email: '" + request.Email + "' is already taken");
        var client = _mapper.Map<Client>(request); 
        try
        {
            await _clientRepository.AddClientAsync(client);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while saving the client: {e.Message}");
        }
    }
    
    /// <summary>
    /// Gets a client by ID.
    /// </summary>
    /// <param name="id">The client ID.</param>
    /// <returns>The client with the specified ID.</returns>
    // helper methods
    private Client GetByIdClient(int id)
    {
        var client = _clientRepository.FindByIdClient(id);
        if (client == null) throw new KeyNotFoundException("Client not found");
        return client;
    }

    /// <summary>
    /// Updates an existing client asynchronously.
    /// </summary>
    /// <param name="id">The ID of the client to update.</param>
    /// <param name="request">The update request.</param>
    public async Task UpdateClientAsync(int id, UpdateRequestClient request)
    {
        var client = GetByIdClient(id);
        _mapper.Map(request, client);
        try
        {
            _clientRepository.UpdateClient(client);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while updating the client: {e.Message}");
        }
    }
    
    public async Task GetClientForLoginAsync(string email, string password)
    {
        var client = await _clientRepository.FindByEmailClientAsync(email);
        if (client == null) throw new KeyNotFoundException("Client not found");
        if (client.Password != password) throw new AppException("Wrong password");
    }
}