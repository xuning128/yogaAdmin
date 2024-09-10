using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace yogaAdminLib.Entities.yogaAdmin;

[Table("teacher")]
public class Teacher
{
    [Key]
    public string id { get; set; }
    public string name { get; set; }
    public string  eng_name { get; set; }

    public string mobile {get;set;}

    public string isfulltime {get;set;}

    public string createtime { get; set; }
    public string modifytime { get; set; }

}
