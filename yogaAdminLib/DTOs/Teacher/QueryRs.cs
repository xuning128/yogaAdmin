using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using yogaAdminLib.DTOs;

namespace yogaAdminLib.DTOs;

/// <summary>
/// 瑜珈老師查詢 Request 
/// </summary>
public class QueryRs : QueryRq
{
    
    public List<TeacherItem> TeacherLt { get; set; }

}

public class TeacherItem
{
    /// <summary>
    /// 老師中文名稱
    /// </summary>
    public string TeacherCName { get; set; }

    /// <summary>
    /// 老師英文名稱
    /// </summary>
    public string TeacherEName { get; set; }

    /// <summary>
    /// 手機號碼
    /// </summary>
    public string Mobile { get; set; }

    /// <summary>
    /// 生日
    /// </summary>
    public string Birthday { get; set; }

    /// <summary>
    /// 是否為全職
    /// </summary>
    public string IsFullTime { get; set; }

    /// <summary>
    /// 工作性質
    /// </summary>
    public string WorkTypeDesc { get; set; }

    /// <summary>
    /// 建立日期（入職日期）
    /// </summary>
    public string CreateTime { get; set; }

    /// <summary>
    /// 修改日期
    /// </summary>
    public string ModifyTime { get; set; }


    /// <summary>
    /// 學生人數
    /// </summary>
    public string StudentCnt { get; set; }
}
