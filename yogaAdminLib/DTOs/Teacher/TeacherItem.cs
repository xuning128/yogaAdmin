using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace yogaAdminLib.DTOs.Teacher;


public class TeacherItem
{
    /// <summary>
    /// 代號
    /// </summary>
    public string TeacherId {get;set;}
    
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
