using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Shared.Domain.Services.Communication;

namespace CargaSinEstres.API.CargaSinEstres.Domain.Services.Communication;

public class MembershipResponse : BaseResponse<Membership>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MembershipResponse"/> class with a message.
    /// </summary>
    /// <param name="message">The response message.</param>
    public MembershipResponse(string message) : base(message)
    {
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="MembershipResponse"/> class with a membership resource.
    /// </summary>
    /// <param name="resource">The review resource.</param>
    public MembershipResponse(Membership resource) : base(resource)
    {
    }
}