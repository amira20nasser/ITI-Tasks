using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTOs
{
    public class AddStudentDto
    {
        public int Id { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
    }
}
