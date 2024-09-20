

using yogaAdminLib.DTOs.YogaSchedule;

namespace yogaAdminAPI.Interfaces;

public interface IYogaScheduleService
{
    Task<QueryRs> Insert(IFormFile file);
}

