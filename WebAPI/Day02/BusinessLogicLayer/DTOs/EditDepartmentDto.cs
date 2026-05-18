using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTOs
{
    public class EditDepartmentDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Location { get; set; }
        public int? ManagerId { get; set; }

        public DateOnly? ManagerHiredate { get; set; }
    }
}
