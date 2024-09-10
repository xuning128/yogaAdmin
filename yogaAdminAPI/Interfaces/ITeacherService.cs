

using yogaAdminLib.DTOs;

namespace yogaAdminAPI.Interfaces;

public interface ITeacherService
{
    /// <summary>
    /// 瑜珈老師查詢
    /// </summary>
    /// <param name="Rq"></param>
    /// <returns></returns>
    Task<QueryRs> GetQuery(QueryRq Rq);
    
    /// <summary>
    /// 新增瑜珈老師基本資料
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
     Task<AddRs> Add(IFormFile file);
}

