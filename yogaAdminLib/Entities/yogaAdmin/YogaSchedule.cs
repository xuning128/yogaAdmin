using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace yogaAdminLib.Entities.yogaAdmin;

[Table("yogaschedule")]
public class YogaSchedule
{
    [Key]
    public string rquid { get; set; }

    /// <summary>
    /// 課程名稱
    /// </summary>
    public string classname { get; set; }


    /// <summary>
    /// 課程時間
    /// </summary>
    public string classtime { get; set; }

    /// <summary>
    /// 上課星期
    /// </summary>
    public string classweek { get; set; }

    /// <summary>
    /// 教練id
    /// </summary>
    public string teacherid { get; set; }

    /// <summary>
    /// 上課時數
    /// </summary>
    public string period { get; set; }

    /// <summary>
    /// 哪一間教室
    /// </summary>
    public string classroom {get;set;}

    /// <summary>
    /// 是否停課
    /// </summary>
    public bool issuspend {get;set;}

    /// <summary>
    /// 建立日期
    /// </summary>
    public string createtime { get; set; }

    /// <summary>
    /// 修改日期
    /// </summary>
    public string modifytime { get; set; }

    

}
