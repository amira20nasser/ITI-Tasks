using BusinessLogicLayer;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Day02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _service;
        public DepartmentController(DepartmentService service)
        {
            _service = service;
        }
      
        [HttpGet]
        public IActionResult Get()
        {
            var departments = _service.GetAll();
            if (departments.Count() == 0)
            {
                return NotFound("No departments found");
            }
            else
            {
                return Ok(departments);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var dept =_service.GetById(id);
            if (dept == null)
            {
                return NotFound("Department not found");
            }
            else
            {
                return Ok(dept);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddDepartmentDto value)
        {
            
            if (value == null)
            {
                return BadRequest("Department is null");
            }
            _service.Add(value);
            return CreatedAtAction(nameof(Post), value);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditDepartmentDto value)
        {
            if (value == null)
            { 
                return BadRequest("Department is null");
            }
            try
            {
                _service.Update(id, value);
                return NoContent();
            }
            catch (Exception ex) {
                return NotFound("Department not found");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("Department deleted successfully");
            }
            catch (Exception ex)
            {
                return NotFound("Department not found");
            }
        }
    }
}
