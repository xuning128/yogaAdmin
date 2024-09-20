

using AutoMapper;
using yogaAdminLib.DTOs.YogaSchedule;
using yogaAdminLib.Entities.yogaAdmin;

namespace yogaAdminAPI.Profiles;

public class YogaScheduleProfile : Profile
{
    public YogaScheduleProfile()
    {
        CreateMap<YogaSchedule, Schedule>();
        

        // CreateMap<EditRq, Teacher>()
        // .ForMember(m=>m.name, o=> o.MapFrom(d=>d.TeacherCName))
        // .ForMember(m=>m.eng_name, o=> o.MapFrom(d=>d.TeacherEName))
        // .ForMember(m=>m.worktype, o=> o.MapFrom(d=>d.WorkTypeDesc));





    }
}

