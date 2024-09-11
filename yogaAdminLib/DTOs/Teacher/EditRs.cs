using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using yogaAdminLib.DTOs;

namespace yogaAdminLib.DTOs;

/// <summary>
/// 瑜珈老師查詢 Request 
/// </summary>
public class EditRs 
{
    public string Action { get; set; }
    public string ActionDesc { get; set; }
    public List<TeacherItem> TeacherLt { get; set; }

}

