using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
using CargaSinEstres.API.CargaSinEstres.Domain.Services;
using CargaSinEstres.API.CargaSinEstres.Domain.Services.Communication;
using CargaSinEstres.API.CargaSinEstres.Resources;
using CargaSinEstres.API.Security.Domain.Repositories;

namespace CargaSinEstres.API.CargaSinEstres.Services;

/// <summary>
/// Service class for handling comment operations.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWorkerRepository _workerRepository;
    private readonly IBookingHistoryRepository _bookingRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CommentService"/> class.
    /// </summary>
    /// <param name="commentRepository">The repository for comment data.</param>
    /// <param name="unitOfWork">The unit of work for transactional operations.</param>
    /// <param name="workerRepository">The repository for worker data.</param>
    public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork, IWorkerRepository workerRepository, IBookingHistoryRepository bookingRepository)
    {
        _commentRepository = commentRepository;
        _unitOfWork = unitOfWork;
        _workerRepository = workerRepository;
        _bookingRepository = bookingRepository;
    }

    /// <summary>
    /// Saves a comment asynchronously and returns a response.
    /// </summary>
    /// <param name="comment">The comment to be saved.</param>
    /// <returns>A response containing the saved comment or an error message.</returns>
    public async Task<CommentResponse> SaveAsync(Comment comment)
    {
        try
        {
            // Associate WorkerId with Booking
            var booking = await _bookingRepository.GetAsync(comment.BookingId);
            if (booking != null)
            {
                booking.Workers.Add(comment.WorkerId);
                // Update bookingHistory by id
                await _bookingRepository.UpdateAsync(booking);
                
                // Save the comment
                await _commentRepository.AddAsync(comment);
                
                // Complete the unit of work
                await _unitOfWork.CompleteAsync();
            }

            //update bookingHistory by id
            //await _bookingRepository.UpdateAsync(booking);
            //await _commentRepository.AddAsync(comment);

            else
            {
            // Handle the case where the booking is not found
            return new CommentResponse($"Booking with id {comment.BookingId} not found.");
            }
            
            return new CommentResponse(comment);
            }
        catch (Exception ex)
        {
            return new CommentResponse($"An error occurred while saving the comment: {ex.Message}");
        }
    }

    /// <summary>
    /// Lists comments associated with a specific worker.
    /// </summary>
    /// <param name="workerId">The identifier of the worker.</param>
    /// <returns>The list of comments associated with the specified worker.</returns>
    public async Task<IEnumerable<Comment>> ListByWorkerIdAsync(int workerId)
    {
        return await _commentRepository.ListByWorkerIdAsync(workerId);
    }
}

