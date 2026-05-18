using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTOs
{
    public class AddDepartmentDto
    {
        public int Id { get; set; }
        public string? DeptName { get; set; }=null;

        public string? DeptDesc { get; set; }=null;

        public string? DeptLocation { get; set; } = null;
    }
}
