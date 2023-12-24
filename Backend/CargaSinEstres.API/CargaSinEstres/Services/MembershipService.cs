using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
using CargaSinEstres.API.CargaSinEstres.Domain.Services;
using CargaSinEstres.API.CargaSinEstres.Domain.Services.Communication;
using CargaSinEstres.API.Security.Domain.Repositories;
using CargaSinEstres.API.CargaSinEstres.Resources;

namespace CargaSinEstres.API.CargaSinEstres.Services;

/// <summary>
/// Service class for handling membership operations.
/// </summary>
/// <remarks> Grupo 1: Carga sin estres </remarks>
public class MembershipService : IMembershipService
{
    private readonly IMembershipRepository _membershipRepository;
    private readonly IUnitOfWork _unitOfWork;
    /// <summary>
    /// Initializes a new instance of the <see cref="MembershipService"/> class.
    /// </summary>
    /// <param name="membershipRepository">The repository for membership data.</param>
    /// <param name="unitOfWork">The unit of work for transactional operations.</param>
    public MembershipService(IMembershipRepository membershipRepository, IUnitOfWork unitOfWork)
    {
        _membershipRepository = membershipRepository;
        _unitOfWork = unitOfWork;
    }
    
    /// <summary>
    /// Saves a membership asynchronously and returns a response.
    /// </summary>
    /// <param name="membership">The membership to be saved.</param>
    /// <returns>A response containing the saved membership or an error message.</returns>
    public async Task<MembershipResponse> SaveAsync(Membership membership)
    {
        try
        {
            await _membershipRepository.AddAsync(membership);
            await _unitOfWork.CompleteAsync();
            return new MembershipResponse(membership);
        }
        catch (Exception e)
        {
            return new MembershipResponse($"An error occurred while saving the membership: {e.Message}");
        }
    }

    public async Task<IEnumerable<Membership>> GetMembershipsAsync()
    {
        return await _membershipRepository.ListAsync();
    }
    
}

