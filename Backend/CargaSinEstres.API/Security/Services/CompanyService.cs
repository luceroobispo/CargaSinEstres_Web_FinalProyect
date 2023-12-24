using AutoMapper;
using CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
using CargaSinEstres.API.Security.Authorization.Handlers.Interfaces;
using CargaSinEstres.API.Security.Domain.Models;
using CargaSinEstres.API.Security.Domain.Services;
using CargaSinEstres.API.Security.Domain.Services.Communication;
using CargaSinEstres.API.Security.Exceptions;
using CargaSinEstres.API.Security.Resources;
using BCryptNet = BCrypt.Net.BCrypt;
using ICompanyRepository = CargaSinEstres.API.Security.Domain.Repositories.ICompanyRepository;

namespace CargaSinEstres.API.Security.Services;

/// <summary>
/// Service that manages operations related to companies.
/// </summary>
/// <remarks> Grupo 1: Carga sin estres </remarks>
public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtHandler _jwtHandler;
    private readonly IMapper _mapper;
    
    /// <summary>
    /// Constructor of the CompanyService class.
    /// </summary>
    /// <param name="companyRepository">Company repository.</param>
    /// <param name="unitOfWork">Unit of work.</param>
    /// <param name="jwtHandler">JWT handler.</param>
    /// <param name="mapper">IMapper object for mappings.</param>
    public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork, IJwtHandler jwtHandler, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
        _jwtHandler = jwtHandler;
        _mapper = mapper;
    }

    /// <summary>
    /// Constructor of the CompanyService class without the JWT handler.
    /// </summary>
    /// <param name="companyRepository">Company repository.</param>
    /// <param name="unitOfWork">Unit of work.</param>
    /// <param name="mapper">IMapper object for mappings.</param>
    public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <summary>
    /// Authenticates a company with the provided credentials.
    /// </summary>
    /// <param name="request">Authentication request containing credentials.</param>
    /// <returns>Authentication response with company details and a JWT token.</returns>
    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        var company = await
            _companyRepository.FindByEmailAsync(request.Email);
        Console.WriteLine($"Request: {request.Email},{request.Password}");
        Console.WriteLine($"Company: {company.Id}, {company.Email}, {company.Password}");
        // validate
        /*if (company == null || !BCryptNet.Verify(request.Password,
                company.Password))
        {
            Console.WriteLine("Authentication Error");
            throw new AppException("Email or password is incorrect");
        }*/
        Console.WriteLine("Authentication successful. About to generate token");
        // authentication successful
        var response = _mapper.Map<AuthenticateResponse>(company);
        Console.WriteLine($"Response: {response.Id}, {response.Email}");
        /*response.Token = _jwtHandler.GenerateToken(company);
        Console.WriteLine($"Generated token is {response.Token}");*/
        return response;
    }

    /// <summary>
    /// Gets a list of all companies.
    /// </summary>
    /// <returns>A collection of companies.</returns>
    public async Task<IEnumerable<Domain.Models.Company>> ListAsync()
    {
        return await _companyRepository.ListAsync();
    }
    
    /// <summary>
    /// Gets a company by its identifier.
    /// </summary>
    /// <param name="id">Unique identifier of the company.</param>
    /// <returns>The company with the provided identifier.</returns>
    public async Task<Domain.Models.Company> GetByIdAsync(int id)
    {
        var company = await _companyRepository.FindByIdAsync(id);
        if (company == null) throw new KeyNotFoundException("Company not found");
        return company;
    }
    
    /// <summary>
    /// Registers a new company.
    /// </summary>
    /// <param name="request">Registration request containing details of the new company.</param>
    public async Task RegisterAsync(RegisterRequest request)
    { 
        // validate
        if (_companyRepository.ExistsByEmail(request.Email))
            throw new AppException("Email: '" + request.Email + "' is already taken"); 
        // map model to new company object
        var company = _mapper.Map<Domain.Models.Company>(request); 
        // hash password
        //company.Password = BCryptNet.HashPassword(request.Password); 
        // save company
        try
        {
            await _companyRepository.AddAsync(company);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while saving the company: {e.Message}");
        }
    }
    
    // helper methods
    /// <summary>
    /// Gets a company by its identifier.
    /// </summary>
    /// <param name="id">Unique identifier of the company.</param>
    /// <returns>The company with the provided identifier.</returns>
    private Domain.Models.Company GetById(int id)
    {
        var company = _companyRepository.FindById(id);
        if (company == null) throw new KeyNotFoundException("Company not found");
        return company;
    }
    
    /// <summary>
    /// Updates details of an existing company.
    /// </summary>
    /// <param name="id">Unique identifier of the company to update.</param>
    /// <param name="request">Update request containing the new details for the company.</param>
    public async Task UpdateAsync(int id, UpdateRequest request)
    {
        var company = GetById(id);
        // Validate
        /*if (_companyRepository.ExistsByEmail(request.Email))
            throw new AppException("Email: '" + request.Email + "' is already taken");*/
        // Hash password if it was entered
        //if (!string.IsNullOrEmpty(request.Password))
          //  company.Password = BCryptNet.HashPassword(request.Password);
        // Copy model to company and save
        _mapper.Map(request, company);
        try
        {
            _companyRepository.Update(company);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while updating the company: {e.Message}");
        }
    }
    
    /*public async Task<CompanyResource> GetByEmailAndPasswordAsync(string email, string password)
    {
        var company = await _companyRepository.FindByEmailAndPasswordClientAsync(email);
        if (company == null || !BCryptNet.Verify(password, company.Password))
        {
            throw new AppException("Email or password is incorrect");
        }
        var companyResource = _mapper.Map<Domain.Models.Company, CompanyResource>(company);
        return companyResource;
    }*/


}