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

