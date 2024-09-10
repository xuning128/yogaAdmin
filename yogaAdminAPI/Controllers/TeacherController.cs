using Microsoft.AspNetCore.Mvc;
using yogaAdminAPI.Interfaces;
using yogaAdminLib.Data;
using yogaAdminLib.DTOs;

namespace yogaAdminAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{

    private readonly ILogger<TeacherController> _logger;

     private readonly yogaAdminDataContext _yogaAdminDataContext;
     private readonly ITeacherService _ITeacherService;
    public TeacherController(
        ITeacherService ITeacherService,
        yogaAdminDataContext yogaAdminDataContext,
        ILogger<TeacherController> logger)
    {
        yogaAdminDataContext = _yogaAdminDataContext;
        _ITeacherService = ITeacherService;
        _logger = logger;
    }

    /// <summary>
    /// 查詢瑜珈老師清單
    /// </summary>
    /// <param name="Rq"></param>
    /// <returns></returns>
    [HttpPost("Query")]
    public async Task<QueryRs>  Query(QueryRq Rq)
    {
        
        try
        {
            QueryRs rsObj = new QueryRs();

            
            if (!ModelState.IsValid)
            {
               ModelState.AddModelError("TeacherId", "資料驗證錯誤");
               return rsObj;

            }

            rsObj = await _ITeacherService.GetQuery(Rq);

            return rsObj;
            
        }
        catch (Exception ex)
        {
            string errMsg = ex.Message;
            //TODO add nlog 
            throw;
        }
      
    }
}
