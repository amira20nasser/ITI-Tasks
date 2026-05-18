using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class InsCourse
{
    public int InsId { get; set; }

    public int CrsId { get; set; }

    public string? Evaluation { get; set; }

    public virtual Course Crs { get; set; } = null!;

    public virtual Instructor Ins { get; set; } = null!;
}
