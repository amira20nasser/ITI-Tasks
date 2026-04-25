using System;
using System.Collections.Generic;

namespace Lab03DatabaseFirst.Models;

public partial class Employee
{
    public int EmpNo { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public int? Salary { get; set; }

    public string? DeptNo { get; set; }

    public virtual Department? DeptNoNavigation { get; set; }

    public virtual ICollection<WorksOn> WorksOns { get; set; } = new List<WorksOn>();
}
