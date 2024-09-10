

using AutoMapper;
using yogaAdminLib.DTOs;
using yogaAdminLib.Entities.yogaAdmin;

namespace yogaAdminAPI.Profiles;

public class TeacherProfile : Profile
{
    public TeacherProfile()
    {
        CreateMap<Teacher, TeacherItem>()
        .ForMember(m => m.TeacherCName, o => o.MapFrom(d=>d.name))
        .ForMember(m => m.TeacherEName, o => o.MapFrom(d=>d.eng_name))
        .ForMember(m => m.WorkTypeDesc, o => o.MapFrom(d => d.worktype) )
        ;


        // CreateMap<TeacherItem, TrxOrderBox>()
        // .ForMember(m => m.ordertype, o => o.MapFrom(d => d.OrderType))
        // .ForMember(m => m.ispickup, o => o.MapFrom(d => d.isPickup.ToString()))
        // .ForMember(m => m.totalcount, o => o.MapFrom(d => d.TotalCount))
        // .ForMember(m => m.totalprice, o => o.MapFrom(d => d.TotalPrice))
        // .ForMember(m => m.pickuptime, o => o.MapFrom(d => d.PickupTime))
        // .ForMember(m => m.address, o => o.MapFrom(d => d.Address))
        // ;

         //CreateMap<TrxOrderBox, SendRs>();


    }
}

