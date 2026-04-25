using System;
using System.Collections.Generic;

namespace Lab03DatabaseFirst.Models;

public partial class WorksOn
{
    public int EmpNo { get; set; }

    public string ProjectNo { get; set; } = null!;

    public string? Job { get; set; }

    public DateOnly EnterDate { get; set; }

    public virtual Employee EmpNoNavigation { get; set; } = null!;

    public virtual Project ProjectNoNavigation { get; set; } = null!;
}
