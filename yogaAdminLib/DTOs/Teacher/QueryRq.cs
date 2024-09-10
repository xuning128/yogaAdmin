using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace yogaAdminLib.DTOs;

/// <summary>
/// 瑜珈老師查詢 Request 
/// </summary>
public class QueryRq
{

  /// <summary>
  /// 老師代號
  /// all：全部
  /// </summary>
  [Required]
  public string TeacherId { get; set; }

}
