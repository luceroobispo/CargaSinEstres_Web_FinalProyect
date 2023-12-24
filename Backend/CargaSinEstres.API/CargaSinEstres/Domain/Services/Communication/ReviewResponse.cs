using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Shared.Domain.Services.Communication;

namespace CargaSinEstres.API.CargaSinEstres.Domain.Services.Communication;

/// <summary>
/// Represents the response from review service operations.
/// </summary>
public class ReviewResponse : BaseResponse<Review>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReviewResponse"/> class with a message.
    /// </summary>
    /// <param name="message">The response message.</param>
    public ReviewResponse(string message) : base(message)
    {
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="ReviewResponse"/> class with a review resource.
    /// </summary>
    /// <param name="resource">The review resource.</param>
    public ReviewResponse(Review resource) : base(resource)
    {
    }
}

