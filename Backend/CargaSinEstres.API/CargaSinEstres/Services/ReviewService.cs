using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
using CargaSinEstres.API.CargaSinEstres.Domain.Services;
using CargaSinEstres.API.CargaSinEstres.Domain.Services.Communication;
using CargaSinEstres.API.CargaSinEstres.Resources;
using CargaSinEstres.API.Security.Domain.Repositories;

namespace CargaSinEstres.API.CargaSinEstres.Services;

/// <summary>
/// Service class for handling review operations.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICompanyRepository _companyRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ReviewService"/> class.
    /// </summary>
    /// <param name="reviewRepository">The repository for review data.</param>
    /// <param name="unitOfWork">The unit of work for transactional operations.</param>
    /// <param name="companyRepository">The repository for company data.</param>
    public ReviewService(IReviewRepository reviewRepository, IUnitOfWork unitOfWork, ICompanyRepository companyRepository)
    {
        _reviewRepository = reviewRepository;
        _unitOfWork = unitOfWork;
        _companyRepository = companyRepository;
    }

    /// <summary>
    /// Retrieves a list of all reviews.
    /// </summary>
    /// <returns>The list of all reviews.</returns>
    public async Task<IEnumerable<Review>> ListAsync()
    {
        return await _reviewRepository.ListAsync();
    }

    /// <summary>
    /// Retrieves reviews associated with a specific company.
    /// </summary>
    /// <param name="companyId">The identifier of the company.</param>
    /// <returns>The list of reviews associated with the specified company.</returns>
    public async Task<IEnumerable<Review>> FindByCompanyIdAsync(int companyId)
    {
        return await _reviewRepository.FindByCompanyIdAsync(companyId);
    }

    /// <summary>
    /// Saves a review asynchronously and returns a response.
    /// </summary>
    /// <param name="review">The review to be saved.</param>
    /// <returns>A response containing the saved review or an error message.</returns>
    public async Task<ReviewResponse> SaveAsync(Review review)
    {
        // Validate if review comment is too short
        if (review.Comment.Length < 10)
            return new ReviewResponse("Comment must be at least 10 characters long.");
        try
        {
            await _reviewRepository.AddAsync(review);
            await _unitOfWork.CompleteAsync();
            return new ReviewResponse(review);
        }
        catch (Exception e)
        {
            return new ReviewResponse($"An error occurred while saving the review: {e.Message}");
        }
    }
}

