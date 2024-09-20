using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using yogaAdminLib.DTOs.Teacher;

namespace yogaAdminLib.DTOs.Teacher;

/// <summary>
/// 瑜珈老師查詢 Request 
/// </summary>
public class EditRs
{
    public string Action { get; set; }
    public string ActionDesc { get; set; }
    public string StateCode { get; set; }
    public string StateCodeDesc { get; set; }
    public List<TeacherItem> TeacherLt { get; set; }

}

