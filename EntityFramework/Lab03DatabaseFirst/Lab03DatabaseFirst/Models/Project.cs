using System;
using System.Collections.Generic;

namespace Lab03DatabaseFirst.Models;

public partial class Project
{
    public string ProjectNo { get; set; } = null!;

    public string ProjectName { get; set; } = null!;

    public int? Budget { get; set; }

    public virtual ICollection<WorksOn> WorksOns { get; set; } = new List<WorksOn>();
}
