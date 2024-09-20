using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using yogaAdminLib.DTOs;

namespace yogaAdminLib.DTOs.YogaSchedule;

/// <summary>
/// 瑜珈老師查詢 Request 
/// </summary>
public class Schedule 
{

    /// <summary>
    /// 課程id
    /// </summary>
    public string Rquid {get;set;}
    
    /// <summary>
    /// 課程名稱
    /// </summary>
    public string ClassName {get;set;}


    /// <summary>
    /// 開放課程的時間
    /// </summary>
    public string ClassTime {get;set;}

    /// <summary>
    /// 開放課程的星期
    /// </summary>
    public string ClassWeek {get;set;}

    /// <summary>
    /// 教練Id
    /// </summary>
    public string TeacherId {get;set;} 



    /// <summary>
    /// 教練中文名字
    /// </summary>
    public string TeacherCName {get;set;}

    /// <summary>
    /// 教練英文名字
    /// </summary>
    public string TeacherEName {get;set;}

    /// <summary>
    /// 課程的長度
    /// </summary>
    public string Period {get;set;}

    /// <summary>
    /// 哪一間教室
    /// </summary>
    public string ClassRoom {get;set;}

    /// <summary>
    /// 有無停課
    /// </summary>
    public bool IsSuspend {get;set;}

    /// <summary>
    /// 建立時間
    /// </summary>
    public string CreateTime {get;set;}


    /// <summary>
    /// 修改時間
    /// </summary>
    public string ModifyTime {get;set;}

    
}

