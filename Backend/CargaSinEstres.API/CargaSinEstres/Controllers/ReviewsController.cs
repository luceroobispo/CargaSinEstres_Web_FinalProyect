using AutoMapper;
using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Services;
using CargaSinEstres.API.CargaSinEstres.Resources;
using CargaSinEstres.API.Security.Domain.Models;
using CargaSinEstres.API.Security.Domain.Services;
using CargaSinEstres.API.Security.Domain.Services.Communication;
using CargaSinEstres.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CargaSinEstres.API.CargaSinEstres.Controllers;

/// <summary>
/// Controller for reviews
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
[ApiController]
[Route("/api/v1/[controller]")]
public class ReviewsController : ControllerBase {
 
    private readonly IReviewService _reviewService;
    private readonly ICompanyService _companyService;
    private readonly IMapper _mapper;

    /// <summary>
    ///  Constructor for the controller
    /// </summary>
    /// <param name="reviewService"> the service for reviews</param>
    /// <param name="companyService"> the service for companies </param>
    /// <param name="mapper"> An AutoMapper instance </param>
    public ReviewsController(IReviewService reviewService, ICompanyService companyService, IMapper mapper)
    {
        _reviewService = reviewService;
        _companyService = companyService;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets all reviews.
    /// </summary>
    /// <returns>An IEnumerable of ReviewResource containing all reviews.</returns>
    [HttpGet]
    public async Task<IEnumerable<ReviewResource>> GetAllAsync()
    {
        var reviews = await _reviewService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(reviews);
        return resources;
    }
    
    /// <summary>
    /// Creates a new review and updates the averageRating of the company it is related to
    /// </summary>
    /// <param name="resource">The SaveReviewResource containing the information for the new review.</param>
    /// <param name="companyId"> Company id.</param>
    /// <returns>An IActionResult indicating the result of the review creation.</returns>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveReviewResource resource, [FromQuery] int companyId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        //confirm company existence
        var company = await _companyService.GetByIdAsync(companyId); // obtains the company of the review
        if (company == null)
        {
            throw new Exception("Company for the review not found");
        }
        
        var NewReview = _mapper.Map<SaveReviewResource, Review>(resource);
        NewReview.CompanyId = companyId;

        var result = await _reviewService.SaveAsync(NewReview); //saves the review in the database
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        //update company averageRating
        var currentReviews = await _reviewService.FindByCompanyIdAsync(company.Id);
        var ratingAverage = 0; var ratingTotal = 0.0;
        foreach (var review in currentReviews)
        {
            ratingTotal += review.Rating;
        }
        ratingAverage = (int)Math.Round(ratingTotal / currentReviews.Count());
        company.AverageRating = ratingAverage;
        var updateCompany = _mapper.Map<Company, UpdateRequest>(company);
        await _companyService.UpdateAsync(company.Id, updateCompany);
        
        //show created review
        var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource); 
        return Ok(reviewResource);
    }
}