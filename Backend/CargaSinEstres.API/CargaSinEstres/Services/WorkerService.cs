using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
using CargaSinEstres.API.CargaSinEstres.Domain.Services;
using CargaSinEstres.API.CargaSinEstres.Domain.Services.Communication;
using CargaSinEstres.API.Security.Domain.Repositories;
using CargaSinEstres.API.CargaSinEstres.Resources;

namespace CargaSinEstres.API.CargaSinEstres.Services;

/// <summary>
/// Service class for handling worker operations.
/// </summary>
/// <remarks> Grupo 1: Carga sin estres </remarks>
public class WorkerService : IWorkerService
{
    private readonly IWorkerRepository _workerRepository;
    private readonly IUnitOfWork _unitOfWork;
    /// <summary>
    /// Initializes a new instance of the <see cref="WorkerService"/> class.
    /// </summary>
    /// <param name="workerRepository">The repository for worker data.</param>
    /// <param name="unitOfWork">The unit of work for transactional operations.</param>
    public WorkerService(IWorkerRepository workerRepository, IUnitOfWork unitOfWork)
    {
        _workerRepository = workerRepository;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Updates comments for a worker asynchronously and returns a response.
    /// </summary>
    /// <param name="id">The identifier of the worker to update comments for.</param>
    /// <param name="updateCommentsResource">The resource containing updated comments.</param>
    /// <returns>A response containing the updated worker or an error message.</returns>
    public async Task<WorkerResponse> UpdateCommentsAsync(int id, UpdateCommentResource updateCommentsResource)
    {
        var existingWorker = await _workerRepository.FindByIdAsync(id);
        if (existingWorker == null)
            return new WorkerResponse("El trabajador no fue encontrado.");
        UpdateComments(existingWorker.Comments, updateCommentsResource.Comments);
        try
        {
            _workerRepository.Update(existingWorker);
            await _unitOfWork.CompleteAsync();
            return new WorkerResponse(existingWorker);
        }
        catch (Exception e)
        {
            return new WorkerResponse(
                $"Un error ocurrió mientras se actualizaba la data del trabajador: {e.Message}");
        }
    }
    
    /// <summary>
    /// Updates comments for a worker.
    /// </summary>
    /// <param name="existingComments">The existing comments of the worker.</param>
    /// <param name="updatedComments">The updated comments resource.</param>
    private void UpdateComments(IList<Comment> existingComments, IList<CommentUpdatedResource> updatedComments)
    {
        foreach (var updatedComment in updatedComments)
        {
            
            // Agrega un nuevo comentario
            existingComments.Add(new Comment
            {
                CommentText = updatedComment.CommentText,
                BookingId = updatedComment.BookingId,
            });
        }

        //return 
    }
    

    /// <summary>
    /// Retrieves a worker by its identifier asynchronously.
    /// </summary>
    /// <param name="workerId">The identifier of the worker to retrieve.</param>
    /// <returns>The worker with the specified identifier.</returns>
    public async Task<Worker> ListByWorkerIdAsync(int workerId)
    {
        return await _workerRepository.FindByIdAsync(workerId);
    }

    /// <summary>
    /// Saves a worker asynchronously and returns a response.
    /// </summary>
    /// <param name="worker">The worker to be saved.</param>
    /// <returns>A response containing the saved worker or an error message.</returns>
    public async Task<WorkerResponse> SaveAsync(Worker worker)
    {
        try
        {
            await _workerRepository.AddAsync(worker);
            await _unitOfWork.CompleteAsync();
            return new WorkerResponse(worker);
        }
        catch (Exception e)
        {
            return new WorkerResponse($"An error occurred while saving the worker: {e.Message}");
        }
    }

    public async Task<IEnumerable<Worker>> GetWorkersAsync()
    {
        return await _workerRepository.ListAsync();
    }
    
}

