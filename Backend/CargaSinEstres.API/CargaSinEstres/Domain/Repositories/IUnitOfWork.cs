namespace CargaSinEstres.API.CargaSinEstres.Domain.Repositories;

/// <summary>
/// Interface for the Unit of Work pattern, providing a method to complete transactions.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public interface IUnitOfWork
{
    /// <summary>
    /// Asynchronously completes the unit of work, committing changes to the underlying data store.
    /// </summary>
    Task CompleteAsync();
}