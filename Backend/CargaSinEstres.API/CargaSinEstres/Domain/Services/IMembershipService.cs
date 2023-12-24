using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Services.Communication;
using CargaSinEstres.API.CargaSinEstres.Resources;

namespace CargaSinEstres.API.CargaSinEstres.Domain.Services;
/// <summary>
/// Represents a service for managing membership entities.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public interface IMembershipService
{
    /// <summary>
    /// Saves a new membership entity asynchronously.
    /// </summary>
    /// <param name="membership">The membership entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a response with the saved membership entity.</returns>
    Task<MembershipResponse> SaveAsync(Membership membership);

    /// <summary>
    /// Gets a membership entity asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a membership entity.</returns>
    Task<IEnumerable<Membership>> GetMembershipsAsync ();
}