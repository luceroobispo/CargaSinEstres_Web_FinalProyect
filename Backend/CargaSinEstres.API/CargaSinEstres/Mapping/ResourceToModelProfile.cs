using AutoMapper;
using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Services.Communication;
using CargaSinEstres.API.CargaSinEstres.Resources;

namespace CargaSinEstres.API.CargaSinEstres.Mapping;

/// <summary>
/// AutoMapper profile for mapping resource models to domain models.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class ResourceToModelProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ResourceToModelProfile"/> class.
    /// </summary>
    public ResourceToModelProfile()
    {
        CreateMap<SaveReviewResource, Review>();
        CreateMap<SaveMembershipResource, Membership>();
        CreateMap<SaveWorkerResource, Worker>();
        CreateMap<SaveBookingHistoryResource, BookingHistory>();

        CreateMap<SaveChatResource, Chat>();
        
        CreateMap<UpdateCommentResource, Worker>()
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));

        CreateMap<UpdateBookingHistoryResource, BookingHistory>();

    }
}