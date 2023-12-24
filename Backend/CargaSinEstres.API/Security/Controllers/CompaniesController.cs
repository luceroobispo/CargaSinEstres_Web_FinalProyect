using AutoMapper;
using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Services;
using CargaSinEstres.API.CargaSinEstres.Resources;
using CargaSinEstres.API.Security.Authorization.Attributes;
using CargaSinEstres.API.Security.Domain.Models;
using CargaSinEstres.API.Security.Domain.Services;
using CargaSinEstres.API.Security.Domain.Services.Communication;
using CargaSinEstres.API.Security.Resources;
using Microsoft.AspNetCore.Mvc;

namespace CargaSinEstres.API.Security.Controllers;

/// <summary>
///   Controller for companies
/// </summary>
/// <remarks> Grupo 1: Carga sin estres </remarks>
[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly IReviewService _reviewService;
    private readonly ICompanyService _companyService;
    private readonly IMapper _mapper;
    
    /// <summary>
    ///  Constructor for the controller
    /// </summary>
    /// <param name="reviewService"> the service for reviews</param>
    /// <param name="companyService"> the service for companies </param>
    /// <param name="mapper"> An AutoMapper instance </param>
    public CompaniesController(IReviewService reviewService, ICompanyService companyService, IMapper mapper)
    {
        _reviewService = reviewService;
        _companyService = companyService;
        _mapper = mapper;
    }

    /// <summary>
    /// Authenticates a company.
    /// </summary>
    /// <param name="request">The authentication request.</param>
    /// <returns>An IActionResult containing the authentication response.</returns>
    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest request)
    {
        var response = await _companyService.Authenticate(request);
        return Ok(response);
    }
    
    /// <summary>
    /// Registers a new company.
    /// </summary>
    /// <param name="request">The registration request.</param>
    /// <returns>An IActionResult indicating the result of the registration.</returns>
    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _companyService.RegisterAsync(request);
        return Ok(new { message = "Registration successful" });
    }
    
    /// <summary>
    /// Gets all companies.
    /// </summary>
    /// <returns>An IActionResult containing the list of companies.</returns>
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var companies = await _companyService.ListAsync();
        
        var resources = _mapper.Map<IEnumerable<Company>,
            IEnumerable<CompanyResource>>(companies);
        
        return Ok(resources);
    }
    
    /// <summary>
    /// Gets a company by its ID.
    /// </summary>
    /// <param name="id">The ID of the company to retrieve.</param>
    /// <returns>An IActionResult containing the company information including it's reviews.</returns>
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var company = await _companyService.GetByIdAsync(id);
        
        var reviews = await _reviewService.FindByCompanyIdAsync(id);
        var reviewResources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(reviews);
        
        var companyResource = _mapper.Map<Company, CompanyResource>(company);
        companyResource.Reviews.Clear();
        foreach (var review in reviewResources)
        {
            companyResource.Reviews.Add(review);
        }
        
        return Ok(companyResource);
    }
    
    /// <summary>
    /// Updates a company by its ID.
    /// </summary>
    /// <param name="id">The ID of the company to update.</param>
    /// <param name="request">The update request.</param>
    /// <returns>An IActionResult indicating the result of the update.</returns>
    [AllowAnonymous]
    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, UpdateRequest request)
    {
        await _companyService.UpdateAsync(id, request);
        return Ok(new { message = "Company updated successfully" });
    }
    
    //get for login
    /*[AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetClientForLogin(string email, string password)
    {
        var company = await _companyService.GetByEmailAndPasswordAsync(email, password);
        var resource = _mapper.Map<Company, CompanyResource>(company);
        return Ok(resource);
    }*/
}