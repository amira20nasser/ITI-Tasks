using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPICourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private AppDbContext _context;
        public CourseController(AppDbContext context)
        {
                _context = context;
        }   
        [HttpGet]
        public IActionResult get()
        {
            var courses = _context.Courses.ToList();
            if(courses.Count == 0)
            {
                return NotFound("No courses found");
            }
            else
            {
                return Ok(courses);
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult deleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if(course == null)
            {
                return NotFound("Course not found");
            }
            else
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
                return Ok("Course deleted successfully");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult put(int id,Course course)
        {
            if(id != course.Id)
            {
                return BadRequest("Course id mismatch");
            }
            var existingCourse = _context.Courses.Find(id);
            if(existingCourse == null)
            {
                return NotFound("Course not found");
            }
            existingCourse.Name = course.Name;
            existingCourse.Description = course.Description;
            _context.SaveChanges();
            //204
            return NoContent();
        }

        [HttpPost]
        public IActionResult post(Course course)
        {
            if (course == null)
            {
                return BadRequest("Course is null");
            }   
             _context.Courses.Add(course);
            _context.SaveChanges();
            return CreatedAtAction(nameof(post), course);
        }

        [HttpGet("{id:int}")]
        public IActionResult getById(int id)
        {
            var course = _context.Courses.Find(id);
            if(course == null)
            {
                return NotFound("Course not found");
            }
            else
            {
                return Ok(course);
            }
        }

        [HttpGet("{name:alpha}")]
        public IActionResult getByName(string name)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Name == name);
            if (course == null)
            {
                return NotFound("Course not found");
            }
            else
            {
                return Ok(course);
            }
        }

    }
}
