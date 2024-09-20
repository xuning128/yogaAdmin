using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace yogaAdminLib.DTOs.Teacher;

/// <summary>
/// 瑜珈老師查詢 Request 
/// </summary>
public class EditRq 
{

    /// <summary>
  /// 修改：E <br/>
  /// 刪除：D
  /// </summary>
  [Required]
  public string Action { get; set; }

  /// <summary>
  /// 老師代號
  /// </summary>
  [Required]
  public string TeacherId {get;set;}

  /// <summary>
  /// 老師中文名稱
  /// </summary>
  public string? TeacherCName { get; set; }

  /// <summary>
  /// 老師英文名稱
  /// </summary>
  public string? TeacherEName { get; set; }

  /// <summary>
  /// 手機號碼
  /// </summary>
  public string? Mobile { get; set; }

  /// <summary>
  /// 是否為全職
  /// </summary>
  public bool? IsFullTime { get; set; }

  /// <summary>
  /// 工作性質
  /// </summary>
  public string? WorkTypeDesc { get; set; }


  
}
