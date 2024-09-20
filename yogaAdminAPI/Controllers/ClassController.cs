using Microsoft.AspNetCore.Mvc;
using yogaAdminAPI.Interfaces;
using yogaAdminLib.Data;
using yogaAdminLib.DTOs.ClassSchedule;

namespace yogaAdminAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassScheduleController : ControllerBase
{

    private readonly ILogger<ClassScheduleController> _logger;

    private readonly yogaAdminDataContext _yogaAdminDataContext;
    private readonly ITeacherService _ITeacherService;
    public ClassScheduleController(
        ITeacherService ITeacherService,
        yogaAdminDataContext yogaAdminDataContext,
        ILogger<ClassScheduleController> logger)
    {
        yogaAdminDataContext = _yogaAdminDataContext;
        _ITeacherService = ITeacherService;
        _logger = logger;
    }

    /// <summary>
    /// 新增課表資訊<br/>
    /// （檔案限制CSV檔）
    /// </summary>
    /// <param name="Rq"></param>
    /// <returns></returns>
    [HttpPost("Add")]
    public async Task<QueryRs> Insert(IFormFile file)
    {
        QueryRs rsObj = new QueryRs();

        try
        {




        }
        catch (Exception ex)
        {
            string errMsg = ex.Message;
            _logger.LogInformation($"Add API : {errMsg}");

        }

        return rsObj;

    }

    

}
