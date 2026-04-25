using System;
using System.Collections.Generic;

namespace Lab03DatabaseFirst.Models;

public partial class Department
{
    public string DeptNo { get; set; } = null!;

    public string DeptName { get; set; } = null!;

    public string? Location { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
