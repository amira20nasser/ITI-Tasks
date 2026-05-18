using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class StudentAudit
{
    public string? ServerUserName { get; set; }

    public DateOnly? AuditDate { get; set; }

    public string? Note { get; set; }
}
