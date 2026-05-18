using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTOs
{
    public class DepartmentListDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Location { get; set; }
  

        public int NumOfStudents { get; set; }
    }
}
