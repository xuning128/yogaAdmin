

using AutoMapper;
using yogaAdminLib.DTOs.Teacher;
using yogaAdminLib.Entities.yogaAdmin;

namespace yogaAdminAPI.Profiles;

public class TeacherProfile : Profile
{
    public TeacherProfile()
    {
        CreateMap<Teacher, TeacherItem>()
        .ForMember(m => m.TeacherId, o => o.MapFrom(d=>d.id))
        .ForMember(m => m.TeacherCName, o => o.MapFrom(d=>d.name))
        .ForMember(m => m.TeacherEName, o => o.MapFrom(d=>d.eng_name))
        .ForMember(m => m.WorkTypeDesc, o => o.MapFrom(d => d.worktype) );

        CreateMap<EditRq, Teacher>()
        .ForMember(m=>m.name, o=> o.MapFrom(d=>d.TeacherCName))
        .ForMember(m=>m.eng_name, o=> o.MapFrom(d=>d.TeacherEName))
        .ForMember(m=>m.worktype, o=> o.MapFrom(d=>d.WorkTypeDesc));





    }
}

