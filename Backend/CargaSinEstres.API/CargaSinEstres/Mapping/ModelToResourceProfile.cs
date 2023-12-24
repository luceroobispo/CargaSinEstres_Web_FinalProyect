using AutoMapper;
using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Resources;

namespace CargaSinEstres.API.CargaSinEstres.Mapping
{
    /// <summary>
    /// AutoMapper profile for mapping domain models to resource models.
    /// </summary>
    ///<remarks> Grupo 1: Carga sin estres </remarks>
    public class ModelToResourceProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelToResourceProfile"/> class.
        /// </summary>
        public ModelToResourceProfile()
        {
            CreateMap<Review, ReviewResource>();
            CreateMap<Membership, MembershipResource>();
            CreateMap<Comment, CommentResource>();
            CreateMap<BookingHistory, UpdateBookingHistoryResource>();
            CreateMap<BookingHistory, BookingHistoryResource>()
                .ForMember(dest => dest.Chats, opt => opt.MapFrom(src => src.Chats))
                .ForMember(dest => dest.Workers, opt => opt.MapFrom(src => src.Workers));

            CreateMap<Worker, WorkerResource>()
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
        }
    }
}