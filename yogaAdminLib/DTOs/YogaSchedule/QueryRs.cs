using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using yogaAdminLib.DTOs.YogaSchedule;

namespace yogaAdminLib.DTOs.YogaSchedule;

/// <summary>
/// 瑜珈老師查詢 Request 
/// </summary>
public class QueryRs
{

    /// <summary>
    /// 新增狀態
    /// </summary>
    public string StateCode { get; set; }

    /// <summary>
    /// 新增狀態說明
    /// </summary>
    public string StateCodeDesc { get; set; }

    /// <summary>
    /// 課表列表
    /// </summary>
    public List<Schedule> Schedules { get; set; }


}

