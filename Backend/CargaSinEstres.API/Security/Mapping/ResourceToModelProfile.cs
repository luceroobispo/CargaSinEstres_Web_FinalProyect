using AutoMapper;
using CargaSinEstres.API.Security.Domain.Models;
using CargaSinEstres.API.Security.Domain.Services.Communication;

namespace CargaSinEstres.API.Security.Mapping;

/// <summary>
///  Mapping from resources to models
/// </summary>
/// <remarks> Grupo 1: Carga sin estres </remarks>
public class ResourceToModelProfile: Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ResourceToModelProfile"/> class.
    /// </summary>
    public ResourceToModelProfile()
    {
        CreateMap<RegisterRequest, Company>();
        CreateMap<RegisterRequestClient, Client>();
        CreateMap<UpdateRequest, Company>();
        CreateMap<UpdateRequestClient, Client>()
            .ForAllMembers(options => options.Condition(
                (source, target, property) =>
                {
                    if (property == null) return false;
                    if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                    return true;
                }
            ));
    }
}