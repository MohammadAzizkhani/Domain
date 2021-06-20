using Api.Viewmodel;
using Api.Viewmodel.Request;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Domain.Utility;

namespace Api.MappingProfile
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<Request, RequestDto>()
                .ForPath(x => x.Customer.Person, c => c.MapFrom(x => x.Customer.Person))
                .ForPath(x => x.Customer, c => c.MapFrom(x => x.Customer))
                .ForMember(x => x.RequestState,
                    c => c.MapFrom(x => ((RequestStateEnum)x.RequestStateId.Value).GetEnumDescription()))
                .ForMember(x => x.Psp, c => c.MapFrom(x => x.Psp.Name))
                .ForMember(x => x.RequestType, c => c.MapFrom(x => ((RequestTypeEnum)x.RequestTypeId.Value).GetEnumDescription()))
                ;


            CreateMap<PageCollection<Request>, PageCollection<RequestDto>>()
                .ForMember(x => x.TotalRecord, x => x.MapFrom(x => x.TotalRecord))
                .ForMember(x => x.Pages, x => x.MapFrom(x => x.Pages))
                .ForMember(x => x.Data, x => x.MapFrom(x => x.Data));
        }
    }
}
