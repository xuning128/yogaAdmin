using Microsoft.AspNetCore.Mvc;
using yogaAdminAPI.Interfaces;
using yogaAdminLib.Data;
using yogaAdminLib.DTOs.YogaSchedule;

namespace yogaAdminAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class YogaScheduleController : ControllerBase
{

    private readonly ILogger<YogaScheduleController> _logger;

    private readonly yogaAdminDataContext _yogaAdminDataContext;
    private readonly IYogaScheduleService _IYogaScheduleService;
    public YogaScheduleController(
        IYogaScheduleService IYogaScheduleService,
        yogaAdminDataContext yogaAdminDataContext,
        ILogger<YogaScheduleController> logger)
    {
        yogaAdminDataContext = _yogaAdminDataContext;
        _IYogaScheduleService = IYogaScheduleService;
        _logger = logger;
    }

    /// <summary>
    /// 新增課表資訊<br/>
    /// （檔案限制CSV檔）
    /// </summary>
    /// <param name="Rq"></param>
    /// <returns></returns>
    [HttpPost("Insert")]
    public async Task<QueryRs> Insert(IFormFile file)
    {
        QueryRs rsObj = new QueryRs();

        try
        {
            if (file == null || file.Length == 0)
            {
                rsObj.StateCode = "999";
                rsObj.StateCodeDesc = "請上傳檔案";

                return rsObj;
            }

            // 確認是否為CSV檔案
            if (!file.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                rsObj.StateCode = "999";
                rsObj.StateCodeDesc = "只接受CSV檔案，請重新上傳";

                return rsObj;
            }

            rsObj = await _IYogaScheduleService.Insert(file);


        }
        catch (Exception ex)
        {
            string errMsg = ex.Message;
            _logger.LogInformation($"Insert API : {errMsg}");

        }

        return rsObj;

    }



}
