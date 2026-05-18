using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTOs
{
    public class EditStudentDto
    {
        public string? StFname { get; set; }

        public string? StLname { get; set; }

        public string? StAddress { get; set; }

        public int? StAge { get; set; }
    }
}
