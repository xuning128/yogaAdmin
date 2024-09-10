using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using yogaAdminLib.DTOs;

namespace yogaAdminLib.DTOs;

/// <summary>
/// 瑜珈老師查詢 Request 
/// </summary>
public class AddRs
{
    /// <summary>
    /// 新增狀態
    /// </summary>
    public string StateCode { get; set; }

    /// <summary>
    /// 新增狀態說明
    /// </summary>
    public string StateCodeDesc { get; set; }
}
