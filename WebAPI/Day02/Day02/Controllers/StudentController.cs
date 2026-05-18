using BusinessLogicLayer;
using BusinessLogicLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _service;
        public StudentController(StudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int page=1, [FromQuery] int pageSize=2)
        {
            var students = _service.GetAll();
            if (students.Count() == 0)
            {
                return NotFound("No students found");
            }
            else
            {
                var total = students.Count();
                var totalPages = (int)Math.Ceiling(total / (double)pageSize);
                var pagedStudents = students.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return Ok(new { Total = total, TotalPages = totalPages, Data = pagedStudents });
            }
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] string? firstName , [FromQuery] string? lastName)
        {
            var students = _service.GetByName(firstName,lastName);
            if (students.Count() == 0)
            {
                return NotFound("No students found");
            }
            else
            {
                return Ok(students);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var student = _service.GetById(id);  
            if (student == null)
            {
                return NotFound("Student not found");
            }
            else
            {
                return Ok(student);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddStudentDto value)
        {

            if (value == null)
            {
                return BadRequest("Student is null");
            }
            _service.Add(value);
            return CreatedAtAction(nameof(Post), value);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditStudentDto value)
        {
            if (value == null)
            {
                return BadRequest("Student is null");
            }
            try
            {
                _service.Update(id, value);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound("Student not found");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("Student deleted successfully");
            }
            catch (Exception ex)
            {
                return NotFound("Student not found");
            }
        }
    }
}
