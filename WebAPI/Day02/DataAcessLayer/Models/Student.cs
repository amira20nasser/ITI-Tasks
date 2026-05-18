using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Student
{
    public int StId { get; set; }

    public string? StFname { get; set; }

    public string? StLname { get; set; }

    public string? StAddress { get; set; }

    public int? StAge { get; set; }

    public int? DeptId { get; set; }

    public int? StSuper { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual ICollection<Student> InverseStSuperNavigation { get; set; } = new List<Student>();

    public virtual Student? StSuperNavigation { get; set; }

    public virtual ICollection<StudCourse> StudCourses { get; set; } = new List<StudCourse>();
}
