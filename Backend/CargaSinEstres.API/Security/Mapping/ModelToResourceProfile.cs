using AutoMapper;
using CargaSinEstres.API.Security.Domain.Models;
using CargaSinEstres.API.Security.Domain.Services.Communication;
using CargaSinEstres.API.Security.Resources;

namespace CargaSinEstres.API.Security.Mapping;

/// <summary>
/// Profile for AutoMapper to define mappings from domain models to resources in the Security domain.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class ModelToResourceProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ModelToResourceProfile"/> class.
    /// </summary>
    public ModelToResourceProfile()
    {
        CreateMap<Company, AuthenticateResponse>();
        CreateMap<Client, AuthenticateResponseClient>();
        CreateMap<Company, CompanyResource>();
        CreateMap<Client, ClientResource>();
        CreateMap<Company, UpdateRequest>();
    }
}