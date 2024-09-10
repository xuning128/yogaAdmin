

using yogaAdminLib.DTOs;

namespace yogaAdminAPI.Interfaces;

public interface ITeacherService
{
    Task<QueryRs> GetQuery(QueryRq Rq);
}

